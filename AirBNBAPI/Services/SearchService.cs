﻿using AirBnb.Model;
using AirBNBAPI.Repositories;

namespace AirBNBAPI.Services
{
    public class SearchService
    {
        private readonly IAirBnBRepository _airBnBRepository;
        public SearchService (IAirBnBRepository airBnBRepository)
        {
            _airBnBRepository = airBnBRepository;
        }
        //LOCATIONS
        public Location ChangeLocation(int id, Location location)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _airBnBRepository.GetAllLocations();

        }

        public Location GetSpecificLocation(int id)
        {
            return _airBnBRepository.GetLocation(id);
        }
        //RESERVATIONS


        public Reservation ChangeReservation(int id, Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _airBnBRepository.GetAllReservations();

        }

        public Reservation GetSpecificReservation(int id)
        {
            return _airBnBRepository.GetReservation(id);
        }

        //CUSTOMERS
        public Customer ChangeCustomer(int id, Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _airBnBRepository.GetAllCustomers();

        }

        public Customer GetSpecificCustomer(int id)
        {
            return _airBnBRepository.GetCustomer(id);
        }

        //LANDLORDS
        public Landlord ChangeLandlord(int id, Landlord landlord)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Landlord> GetAllLandlords()
        {
            return _airBnBRepository.GetAllLandlords();

        }

        public Landlord GetSpecificLandlord(int id)
        {
            return _airBnBRepository.GetLandlord(id);
        }
    }
}