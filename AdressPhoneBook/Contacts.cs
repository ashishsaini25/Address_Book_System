using AddressPhoneBook;
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
           Console.WriteLine( contact.Count());
            try
            {
                AddressBook addressBook = new AddressBook();
                addressBook = AddContact();
                contact.Add(addressBook);
                nlog.LogInfo("New Contact Added in Adressbook");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
        public AddressBook AddContact()
        {
            AddressBook addressBook =new AddressBook();
            Console.WriteLine("Enter the First Name");
            addressBook.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the Last Name");
            addressBook.LastName = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            addressBook.Address = Console.ReadLine();
            Console.WriteLine("Enter the City");
            addressBook.City = Console.ReadLine();
            Console.WriteLine("Enter the State");
            addressBook.State = Console.ReadLine();
            Console.WriteLine("Enter the Zip");
            addressBook.Zip = Console.ReadLine();
            Console.WriteLine("Enter the PhoneNumber");
            addressBook.Phonenumber = Console.ReadLine();
            Console.WriteLine("Enter the Email");
            addressBook.Email = Console.ReadLine();
            return addressBook;
        }
        public bool EditContact()
        {
            Console.WriteLine("Enter The First Name");
            string Fname = Console.ReadLine();
            Console.WriteLine("Enter The Last Name");
            string Lname=Console.ReadLine();

            foreach( AddressBook  addressBook in contact)
            {
                if (addressBook.FirstName == Fname && addressBook.LastName == Lname)
                {
                    Console.WriteLine("Current Information About The Contact");
                    Display(addressBook);
                    AddressBook temp = new AddressBook();
                    temp = Edit( addressBook);
                    contact.Remove(addressBook);
                    contact.Add(temp);
                    return true;
                }
            }
            return false;

        }
        public AddressBook Edit( AddressBook  address)
        {
            Console.WriteLine("Enter 1 to update First Name" + "Enter 2 to update Last Name" +
                "Enter 3 To update Address" + "Enter 4 to update city" + "Enter 5 to update State" +
                "Enter 6 to update Zip"+"Enter 7 to upadte PhoneNumber"+"Enter 8 to update Email");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the New Information");
            string temp=Console.ReadLine();
            switch (n)
            {
                case 1:
                    address.FirstName = temp;
                    break;
                case 2:
                    address.LastName = temp;
                    break;
                case 3:
                    address.Address = temp;
                    break;
                case 4:
                    address.City = temp;
                    break;
                case 5:
                    address.State = temp;
                    break;
                case 6:
                    address.Zip = temp;
                    break;
                case 7:
                    address.Phonenumber = temp;
                    break;
                case 8:
                    address.Email = temp;
                    break;
                default:
                    Console.WriteLine("Choose Correct Option");
                    break;
            }
            return address;
        }
        public void Display(AddressBook address)
        {
            Console.WriteLine("First Name :"+ address.FirstName);
            Console.WriteLine("Last Name  :"+ address.LastName);
            Console.WriteLine("Address    :"+ address.Address);
            Console.WriteLine("City       :"+ address.City);
            Console.WriteLine("State      :"+ address.State);
            Console.WriteLine("Zip        :"+address.Zip);
            Console.WriteLine("Phonenumber :"+ address.Phonenumber);
            Console.WriteLine("Email :"+ address.Email);

        }
        public void View()
        {
         //   int i = 0;
            foreach(AddressBook addressBook in contact)
            {
                ///     Console.WriteLine(i);
                Console.WriteLine(addressBook.FirstName);
               Display(addressBook);
            }
        }
        public void Phonebook()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter 1 to add contact \n" + "Enter to 2  Edit Contact\n" + "Enter 3 To view Contact\n"+"Enter 4 to Exit\n");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        NewContact();
                        break;
                    case 2:
                        bool done = EditContact();
                        if (done) Console.WriteLine("Contact Updated\n");
                        else Console.WriteLine("No Record Found\n");
                        break;
                    case 3:
                        View();
                        break;
                    case 4:
                        flag=false;
                        break;

                }
            }
        }
    }
}
