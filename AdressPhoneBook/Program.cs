using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressPhoneBook
{
    internal class Program
    {
        public static void Find(Dictionary<string, Contacts> phonebooks,string name)
        {
            List<AddressBook> list = new List<AddressBook>();
            foreach(var contact in phonebooks)
            {
                list=(contact.Value.contact.FindAll(e => e.State == name | e.City == name).ToList());
                bool ff = true;
                foreach(AddressBook item in list)
                {
                    if (ff)
                    {
                        Console.WriteLine(contact.Key);
                        ff = false;
                    }
                    Console.WriteLine(item.FirstName+" "+item.LastName);

                }
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Contacts> Adressbooks = new Dictionary<string, Contacts>();
            Contacts first = new Contacts("firstuser");
            Adressbooks.Add("firstuser", first);
            Contacts second = new Contacts("seconduser");
            Adressbooks.Add("seconduser", second);
            Adressbooks["firstuser"].Phonebook();
            Adressbooks["seconduser"].Phonebook();
            Console.WriteLine("Enter the city or state name by which you want to search");
            string choice = Console.ReadLine();
            Find(Adressbooks, choice);
          
        }
    }
}