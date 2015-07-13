using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sven_Bobrowski.DE.Integration
{
    public enum PointState { Occupied, Free, Locked };
    public enum ExternalType { Base, Text, Image };
    public enum DecoderType { Standard, Light, Signal, Switch_Motor, Switch_Servo, Feedback };
    public enum DecoderProtocol { Multi, DCC, Motorola, S88, Loconet };

    public class DataItem : IDisposable
    {
        private DecoderItem FDecoder;
        
        private Device_ExternalItem FDevice;
        private Segment_ExternalItem FSegment;
        private Label_ExternalItem FLabel;
        private Image_ExternalItem FImage;

        public int ID { get; set; }
        public int DecoderId { get; set; }
        public int Point { get; set; }
        public int DCCAdress1 { get; set; }
        public int DCCAdress2 { get; set; }
        public int DCCAdress3 { get; set; }
        public int DCCAdress4 { get; set; }
        public PointState State {get; set; }
        public string Notes { get; set; }
        
        public DataItem()
        {
            ID = -1;
            
            DecoderId = -1;
            FDecoder = null;

            Point = -1;

            DCCAdress1 = 0;
            DCCAdress2 = 0;
            DCCAdress3 = 0;
            DCCAdress4 = 0;

            State = PointState.Free;

            FDevice = new Device_ExternalItem();
            FSegment = new Segment_ExternalItem();
            FLabel = new Label_ExternalItem();
            FImage = new Image_ExternalItem();

            Notes = "";
        }

        public void Dispose()
        {
            FDecoder = null;

            FDevice = null;
            FSegment = null;
            FLabel = null;
            FImage = null;
        }

        public void Dummy()
        {
            Random tRnd = new Random();

            this.DCCAdress1 = tRnd.Next(1, 240);
            this.DCCAdress2 = this.DCCAdress1 + 1;
            this.DCCAdress3 = 0;
            this.DCCAdress4 = 0;
            this.Device.Value = "Li-HS-1";
            this.Segment.Value = "A";
            this.Label.Value = "S5";

            Notes = "Simply a random item";
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

        public Device_ExternalItem Device
        {
            get
            {
                return FDevice;
            }
            set
            {
                FDevice = value;
            }
        }

        public Segment_ExternalItem Segment
        {
            get
            {
                return FSegment;
            }
            set
            {
                FSegment = value;
            }
        }

        public Label_ExternalItem Label
        {
            get
            {
                return FLabel;
            }
            set
            {
                FLabel = value;
            }
        }

        public Image_ExternalItem Image
        {
            get
            {
                return FImage;
            }
            set
            {
                FImage = value;
            }
        }
    }

    public class DecoderItem
    {
        public DecoderItem()
        {
            this.Type = DecoderType.Standard;
            this.Protocol = DecoderProtocol.DCC;
            // FF: resources
            this.Label = "Dekoder";
            this.Name = "";
            this.Manufacturer = "";
            this.ManualURL = "";
            this.Connections = 0;
            this.ConnectionsUsed = 0;
            this.Notes = "";
        }

        public void Dummy()
        {
            this.Type = DecoderType.Signal;
            this.Protocol = DecoderProtocol.DCC;
            this.Label = "SD-02";
            this.Name = "Z1-16 Signal DACH";
            this.Manufacturer = "qdecoder";
            this.ManualURL = "http://qdecoder.de/index.php?option=com_phocadownload&view=category&id=35%3Az1-16-signal&Itemid=92&lang=de";
            this.Connections = 4;
            this.ConnectionsUsed = 0;
            this.Notes = "Verfügbar";
        }

        // DecoderType
        public DecoderType Type { get; set; }
        public DecoderProtocol Protocol { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ManualURL { get; set; }
        public int Connections { get; set; }
        public int ConnectionsUsed { get; set; }
        public string Notes { get; set; }
    }

    public interface IExternalItem
    {
        int ID { get; set; }
        ExternalType Type { get; set; }
        string Key { get; set; }
        string Value { get; set; }
        int Image { get; set; }
    }

    public class ExternalItem : IExternalItem
    {
        private int FID;
        private ExternalType FType;
        private string FKey;
        private string FValue;
        private int FImage;

        public ExternalItem()
        {
            FID = -1;
            FType = ExternalType.Base;
            FKey = "";
            FValue = "";
            FImage = 0;
        }

        protected virtual string GetValueAsString()
        {
            return FValue;
        }

        protected virtual void SetValueAsString(string pValue)
        {
            FValue = pValue;
        }

        protected virtual int GetValueAsBlob()
        {
            return FImage;
        }

        protected virtual void SetValueAsBlob(int pValue)
        {
            FImage = pValue;
        }

        public int ID
        {
            get
            {
                return FID;
            }
            set
            {
                FID = value;
            }
        }

        public ExternalType Type
        {
            get
            {
                return FType;
            }
            set
            {
                FType = value;
            }
        }

        public string Key
        {
            get
            {
                return FKey;
            }
            set
            {
                FKey = value;
            }
        }

        public string Value
        {
            get
            {
                return GetValueAsString();
            }
            set
            {
                SetValueAsString(value);
            }
        }

        public int Image
        {
            get
            {
                return GetValueAsBlob();
            }
            set
            {
                SetValueAsBlob(value);
            }
        }
    }

    public class Device_ExternalItem : ExternalItem
    {
        public Device_ExternalItem()
        {
            this.Type = ExternalType.Text;
            // FF: translation
            this.Key = "Device";
        }
    }

    public class Segment_ExternalItem : ExternalItem
    {
        public Segment_ExternalItem()
        {
            this.Type = ExternalType.Text;
            // FF: translation
            this.Key = "Segment";
        }
    }

    public class Label_ExternalItem : ExternalItem
    {
        public Label_ExternalItem()
        {
            this.Type = ExternalType.Text;
            // FF: translation
            this.Key = "ID";
        }
    }

    public class Image_ExternalItem : ExternalItem
    {
        public Image_ExternalItem()
        {
            this.Type = ExternalType.Image;
            // FF: translation
            this.Key = "";
        }
    }
}

