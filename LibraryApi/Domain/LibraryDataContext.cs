using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryApi.Domain
{
    public class LibraryDataContext : DbContext
    {
        public LibraryDataContext(DbContextOptions<LibraryDataContext> options): base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        public DbSet<BookReservation> Reservations { get; set; }

        public IQueryable<Book> AvailableBooks {  
            get {
                return Books.Where(b => b.IsAvailable);
            } 
        }
    }
}
