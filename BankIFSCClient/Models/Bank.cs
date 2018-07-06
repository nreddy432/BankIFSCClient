using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankIFSCClient.Models
{
    public class Bank
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IFSCCode { get; set; }

        public string MICRCode { get; set; }

        public string Branch { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string State { get; set; }
    }
}