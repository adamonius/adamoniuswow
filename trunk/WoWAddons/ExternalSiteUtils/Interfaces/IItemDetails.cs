using System;
namespace ExternalSiteUtils
{
    public interface IItemDetails
    {
        Int32 ILvl { get; }
        Int32 ItemID { get; }
        String Name { get; }
        ItemQuality Quality { get; }
        Boolean IsTwoHandWeapon { get; }
        String Tooltip { get; }
    }
}
