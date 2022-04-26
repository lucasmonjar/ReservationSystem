/*
Lucas Monjar
Object Oriented Programming
Final Project
Reservation System
Spring 2022
*/
namespace ReservationSystem;

public class User
{
    public string Username { get; }
    public string Password { get; }
    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
};

public static class SystemRunner
{
    public static List<Guest> GuestList = new List<Guest>();
    public static List<Site> SiteList = new List<Site>();
    public static List<Reservation> ReservationList = new List<Reservation>();
    public static List<User> UserList = new List<User>();
    public static bool LoggedIn = false;

    public static void LogIn(string selectedUser, string enteredPass)
    {
        int index = 0;
        for (int i = 0; i < UserList.Count; i++)
        {
            if (selectedUser == UserList[i].Username)
            {
                index = i;
                break;
            }
        }
        if (enteredPass == UserList[index].Password)
        {
            LoggedIn = true;
        }
    }

    public static void MakeUser(string username, string password)
    {
        User newAdmin = new User(username, password);
        UserList.Add(newAdmin);
    }
    public static void RemoveUser(User user)
    {
        UserList.Remove(user);
    }

    public static string[] MakeGuest(string firstName, string lastName, uint phoneNumber, string email, string address)
    {
        string nameError = "";
        string phoneError = "";
        string emailError = "";
        firstName = firstName.Trim();
        lastName = lastName.Trim();
        string wholeName = firstName + lastName;
        email = email.Trim();
        address = address.Trim();
        for (int i = 0; i < wholeName.Length; i++)
        {
            if (wholeName[i] > 'z' || wholeName[i] < 'A')
            {
                nameError = "Please enter only letters.";
                break;
            }
            else
            {
                nameError = "";
            }
        }
        if (firstName == "" || lastName == "")
        {
            nameError = "Please enter both names before submitting.";
        }
        else if (nameError != "Please enter only letters.")
        {
            nameError = "";
        }


        if (phoneNumber.ToString().Length != 10)
        {
            phoneError = "Please enter a valid phone number.";
        }
        else
        {
            phoneError = "";
        }

        if (!(email.Contains('@')) || !(email.Contains('.')))
        {
            emailError = "Please enter a valid email.";
        }
        else
        {
            emailError = "";
        }

        if ((nameError == "") && (phoneError == "") && (emailError == ""))
        {
            Guest newGuest = new Guest(firstName, lastName, phoneNumber, email, address);
            SystemRunner.GuestList.Add(newGuest);
        }
        string[] result = new string[3];
        result[0] = nameError;
        result[1] = phoneError;
        result[2] = emailError;
        return result;
    }

    public static string[] MakeReservation(int guestNumber, int siteNumber, DateTime arrival, DateTime departure)
    {
        string[] result = new string[2];
        string guestError = "Please select a valid guest. You can find them on the Guest Management page.";
        string siteError = "Please select a valid site number. You can find them on the Site Management page.";
        Site newResSite = new Site(0, SiteTypes.Tent, 0, 20, false, false);
        Guest newResGuest = GuestList[0];

        for (int i = 0; i < GuestList.Count(); i++)
        {
            if (guestNumber == GuestList[i].GuestNumber)
            {
                guestError = "";
                newResGuest = GuestList[i];
                break;
            }
        }
        for (int i = 0; i < SiteList.Count; i++)
        {
            if (siteNumber == SiteList[i].SiteNumber)
            {
                siteError = "";
                newResSite = SiteList[i];
                break;
            }
        }

        if ((guestError == "") && (siteError == ""))
        {
            Reservation newRes = new Reservation(newResGuest, newResSite, arrival, departure);
            ReservationList.Add(newRes);
        }
        result[0] = guestError;
        result[1] = siteError;
        return result;
    }

