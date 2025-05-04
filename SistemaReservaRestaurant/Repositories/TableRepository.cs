using SistemaReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaRestaurant.Repositories
{
    public class TableRepository : ITableRepository
    {
        private List<Table> _tables = new List<Table>();
        private int _nextId = -1;

        public TableRepository() 
        {
            _tables.Add(new Table { Id = _nextId, Number = 1, Capacity = 2, IsAvailable = true, Location = "Windows" });
            _tables.Add(new Table { Id = _nextId, Number = 2, Capacity = 4, IsAvailable = true, Location = "Center" });
            _tables.Add(new Table { Id = _nextId, Number = 3, Capacity = 4, IsAvailable = true, Location = "Left" });
            _tables.Add(new Table { Id = _nextId, Number = 4, Capacity = 7, IsAvailable = true, Location = "Windows" });
            _tables.Add(new Table { Id = _nextId, Number = 5, Capacity = 2, IsAvailable = true, Location = "Windows" });
            _tables.Add(new Table { Id = _nextId, Number = 6, Capacity = 4, IsAvailable = true, Location = "Windows" });
        }


        public void Add(Table entity)
        {
            entity.Id = ++_nextId;
            _tables.Add(entity);
        }

        public void Delete(Table entity)
        {
            _tables.Remove(entity);
        }

        public List<Table> GetAll()
        {
            return _tables;
        }

        public List<Table> GetAvailableTables(DateTime date, int partySize)
        {
            return _tables.Where(t => t.IsAvailable && t.Capacity > partySize).ToList();
        }

        public Table? GetById(int id)
        {
            return _tables.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Table entity)
        {
            var index = _tables.FindIndex(x => x.Id == entity.Id);

            if (index != -1)
            {
                _tables[index] = entity;
            }
        }
    }
}
