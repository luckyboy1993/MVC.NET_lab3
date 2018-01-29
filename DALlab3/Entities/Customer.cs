﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DALlab3.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        public int CustomerId { get; set; }
        public int? PersonId { get; set; }
        public int? StoreId { get; set; }
        public int? TerritoryId { get; set; }
        public string AccountNumber { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Person Person { get; set; }
        public Store Store { get; set; }
        public SalesTerritory Territory { get; set; }
        public ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }

        public string SecretHash
        {
            get
            {
                byte[] md5 = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(Person.FirstName + Person.LastName));
                return Encoding.ASCII.GetString(md5);
            }
        }
    }
}
