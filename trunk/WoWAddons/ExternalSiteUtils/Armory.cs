using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;

namespace ExternalSiteUtils
{
    public class Armory
    {
        #region Private members
        Region serverRegion;
        String serverName;

        private readonly String serverUS = @"http://www.wowarmory.com/";
        private readonly String serverEU = @"http://eu.wowarmory.com/";
        private readonly String userInfo = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; fr; rv:1.8.1) Gecko/20061010 Firefox/2.0";
        #endregion

        public enum Region
        {
            US,
            EU
        }

        public Armory(Region localRegion, String server)
        {
            serverRegion = localRegion;
            serverName = server;
        }

        public List<String> GetGuildList(String guildName)
        {
            List<String> charList = new List<String>();

            if (String.IsNullOrEmpty(guildName) || String.IsNullOrEmpty(serverName))
                return charList;
            try
            {
                XmlDocument xDoc = GetArmoryPage("guild-info.xml", guildName);
                XmlNode root = xDoc.DocumentElement;
                XmlNodeList chars = root.SelectNodes(@"//character/@name");

                foreach (XmlNode xNode in chars)
                    charList.Add(xNode.Value);
                return charList;
            } catch (WebException)
            {
                throw new ArmoryException();
            }
        }

        public Int32 GetProfessions(String charName,
            out String profOneName, out Int32 profOneLevel, out String profTwoName, out Int32 profTwoLevel)
        {
            profOneName = String.Empty;
            profTwoName = String.Empty;
            profOneLevel = 0;
            profTwoLevel = 0;

            if (String.IsNullOrEmpty(charName) || String.IsNullOrEmpty(serverName))
                return 0;
            try
            {
                XmlDocument xDoc = GetArmoryPage("character-sheet.xml", charName);
                XmlNode root = xDoc.DocumentElement;
                XmlNode profs = root.SelectSingleNode(@"/page/characterInfo/characterTab/professions");
                if (profs == null)
                    return 0;
                if (!profs.HasChildNodes)
                    return 0;

                if (profs.ChildNodes.Count >= 1)
                {
                    profOneName = profs.ChildNodes[0].Attributes["name"].Value;
                    profOneLevel = Int32.Parse(profs.ChildNodes[0].Attributes["value"].Value);
                }
                if (profs.ChildNodes.Count == 2)
                {
                    profTwoName = profs.ChildNodes[1].Attributes["name"].Value;
                    profTwoLevel = Int32.Parse(profs.ChildNodes[1].Attributes["value"].Value);
                }

                return profs.ChildNodes.Count;
            } catch (WebException)
            {
                throw new ArmoryException();
            }
        }

        public CharacterEquipment GetEquipment(String charName)
        {
            if (String.IsNullOrEmpty(charName) || String.IsNullOrEmpty(serverName))
                return null;
            try
            {
                XmlDocument xDoc = GetArmoryPage("character-sheet.xml", charName);
                XmlNode root = xDoc.DocumentElement;
                XmlNode itemList = root.SelectSingleNode(@"/page/characterInfo/characterTab/items");

                if (itemList == null)
                    return null;
                CharacterEquipment charEquip = new CharacterEquipment();
                charEquip.Helm = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 0));
                charEquip.Neck = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 1));
                charEquip.Shoulders = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 2));
                charEquip.Chest = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 4));
                charEquip.Belt = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 5));
                charEquip.Pants = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 6));
                charEquip.Boots = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 7));
                charEquip.Bracer = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 8));
                charEquip.Gloves = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 9));
                charEquip.Ring1 = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 10));
                charEquip.Ring2 = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 11));
                charEquip.Trinket1 = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 12));
                charEquip.Trinket2 = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 13));
                charEquip.Back = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 14));
                charEquip.MainHand = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 15));
                if (charEquip.MainHand.IsTwoHandWeapon)
                {
                    charEquip.UsesTwoHand = true;
                    charEquip.OffHand = null;
                } else
                {
                    charEquip.UsesTwoHand = false;
                    charEquip.OffHand = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 16));
                }
                charEquip.Ranged = SearchCache.GetItemWithWowhead(ExtractItemID(itemList, 17));

                return charEquip;
            } catch (WebException)
            {
                throw new ArmoryException();
            }
        }

        private XmlDocument GetArmoryPage(String pageName, String optionName)
        {
            String uriString = String.Format("{0}/{1}?r={2}&n={3}&p=1", 
                (serverRegion == Region.US ? serverUS : serverEU), pageName, serverName, optionName);

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(uriString);
            myReq.UserAgent = userInfo;
            HttpWebResponse response = (HttpWebResponse)myReq.GetResponse();
            Stream responseStream = response.GetResponseStream();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(responseStream);
            responseStream.Close();
            return xDoc;
        }

        /// <summary>
        /// Get the ID attribute for an item in the itemlist
        /// </summary>
        /// <param name="itemListNode">parent "items" node</param>
        /// <param name="itemSlot">slot number</param>
        /// <returns>Item ID number; 0 if not found</returns>
        private Int32 ExtractItemID(XmlNode itemListNode, Int32 itemSlot)
        {
            try
            {
                XmlNode itemNode = itemListNode.SelectSingleNode("item[@slot='" + itemSlot.ToString() + "']");
                if (itemNode != null)
                    return Int32.Parse(itemNode.Attributes["id"].Value);
            } catch (Exception)
            {  }
            return 0;
        }
    }

    public class ArmoryException : WebException
    {
        public ArmoryException() : base("Armoy is having issues") { }
    }
}
