using SistemaReservaAutos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Year { get; set; }
        public StatusSegment Segment {  get; set; }
        public TypeCar Type { get; set; }
        public string? Plate { get; set; }
        public int QuantityPax {  get; set; }
        public decimal Tax {  get; set; }   
        public StatusVehicle statusVehicle { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Brand: {Brand}, Model: {Model}, Status: {statusVehicle}";
        }
    }
}
