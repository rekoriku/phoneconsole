using System;
using System.Net.Sockets;
using System.Text;

public class TcpTimeClient
{
    private const int portNum = 5500;
    private const string hostName = "localhost";

    public static int Main(String[] args)
    {
        try
        {
            TcpClient client = new TcpClient(hostName, portNum);
            NetworkStream ns = client.GetStream();

            //Console.WriteLine(ReadMessage(ns));
            //Networking.SendMessage(ns, "Hello Server!");

            bool done = false;
            while(!done)
            {
                string input = String.Empty;
                int choice = -1;
                Console.Write("To add new row select 0\n" +
                              "To delete row select: 1\n" +
                              "To get all rows select 2\n" +
                              "To search row by name select 3\n" +
                              "To search row by number select 4\n" +
                              "To end the program select 5\n");
                Console.Write("Enter your choice: ");
                input = Console.ReadLine();
                try
                {
                    choice = Int32.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{input}'");
                    continue;
                }

                RequestType request = (RequestType)choice;
                switch (choice)
                {
                    case 0:
                        {
                            Console.WriteLine("Case 0");
                            string finalRequest = request.ToString();
                            string lastname = String.Empty, firstname = String.Empty, address = String.Empty, phonenumber = String.Empty;
                            if (GetInputString("Enter lastname:", ref lastname) && GetInputString("Enter firstname:", ref firstname) && GetInputString("Enter address:", ref address) && GetInputString("Enter phonenumber:", ref phonenumber))
                            {
                                finalRequest += "," + lastname + "," + firstname + "," + address + "," + phonenumber;
                                Networking.SendMessage(ns, finalRequest.ToString());
                            }
                        }
                        break;
                    case 1:
                        Console.WriteLine("Case 1");
                        Networking.SendMessage(ns, request.ToString());
                        break;
                    case 2:
                        Console.WriteLine("Case 2");
                        Networking.SendMessage(ns, request.ToString());
                        break;
                    case 3:
                        {
                            Console.WriteLine("Case 3");
                            string finalRequest = request.ToString();
                            string lastname = String.Empty;
                            if (GetInputString("Enter lastname:", ref lastname))
                            {
                                finalRequest += "," + lastname;
                                Networking.SendMessage(ns, finalRequest.ToString());
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Case 3");
                            string finalRequest = request.ToString();
                            string phonenumber = String.Empty;
                            if (GetInputString("Enter phonenumber:", ref phonenumber))
                            {
                                finalRequest += "," + phonenumber;
                                Networking.SendMessage(ns, finalRequest.ToString());
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Case 5");
                        Networking.SendMessage(ns, request.ToString());
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }

            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        return 0;
    }

    public static bool GetInputString(string promt, ref string input)
    {
        bool done = false;
        string tempInput = String.Empty;
        while(!done)
        {
            tempInput = String.Empty;
            Console.WriteLine(promt);
            Console.WriteLine("If you want to abort enter: abort");
            tempInput = Console.ReadLine();
            if(tempInput == "abort")
            {
                input = String.Empty;
                return false;
            }
            else if (tempInput != "")
            {
                continue;
            }
        }

        input = tempInput;
        return true;
    }

    public static bool GetInputInt(string promt, ref int input)
    {
        bool done = false;
        int tempInput = -1;
        string userInput = String.Empty;
        while (!done)
        {
            tempInput = -1;
            userInput = String.Empty;
            Console.WriteLine(promt);
            Console.WriteLine("If you want to abort enter: abort");
            userInput = Console.ReadLine();
            if (userInput == "abort")
            {
                input = -1;
                return false;
            }
            else if (userInput != "")
            {
                continue;
            }
            else if(Int32.TryParse(userInput, out tempInput))
            {
                done = true;
            }
        }

        input = tempInput;
        return true;
    }
}