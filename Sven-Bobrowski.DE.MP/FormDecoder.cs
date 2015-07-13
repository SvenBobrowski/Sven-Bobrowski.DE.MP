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
    public enum DecoderFormState { New, Edit };

    public partial class FormDecoder : Form
    {
        private DecoderFormState FState;
        private DecoderItem FDecoder;

        public FormDecoder()
        {
            InitializeComponent();

            FDecoder = null;

            LoadDecoderTypes();
            LoadProtocolTypes();
        }

        public FormDecoder(DecoderFormState pState)
        {
            InitializeComponent();

            FState = pState;

            ApplyCaption();

            FDecoder = null;

            LoadDecoderTypes();
            LoadProtocolTypes();
        }

        public DecoderFormState State
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

        public DecoderItem Decoder
        {
            get
            {
                return FDecoder;
            }
            set
            {
                FDecoder = value;
            }
        }

        private void ApplyCaption()
        {
            switch (FState)
            {
                case DecoderFormState.New:
                    this.Text = Resources.Decoder_Caption_ModeNew;
                    break;
                case DecoderFormState.Edit:
                    this.Text = Resources.Decoder_Caption_ModeEdit;
                    break;
            }
        }

        // Standard, Light, Signal, Switch_Motor, Switch_Servo, Feedback
        private void LoadDecoderTypes()
        {
            cbxDecoderType.BeginUpdate();
            try
            {
                cbxDecoderType.Items.Clear();
                cbxDecoderType.Items.Add(Resources.DecoderType_Standard);
                cbxDecoderType.Items.Add(Resources.DecoderType_Light);
                cbxDecoderType.Items.Add(Resources.DecoderType_Signal);
                cbxDecoderType.Items.Add(Resources.DecoderType_Switch_Motor);
                cbxDecoderType.Items.Add(Resources.DecoderType_Switch_Servo);
                cbxDecoderType.Items.Add(Resources.DecoderType_Feedback);

                cbxDecoderType.SelectedIndex = 0;
            }
            finally
            {
                cbxDecoderType.EndUpdate();
            }
        }

        // Multi, DCC, Motorola, S88
        private void LoadProtocolTypes()
        {
            cbxProtocoll.BeginUpdate();
            try
            {
                cbxProtocoll.Items.Clear();
                cbxProtocoll.Items.Add(Resources.Protocol_Multi);
                cbxProtocoll.Items.Add(Resources.Protocol_DCC);
                cbxProtocoll.Items.Add(Resources.Protocol_Motorola);
                cbxProtocoll.Items.Add(Resources.Protocol_S88);
                cbxProtocoll.Items.Add(Resources.Protocol_Loconet);

                cbxProtocoll.SelectedIndex = 0;
            }
            finally
            {
                cbxProtocoll.EndUpdate();
            }
        }

        private void FormDecoder_Load(object sender, EventArgs e)
        {
            // if decoder assigned and loading
            if ((null != FDecoder) && (FState == DecoderFormState.Edit))
            {
                // load decoder data
                LoadValues();
            }
            else
            {
                LoadValues(true);
            }
        }

        private bool ValidateValues()
        {
            if (String.IsNullOrEmpty(edName.Text))
            {
                MessageBox.Show("!Please enter an valid name.");
                edName.Focus();

                return false;
            }

            if (String.IsNullOrEmpty(edID.Text))
            {
                MessageBox.Show("!Please specify an decoder name.");
                edID.Focus();

                return false;
            }

            
            return true;
        }

        private void SetComboEditValues(ComboBox pControl, string pValue, bool pAddDefaultsOnly)
        {
            // FF: load values from database also
            if (!pAddDefaultsOnly)
                pControl.Text = FDecoder.Name;

            pControl.BeginUpdate();
            try
            {
                pControl.Items.Clear();
                
                if (!pAddDefaultsOnly)
                    pControl.Items.Add(pValue);
            }
            finally
            {
                pControl.EndUpdate();
            }
        }

        private void LoadValues(bool pDefaultValues = false)
        {
            if (!pDefaultValues)
            {
                edName.Text = FDecoder.Label;
                SetComboEditValues(edID, FDecoder.Name, false);
                SetComboEditValues(edManufacturer, FDecoder.Manufacturer, false);
                int tIdx = (int)FDecoder.Type;
                cbxDecoderType.SelectedIndex = tIdx;
                edManual.Text = FDecoder.ManualURL;
                edMax.Value = FDecoder.Connections;
                edOccupied.Value = FDecoder.ConnectionsUsed;
                memNotes.Text = FDecoder.Notes;
            }
            else
            {
                SetComboEditValues(edID, FDecoder.Name, true);
                SetComboEditValues(edManufacturer, FDecoder.Manufacturer, true);
            }
        }

        private void ApplyValues()
        {
            FDecoder.Label = edName.Text;
            FDecoder.Name = edID.Text;
            FDecoder.Manufacturer = edManufacturer.Text;
            if (cbxDecoderType.SelectedIndex >= 0)
                FDecoder.Type = (DecoderType)cbxDecoderType.SelectedIndex;
            if (cbxProtocoll.SelectedIndex >= 0)
                FDecoder.Protocol = (DecoderProtocol)cbxProtocoll.SelectedIndex;
            FDecoder.ManualURL = edManual.Text;
            FDecoder.Connections = (int)edMax.Value;
            FDecoder.ConnectionsUsed = (int)edOccupied.Value;
            FDecoder.Notes = memNotes.Text;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            // validate
            if (ValidateValues())
            {
                ApplyValues();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
