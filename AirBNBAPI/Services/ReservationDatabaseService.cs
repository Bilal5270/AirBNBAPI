using AirBnb.Model;
using AirBNBAPI.Data;
using AirBNBAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirBNBAPI.Services
{
    public class ReservationDatabaseService : IReservationService
    {
        private readonly IAirBnBRepository _airBnBRepository;
        public ReservationDatabaseService(IAirBnBRepository airBnBRepository)
        {
            _airBnBRepository = airBnBRepository;
        }

        

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

        
    }
}
