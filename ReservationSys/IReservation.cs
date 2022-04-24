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
    IGuest Guest { get; }
    ISite Site { get; }
    DateTime Arrival { get; }
    DateTime Departure { get; }
    ReservationStatus Status { get; }
    int NumGuests { get; }

    bool CheckIn();
    bool CheckOut();
    bool CancelReservation();
}

public class Reservation : IReservation
{
    public IGuest Guest { get; private set; }
    public ISite Site { get; private set; }
    public DateTime Arrival { get; private set; }
    public DateTime Departure { get; private set; }
    public ReservationStatus Status { get; private set; } = ReservationStatus.Confirmed;
    public int NumGuests {get; private set;}

    public Reservation(IGuest guest, ISite site, DateTime arrival, DateTime departure, int numGuests)
    {
        Guest = guest;
        Site = site;
        Arrival = arrival;
        Departure = departure;
        NumGuests = numGuests;
        SystemRunner.ReservationList.Add(this);
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