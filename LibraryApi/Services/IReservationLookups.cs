using LibraryApi.Models.Reservations;
using System;
using System.Threading.Tasks;

namespace LibraryApi
{
    public interface IReservationLookups
    {
        Task<GetReservationSummaryResponse> GetAllReservationsAsync();
        Task<GetReservationSummaryResponseItem> GetByIdAsync(int id);
    }
}