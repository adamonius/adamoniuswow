using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExternalSiteUtils;

namespace TestExternalSiteUtils
{
    /// <summary>
    /// Summary description for WowheadItemProps
    /// </summary>
    [TestClass]
    public class WowheadItemProps
    {
        public WowheadItemProps()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AllItemProperties()
        {
            Int32 itemNum = 40543; // Blue Aspect Helm

            IItemDetails target = SearchCache.GetItemWithWowhead(itemNum);

            Assert.AreEqual("Blue Aspect Helm", target.Name, "ExternalSiteUtils.WowheadDetails.Name was not set correctly.");
            Assert.AreEqual(226, target.ILvl, "ExternalSiteUtils.WowheadDetails.Name was not set correctly.");
            Assert.AreEqual(40543, target.ItemID, "ExternalSiteUtils.WowheadDetails.Name was not set correctly.");
            Assert.AreEqual(ItemQuality.Epic, target.Quality, "ExternalSiteUtils.WowheadDetails.Quality was not set correctly");
        }

        [TestMethod]
        public void CharacterItemList()
        {
            Armory usArm = new Armory(Armory.Region.US, "Greymane");
            CharacterEquipment myEqup = usArm.GetEquipment("Ashean");
        }
    }
}
