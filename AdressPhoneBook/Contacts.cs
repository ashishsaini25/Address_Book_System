﻿using AddressPhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressPhoneBook
{
    public  class Contacts
    {
        List<AddressBook>contact=new List<AddressBook>();
        Nlog nlog =new Nlog();
        public void NewContact()
        {
            try
            {
                AddressBook addressBook = new AddressBook();
                addressBook.AddContact();
                contact.Add(addressBook);
                nlog.LogInfo("New Contact Added in Adressbook");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }
}
