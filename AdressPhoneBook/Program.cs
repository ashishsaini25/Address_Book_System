using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace AdressPhoneBook
{
    internal class Program
    {
        public static void Find(Dictionary<string, Contacts> phonebooks, string name)
        {
            List<AddressBook> list = new List<AddressBook>();
            foreach (var contact in phonebooks)
            {
                list = (contact.Value.contact.FindAll(e => e.State == name | e.City == name).ToList());
                bool ff = true;
                foreach (AddressBook item in list)
                {
                    if (ff)
                    {
                        Console.WriteLine(contact.Key);
                        ff = false;
                    }
                    Console.WriteLine(item.FirstName + " " + item.LastName);

                }
            }
        }
        public static int CountByCityorState(Dictionary<string, Contacts> phonebooks, string name)
        {
            List<AddressBook> list = new List<AddressBook>();
            int count = 0;
            foreach (var contact in phonebooks)
            {
                list = (contact.Value.contact.FindAll(e => e.State == name | e.City == name).ToList());
                count += list.Count;
            }
            return count;
        }
        static void Main(string[] args)
        {
            Dictionary<string, Contacts> Adressbooks = new Dictionary<string, Contacts>();
            Contacts first = new Contacts("firstuser");
            Adressbooks.Add("firstuser", first);
            string file = @"C:\Users\Lenovo\Desktop\git project\Address_Book_System\AdressPhoneBook\Csvfile.csv";
            using (var reader = new StreamReader(file))
                using(var csv =new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressBook>().ToList();
                foreach (AddressBook record in records)
                {
                  first.FileAddContact(record);
                }
                first.Phonebook();   
            }
            using(var writer=new StreamWriter(file))
                using(var csvExport =new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvExport.WriteRecords(first.contact);
            }


        }
    }
}