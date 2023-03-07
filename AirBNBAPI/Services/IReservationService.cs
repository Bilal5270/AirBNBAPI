using AirBnb.Model;

namespace AirBNBAPI.Services
{
    public interface IReservationService
    {
        public IEnumerable<Reservation> GetAllReservations();
        public Reservation GetSpecificReservation(int id);

        public Reservation ChangeReservation(int id, Reservation reservation);
    }
}
