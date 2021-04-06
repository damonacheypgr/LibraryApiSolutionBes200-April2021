using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public interface IBookCommands
    {
        Task RemoveBookAsync(int id);
    }
}