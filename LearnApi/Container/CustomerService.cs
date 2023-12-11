
using LearnAPI.Service;
using LearnAPI.Repos;
using LearnAPI.Repos.Models;



namespace LearnAPI.Container
{
    public class CustomerService : ICustomerService
    {
        private readonly LearndataContext context;
        public CustomerService(LearndataContext context) { 
            this.context = context;
        }
            public List<TblCustomer> Getall()
        {
            return this.context.TblCustomers.ToList();
        }
       
}
}


      

