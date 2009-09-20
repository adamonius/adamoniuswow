using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace ExternalSiteUtils
{
    internal class WowheadDetails : IItemDetails
    {
        #region Private values
        private Int32 itemID;
        private Int32 iLvl;
        private String name;
        private ItemQuality qual;
        private Boolean isTwoHandWeapon;
        private String tooltip;
        #endregion
       
        #region Public values

        public Int32 ItemID
        {
            get { return itemID; }
        }
        public Int32 ILvl
        {
            get { return iLvl; }
        }
        public String Name
        {
            get { return name; }
        }
        public ItemQuality Quality
        {
            get { return qual; }
        }
        public Boolean IsTwoHandWeapon
        {
            get { return isTwoHandWeapon; }
        }
        public String Tooltip
        {
            get { return tooltip; }
        }
        #endregion

        public WowheadDetails(String itemName)
        {
            //replace spaces / search?
        }

        public WowheadDetails(Int32 itemNum)
        {
            XmlDocument itemRoot = GetItem(itemNum);
            if (itemRoot == null)
                return;

            itemID = itemNum;
            XmlNode root = itemRoot.DocumentElement.SelectSingleNode(@"/wowhead/item");

            XmlNode xName = root.SelectSingleNode("name").FirstChild;
            if (xName is XmlCDataSection)
            {
                XmlCDataSection cdataSection = xName as XmlCDataSection;
                name = cdataSection.Value;
            }

            iLvl = Int32.Parse(root.SelectSingleNode("level").InnerText);
            qual = (ItemQuality)Enum.Parse(typeof(ItemQuality), root.SelectSingleNode("quality").InnerText);
            if (root.SelectSingleNode("inventorySlot").InnerText.Equals("Two-Hand"))
                isTwoHandWeapon = true;

            XmlNode xTip = root.SelectSingleNode("htmlTooltip").FirstChild;
            if (xTip is XmlCDataSection)
            {
                XmlCDataSection cdataSection = xTip as XmlCDataSection;
                tooltip = FormatHtmlTooltip(cdataSection.Value);
            }
}

        private XmlDocument GetItem(Int32 itemID)
        {
            try
            {
                String uriString = String.Format("http://www.wowhead.com/?item={0}&xml", itemID.ToString());
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(uriString);
                myReq.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; fr; rv:1.8.1) Gecko/20061010 Firefox/2.0"; ;
                HttpWebResponse response = (HttpWebResponse)myReq.GetResponse();
                Stream responseStream = response.GetResponseStream();

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(responseStream);

                XmlNode root = xDoc.DocumentElement;
                if (root.SelectSingleNode(@"//error") == null) //no error
                    return xDoc;
            } catch (Exception)
            {
            }

            return null;
        }

        private String FormatHtmlTooltip(String htmlTooltip)
        {
            //Put rating conversions on same line; replace space chars
            String formattedTooltip = Regex.Replace(htmlTooltip, @"&nbsp;<small>\(<!.*?>+", " (").Replace("&nbsp;", " ");
            //Replace HTML tags with newlines
            formattedTooltip = Regex.Replace(formattedTooltip, "(<.*?>)+", Environment.NewLine);
            //Remove empty lines or lines with only a period
            formattedTooltip = formattedTooltip.Replace(Environment.NewLine + ".", "").Trim();

            return formattedTooltip;
        }
    }
}
