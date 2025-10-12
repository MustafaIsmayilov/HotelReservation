using HotelReservation.Application.Abstracts.Services;
using HotelReservation.Application.DTOs.ReservationDto;
using HotelReservation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReservationCreateDto dto)
        {
            if (dto == null || dto.RoomIds == null || dto.RoomIds.Count == 0)
                return BadRequest(new { error = "At least one room must be selected." });

            if (dto.StartDate >= dto.EndDate)
                return BadRequest(new { error = "StartDate must be earlier than EndDate." });

            var createdReservations = new List<Reservation>();

            foreach (var roomId in dto.RoomIds)
            {
                try
                {
                    var reservation = await _reservationService.CreateReservationAsync(
                        roomId,
                        dto.StartDate,
                        dto.EndDate
                    );
                    createdReservations.Add(reservation);
                }
                catch (Exception ex) when (ex is InvalidOperationException || ex is ArgumentException)
                {
                    return BadRequest(new { roomId, error = ex.Message });
                }
            }

            if (createdReservations.Count == 1)
                return CreatedAtAction(nameof(GetById), new { id = createdReservations[0].Id }, createdReservations[0]);

            return Ok(createdReservations);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var reservation = await _reservationService.GetReservationAsync(id);
            if (reservation == null)
                return NotFound(new { error = "Reservation not found." });

            return Ok(reservation);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            try
            {
                await _reservationService.CancelReservationAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}

