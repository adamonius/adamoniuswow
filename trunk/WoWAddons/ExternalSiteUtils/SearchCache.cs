using System;
using System.Collections.Generic;
using System.Text;

namespace ExternalSiteUtils
{
    public class SearchCache
    {
        public static IItemDetails GetItemWithWowhead(Int32 itemID)
        {
            if (itemID == 0)
                return null;

            DataStorage cacheStore = new DataStorage();
            IItemDetails itemDetails = cacheStore.LookupItemCache(itemID);
            if (itemDetails == null)
            {
                itemDetails = new WowheadDetails(itemID);
                cacheStore.StoreItemCache(itemDetails);
            }
            return itemDetails;
        }
    }
}
