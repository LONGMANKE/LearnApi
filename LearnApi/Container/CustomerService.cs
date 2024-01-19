
using LearnAPI.Service;
using LearnAPI.Repos;
using LearnAPI.Repos.Models;
using LearnAPI.Modal;
using AutoMapper;



namespace LearnAPI.Container
{
    public class CustomerService : ICustomerService
    {
        private readonly LearndataContext context;
        private readonly IMapper mapper;
        public CustomerService(LearndataContext context, IMapper mapper) { 
            this.context = context;
            this.mapper = mapper; 
                }
            public List<Customermodal> Getall()
        { List<Customermodal> _response= new List<Customermodal>();
            var _data= this.context.TblCustomers.ToList();
            if (_data != null)
            {
                _response = this.mapper.Map<List<TblCustomer>, List<Customermodal>>(_data);
            }
            return _response;
        }

       
}
}


      

