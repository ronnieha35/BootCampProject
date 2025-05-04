using SistemaReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaRestaurant.Services
{
    public class TableService : ITableService
    {
        private readonly ITableService _tableService;

        public TableService(ITableService tableService)
        {
            this._tableService = tableService;
        }

        public List<Table> GetAll()
        {
            return _tableService.GetAll();
        }

        public List<Table> GetAvailable(DateTime date, TimeSpan time, int partySize)
        {
            return _tableService.GetAvailable(date, time, partySize);
        }

        public Table GetByTableById(int id)
        {
            return _tableService.GetByTableById(id);
        }
    }
}