    public static bool MakeNewTent(int siteNumber)
    {
        if (ValidSiteNumber(siteNumber))
        {
            Site newSite = new Site(SiteList.Count, SiteTypes.Tent, 0, 20, false, false);
            SiteList.Add(newSite);
            return true;
        }
        return false;
    }
    public static bool MakeNewWE30(int siteNumber)
    {
        if (ValidSiteNumber(siteNumber))
        {
            Site newSite = new Site(SiteList.Count, SiteTypes.WaterElectric30, 50, 30, false, false);
            SiteList.Add(newSite);
            return true;
        }
        return false;
    }
    public static bool MakeNewWE50(int siteNumber)
    {
        if (ValidSiteNumber(siteNumber))
        {
            Site newSite = new Site(SiteList.Count, SiteTypes.WaterElectric50, 50, 50, false, false);
            SiteList.Add(newSite);
            return true;
        }
        return false;
    }
    public static bool MakeNewFHU30(int siteNumber)
    {
        if (ValidSiteNumber(siteNumber))
        {
            Site newSite = new Site(SiteList.Count, SiteTypes.FullHookUp30, 55, 30, false, true);
            SiteList.Add(newSite);
            return true;
        }
        return false;
    }
    public static bool MakeNewFHU50(int siteNumber)
    {
        if (ValidSiteNumber(siteNumber))
        {
            Site newSite = new Site(SiteList.Count, SiteTypes.FullHookUp50, 55, 50, false, true);
            SiteList.Add(newSite);
            return true;
        }
        return false;
    }
    public static bool MakeNewFHUC(int siteNumber)
    {
        if (ValidSiteNumber(siteNumber))
        {
            Site newSite = new Site(SiteList.Count, SiteTypes.FullHookUpCement, 60, 50, true, true);
            SiteList.Add(newSite);
            return true;
        }
        return false;
    }
    public static bool MakeNewPT(int siteNumber)
    {
        if (ValidSiteNumber(siteNumber))
        {
            Site newSite = new Site(SiteList.Count, SiteTypes.PullThrough, 70, 50, true, true);
            SiteList.Add(newSite);
            return true;
        }
        return false;
    }
    public static bool MakeNewGS(int siteNumber)
    {
        if (ValidSiteNumber(siteNumber))
        {
            Site newSite = new Site(SiteList.Count, SiteTypes.GroupSite, 0, 30, false, false);
            SiteList.Add(newSite);
            return true;
        }
        return false;
    }

    public static bool ValidSiteNumber(int siteNumber)
    {
        for (int i = 0; i < SiteList.Count(); i++)
        {
            if (siteNumber == SiteList[i].SiteNumber)
            {
                return false;
            }
        }
        if (siteNumber < 0)
        {
            return false;
        }
        return true;
    }

    public static void SaveAllInfo()
    {
        JsonSerializedStorage StorageManager = new();
        StorageManager.SaveGuests(GuestList);
        StorageManager.SaveReservations(ReservationList);
        StorageManager.SaveSites(SiteList);
        StorageManager.SaveUsers(UserList);
    }

    public static void LoadAllInfo()
    {
        JsonSerializedStorage StorageManager = new();
        GuestList = StorageManager.LoadGuests().ToList();
        ReservationList = StorageManager.LoadReservations().ToList();
        SiteList = StorageManager.LoadSites().ToList();
        UserList = StorageManager.LoadUsers().ToList();
    }

    public static void CheckInRes(Reservation reservation)
    {
        reservation.CheckIn();
    }
    public static void CheckOutRes(Reservation reservation)
    {
        reservation.CheckOut();
    }
    public static void CancelRes(Reservation reservation)
    {
        reservation.CancelReservation();
    }
    public static void ClearDepartedRes()
    {
        List<Reservation> clearList = new();
        foreach (var reservation in ReservationList)
        {
            if (reservation.Status == ReservationStatus.Cancelled || reservation.Status == ReservationStatus.Departed)
            {
                clearList.Add(reservation);
            }
        }
        foreach (var reservation in clearList)
        {
            ReservationList.Remove(reservation);
        }
    }
}
