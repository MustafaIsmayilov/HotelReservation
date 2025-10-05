using HotelReservation.Application.Abstracts.Repositories;
using HotelReservation.Application.Abstracts.Services;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Persistence.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepo;
    private readonly IRoomRepository _roomRepo;

    public ReservationService(IReservationRepository reservationRepo, IRoomRepository roomRepo)
    {
        _reservationRepo = reservationRepo;
        _roomRepo = roomRepo;
    }

    public async Task<Reservation> CreateReservationAsync(Guid roomId, DateTime startDate, DateTime endDate)
    {
        if (startDate >= endDate)
            throw new ArgumentException("StartDate must be earlier than EndDate");

        var room = await _roomRepo.GetByIdAsync(roomId);
        if (room == null || !room.IsAvailable)
            throw new InvalidOperationException("Room not available");

        bool overlap = !await _reservationRepo.IsRoomAvailableAsync(roomId, startDate, endDate);
        if (overlap)
            throw new InvalidOperationException("Reservation dates overlap");

        var reservation = new Reservation
        {
            StartDate = startDate,
            EndDate = endDate,
            Rooms = new List<Room> { room },
        };

        room.IsAvailable = false;
        await _reservationRepo.AddAsync(reservation);
        await _roomRepo.UpdateAsync(room);

        return reservation;
    }

    public async Task<Reservation?> GetReservationAsync(Guid id) =>
        await _reservationRepo.GetByIdAsync(id);

    public async Task CancelReservationAsync(Guid id)
    {
        var reservation = await _reservationRepo.GetByIdAsync(id);
        if (reservation == null)
            throw new KeyNotFoundException("Reservation not found");

        foreach (var room in reservation.Rooms)
        {
            room.IsAvailable = true;
            await _roomRepo.UpdateAsync(room);
        }

        await _reservationRepo.DeleteAsync(reservation);
    }
}

