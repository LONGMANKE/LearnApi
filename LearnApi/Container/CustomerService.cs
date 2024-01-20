
using LearnAPI.Service;
using LearnAPI.Repos;
using LearnAPI.Repos.Models;
using LearnAPI.Modal;
using AutoMapper;
using Microsoft.EntityFrameworkCore;



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
            public async Task<List<Customermodal>> Getall()
        { List<Customermodal> _response= new List<Customermodal>();
            var _data= await this.context.TblCustomers.ToListAsync();
            if (_data != null)
            {
                _response = this.mapper.Map<List<TblCustomer>, List<Customermodal>>(_data);
            }
            return _response;
        }

       
}
}


      

