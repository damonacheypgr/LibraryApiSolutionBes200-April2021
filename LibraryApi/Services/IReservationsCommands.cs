using LibraryApi.Models.Reservations;
using System.Threading.Tasks;

namespace LibraryApi
{
    public interface IReservationsCommands
    {
        Task<GetReservationSummaryResponseItem> AddReservationAsync(PostReservationRequest request);
    }
}