/*
Lucas Monjar
Object Oriented Programming
Final Project
Reservation System
Spring 2022
*/
namespace ReservationSystem;

public interface IInformationHandler
{
    IEnumerable<Guest> LoadGuests();
    void SaveGuests(IEnumerable<Guest> guestlist);
    IEnumerable<Reservation> LoadReservations();
    void SaveReservations(IEnumerable<Reservation> reservationlist);
    IEnumerable<Site> LoadSites();
    void SaveSites(IEnumerable<Site> sitelist);
    IEnumerable<User> LoadUsers();
    void SaveUsers(IEnumerable<User> userlist);
}


public class JsonSerializedStorage : IInformationHandler
{
    public IEnumerable<Guest> LoadGuests()
    {
        List<Guest> guestList = new();
        if(File.Exists("guestList.json"))
        {
            var json = File.ReadAllText("guestList.json");
            guestList = System.Text.Json.JsonSerializer.Deserialize<List<Guest>>(json);
        }
        return guestList;
    }

    public void SaveGuests(IEnumerable<Guest> guestlist)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(guestlist);
        File.WriteAllText("guestList.json", json);
    }

    public IEnumerable<Reservation> LoadReservations()
    {
        List<Reservation> reservationList = new();
        if(File.Exists("reservationList.json"))
        {
            var json = File.ReadAllText("reservationList.json");
            reservationList = System.Text.Json.JsonSerializer.Deserialize<List<Reservation>>(json);
        }
        return reservationList;
    }

    public void SaveReservations(IEnumerable<Reservation> reservationlist)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(reservationlist);
        File.WriteAllText("reservationList.json", json);
    }

    public IEnumerable<Site> LoadSites()
    {
        List<Site> siteList = new();
        if(File.Exists("siteList.json"))
        {
            var json = File.ReadAllText("siteList.json");
            siteList = System.Text.Json.JsonSerializer.Deserialize<List<Site>>(json);
        }
        return siteList;
    }

    public void SaveSites(IEnumerable<Site> sitelist)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(sitelist);
        File.WriteAllText("siteList.json", json);
    }

    public IEnumerable<User> LoadUsers()
    {
        List<User> userList = new();
        if(File.Exists("userList.json"))
        {
            var json = File.ReadAllText("userList.json");
            userList = System.Text.Json.JsonSerializer.Deserialize<List<User>>(json);
        }
        return userList;
    }

    public void SaveUsers(IEnumerable<User> userlist)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(userlist);
        File.WriteAllText("userList.json", json);
    }
}