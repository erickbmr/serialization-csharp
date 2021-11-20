using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    [XmlRoot("Client")]
    [ProtoContract]
    public class Client
    {
        public Client() { }
        public Client(string name, string document, string phoneNumber, Address address)
        {
            Name = name;
            Document = document;
            PhoneNumber = phoneNumber;
            Address = address;
        }
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public string Document { get; set; }
        [ProtoMember(3)]
        public string PhoneNumber { get; set; }
        [ProtoMember(4)]
        public Address Address { get; set; }
    }

    [ProtoContract]
    public class Address
    {
        public Address() { }
        public Address(string address, string city, string state, string country)
        {
            Line = address;
            City = city;
            State = state;
            Country = country;
        }
        [ProtoMember(5)]
        public string Line { get; set; }
        [ProtoMember(6)]
        public string City { get; set; }
        [ProtoMember(7)]
        public string State { get; set; }
        [ProtoMember(8)]
        public string Country { get; set; }
    }

}
