using LearnAPI.Modal;
using LearnAPI.Repos.Models;

namespace LearnAPI.Service
{
    public interface ICustomerService
        {
        Task<List<Customermodal>> Getall();
    }
}
