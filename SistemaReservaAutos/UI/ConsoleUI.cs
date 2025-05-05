using SistemaReservaAutos.Models;
using SistemaReservaAutos.Repositories;
using SistemaReservaAutos.Services;
using SistemaReservaAutos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaAutos.UI
{
    public class ConsoleUI
    {
        private readonly IVehicleService _vehicleService;
        private readonly ICustomerService _customerService;
        private readonly IPaymentService _paymentService;
        private readonly IReservationService _reservationService;

        private bool _isRunning = true;

        public ConsoleUI(IReservationService reservationService,
                         ICustomerService customerService,
                         IVehicleService vehicleService,
                         IPaymentService paymentService)
        {
            _customerService = customerService;
            _reservationService = reservationService;
            _paymentService = paymentService;
            _vehicleService = vehicleService;
        }

        public void Run()
        {
            
            Console.WriteLine("=== Welcome RentCar Reservation ===");
          

            while (_isRunning)
            {
                OptionsMenuPrincipal();

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddNewReservation();
                        break;
                    case "2":
                        ListReservations();
                        break;
                    case "3":
                        CancelReservation();
                        break;
                    case "4":
                        ManageCustomers();
                        break;
                    case "5":
                        ManageVehicles();
                        break;
                    case "6":
                        ManagePayments();
                        break;
                    case "0":
                        _isRunning = false;
                        Console.WriteLine("Thank you for using the Car Reservation System!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        #region Payments
        private void ManagePayments()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Payments ===");
                Console.WriteLine("1. ViewPayments");
                Console.WriteLine("2. List Payments By User");
                Console.WriteLine("3. Exit");
                Console.Write("Enter option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ViewPayments();
                        break;
                    case "2":
                        ListPaymentsByUser();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
        private void ListPaymentsByUser()
        {
            //Seleccionar Customer
            var customers = _customerService.GetCustomer();

            if (customers == null)
            {
                Console.WriteLine("No Customers found. ");
                return;
            }

            Console.Write("\n=== Select Customer  ===\n");
            for (int i = 0; i < customers.Count; i++)
            {
                var c = customers[i];
                Console.WriteLine($"[{i + 1}] {c.Id} | {c.FullName} | {c.IdentityDocument}");
            }

            // Select Customer
            Console.Write("\nSelect Customer (number): ");
            if (!int.TryParse(Console.ReadLine(), out int tableIndexCustomer) ||
                tableIndexCustomer < 1 || tableIndexCustomer > customers.Count)
            {
                Console.WriteLine("Invalid Customer selection.");
                return;
            }

            
            var selectedCustomer = customers[tableIndexCustomer - 1];

            var payments = _paymentService.GetPaymentByUser(selectedCustomer.Id);


            Console.WriteLine("\n ID | FullName | Model | Year | Segment | Type | Plate | Amount | PayDate | status");
            Console.WriteLine(" " + new string('-', 80));

            foreach (var item in payments)
            {
                var reservation = _reservationService.GetReservationById(item.Id);
                var vehicle = _vehicleService.GetByVehicleId(reservation.VehicleId);

                Console.WriteLine($" {item.Id} | {selectedCustomer.FullName} | {vehicle.Model} | {vehicle.Segment} | {vehicle.Plate} | S/ {item.Amount.ToString("N2")} |{item.paymentDate.ToShortDateString()} | {reservation.statusReservation}");
            }

            Console.ReadKey();


        }
        private void ViewPayments()
        {
            Console.WriteLine("\n=== List of Payments ===");

            var payments = _paymentService.GetAllPayment();

            if (payments.Count == 0)
            {
                Console.WriteLine("No payments registed");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\n ID | IdReservation | FullName | PayDay | Amount | Vehicle | Model | status");
            Console.WriteLine(" " + new string('-', 80));

            foreach (var payment in payments)
            {
                var reservation = _reservationService.GetReservationById(payment.IdReservation);
                var customer = _customerService.GetCustomerById(reservation.CustomerId);
                var vehicle = _vehicleService.GetByVehicleId(reservation.VehicleId);

                Console.WriteLine($" {payment.Id} | {reservation.Id} | {customer.FullName} | {payment.paymentDate.ToShortDateString()} | S/. {payment.Amount.ToString("N2")} | {vehicle.Brand} | {vehicle.Model} | {reservation.statusReservation}");

            }

            Console.ReadKey();

        }
        #endregion

        #region Customer
        private void ManageCustomers()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Customers ===");
                Console.WriteLine("1. Create Customer");
                Console.WriteLine("2. Update Customer");
                Console.WriteLine("3. List Customer");
                Console.WriteLine("4. List Reservation History");
                Console.WriteLine("5. Exit");
                Console.Write("Enter option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddNewCustomer();
                        break;
                    case "2":
                        UpdateCustomer();
                        break;
                    case "3":
                        ListCustomer();
                        break;
                    case "4":
                        ListReservationHistory();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            } 
        }
        private void ListReservationHistory()
        {
            var customers = _customerService.GetCustomer();

            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found");
                Console.ReadKey();
                return;
            }

            Console.Write("\n=== Select Customer  ===\n");
            for (int i = 0; i < customers.Count; i++)
            {
                var c = customers[i];
                Console.WriteLine($"[{i + 1}] {c.Id} | {c.FullName} | {c.IdentityDocument}");
            }

            // Select Customer
            Console.Write("\nSelect Customer (number): ");
            if (!int.TryParse(Console.ReadLine(), out int tableIndexCustomer) ||
                tableIndexCustomer < 1 || tableIndexCustomer > customers.Count)
            {
                Console.WriteLine("Invalid Customer selection.");
                return;
            }

            var selectedCustomer = customers[tableIndexCustomer - 1];

            if (selectedCustomer.reservationsHistory.Count == 0)
            {
                Console.WriteLine("No customers found");
                Console.ReadKey();
                return;
            }


            Console.WriteLine("\n ID | FullName | Model | Year | Segment | Type | Plate | DateReserved | DateReturn | status");
            Console.WriteLine(" " + new string('-', 80));
            foreach (var reservation in selectedCustomer.reservationsHistory)
            { 
                
                var vehicle = _vehicleService.GetByVehicleId(reservation.VehicleId);

                Console.WriteLine($" {reservation.Id} | {selectedCustomer.FullName} | {vehicle.Model} | {vehicle.Year} | {vehicle.Segment} | {vehicle.Type} | {vehicle.Plate} | {(reservation.ReturnDate.ToShortDateString())} | {reservation.ReturnDate.ToShortDateString()} | {reservation.statusReservation}");
               

                
            }

            Console.ReadKey();
        }
        private void AddNewCustomer()
        {
            Console.Clear();
            Console.WriteLine("=== Create Customer ===");

            Console.WriteLine("Customer name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Genre: ");
            int i = 1;
            foreach (Genero gen in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"[{i}] {gen}");
            }

            Genero selectedGenre;

            while (true)
            {
                Console.Write("Opción: ");
                string entrada = Console.ReadLine();

                if (entrada == "0" || string.IsNullOrWhiteSpace(entrada))
                    return;

                if (int.TryParse(entrada, out int opcion) &&
                    opcion > 0 && opcion <= Enum.GetValues(typeof(Genero)).Length)
                {
                    selectedGenre = (Genero)(opcion - 1);
                    break;
                }

                Console.WriteLine(" Opción inválida.");
            }

            Console.WriteLine("IndentityNumbre: ");
            var numIdentity = Console.ReadLine();

            Console.WriteLine("Phone Number: ");
            var phoneNumber = Console.ReadLine();

            Console.WriteLine("Email: ");
            var email = Console.ReadLine();

            Console.WriteLine("EsVip : (yes/no)");
            bool esVip = false;
            var valvip = Console.ReadLine();

            if (valvip == "yes")
                esVip = true;

            Console.WriteLine("EsHandicap : (yes/no)");
            bool esHandicap = false;
            var valHandicap = Console.ReadLine();

            if (valHandicap == "yes")
                esHandicap = true;

            var customer = new Customer()
            {
                FullName = name,
                genero = selectedGenre,
                IdentityDocument = numIdentity,
                PhoneNumber = phoneNumber,
                Email = email,
                IsVip = esVip,
                IsHandicap = esHandicap,
            };

            var confirmCustomer = _customerService.CreateCustomer(customer);
            Console.WriteLine("Customer Created Succesfully....!");
            Console.ReadKey();
        }
        private void ListCustomer()
        {
            var customer = _customerService.GetCustomer();

            if (customer == null)
            {
                Console.WriteLine("No customers found. ");
                return;
            }
            else
            {
                Console.WriteLine("\n ID | Names | Identity | Genre | Email | Phone | esVip | esHandicap");
                Console.WriteLine(" " + new string('-', 80));

                foreach (var item in customer)
                {
                    Console.WriteLine($" {item.Id} | {item.FullName} | {item.IdentityDocument} | {item.genero} | {item.Email} | {item.PhoneNumber} | {(item.IsVip ? "Yes" : "No")} | {(item.IsHandicap ? "Yes" : "No")}");
                }
            }

            Console.ReadKey();
        
        }
        private void UpdateCustomer()
        {
            var customers = _customerService.GetCustomer();

            if (customers == null)
            {
                Console.WriteLine("No customers found. ");
                return;
            }

            
            Console.Write("=== Select Customer to Update === ");
            for (int i = 0; i < customers.Count; i++)
            {
                var c = customers[i];
                Console.WriteLine($"[{i + 1}] {c.FullName} | {c.IdentityDocument} | {c.Email}");
            }

            while (true)
            {
                Console.Write("Enter the number of the customer to update (0 to cancel): ");
                string entrada = Console.ReadLine();

                if (entrada == "0" || string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("Operation cancelled.");
                    return;
                }

                if (int.TryParse(entrada, out int opcion) &&
                    opcion > 0 && opcion <= customers.Count)
                {
                    var selectedCustomer = customers[opcion - 1];

                    
                    Console.WriteLine($"You selected: {selectedCustomer.FullName}");

                    // Ejemplo: actualizar el email
                    Console.Write("Enter new email: ");
                    string newEmail = Console.ReadLine();
                    selectedCustomer.Email = newEmail;

                    Console.Write("Enter new Phone: ");
                    string Phone = Console.ReadLine();
                    selectedCustomer.PhoneNumber = newEmail;



                    // Guardar cambios
                    _customerService.UpdateCustomer(selectedCustomer);

                    Console.WriteLine("Customer updated successfully.");
                    return;
                }

                Console.WriteLine("Invalid option.");
            }
        }
        #endregion
        #region Vehicles
        private void ManageVehicles()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Vehicles ===");
                Console.WriteLine("1. Create Vehicle");
                Console.WriteLine("2. Update Status Vehicle");
                Console.WriteLine("3. List Vehicle");
                Console.WriteLine("4. List Vehicle by Status");
                Console.WriteLine("5. Exit");
                Console.Write("Enter option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddNewVehicle();
                        break;
                    case "2":
                        UpdateStatusVehicle();
                        break;
                    case "3":
                        ListVehicle();
                        break;
                    case "4":
                        ListVehicleByStatus();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

          
        }
        private void ListVehicleByStatus()
        {

            Console.WriteLine("=== Select Vehicle Status to List ===");

            int i = 1;
            foreach (var status in Enum.GetValues(typeof(StatusVehicle)))
            {
                Console.WriteLine($"[{i}] {status}");
                i++;
            }

            StatusVehicle selectedStatus;

            while (true)
            {
                Console.Write("Enter the number of the status to filter by (0 to cancel): ");
                string input = Console.ReadLine();

                if (input == "0" || string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Operation cancelled.");
                    return;
                }

                if (int.TryParse(input, out int statusOption) &&
                    statusOption > 0 && statusOption <= Enum.GetValues(typeof(StatusVehicle)).Length)
                {
                    selectedStatus = (StatusVehicle)(statusOption - 1);
                    break;
                }

                Console.WriteLine("Invalid option.");
            }



            var vehicle = _vehicleService.GetAvailablesVehicles(selectedStatus);

            if (vehicle.Count() == 0)
            {
                Console.WriteLine("No available vehicles. ");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("\n ID | Brand | Model | Year | Segment | Type | Plate | QuantityPax | statusVehicle");
                Console.WriteLine(" " + new string('-', 90));

                foreach (var item in vehicle)
                {
                    Console.WriteLine($" {item.Id} | {item.Brand} | {item.Model} | {item.Year} | {item.Segment} | {item.Type} | {item.Plate} | {(item.QuantityPax)} | {item.statusVehicle}");
                }
            }

            Console.ReadKey();
        }
        private void ListVehicle()
        {
            var vehicle = _vehicleService.GetAllVehicles();

            if (vehicle.Count == 0)
            {
                Console.WriteLine("No vehicles found. ");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("\n ID | Brand | Model | Year | Segment | Type | Plate | QuantityPax | statusVehicle | Tax");
                Console.WriteLine(" " + new string('-', 80));

                foreach (var item in vehicle)
                {
                    Console.WriteLine($" {item.Id} | {item.Brand} | {item.Model} | {item.Year} | {item.Segment} | {item.Type} | {item.Plate} | {(item.QuantityPax)} | {item.statusVehicle} | S/ {item.Tax.ToString("N2")}");
                }
            }

            Console.ReadKey();
        }
        private void UpdateStatusVehicle()
        {
            var vehicle = _vehicleService.GetAllVehicles();

            if (vehicle == null)
            {
                Console.WriteLine("No Vehicles found. ");
                return;
            }


            Console.Write("=== Select Vehicle to Update === \n");
            for (int i = 0; i < vehicle.Count; i++)
            {
                var c = vehicle[i];
                Console.WriteLine($"[{i + 1}] {c.Brand} | {c.Model} | {c.statusVehicle}");
            }

            while (true)
            {
                Console.Write("Enter the number of the vehicle to update (0 to cancel): ");
                string entrada = Console.ReadLine();

                if (entrada == "0" || string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("Operation cancelled.");
                    return;
                }

                if (int.TryParse(entrada, out int opcion) &&
                    opcion > 0 && opcion <= vehicle.Count)
                {
                    var selectedVehicle = vehicle[opcion - 1];


                    Console.WriteLine($"You selected: {selectedVehicle.Brand} Model: {selectedVehicle.Model}");
                    Console.WriteLine("Select new Status");

                    int i = 1;
                    foreach (var status in Enum.GetValues(typeof(StatusVehicle)))
                    {
                        Console.WriteLine($"[{i}] {status}");
                        i++;
                    }

                    while (true)
                    {
                        Console.Write("Enter new status number (0 to cancel): ");
                        string statusEntrada = Console.ReadLine();

                        if (statusEntrada == "0" || string.IsNullOrWhiteSpace(statusEntrada))
                        {
                            Console.WriteLine("Operation cancelled.");
                            return;
                        }

                        if (int.TryParse(statusEntrada, out int statusOpcion) &&
                            statusOpcion > 0 && statusOpcion <= Enum.GetValues(typeof(StatusVehicle)).Length)
                        {
                            selectedVehicle.statusVehicle = (StatusVehicle)(statusOpcion - 1);
                            break;
                        }

                        Console.WriteLine("Invalid status option.");
                    }

                    // Guardar cambios
                    _vehicleService.UpdateStatusVehicle(selectedVehicle);

                    Console.WriteLine("vehicle updated successfully.");
                    return;
                }

                Console.WriteLine("Invalid option.");
            }
        }
        private void AddNewVehicle()
        {
            Console.Clear();
            Console.WriteLine("=== Create Vehicle ===");

            Console.WriteLine("Brand name: ");
            var brandName = Console.ReadLine();

            Console.WriteLine("Model name: ");
            var ModelName = Console.ReadLine();

            Console.WriteLine("Year: ");
            var year = Console.ReadLine();

            Console.WriteLine("Segment name: ");
            int i = 1;
            foreach (StatusSegment seg in Enum.GetValues(typeof(StatusSegment)))
            {
                Console.WriteLine($"[{i}] {seg}");
                i++;
            }

            StatusSegment selectedSegment;

            while (true)
            {
                Console.Write("Option: ");
                string entrada = Console.ReadLine();

                if (entrada == "0" || string.IsNullOrWhiteSpace(entrada))
                    return;

                if (int.TryParse(entrada, out int opcion) &&
                    opcion > 0 && opcion <= Enum.GetValues(typeof(StatusSegment)).Length)
                {
                    selectedSegment = (StatusSegment)(opcion - 1);
                    break;
                }

                Console.WriteLine(" Opción inválida.");
            }

            Console.WriteLine("Type Car: ");
            int t = 1;
            foreach (TypeCar type in Enum.GetValues(typeof(TypeCar)))
            {
                Console.WriteLine($"[{t}] {type}");
                t++;
            }
            TypeCar selectedCar;

            while (true)
            {
                Console.Write("Option: ");
                string entrada = Console.ReadLine();

                if (entrada == "0" || string.IsNullOrWhiteSpace(entrada))
                    return;

                if (int.TryParse(entrada, out int opcion) &&
                    opcion > 0 && opcion <= Enum.GetValues(typeof(TypeCar)).Length)
                {
                    selectedCar = (TypeCar)(opcion - 1);
                    break;
                }

                Console.WriteLine(" Opción inválida.");
            }

            

            Console.WriteLine("Status Vehicle: ");
            int s = 1;
            foreach (StatusVehicle status in Enum.GetValues(typeof(StatusVehicle)))
            {
                Console.WriteLine($"[{s}] {status}");
                s++;
            }

            StatusVehicle selectedStatus;

            while (true)
            {
                Console.Write("Option: ");
                string entrada = Console.ReadLine();

                if (entrada == "0" || string.IsNullOrWhiteSpace(entrada))
                    return;

                if (int.TryParse(entrada, out int opcion) &&
                    opcion > 0 && opcion <= Enum.GetValues(typeof(StatusVehicle)).Length)
                {
                    selectedStatus = (StatusVehicle)(opcion - 1);
                    break;
                }

                Console.WriteLine(" Opción inválida.");
            }


            Console.WriteLine("Plate: ");
            var plate = Console.ReadLine();

            Console.WriteLine("Quantity Pax: ");
            var quantity = Console.ReadLine();

            decimal price = ReadDecimal("Tax: ");




            var vehicle = new Vehicle()
            {
                Brand = brandName,
                Model = ModelName,
                Year = year,
                Segment = selectedSegment,
                Type = selectedCar,
                statusVehicle = selectedStatus,
                Plate = plate,
                QuantityPax = int.Parse(quantity),
                Tax = price
            };

            var confirmVehicle = _vehicleService.CreateVehicle(vehicle);
            Console.WriteLine("Vehicle Created Succesfully....!");
            Console.ReadKey();
        }
        #endregion
        #region Reservation
        private void CancelReservation()
        {
            var _reservations = _reservationService.GetReservationsByStatus();

            if (_reservations.Count == 0)
            {
                Console.WriteLine("No reservations found. ");
                Console.ReadKey();
                return;
            }

            Console.Write("=== Select Reservation  === \n");
            for (int i = 0; i < _reservations.Count; i++)
            {
                var r = _reservations[i];

                var customer = _customerService.GetCustomerById(r.CustomerId);
                var vehicle  = _vehicleService.GetByVehicleId(r.VehicleId);

                Console.WriteLine($"[{i + 1}] {r.Id} | {customer.FullName} | {vehicle.Model} | {r.ReservationDate.Date} | {r.statusReservation}");
            }

            // Select Customer
            Console.Write("\nSelect reservation (number): ");
            if (!int.TryParse(Console.ReadLine(), out int tableIndexCustomer) ||
                tableIndexCustomer < 1 || tableIndexCustomer > _reservations.Count)
            {
                Console.WriteLine("Invalid reservation selection.");
                return;
            }

            var selectedReservation = _reservations[tableIndexCustomer - 1];

            selectedReservation.statusReservation = StatusReservation.Canceled;

            _reservationService.UpdateReservation(selectedReservation);
            Console.WriteLine($"Reservation Id {selectedReservation.Id} Canceled");
            Console.ReadKey();

        }
        private void ListReservations()
        {
            var reservations = _reservationService.GetAllReservations();

            if (reservations.Count == 0)
            {
                Console.WriteLine("No reservations found. ");
                Console.ReadKey();
                return;
            }
            else
            {

                Console.WriteLine("\n ID | FullName | Model | Year | Segment | Type | Plate | DateReserved | DateReturn | status");
                Console.WriteLine(" " + new string('-', 80));

                foreach (var item in reservations)
                {
                    var customer = _customerService.GetCustomerById(item.CustomerId);
                    var vehicle = _vehicleService.GetByVehicleId(item.VehicleId);

                    Console.WriteLine($" {item.Id} | {customer.FullName} | {vehicle.Model} | {vehicle.Year} | {vehicle.Segment} | {vehicle.Type} | {vehicle.Plate} | {(item.ReturnDate.ToShortDateString())} | {item.ReturnDate.ToShortDateString()} | {item.statusReservation}");
                }

                Console.ReadKey();
            }
        }
        private void AddNewReservation()
        {
            Console.Clear();
            Console.WriteLine("=== Create Reservation ===");

            //Seleccionar Customer
            var customers = _customerService.GetCustomer();

            if (customers == null)
            {
                Console.WriteLine("No Customers found. ");
                return;
            }

            Console.Write("\n=== Select Customer  ===\n");
            for (int i = 0; i < customers.Count; i++)
            {
                var c = customers[i];
                Console.WriteLine($"[{i + 1}] {c.Id} | {c.FullName} | {c.IdentityDocument}");
            }

            // Select Customer
            Console.Write("\nSelect Customer (number): ");
            if (!int.TryParse(Console.ReadLine(), out int tableIndexCustomer) ||
                tableIndexCustomer < 1 || tableIndexCustomer > customers.Count)
            {
                Console.WriteLine("Invalid Customer selection.");
                return;
            }

            var selectedCustomer = customers[tableIndexCustomer - 1];

            //Seleccionar Vehicle
            var vehicle = _vehicleService.GetAvailablesVehicles(StatusVehicle.Available);

            if (vehicle == null)
            {
                Console.WriteLine("No Vehicles found. ");
                return;
            }

          
            Console.WriteLine("=== Select Vehicle ===");
            for (int i = 0; i < vehicle.Count; i++)
            {
                var v = vehicle[i];
                Console.WriteLine($"[{i + 1}] {v.Id} | {v.Brand} | {v.Model} | {v.Year} | {v.Segment} | {v.statusVehicle}");
            }

            // Select Vehicle
            Console.Write("\nSelect Vehicle (number): ");
            if (!int.TryParse(Console.ReadLine(), out int tableIndexVehicle) ||
                tableIndexVehicle < 1 || tableIndexVehicle > vehicle.Count)
            {
                Console.WriteLine("Invalid Vehicle selection.");
                return;
            }

            var selectedVehicle = vehicle[tableIndexVehicle - 1];

           

            // Get Reservation Date
            Console.Write("Reservation date (MM/DD/YYYY): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dateReservation))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            //Get Return Date
            Console.Write("Return date (MM/DD/YYYY): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dateReturn))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            decimal taxVehicle;

            if (dateReturn < dateReservation)
            {
                Console.WriteLine("Retur date must be higher from the Reservation Date");
                return;
            }
            else
            {
                TimeSpan diffDay = dateReturn - dateReservation;
                decimal numberday = diffDay.Days;
                taxVehicle = selectedVehicle.Tax * numberday;
            }

                

            var reservation = new Reservation()
            {
                CustomerId = selectedCustomer.Id,
                VehicleId = selectedVehicle.Id,
                ReservationDate = dateReservation,
                ReturnDate = dateReturn,
            };

            _reservationService.CreateReservation(reservation);

            //Update de Status of the Vehicle
            selectedVehicle.statusVehicle = StatusVehicle.Rented;
            _vehicleService.UpdateStatusVehicle(selectedVehicle);
            
            //Add History Reservation
            selectedCustomer.reservationsHistory.Add(reservation);
            _customerService.UpdateCustomer(selectedCustomer);

            Console.WriteLine("Reservation was created successful");
            Console.WriteLine($"Pax {selectedCustomer.FullName} has: {selectedCustomer.reservationsHistory.Count().ToString()} history reservations registed\n");

            Console.WriteLine("=== Add Payment ===\n");
            
            var idreservation = reservation.Id;
            Console.WriteLine($"Add IdReservation: {reservation.Id}");
            Console.WriteLine($"Date Payment: {reservation.ReservationDate.Date}");
            Console.WriteLine($"Add Amount: { taxVehicle.ToString("N2") }");
            Console.WriteLine("Add Method Pay Cash/TC");
            var methodPay = Console.ReadLine();

            var payment = new Payment()
            {
                IdReservation = reservation.Id,
                IdCustomer = selectedCustomer.Id,
                paymentDate = reservation.ReservationDate,
                Amount = taxVehicle,
                paymentMethod = methodPay,

            };

            _paymentService.CreatePayment(payment);
            Console.WriteLine($"Payment from the IdReservation {reservation.Id} was added");

            Console.ReadKey();
        }
        #endregion



        public void OptionsMenuPrincipal()
        {
            

            Console.WriteLine("\n=== Main Menu ===");
            Console.WriteLine("1. Create Reservation");
            Console.WriteLine("2. View Reservations");
            Console.WriteLine("3. Cancel Reservation");
            Console.WriteLine("4. Manage Customers");
            Console.WriteLine("5. Manage Vehicles");
            Console.WriteLine("6. View Payments");
            Console.WriteLine("0. Exit");
            Console.Write("Enter option: ");
        }

        private decimal ReadDecimal(string mensaje)
        {
            Console.Write(mensaje);
            string input = Console.ReadLine();
            if (decimal.TryParse(input, out decimal valor))
            {
                return (decimal)valor;
            }
            throw new FormatException("Must be enter a valid number.");
        }
    }
}
