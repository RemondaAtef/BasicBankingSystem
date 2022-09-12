using BankingSystem.Models;
using BankingSystem.Reposatory;
using Microsoft.Extensions.Primitives;

namespace BankingSystem.Manger
{
    public class CustomerManger
    {
        private readonly BaseRepo<Customers> CustomerRepo;
        public CustomerManger(BankingSystemContext systemContext)
        {
            CustomerRepo=new BaseRepo<Customers>(systemContext);
        }
        public List<Customers> GetAllCustomers()
        {
            return CustomerRepo.GetAll().ToList();
        }

        public IQueryable<Customers> SearchCustomer(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                return CustomerRepo.GetAll();
            }
            return CustomerRepo.GetMany(cus => cus.Name.Contains(searchValue) || cus.Email.Contains(searchValue) || cus.Balance == Convert.ToInt64(searchValue));
        }
    }
}
