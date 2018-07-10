using BankIFSCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankIFSCClient.ViewModels
{
    public class BankMICRCodeViewModel
    {
        public List<string> MICRCodes { get; set; }

        public Bank Bank { get; set; }
    }
}