using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMqUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProcessor
{
    public class ReservationListener : RabbitListener
    {
        private readonly ILogger<ReservationListener> _logger;

        public ReservationListener(ILogger<ReservationListener> logger, IOptionsMonitor<RabbitOptions> options)
            : base(options)
        {
            _logger = logger;
            base.QueueName = "reservations";
            base.ExchangeName = "";
        }

        public override Task<bool> Process(string message)
        {
            _logger.LogInformation(message);



            return Task.FromResult(false);
        }
    }
}
