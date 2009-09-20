using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ExternalSiteUtils;

namespace ArmoryEquipmentDisplay
{
    public partial class ArmoryEquipmentDisplayForm : Form
    {
        private List<String> characterNames;
        private List<CharacterEquipment> equipmentList;
        private Armory server;
        private Int32 rowInEdit = -1;

        public ArmoryEquipmentDisplayForm()
        {
            InitializeComponent();
            characterNames = new List<String>();
            equipmentList = new List<CharacterEquipment>();

            server = new Armory(Armory.Region.US, "Greymane");
            characterNames.Add("Ashean");
            characterNames.Add("Khatian");

            foreach (String name in characterNames)
            {
                equipmentList.Add(server.GetEquipment(name));
            }

            dgViewCharacters.RowCount = characterNames.Count + 1;
        }

        private void dgViewCharacters_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex == dgViewCharacters.RowCount - 1)
                return;
            if (e.RowIndex == rowInEdit)
                return;
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (e.ColumnIndex == 0)
                {
                    e.ToolTipText = characterNames[e.RowIndex];
                } else
                {
                    String colName = dgViewCharacters.Columns[e.ColumnIndex].HeaderText;
                    object equipPiece = equipmentList[e.RowIndex].GetType().GetProperty(colName).GetValue(equipmentList[e.RowIndex], null);
                    e.ToolTipText = ((IItemDetails)equipPiece).Tooltip;
                }
            }
        }

        private void dgViewCharacters_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex == dgViewCharacters.RowCount - 1) 
                return;
            if (e.RowIndex == rowInEdit)
                return;
            else if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 0)
                {
                    e.Value = characterNames[e.RowIndex];
                } else
                {
                    String colName = dgViewCharacters.Columns[e.ColumnIndex].HeaderText;
                    object equipPiece = equipmentList[e.RowIndex].GetType().GetProperty(colName).GetValue(equipmentList[e.RowIndex], null);
                    e.Value = ((IItemDetails)equipPiece).Name;
                }
            }
        }

        private void dgViewCharacters_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            rowInEdit = dgViewCharacters.Rows.Count - 1;
        }

        private void dgViewCharacters_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            String charName = e.Value.ToString();
            CharacterEquipment charEquip = server.GetEquipment(charName);
            if (charEquip == null)
            {
                dgViewCharacters.Rows.RemoveAt(rowInEdit);
                rowInEdit = -1;
                return;
            }

            characterNames.Add(charName);
            equipmentList.Add(charEquip);
            dgViewCharacters.Invalidate();
        }
    }
}