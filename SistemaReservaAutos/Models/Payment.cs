using SistemaReservaAutos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int IdReservation { get; set; }
        public int IdCustomer {  get; set; }
        public DateTime paymentDate { get; set; }
        public decimal Amount { get; set; }
        public string? paymentMethod { get; set; }
        public StatusPayment statusPayment { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} - Payment of S/.{Amount} - {paymentMethod} - {paymentDate.ToShortDateString()}";
        }
    }
}
