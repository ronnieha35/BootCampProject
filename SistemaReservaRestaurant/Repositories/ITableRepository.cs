using SistemaReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaRestaurant.Repositories
{
    public interface ITableRepository : IRepository<Table>
    {
        List<Table> GetAvailableTables(DateTime date, int partySize);
    }
}
