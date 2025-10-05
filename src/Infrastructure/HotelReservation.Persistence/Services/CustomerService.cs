using HotelReservation.Application.Abstracts.Repositories;
using HotelReservation.Application.Abstracts.Services;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Persistence.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repo;
    public CustomerService(ICustomerRepository repo) => _repo = repo;

    public async Task<Customer?> GetByIdAsync(Guid id) =>
        await _repo.GetByIdAsync(id);

    public async Task<IEnumerable<Customer>> GetAllAsync() =>
        await _repo.GetAllAsync();

    public async Task<Customer> CreateAsync(Customer customer)
    {
        await _repo.AddAsync(customer);
        return customer;
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        await _repo.UpdateAsync(customer);
        return customer;
    }

    public async Task DeleteAsync(Guid id)
    {
        var customer = await _repo.GetByIdAsync(id);
        if (customer != null)
            await _repo.DeleteAsync(customer);
    }
}

