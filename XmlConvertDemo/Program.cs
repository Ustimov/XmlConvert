/*
 *  Created by Artem Ustimov (art@ustimov.org) on 22/10/2016.
 */

using System;
using System.Collections.Generic;
using Ustimov.Org.XmlConvert;

namespace XmlConvertDemo
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }

    public class ContactModel
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string FullName { get; set; }

        public string LastMessage { get; set; }

        public DateTime LastMessageDateTime { get; set; }
    }

    public class ContactsResponse
    {
        public List<ContactModel> Contacts { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            // Support for object serialization/deserialization without namespaces
            var john = new Person { FirstName = "John", LastName = "Doe", Age = 45 };

            Console.WriteLine(XmlConvert.SerializeObject(john));

            Console.WriteLine();

            var xml = @"<ContactsResponse xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""
                                          xmlns=""http://schemas.datacontract.org/2004/07/"">
                          <Contacts>
                            <ContactModel>
                              <FullName>String</FullName>
                              <Id>0</Id>
                              <Image>String</Image>
                              <LastMessage>String</LastMessage>
                              <LastMessageDateTime>0001-01-01T00:00:00</LastMessageDateTime>
                            </ContactModel>
                          </Contacts>
                        </ContactsResponse>";

            // Support for object serialization/deserialization with default namespace
            var contactsReponse = XmlConvert.DeserializeObject<ContactsResponse>(xml,
                "http://schemas.datacontract.org/2004/07/");

            foreach (var contact in contactsReponse.Contacts)
            {
                // Support for object serialization/deserialization with default and custom namespaces
                Console.WriteLine(XmlConvert.SerializeObject(contact, "http://ustimov.org/",
                    new Dictionary<string, string>
                    {
                        {"i", "http://ustimov.org/instance/" }
                    }));

                Console.WriteLine();

                Console.WriteLine($"Id: {contact.Id} | Full Name: {contact.FullName} " +
                                  $"| Image: {contact.Image} | Last Message: {contact.LastMessage} " +
                                  $"| Last Message Date Time: {contact.LastMessageDateTime}");
            }
        }
    }
}
