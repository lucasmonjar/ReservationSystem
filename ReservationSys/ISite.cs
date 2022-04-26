/*
Lucas Monjar
Object Oriented Programming
Final Project
Reservation System
Spring 2022
*/
namespace ReservationSystem;

public enum SiteTypes
{
    Tent,
    WaterElectric30,
    WaterElectric50,
    FullHookUp30,
    FullHookUp50,
    FullHookUpCement,
    PullThrough,
    GroupSite
}

public interface ISite
{
    int SiteNumber { get; }
    SiteTypes SiteType { get; }
    int HighestAmp { get; }
    bool HasPotableWater { get; }
    bool HasBrownWater { get; }
}

public class Site : ISite
{
    public int SiteNumber { get; private set; }
    public SiteTypes SiteType {get;}
    public int HighestAmp { get; }
    public int Length { get; private set; }
    public bool HasPotableWater { get; } = true;
    public bool HasBrownWater { get; private set; }
    public bool HasCementPad { get; private set; }

    public Site(int siteNumber, SiteTypes siteType, int length, int highestAmp, bool HasCementPad, bool hasBrownWater)
    {
        SiteNumber = siteNumber;
        SiteType = siteType;
        HighestAmp = highestAmp;
        Length = length;
        HasBrownWater = HasBrownWater;
    }
}