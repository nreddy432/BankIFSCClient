using BankIFSCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult GetBankDetailsByIFSCCode(Bank bank)
        {
            var bankDetails = _context.Banks.SingleOrDefault(b => b.IFSCCode == bank.IFSCCode);

            return View(bankDetails);
        }

        [Route("bank/micr")]
        [HttpPost]
        public ActionResult GetBankDetailsByMICRCode(Bank bank)
        {
            var bankDetails = _context.Banks.SingleOrDefault(b => b.MICRCode == bank.MICRCode);

            return View(bankDetails);
        }

    }
}