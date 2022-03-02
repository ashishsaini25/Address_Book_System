using System;
using System.Collections.Generic;
using System.IO;
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
            string file = @"C:\Users\Lenovo\Desktop\git project\Address_Book_System\AdressPhoneBook\TextFile1.txt";

           
            if (File.Exists(file))
            {
               const Int32 BufferSize = 128;
                using (var fileStream = File.OpenRead(file))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        first.AddContact(line);  
                    }
           }
                first.Phonebook();
                string temp="";
                foreach(var user in first.contact)
                {
                    temp+=user.FirstName+" "+ user.LastName+" "+user.Address+" "+user.City+" "+user.State+" "+user.Zip+" "+user.Phonenumber+" "+user.Email+"\n";
                }
                File.WriteAllText(file, temp);

            }
            else
            {
                Console.WriteLine("File Does not Exist");
            }


        }
    }
}