using System;
using System.Collections.Generic;
using System.Text;

namespace ExternalSiteUtils
{
    public class CharacterEquipment
    {
        #region Private members
        private IItemDetails helm;
        private IItemDetails neck;
        private IItemDetails shoulders;
        private IItemDetails chest;
        private IItemDetails belt;
        private IItemDetails pants;
        private IItemDetails boots;
        private IItemDetails bracer;
        private IItemDetails gloves;
        private IItemDetails ring1;
        private IItemDetails ring2;
        private IItemDetails trinket1;
        private IItemDetails trinket2;
        private IItemDetails back;
        private IItemDetails mainHand;
        private IItemDetails offHand;
        private IItemDetails ranged;
        private Boolean usesTwoHand;
        #endregion

        #region Properties
        public IItemDetails Helm
        {
            get { return helm; }
            set { helm = value; }
        }

        public IItemDetails Neck
        {
            get { return neck; }
            set { neck = value; }
        }

        public IItemDetails Shoulders
        {
            get { return shoulders; }
            set { shoulders = value; }
        }

        public IItemDetails Chest
        {
            get { return chest; }
            set { chest = value; }
        }

        public IItemDetails Belt
        {
            get { return belt; }
            set { belt = value; }
        }

        public IItemDetails Pants
        {
            get { return pants; }
            set { pants = value; }
        }

        public IItemDetails Boots
        {
            get { return boots; }
            set { boots = value; }
        }

        public IItemDetails Bracer
        {
            get { return bracer; }
            set { bracer = value; }
        }

        public IItemDetails Gloves
        {
            get { return gloves; }
            set { gloves = value; }
        }

        public IItemDetails Ring1
        {
            get { return ring1; }
            set { ring1 = value; }
        }

        public IItemDetails Ring2
        {
            get { return ring2; }
            set { ring2 = value; }
        }

        public IItemDetails Trinket1
        {
            get { return trinket1; }
            set { trinket1 = value; }
        }

        public IItemDetails Trinket2
        {
            get { return trinket2; }
            set { trinket2 = value; }
        }

        public IItemDetails Back
        {
            get { return back; }
            set { back = value; }
        }

        public IItemDetails MainHand
        {
            get { return mainHand; }
            set { mainHand = value; }
        }

        public IItemDetails OffHand
        {
            get { return offHand; }
            set { offHand = value; }
        }

        public IItemDetails Ranged
        {
            get { return ranged; }
            set { ranged = value; }
        }

        public Boolean UsesTwoHand
        {
            get { return usesTwoHand; }
            set { usesTwoHand = value; }
        }
        #endregion
    }
}
