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
            return CustomerRepo.GetMany(cus => cus.Name.Contains(searchValue) || cus.Email.Contains(searchValue)  || cus.AccountNumber.Contains(searchValue) );
        }
        public Customers SearchCustomerById(int Id)
        {
            return CustomerRepo.Get(Id);    
        }
        public Customers SearchCustomerByAccountNumber(string AccountNumber)
        {
            var customer = CustomerRepo.GetOne(Customer=>Customer.AccountNumber.Equals(AccountNumber));
            if(customer != null)
                return customer;

            var NotFoundCustomer = new Customers { Email = "Customer not found"  };
            return NotFoundCustomer;
        }
        public string SendMoney(Customers Sender,string ReciverAccountNumber, decimal AmmountOfMoney)
        {
            if (AmmountOfMoney == 0)
                return "Not vaild ammount of money";


            if (Sender.Balance < AmmountOfMoney)
                return "Not enough money in your account";
           
            Sender.Balance -= AmmountOfMoney;
            UpdateCustomer(Sender);
            Customers Reciver = SearchCustomerByAccountNumber(ReciverAccountNumber);
            Reciver.Balance += AmmountOfMoney;

            return "transfered succesfully";

        }
        public void UpdateCustomer(Customers customer)
        {
            CustomerRepo.Edit(customer);
        }
    }
}
