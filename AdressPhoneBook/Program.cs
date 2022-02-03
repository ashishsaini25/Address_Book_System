using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressPhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBook book = new AddressBook();
            book.AddContact();
        }
    }
}
