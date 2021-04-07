using LibraryApi.Domain;
using LibraryApi.Models.Reservations;
using RabbitMqUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class RabbitMQReservationProcessor : IProcessReservations
    {
        private readonly IRabbitManager _manager;

        public RabbitMQReservationProcessor(IRabbitManager manager)
        {
            _manager = manager;
        }

        public Task AddWorkAsync(BookReservation reservation)
        {
            _manager.Publish(reservation, "", "direct", "reservations");

            return Task.CompletedTask;
        }
    }
}
