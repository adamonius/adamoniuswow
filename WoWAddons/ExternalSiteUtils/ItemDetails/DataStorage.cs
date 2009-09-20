using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace ExternalSiteUtils
{
    internal class DataStorage
    {
        private readonly String dbConnString = @"Data Source=LocalCache.s3db";
        private Type onlineLookup = typeof(WowheadDetails);

        public DataStorage()
        {
            SetupDatabase();
        }

        private Boolean SetupDatabase()
        {
            try
            {
                SQLiteConnection cnn = new SQLiteConnection(dbConnString);
                cnn.Open();
                SQLiteCommand createCommand = new SQLiteCommand(cnn);
                createCommand.CommandText = @"CREATE TABLE IF NOT EXISTS Items (
                    itemID int PRIMARY KEY NOT NULL,
                    itemLevel int NOT NULL,
                    name varchar(100) NOT NULL,
                    quality varchar(20) NOT NULL,
                    is2H bit NOT NULL,
                    tooltip varchar(1500) NOT NULL
                    );
                    ";
                Int32 x = createCommand.ExecuteNonQuery();
                cnn.Close();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public IItemDetails LookupItemCache(Int32 itemID)
        {
            CacheItemDetails itemDetails = null;
            try
            {
                SQLiteConnection conn = new SQLiteConnection(dbConnString);
                conn.Open();
                
                SQLiteCommand itemCommand = new SQLiteCommand(conn);
                itemCommand.CommandText = "SELECT * FROM Items WHERE itemID = @itemID";

                SQLiteParameter itemIDParam = new SQLiteParameter("@itemID");
                itemCommand.Parameters.Add(itemIDParam);
                itemIDParam.Value = itemID;

                DataTable dt = new DataTable();
                SQLiteDataReader reader = itemCommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conn.Close();

                if (dt.Rows.Count == 0)
                    return null;

                DataRow itemEntry = dt.Rows[0];
                itemDetails = new CacheItemDetails();
                itemDetails.ILvl = Int32.Parse(itemEntry["itemLevel"].ToString());
                itemDetails.ItemID = Int32.Parse(itemEntry["itemID"].ToString());
                itemDetails.Name = itemEntry["name"].ToString();
                itemDetails.Quality = (ItemQuality)Enum.Parse(typeof(ItemQuality), itemEntry["quality"].ToString());
                itemDetails.IsTwoHandWeapon = Boolean.Parse(itemEntry["is2H"].ToString());
                itemDetails.Tooltip = itemEntry["tooltip"].ToString();

            } catch
            {
                return null;
            }
            return itemDetails;
        }

        public void StoreItemCache(IItemDetails itemDetail)
        {
            if (itemDetail == null)
                return;

            try
            {
                SQLiteConnection conn = new SQLiteConnection(dbConnString);
                conn.Open();

                SQLiteCommand itemCommand = new SQLiteCommand(conn);
                itemCommand.CommandText = "INSERT INTO Items (itemID, itemLevel, name, quality, is2H, tooltip) " +
                    "values (@itemID, @itemLvl, @name, @quality, @is2H, @tip);";

                SQLiteParameter itemIDParam = new SQLiteParameter("@itemID");
                itemCommand.Parameters.Add(itemIDParam);
                itemIDParam.Value = itemDetail.ItemID;

                SQLiteParameter itemLvlParam = new SQLiteParameter("@itemLvl");
                itemCommand.Parameters.Add(itemLvlParam);
                itemLvlParam.Value = itemDetail.ILvl;

                SQLiteParameter itemNameParam = new SQLiteParameter("@name");
                itemCommand.Parameters.Add(itemNameParam);
                itemNameParam.Value = itemDetail.Name;

                SQLiteParameter itemQualParam = new SQLiteParameter("@quality");
                itemCommand.Parameters.Add(itemQualParam);
                itemQualParam.Value = itemDetail.Quality;

                SQLiteParameter item2HParam = new SQLiteParameter("@is2H");
                itemCommand.Parameters.Add(item2HParam);
                item2HParam.Value = itemDetail.IsTwoHandWeapon;

                SQLiteParameter tipParam = new SQLiteParameter("@tip");
                itemCommand.Parameters.Add(tipParam);
                tipParam.Value = itemDetail.Tooltip;

                Int32 rowInserted = itemCommand.ExecuteNonQuery();
                conn.Close();
            } catch
            {
            }
        }
    }
}
