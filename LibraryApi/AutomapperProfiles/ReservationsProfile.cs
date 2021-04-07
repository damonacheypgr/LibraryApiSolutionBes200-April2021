using AutoMapper;
using LibraryApi.Domain;
using LibraryApi.Models.Reservations;

namespace LibraryApi.AutomapperProfiles
{
    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {
            CreateMap<BookReservation, GetReservationSummaryResponseItem>();
        }
    }
}
