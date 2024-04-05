using file.Entities;
using file.Implementation.Repositories;
using file.RequestModel;
using file.ResponseModel;

namespace file.Implementation.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public BaseResponse Register(CustomerRequestModel customerRequestModel)
        {
            //var customer = _customerRepository.GetAllCustomers().SingleOrDefault(x => x.Email == customerRequestModel.Email);
            if (_customerRepository.GetAllCustomers().SingleOrDefault(x => x.Email == customerRequestModel.Email) == null)
            {
                return new BaseResponse
                {
                    Message = "Email already exist",
                    Status = false
                };             
            }
            Customer customer = new Customer
            {
                Name = customerRequestModel.Name,
                Address = customerRequestModel.Address,
                Email = customerRequestModel.Email,
                Password = customerRequestModel.Password
            };
            _customerRepository.Add(customer);
            return new BaseResponse
            {
                Message = "Sucessfully registered",
                Status = true
            };
        }
    }
}