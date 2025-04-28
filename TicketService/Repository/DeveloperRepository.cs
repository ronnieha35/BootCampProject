using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Interface;
using TicketService.Models;

namespace TicketService.Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly List<Developer> _developers = new List<Developer>();
        public void Add(Developer developer)
        {
            // Verifica si el Developer Existe
            if (_developers.Any(u => u.Id == developer.Id))
            {
                Console.WriteLine("El Developer ya está registrado.");
                return;
            }
 
            _developers.Add(developer);
            
        }

        public List<Developer> GetAll()
        {
            return _developers.ToList();
        }

        public Developer? GetById(int id)
        {
            return _developers.FirstOrDefault(x => x.Id == id);
        }
    }
}
