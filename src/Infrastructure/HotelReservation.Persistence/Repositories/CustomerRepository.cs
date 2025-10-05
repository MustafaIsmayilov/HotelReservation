using System.Data.Entity;
using HotelReservation.Application.Abstracts.Repositories;
using HotelReservation.Domain.Entities;
using HotelReservation.Persistence.Contexts;

namespace HotelReservation.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly HotelDbContext _context;
    public CustomerRepository(HotelDbContext context) => _context = context;

    public async Task<Customer?> GetByIdAsync(Guid id) =>
        await _context.Customers.FindAsync(id);

    public async Task<IEnumerable<Customer>> GetAllAsync() =>
        await _context.Customers.ToListAsync();

    public async Task AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Customer customer)
    {
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}

