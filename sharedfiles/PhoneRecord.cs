using System;
using System.Collections.Generic;
using System.Text;

class PhoneRecord
{
    private int id;
    private string lastname, firstname, address, phonenumber;

    public PhoneRecord(int id, string lastname, string firstname, string address, string phonenumber)
    {
        this.id = id;
        this.lastname = lastname;
        this.firstname = firstname;
        this.address = address;
        this.phonenumber = phonenumber;
    }

    public override string ToString()
    {
        return "id: " + id + ", " + lastname + " " + firstname + ", address: " + address + ", phonenumber: " + phonenumber;
    }
}

