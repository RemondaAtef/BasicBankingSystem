using BankingSystem.Manger;
using BankingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    public class customerController : Controller
    {
        private readonly CustomerManger customerManger;

        public customerController(CustomerManger customerManger)
        {
            this.customerManger = customerManger;
        }
        [HttpGet]
        public IActionResult index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult details(int Id)
        {
            var CustomerDetails = customerManger.SearchCustomerById(Id);
            return View(CustomerDetails);
        }
        [HttpPost]
        public IActionResult details(Customers SenderDetails, string ReciverAccountNumber , decimal AmountOfMoney)
        {
            return View();
        }
        public IActionResult SearchCustomerByAccountNumber(string AccountNumber)
        {
            var Account_Number = customerManger.SearchCustomerByAccountNumber(AccountNumber);
            return Json(Account_Number);
        }
    }
}
