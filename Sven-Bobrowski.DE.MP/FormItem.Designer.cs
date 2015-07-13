namespace Sven_Bobrowski.DE.MP
{
    partial class FormItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataAdresses = new Sven_Bobrowski.DE.MP.InternalData.DataAdresses();
            this.dataAdressesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridDCCAdresses = new System.Windows.Forms.DataGridView();
            this.memNotes = new System.Windows.Forms.TextBox();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.edPoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btDecoderAdd = new System.Windows.Forms.Button();
            this.cbxDecoder = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.dCC1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCC2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCC3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCC4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataAdresses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAdressesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDCCAdresses)).BeginInit();
            this.SuspendLayout();
            // 
            // dataAdresses
            // 
            this.dataAdresses.DataSetName = "DataAdresses";
            this.dataAdresses.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataAdressesBindingSource
            // 
            this.dataAdressesBindingSource.AllowNew = true;
            this.dataAdressesBindingSource.DataMember = "DCCAdresses";
            this.dataAdressesBindingSource.DataSource = this.dataAdresses;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gridDCCAdresses);
            this.groupBox1.Controls.Add(this.memNotes);
            this.groupBox1.Controls.Add(this.cbxState);
            this.groupBox1.Controls.Add(this.edPoint);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 265);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "!Properties";
            // 
            // gridDCCAdresses
            // 
            this.gridDCCAdresses.AllowUserToDeleteRows = false;
            this.gridDCCAdresses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gridDCCAdresses.AutoGenerateColumns = false;
            this.gridDCCAdresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDCCAdresses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dCC1DataGridViewTextBoxColumn,
            this.dCC2DataGridViewTextBoxColumn,
            this.dCC3DataGridViewTextBoxColumn,
            this.dCC4DataGridViewTextBoxColumn});
            this.gridDCCAdresses.DataSource = this.dataAdressesBindingSource;
            this.gridDCCAdresses.Location = new System.Drawing.Point(16, 167);
            this.gridDCCAdresses.Name = "gridDCCAdresses";
            this.gridDCCAdresses.Size = new System.Drawing.Size(450, 92);
            this.gridDCCAdresses.TabIndex = 7;
            // 
            // memNotes
            // 
            this.memNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memNotes.Location = new System.Drawing.Point(251, 53);
            this.memNotes.Multiline = true;
            this.memNotes.Name = "memNotes";
            this.memNotes.Size = new System.Drawing.Size(215, 98);
            this.memNotes.TabIndex = 6;
            // 
            // cbxState
            // 
            this.cbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Location = new System.Drawing.Point(97, 53);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(121, 21);
            this.cbxState.TabIndex = 5;
            // 
            // edPoint
            // 
            this.edPoint.Location = new System.Drawing.Point(97, 22);
            this.edPoint.Name = "edPoint";
            this.edPoint.Size = new System.Drawing.Size(100, 20);
            this.edPoint.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "!Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "!Bemerkungen:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "!DCC Adressen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "!Anschluss:";
            // 
            // btDecoderAdd
            // 
            this.btDecoderAdd.Location = new System.Drawing.Point(307, 10);
            this.btDecoderAdd.Name = "btDecoderAdd";
            this.btDecoderAdd.Size = new System.Drawing.Size(75, 23);
            this.btDecoderAdd.TabIndex = 9;
            this.btDecoderAdd.Text = "!New...";
            this.btDecoderAdd.UseVisualStyleBackColor = true;
            this.btDecoderAdd.Click += new System.EventHandler(this.btDecoderAdd_Click_1);
            // 
            // cbxDecoder
            // 
            this.cbxDecoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDecoder.FormattingEnabled = true;
            this.cbxDecoder.Location = new System.Drawing.Point(106, 12);
            this.cbxDecoder.Name = "cbxDecoder";
            this.cbxDecoder.Size = new System.Drawing.Size(195, 21);
            this.cbxDecoder.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "!Decoder";
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(400, 498);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 11;
            this.btCancel.Text = "!Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(319, 498);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 12;
            this.btOK.Text = "!OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // dCC1DataGridViewTextBoxColumn
            // 
            this.dCC1DataGridViewTextBoxColumn.DataPropertyName = "DCC1";
            this.dCC1DataGridViewTextBoxColumn.HeaderText = "DCC1";
            this.dCC1DataGridViewTextBoxColumn.Name = "dCC1DataGridViewTextBoxColumn";
            // 
            // dCC2DataGridViewTextBoxColumn
            // 
            this.dCC2DataGridViewTextBoxColumn.DataPropertyName = "DCC2";
            this.dCC2DataGridViewTextBoxColumn.HeaderText = "DCC2";
            this.dCC2DataGridViewTextBoxColumn.Name = "dCC2DataGridViewTextBoxColumn";
            // 
            // dCC3DataGridViewTextBoxColumn
            // 
            this.dCC3DataGridViewTextBoxColumn.DataPropertyName = "DCC3";
            this.dCC3DataGridViewTextBoxColumn.HeaderText = "DCC3";
            this.dCC3DataGridViewTextBoxColumn.Name = "dCC3DataGridViewTextBoxColumn";
            // 
            // dCC4DataGridViewTextBoxColumn
            // 
            this.dCC4DataGridViewTextBoxColumn.DataPropertyName = "DCC4";
            this.dCC4DataGridViewTextBoxColumn.HeaderText = "DCC4";
            this.dCC4DataGridViewTextBoxColumn.Name = "dCC4DataGridViewTextBoxColumn";
            // 
            // FormItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 533);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btDecoderAdd);
            this.Controls.Add(this.cbxDecoder);
            this.Controls.Add(this.label1);
            this.Name = "FormItem";
            this.Text = "FormItem";
            this.Load += new System.EventHandler(this.FormItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataAdresses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAdressesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDCCAdresses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dataAdressesBindingSource;
        private InternalData.DataAdresses dataAdresses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridDCCAdresses;
        private System.Windows.Forms.TextBox memNotes;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.TextBox edPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btDecoderAdd;
        private System.Windows.Forms.ComboBox cbxDecoder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCC1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCC2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCC3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCC4DataGridViewTextBoxColumn;
    }
}