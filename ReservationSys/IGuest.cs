/*
Lucas Monjar
Object Oriented Programming
Final Project
Reservation System
Spring 2022
*/
namespace ReservationSystem;

public enum GuestType
{
    Standard,
    Premium,
    Gold
}
public interface IGuest
{
    string FirstName { get; }
    string LastName { get; }
    GuestType Membership { get; }
    int NumberOfVisits { get; }
    int GuestNumber { get; }
    uint PhoneNumber {get;}
    string Address {get;}
    void guestCheckIn();
}

public class Guest : IGuest
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public GuestType Membership { get; private set; } = GuestType.Standard;
    public int NumberOfVisits { get; private set; } = 0;
    public int GuestNumber {get;}

    public uint PhoneNumber {get; private set;}
    public string Email {get; private set;}

    public string Address {get; private set;}

    public Guest(string firstName, string lastName, uint phoneNumber, string email, string address)
    {
        FirstName = firstName;
        LastName = lastName;
        GuestNumber = SystemRunner.NumGuests;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
    }

    public void guestCheckIn()
    {
        this.NumberOfVisits ++;
        if (NumberOfVisits >= 10)
        {
            Membership = GuestType.Premium;
        }
        else if (NumberOfVisits >= 25)
        {
            Membership = GuestType.Gold;
        }
    }
}
