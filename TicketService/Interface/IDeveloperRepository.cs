using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Models;

namespace TicketService.Interface
{
    public interface IDeveloperRepository
    {
        public List<Developer> GetAll();
        public Developer GetById(int id);
        public void Add(Developer developer);
    }
}
