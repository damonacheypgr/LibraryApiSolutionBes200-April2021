using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationLookups _reservationLookups;

        public ReservationsController(IReservationLookups reservationLookups)
        {
            _reservationLookups = reservationLookups;
        }

        // POST
        // GET /{id}
        [HttpGet("/reservations/{id:int}", Name = "reservations#getbyid")]
        public async Task<ActionResult> GetReservationById(int id)
        {
            var response = await _reservationLookups.GetByIdAsync(id);
            return this.Maybe(response);
        }

        // GET /
        [HttpGet("/reservations")]
        public async Task<ActionResult> GetAllReservations()
        {
            var response = await _reservationLookups.GetAllReservationsAsync();

            return Ok(response);
        }

        // GET /pending

        // GET /ready
        // POST /ready

        // GET /denied
        // POST /denied
    }
}
