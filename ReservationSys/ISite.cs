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
    int MaxGuests { get; }
    int HighestAmp { get; }
    bool HasPotableWater { get; }
    bool HasBrownWater { get; }
}

public abstract class RVSite : ISite
{
    public int SiteNumber { get; private set; }
    public int MaxGuests { get; } = 8;
    public int HighestAmp { get; }
    public int Length { get; private set; }
    public bool HasPotableWater { get; } = true;
    public bool HasBrownWater { get; private set; }
    public bool HasCementPad { get; private set; }
    public SiteTypes SiteType { get; }

    public RVSite(int siteNumber, SiteTypes siteType, int length, int highestAmp, bool HasCementPad, bool hasBrownWater)
    {
        SiteNumber = siteNumber;
        SiteType = siteType;
        HighestAmp = highestAmp;
        Length = length;
        HasBrownWater = HasBrownWater;
        SystemRunner.SiteList.Add(this);
    }
}

public abstract class FullHookUpSite : RVSite
{
    public FullHookUpSite(int siteNumber, SiteTypes siteType, int length, int highestAmp, bool hasCementPad)
    : base(siteNumber, siteType, length, highestAmp, hasCementPad, true) { }
}

public class TentSite : ISite
{
    public int SiteNumber { get; private set; }
    public int MaxGuests { get; } = 8;
    public int HighestAmp { get; } = 20;
    public bool HasPotableWater { get; } = true;
    public bool HasBrownWater { get; } = false;
    public SiteTypes SiteType { get; } = SiteTypes.Tent;

    public TentSite(int siteNumber)
    {
        SiteNumber = siteNumber;
        SystemRunner.SiteList.Add(this);

    }
}

public class WaterElectric30 : RVSite
{
    public WaterElectric30(int siteNumber, int length)
    : base(siteNumber, SiteTypes.WaterElectric30, length, 30, false, false) { }
}

public class WaterElectric50 : RVSite
{
    public WaterElectric50(int siteNumber, int length)
    : base(siteNumber, SiteTypes.WaterElectric50, length, 50, false, false) { }
}

public class FullHookUp30 : FullHookUpSite
{
    public FullHookUp30(int siteNumber, int length)
    : base(siteNumber, SiteTypes.FullHookUp30, length, 30, false) { }
}

public class FullHookUp50 : FullHookUpSite
{
    public FullHookUp50(int siteNumber, int length)
    : base(siteNumber, SiteTypes.FullHookUp50, length, 50, false) { }
}

public class FullHookUpCement : FullHookUpSite
{
    public FullHookUpCement(int siteNumber, int length)
    : base(siteNumber, SiteTypes.FullHookUpCement, length, 50, true) { }
}

public class PullThrough : FullHookUpSite
{
    public PullThrough(int siteNumber, int length)
    : base(siteNumber, SiteTypes.PullThrough, length, 50, true) { }
}

public class GroupSite : ISite
{
    public int SiteNumber { get; private set; }
    public int MaxGuests { get; private set; } = 60;
    public int HighestAmp { get; } = 30;
    public bool HasPotableWater { get; } = true;
    public bool HasBrownWater { get; } = false;

    public SiteTypes SiteType { get; } = SiteTypes.GroupSite;

    public GroupSite(int siteNumber)
    {
        SiteNumber = siteNumber;
        SystemRunner.SiteList.Add(this);
    }
}