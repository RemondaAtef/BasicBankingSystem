using BankingSystem.Manger;
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
        public IActionResult list()
        {
            var Customers = customerManger.GetAllCustomers();
            return new JsonResult(Customers);
        }
    }
}
