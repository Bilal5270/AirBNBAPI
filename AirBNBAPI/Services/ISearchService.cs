﻿using AirBnb.Model;

namespace AirBNBAPI.Services
{
    public interface ISearchService
    {
        public IEnumerable<Location> GetAllLocations();
        public Location GetSpecificLocation(int id);

        public Location ChangeLocation(int id, Location location);
        public IEnumerable<Reservation> GetAllReservations();
        public Reservation GetSpecificReservation(int id);

        public Reservation ChangeReservation(int id, Reservation reservation);

        public IEnumerable<Landlord> GetAllLandlords();
        public Landlord GetSpecificLandlord(int id);

        public Landlord ChangeLandlord(int id, Landlord landlord);
        public IEnumerable<Customer> GetAllCustomers();
        public Customer GetSpecificCustomer(int id);

        public Customer ChangeCustomer(int id, Customer customer);
    }
}