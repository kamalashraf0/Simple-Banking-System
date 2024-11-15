using Core.DTOs;

namespace Application.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CustomerCreateDto customerDto);
        Task UpdateCustomerAsync(int id, CustomerCreateDto customerDto);
        Task DeleteCustomerAsync(int id);
    }
}
