using LibraryApi.Models.Books;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public interface ILookupBooks
    {
        Task<GetBooksSummaryResponse> GetBooksByGenreAsync(string genre);
        Task<GetBookDetailsResponse> GetBooksByIdAsync(int id);
    }
}