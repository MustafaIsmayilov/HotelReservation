using HotelReservation.Application.Abstracts.Repositories;
using HotelReservation.Application.Abstracts.Services;
using HotelReservation.Persistence.Repositories;
using HotelReservation.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservation.Persistence.Registration;

public static class ServiceRegistration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        // Services
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<ICustomerService, CustomerService>();
    }
}

