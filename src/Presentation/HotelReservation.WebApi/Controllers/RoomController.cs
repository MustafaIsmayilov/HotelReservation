using HotelReservation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelReservation.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
    private static List<Room> Rooms = new List<Room>();

    [HttpGet]
    public IActionResult GetAll([FromQuery] int? capacity)
    {
        var query = Rooms.AsQueryable();

        if (capacity.HasValue)
        {
            if (capacity.Value <= 0)
                return BadRequest("Capacity must be positive.");

            query = query.Where(r => r.Capacity >= capacity.Value);
        }

        return Ok(query.ToList());
    }
}

