using BankingSystem.Manger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class custmoerListController : ControllerBase
    {
        private readonly CustomerManger customerManger;

        public custmoerListController(CustomerManger customerManger)
        {
            this.customerManger = customerManger;
        }
        [HttpPost]
        public IActionResult ListCustomer()
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            var searchValue = Request.Form["search[value]"];

            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];

            var Customers = customerManger.SearchCustomer(searchValue);

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                Customers = Customers.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));

            var data = Customers.Skip(skip).Take(pageSize).ToList();

            var recordsTotal = Customers.Count();

            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };

            return Ok(jsonData);
        }
    }
}
