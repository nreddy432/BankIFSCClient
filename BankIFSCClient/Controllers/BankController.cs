using BankIFSCClient.Models;
using BankIFSCClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;

namespace BankIFSCClient.Controllers
{
    public class BankController : Controller
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

        public ActionResult Home()
        {
            return View();
        }

        [Route("bank/name")]
        [HttpGet]
        public ActionResult SearchByName()
        {
            return View(new Bank());
        }

        [Route("bank/ifsc")]
        [HttpGet]
        public ActionResult SearchByIFSC()
        {
            
            return View(new Bank());
        }

        [Route("bank/micr")]
        [HttpGet]
        public ActionResult SearchByMICR()
        {
            return View(new Bank());
        }

        [Route("bank/name")]
        [HttpPost]
        public ActionResult GetBankDetails(Bank bank)
        {
            var bankDetails = _context.Banks.SingleOrDefault(b => b.Name == bank.Name && b.Branch == bank.Branch
                              && b.District == bank.District && b.State == bank.State);

            return View(bankDetails);
        }

        [Route("bank/ifsc")]
        [HttpPost]
        public ActionResult SearchByIFSC(Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return View(bank);
            }

            if (MemoryCache.Default["Banks"] == null)
            {
                MemoryCache.Default["Banks"] = _context.Banks.ToList();
            }
            var banks = MemoryCache.Default["Banks"] as List<Bank>;

            var bankDetails = banks.SingleOrDefault(b => b.IFSCCode == bank.IFSCCode);

            return View(bankDetails);
        }

        [Route("bank/micr")]
        [HttpPost]
        public ActionResult SearchByMICR(Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return View(bank);
            }

            if (MemoryCache.Default["Banks"] == null)
            {
                MemoryCache.Default["Banks"] = _context.Banks.ToList();
            }
            var banks = MemoryCache.Default["Banks"] as List<Bank>;

            var bankDetails = banks.SingleOrDefault(b => b.MICRCode == bank.MICRCode);

            return View(bankDetails);
        }

    }
}