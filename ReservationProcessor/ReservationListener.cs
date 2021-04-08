using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMqUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReservationProcessor
{
    public class ReservationListener : RabbitListener
    {
        private readonly ILogger<ReservationListener> _logger;
        private readonly ReservationHttpService _service;

        public ReservationListener(ILogger<ReservationListener> logger, IOptionsMonitor<RabbitOptions> options, ReservationHttpService service)
            : base(options)
        {
            _logger = logger;
            base.QueueName = "reservations";
            base.ExchangeName = "";
            _service = service;
        }

        public override async Task<bool> Process(string message)
        {
            _logger.LogInformation(message);

            var reservation = JsonSerializer.Deserialize<ReservationModel>(message);

            var numberOfBooks = reservation.BooksIds.Count(c => c == ',');
            await Task.Delay(1000 * numberOfBooks);

            if (numberOfBooks % 2 == 0)
            {
                _logger.LogInformation($"Got a reservation for {reservation.For}. It is approved.");
                return await _service.MarkReservationReady(reservation);
            }
            else
            {
                _logger.LogInformation($"Got a reservation for {reservation.For}. It is DENIED.");
                return await _service.MarkReservationDenied(reservation);
            }
        }
    }
}
