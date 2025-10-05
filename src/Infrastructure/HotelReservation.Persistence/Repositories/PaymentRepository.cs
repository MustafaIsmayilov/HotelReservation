using System.Data.Entity;
using HotelReservation.Application.Abstracts.Repositories;
using HotelReservation.Domain.Entities;
using HotelReservation.Persistence.Contexts;

namespace HotelReservation.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly HotelDbContext _context;
    public PaymentRepository(HotelDbContext context) => _context = context;

    public async Task<Payment?> GetByIdAsync(Guid id) =>
        await _context.Payments.Include(p => p.Reservation).FirstOrDefaultAsync(p => p.Id == id);

    public async Task AddAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
    }
}

