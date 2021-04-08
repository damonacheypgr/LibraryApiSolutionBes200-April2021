using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProcessor
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public string For { get; set; }
        public string BooksIds { get; set; }
        public string Status { get; set; }

    }
}
