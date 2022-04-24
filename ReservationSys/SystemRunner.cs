/*
Lucas Monjar
Object Oriented Programming
Final Project
Reservation System
Spring 2022
*/
namespace ReservationSystem;

public struct User
{
    public string username;
    public string password;
};

public static class SystemRunner
{
    public static int NumGuests = 0;
    public static List<IGuest> GuestList = new List<IGuest>();
    public static List<ISite> SiteList = new List<ISite>();
    public static List<IReservation> ReservationList = new List<IReservation>();
    public static List<User> UserList = new List<User>();
    public static bool LoggedIn = false;

    public static void LogIn(string selectedUser, string enteredPass)
    {
        int index = 0;
        for (int i = 0; i < UserList.Count; i++)
        {
            if (selectedUser == UserList[i].username)
            {
                index = i;
                break;
            }
        }
        if (enteredPass == UserList[index].password)
        {
            LoggedIn = true;
        }
    }

    public static void MakeAdmin(string username, string password)
    {
        User newAdmin;
        newAdmin.username = username;
        newAdmin.password = password;
        UserList.Add(newAdmin);
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
            SystemRunner.NumGuests++;
            Guest newGuest = new Guest(firstName, lastName, phoneNumber, email, address);
            SystemRunner.GuestList.Add(newGuest);
        }
        string[] result = new string[3];
        result[0] = nameError;
        result[1] = phoneError;
        result[2] = emailError;
        return result;
    }

    public static string[] MakeReservation(int guestNumber, int siteNumber, DateTime arrival, DateTime departure, int numGuests)
    {
        string[] result = new string[3];
        string guestError = "Please select a valid guest. You can find them on the Guest Management page.";
        string siteError = "Please select a valid site number. You can find them on the Site Management page.";
        string numGuestsError = "";
        ISite newResSite = new TentSite(0);
        IGuest newResGuest = GuestList[0];

        for (int i = 0; i < NumGuests; i++)
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
        if (numGuests > newResSite.MaxGuests)
        {
            numGuestsError = $"Sorry you are only permitted {newResSite.MaxGuests} guests on your site.";
        }

        if ((guestError == "") && (siteError == "") && (numGuestsError == ""))
        {
            Reservation newRes = new Reservation(newResGuest, newResSite, arrival, departure, numGuests);
            ReservationList.Add(newRes);
        }
        result[0] = guestError;
        result[1] = siteError;
        result[2] = numGuestsError;
        return result;
    }

    public static void MakeNewTent()
    {
        ISite newSite = new TentSite(SiteList.Count);
        SiteList.Add(newSite);
    }
    public static void MakeNewWE30()
    {
        ISite newSite = new WaterElectric30(SiteList.Count, 50);
        SiteList.Add(newSite);
    }
    public static void MakeNewWE50()
    {
        ISite newSite = new WaterElectric50(SiteList.Count, 50);
        SiteList.Add(newSite);
    }
    public static void MakeNewFHU30()
    {
        ISite newSite = new FullHookUp30(SiteList.Count, 55);
        SiteList.Add(newSite);
    }
    public static void MakeNewFHU50()
    {
        ISite newSite = new FullHookUp50(SiteList.Count, 55);
        SiteList.Add(newSite);
    }
    public static void MakeNewFHUC()
    {
        ISite newSite = new FullHookUpCement(SiteList.Count, 60);
        SiteList.Add(newSite);
    }
    public static void MakeNewPT()
    {
        ISite newSite = new PullThrough(SiteList.Count, 70);
        SiteList.Add(newSite);
    }
    public static void MakeNewGS()
    {
        ISite newSite = new GroupSite(SiteList.Count);
        SiteList.Add(newSite);
    }
}