using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Abstracts.Services;

public interface ICustomerService
{
    Task<Customer?> GetByIdAsync(Guid id);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> CreateAsync(Customer customer);
    Task<Customer> UpdateAsync(Customer customer);
    Task DeleteAsync(Guid id);
}

