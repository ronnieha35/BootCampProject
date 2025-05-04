using SistemaReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaRestaurant.Services
{
    public interface ITableService
    {
        List<Table> GetAvailable(DateTime date, TimeSpan time, int partySize);
        Table GetByTableById(int id);

        List<Table> GetAll();

    }
}
