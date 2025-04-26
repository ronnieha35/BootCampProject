using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketService.Models
{
    public class Comment
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string CreatedDate { get; set; }

        public Comment()
        {
            Id = _nextId++;
        }
    }
}
