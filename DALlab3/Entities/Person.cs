﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DALlab3.Entities
{
    public partial class Person
    {
        public Person()
        {
            BusinessEntityContact = new HashSet<BusinessEntityContact>();
            Customer = new HashSet<Customer>();
            EmailAddress = new HashSet<EmailAddress>();
            PersonCreditCard = new HashSet<PersonCreditCard>();
            PersonPhone = new HashSet<PersonPhone>();
        }

        public int BusinessEntityId { get; set; }
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public int EmailPromotion { get; set; }
        public string AdditionalContactInfo { get; set; }
        public string Demographics { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public BusinessEntity BusinessEntity { get; set; }
        public Employee Employee { get; set; }
        public Password Password { get; set; }
        public ICollection<BusinessEntityContact> BusinessEntityContact { get; set; }
        public ICollection<Customer> Customer { get; set; }
        public ICollection<EmailAddress> EmailAddress { get; set; }
        public ICollection<PersonCreditCard> PersonCreditCard { get; set; }
        public ICollection<PersonPhone> PersonPhone { get; set; }

        public string SecretHash
        {
            get
            {
                byte[] md5 = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(FirstName + LastName));
                return Encoding.ASCII.GetString(md5);
            }
        }
    }
}
