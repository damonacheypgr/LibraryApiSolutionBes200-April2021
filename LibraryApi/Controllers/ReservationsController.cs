using LibraryApi.Filters;
using LibraryApi.Models.Reservations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationLookups _reservationLookups;
        private readonly IReservationsCommands _reservationCommands;

        public ReservationsController(IReservationLookups reservationLookups, IReservationsCommands reservationCommands)
        {
            _reservationLookups = reservationLookups;
            _reservationCommands = reservationCommands;
        }

        // POST
        [HttpPost("/reservations")]
        [ValidateModel]
        public async Task<ActionResult> AddAReservation([FromBody] PostReservationRequest request)
        {
            var response = await _reservationCommands.AddReservationAsync(request);

            return CreatedAtRoute("reservations#getbyid", new { Id = response.Id }, response);
        }

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
        [HttpPost("/reservations/ready")]
        public async Task<ActionResult> PutReservationInReadyBucket([FromBody] GetReservationSummaryResponseItem item)
        {
            if (await _reservationCommands.MarkReady(item))
            {
                return Accepted();
            }
            else
            {
                return BadRequest("No such reservation");
            }
        }

        // GET /denied
        // POST /denied
        [HttpPost("/reservations/ready")]
        public async Task<ActionResult> PutReservationInDeniedBucket([FromBody] GetReservationSummaryResponseItem item)
        {
            if (await _reservationCommands.MarkDenied(item))
            {
                return Accepted();
            }
            else
            {
                return BadRequest("No such reservation");
            }
        }
    }
}
