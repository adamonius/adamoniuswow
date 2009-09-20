using System;
using System.Collections.Generic;
using System.Text;

namespace ExternalSiteUtils
{
    internal class CacheItemDetails : IItemDetails
    {
        private Int32 itemID;
        private Int32 iLvl;
        private String name;
        private ItemQuality qual;
        private Boolean isTwoHandWeapon;
        private String tooltip;
    

        public int ILvl
        {
            get { return iLvl; }
            set { iLvl = value; }
        }

        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public ItemQuality Quality
        {
            get { return qual; }
            set { qual = value; }
        }

        public bool IsTwoHandWeapon
        {
            get { return isTwoHandWeapon; }
            set { isTwoHandWeapon = value; }
        }
        public String Tooltip
        {
            get { return tooltip; }
            set { tooltip = value; }
        }

    }
}
