
using LearnAPI.Service;
using LearnAPI.Repos;
using LearnAPI.Repos.Models;
using LearnAPI.Modal;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LearnAPI.Helper;
using static System.Runtime.InteropServices.JavaScript.JSType;



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

        public async Task<APIResponse> Create(Customermodal data)
        {
            APIResponse response = new APIResponse();
            try
            {
                TblCustomer _customer = this.mapper.Map<Customermodal, TblCustomer>(data);
               await  this.context.TblCustomers.AddAsync(_customer);
                await this.context.SaveChangesAsync();
                response.ResponseCode = 201;
                response.Result = data.Code;
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
            }
            return response;
        }

        public async Task<List<Customermodal>> Getall()
        {
            List<Customermodal> _response= new List<Customermodal>();
            var _data= await this.context.TblCustomers.ToListAsync();
            if (_data != null)
            {
                _response = this.mapper.Map<List<TblCustomer>, List<Customermodal>>(_data);
            }
            return _response;
        }

        public async Task<Customermodal> Getbycode(string code)
        {
            Customermodal _response = new Customermodal();
            var _data = await this.context.TblCustomers.FindAsync(code);
            if (_data != null)
            {
                _response = this.mapper.Map<TblCustomer, Customermodal>(_data);
            }
            return _response;
        }

        public async Task<APIResponse> Remove(string code)
        {
            APIResponse response = new APIResponse();
            try
            {
                //TblCustomer _customer = this.mapper.Map<Customermodal, TblCustomer>(data);
                //await this.context.TblCustomers.AddAsync(_customer);
                //await this.context.SaveChangesAsync();

                var _customer = await this.context.TblCustomers.FindAsync(code);
                if ( _customer != null )
                {
                    this.context.TblCustomers.Remove( _customer );
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 201;
                    response.Result = code;
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Errormessage = "Customer Not Found";

                }
              
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> Update(Customermodal data, string code)
        {
            APIResponse response = new APIResponse();
            try
            {
                
                var _customer = await this.context.TblCustomers.FindAsync(code);
                if (_customer != null)
                {

                    _customer.Email = data.Email;
                    _customer.Phone = data.Phone;
                    _customer.Name = data.Name;
                    _customer.IsActive= data.IsActive;
                    _customer.Creditlimit = data.Creditlimit;
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 201;
                    response.Result = code;
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Errormessage = "Customer Not Found";

                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
            }
            return response;
        
    }
    }
}


      

