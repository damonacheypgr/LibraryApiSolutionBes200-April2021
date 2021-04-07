using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryApi.Domain;
using LibraryApi.Models.Reservations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class EfReservationsLookup : IReservationLookups, IReservationsCommands
    {
        private readonly LibraryDataContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _config;

        public EfReservationsLookup(LibraryDataContext context, IMapper mapper, MapperConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        public async Task<GetReservationSummaryResponseItem> AddReservationAsync(PostReservationRequest request)
        {
            await Task.Delay(TimeSpan.FromSeconds(1) * request.Books.Count(c => c == ','));

            var reservation = new BookReservation
            {
                For = request.For,
                BookIds = request.Books,
                Status = ReservationStatus.Ready,
            };

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetReservationSummaryResponseItem>(reservation);
        }

        public async Task<GetReservationSummaryResponseItem> GetByIdAsync(int id)
        {
            var response = await _context
                .Reservations
                .Where(r => r.Id == id)
                .ProjectTo<GetReservationSummaryResponseItem>(_config)
                .SingleOrDefaultAsync();

            return response;
        }

        async Task<GetReservationSummaryResponse> IReservationLookups.GetAllReservationsAsync()
        {
            var response = new GetReservationSummaryResponse();

            var books = await _context
                .Reservations
                .ProjectTo<GetReservationSummaryResponseItem>(_config)
                .ToListAsync();

            response.Data = books;

            return response;
        }
    }
}
