using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sven_Bobrowski.DE.MP.Properties;
using Sven_Bobrowski.DE.Integration;

namespace Sven_Bobrowski.DE.MP
{
    public enum ItemFormState { New, Edit };

    public partial class FormItem : Form
    {
        private ItemFormState FState;
        private DataItem FItem;

        public FormItem()
        {
            InitializeComponent();

            BuildStateList();

            FItem = null;
        }

        public FormItem(ItemFormState pState)
        {
            InitializeComponent();

            FState = pState;

            BuildStateList();

            ApplyCaption();

            FItem = null;
        }

        public DataItem Item
        {
            get
            {
                return FItem;
            }
            set
            {
                FItem = value;
            }
        }

        private void ApplyCaption()
        {
            switch (FState)
            {
                case ItemFormState.New:
                    this.Text = Resources.Item_Caption_ModeNew;
                    break;
                case ItemFormState.Edit:
                    this.Text = Resources.Item_Caption_ModeEdit;
                    break;
            }
        }

        // Occupied, Free, Locked
        private void BuildStateList()
        {
            cbxState.BeginUpdate();
            try
            {
                cbxState.Items.Clear();
                cbxState.Items.Add(Resources.State_Combox_Occupied);
                cbxState.Items.Add(Resources.State_Combox_Free);
                cbxState.Items.Add(Resources.State_Combox_Locked);
            }
            finally
            {
                cbxState.EndUpdate();
            }
            // preselect
            cbxState.SelectedIndex = 0;
        }

        public ItemFormState State
        {
            get
            {
                return FState;
            }
            set
            {
                FState = value;

                ApplyCaption();
            }
        }

        private void FormItem_Load(object sender, EventArgs e)
        {
            // if item assigned and not new mode
            if ((null != FItem) && (FState == ItemFormState.Edit))
            {
                LoadValues();
            }
        }

        private void btDecoderAdd_Click(object sender, EventArgs e)
        {

        }

        private void btDecoderAdd_Click_1(object sender, EventArgs e)
        {
            // new decoder dialog
            DecoderItem tDecoder = new DecoderItem();
            // dialog
            FormDecoder tDlg = new FormDecoder(DecoderFormState.New);
            tDlg.Decoder = tDecoder;
            if (tDlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                // reload list and set as new decoder
                tDecoder = tDlg.Decoder;
                // set as new
                FItem.Decoder = tDecoder;
                // FF: reload list

            }
        }

        private bool ValidateValues()
        {
            return true;
        }

        private void LoadValues()
        {

        }

        private int TryGetDCC(int pColum, DataRowView pView)
        {
            int tDCC = 0;
            int.TryParse(pView["DCC" + Convert.ToString(pColum)].ToString(), out tDCC);
            return tDCC;
        }

        private void ApplyValues()
        {
            int tPoint = 0;
            if (int.TryParse(edPoint.Text, out tPoint))
                FItem.Point = tPoint;
            if (cbxState.SelectedIndex >= 0)
                FItem.State = (PointState)cbxState.SelectedIndex;
            FItem.Notes = memNotes.Text;
            
            DataRowView tDCCItems = (DataRowView)this.dataAdressesBindingSource.List[0];
            FItem.DCCAdress1 = TryGetDCC(1, tDCCItems);
            FItem.DCCAdress2 = TryGetDCC(2, tDCCItems);
            FItem.DCCAdress3 = TryGetDCC(3, tDCCItems);
            FItem.DCCAdress4 = TryGetDCC(4, tDCCItems);
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (ValidateValues())
            {
                // apply values
                ApplyValues();
                // okay
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
