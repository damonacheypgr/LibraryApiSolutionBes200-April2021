using LibraryApi.Domain;

namespace LibraryApi.Models.Reservations
{
    public class GetReservationSummaryResponse : CollectionRepresentation<GetReservationSummaryResponseItem>
    {
    }

    public class GetReservationSummaryResponseItem
    {
        public int Id { get; set; }
        public string For { get; set; }
        public string BookIds { get; set; }

        public ReservationStatus Status { get; set; }
    }
}
