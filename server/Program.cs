using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;

namespace server
{
    public class TcpTimeServer
    {
        private const int portNum = 5500;
        
        public static int Main(String[] args)
        {
            bool done = false;
            Database db = new Database("niisku.lamk.fi", "laurtomi", "Koodaus1", "user_laurtomi");
            TcpListener listener = new TcpListener(IPAddress.Any, portNum);

                listener.Start();

                Console.Write("Waiting for connection...");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Connection accepted.");

                while (!done)
                {
                    NetworkStream ns = client.GetStream();
                    string message = Networking.ReadMessage(ns);
                    //db.AddRow(db.Parse(message));
                    //Console.WriteLine();

                    string[] messageArr = db.Parse(message);
                    switch (messageArr[0])
                    {
                        case "add_rows":
                            {
                                int result = db.AddRow(message);
                                Networking.SendMessage(ns, result + " rows added!");
                                break;
                            }
                        case "delete_rows":
                            {
                                int result = db.DelRow(message);
                                Networking.SendMessage(ns, result + " rows deleted!");
                                break;
                            }
                        case "search_all_rows":
                            {
                                List<PhoneRecord> records = db.GetAllEntries("ds19_phonenumbers");
                                Networking.SendMessage(ns, String.Join(",", records));
                                break;
                            }
                        case "search_rows_by_name":
                            {
                                List<PhoneRecord> records = db.GetFromColumnByValue("ds19_phonenumbers", "lastname", messageArr[1]);
                                Networking.SendMessage(ns, String.Join(",", records));
                                break;
                            }
                        case "search_rows_by_number":
                            {
                                List<PhoneRecord> records = db.GetFromColumnByValue("ds19_phonenumbers", "phonenumber", messageArr[1]);
                                Networking.SendMessage(ns, String.Join(",", records));
                                break;
                            }

                        case "end":
                            {
                                done = true;
                                break;
                            }
                    }

                    Console.WriteLine(message);
                }
                Console.WriteLine("stopping");
                listener.Stop();

                //Database db = new Database("niisku.lamk.fi", "laurtomi", "Koodaus1", "user_laurtomi");
                //List<PhoneRecord> records = db.GetFromColumnByValue("ds19_phonenumbers", "firstname", "Tomi");
                //List<PhoneRecord> records = db.GetAllEntries("ds19_phonenumbers");
                //foreach (var record in records)
                //{
                //    Console.WriteLine(record.ToString());
                //}
        
 
            return 0;
        }

    }
}
