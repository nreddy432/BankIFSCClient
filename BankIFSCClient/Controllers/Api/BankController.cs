using BankIFSCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;

namespace BankIFSCClient.Controllers.Api
{
    public class BankController : ApiController
    {
        ApplicationDbContext _context;

        public BankController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult GetBanksByIFSCCode(string query = null)
        {
            if (MemoryCache.Default["Banks"]==null)
            {
                MemoryCache.Default["Banks"] = _context.Banks.ToList();
            }
            var banks = MemoryCache.Default["Banks"] as List<Bank>;

            if (!String.IsNullOrWhiteSpace(query))
                banks = banks.Where(bank => bank.IFSCCode.Contains(query)).ToList();

            

            return Ok(banks);
        }

    }
}
