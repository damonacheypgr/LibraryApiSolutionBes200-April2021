using LibraryApi.Domain;
using LibraryApi.Models.Reservations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class EfReservationsLookup : IReservationLookups
    {
        private readonly LibraryDataContext _context;

        public EfReservationsLookup(LibraryDataContext context)
        {
            _context = context;
        }

        public async Task<GetReservationSummaryResponseItem> GetByIdAsync(int id)
        {
            var response = await _context
                .Reservations
                .Where(r => r.Id == id)
                .Select(r => new GetReservationSummaryResponseItem
                {
                    Id = r.Id,
                    For = r.For,
                    BookIds = r.BookIds,
                    Status = r.Status,
                }).SingleOrDefaultAsync();

            return response;
        }

        async Task<GetReservationSummaryResponse> IReservationLookups.GetAllReservationsAsync()
        {
            var response = new GetReservationSummaryResponse();

            var books = await _context
                .Reservations
                .Select(r => new GetReservationSummaryResponseItem
                {
                    Id = r.Id,
                    For = r.For,
                    BookIds = r.BookIds,
                    Status = r.Status,
                }).ToListAsync();

            response.Data = books;

            return response;
        }
    }
}
