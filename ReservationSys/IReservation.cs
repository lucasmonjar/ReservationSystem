/*
Lucas Monjar
Object Oriented Programming
Final Project
Reservation System
Spring 2022
*/
namespace ReservationSystem;

public enum ReservationStatus
{
    Confirmed,
    Arrived,
    Departed,
    Cancelled
}
public interface IReservation
{
    Guest Guest { get; }
    Site Site { get; }
    DateTime Arrival { get; }
    DateTime Departure { get; }
    ReservationStatus Status { get; }

    bool CheckIn();
    bool CheckOut();
    bool CancelReservation();
}

public class Reservation : IReservation
{
    public Guest Guest { get; private set; }
    public Site Site { get; private set; }
    public DateTime Arrival { get; private set; }
    public DateTime Departure { get; private set; }
    public ReservationStatus Status { get; private set; } = ReservationStatus.Confirmed;
    public Reservation(Guest guest, Site site, DateTime arrival, DateTime departure)
    {
        Guest = guest;
        Site = site;
        Arrival = arrival;
        Departure = departure;
    }

    public bool CheckIn()
    {
        var currentTime = DateTime.Now;
        if (currentTime > Arrival)
        {
            Status = ReservationStatus.Arrived;
            return true;
        }
        return false;
    }

    public bool CheckOut()
    {
        Status = ReservationStatus.Departed;
        return true;
    }

    public bool CancelReservation()
    {
        Status = ReservationStatus.Cancelled;
        return true;
    }
}