using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Models;

namespace TicketService.Interface
{
    public interface IPersonaRepository
    {
        public void AddPersona(Persona entity);

        public List<Persona> GetAll();

        public Persona GetByIdPersona(int id);
    }
}
