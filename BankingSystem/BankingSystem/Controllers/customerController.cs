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
        public IActionResult index(bool transfer)
        {
            if (transfer == true)
            {
                ViewBag.transfer = true;
                return View(ViewBag.transfer);  
            }
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
            var Output = customerManger.SendMoney(SenderDetails, ReciverAccountNumber, AmountOfMoney);
            if (Output.Equals("transfered succesfully"))
                return Redirect("/customer?transfer=true#list");
            ModelState.AddModelError("", Output);
            return View(SenderDetails);
        }
       
        //ajax
        public IActionResult SearchCustomerByAccountNumber(string ReciverAccountNumber)
        {
            var Account_Number = customerManger.SearchCustomerByAccountNumber(ReciverAccountNumber);
            return Json(Account_Number);
        }
    }
}
