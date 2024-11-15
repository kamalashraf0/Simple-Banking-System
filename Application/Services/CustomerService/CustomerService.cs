using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task AddCustomerAsync(CustomerCreateDto customerCreateDto)
        {
            var customer = mapper.Map<Customer>(customerCreateDto);
            await unitOfWork.Repository<Customer>().AddAsync(customer);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {


            var customer = await unitOfWork.Repository<Customer>().GetByIdAsync(id);

            if (customer != null)
            {
                unitOfWork.Repository<Customer>().Delete(customer);
                await unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await unitOfWork.Repository<Customer>().GetAllAsync();
            return mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await unitOfWork.Repository<Customer>().GetByIdAsync(id);
            return mapper.Map<CustomerDto>(customer);
        }

        public async Task UpdateCustomerAsync(int id, CustomerCreateDto customerCreateDto)
        {
            var customer = await unitOfWork.Repository<Customer>().GetByIdAsync(id);

            if (customer != null)
            {
                mapper.Map(customerCreateDto, customer);
                unitOfWork.Repository<Customer>().Update(customer);
                await unitOfWork.SaveChangesAsync();
            }
        }
    }
}
