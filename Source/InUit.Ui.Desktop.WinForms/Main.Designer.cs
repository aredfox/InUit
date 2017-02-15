namespace InUit.Ui.Desktop.WinForms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.uxIn = new System.Windows.Forms.CheckedListBox();
            this.uxOut = new System.Windows.Forms.CheckedListBox();
            this.uxInOutName = new System.Windows.Forms.TextBox();
            this.uxInOutDateTime = new System.Windows.Forms.DateTimePicker();
            this.uxAddIn = new System.Windows.Forms.Button();
            this.uxAddOut = new System.Windows.Forms.Button();
            this.uxTitle = new System.Windows.Forms.Label();
            this.uxPeriod = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // uxIn
            // 
            this.uxIn.CheckOnClick = true;
            this.uxIn.FormattingEnabled = true;
            this.uxIn.Location = new System.Drawing.Point(9, 33);
            this.uxIn.Margin = new System.Windows.Forms.Padding(2);
            this.uxIn.Name = "uxIn";
            this.uxIn.Size = new System.Drawing.Size(203, 139);
            this.uxIn.Sorted = true;
            this.uxIn.TabIndex = 0;
            this.uxIn.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.uxIn_ItemCheck);
            // 
            // uxOut
            // 
            this.uxOut.CheckOnClick = true;
            this.uxOut.FormattingEnabled = true;
            this.uxOut.Location = new System.Drawing.Point(219, 33);
            this.uxOut.Margin = new System.Windows.Forms.Padding(2);
            this.uxOut.Name = "uxOut";
            this.uxOut.Size = new System.Drawing.Size(203, 139);
            this.uxOut.Sorted = true;
            this.uxOut.TabIndex = 1;
            this.uxOut.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.uxOut_ItemCheck);
            // 
            // uxInOutName
            // 
            this.uxInOutName.Location = new System.Drawing.Point(9, 180);
            this.uxInOutName.Margin = new System.Windows.Forms.Padding(2);
            this.uxInOutName.Name = "uxInOutName";
            this.uxInOutName.Size = new System.Drawing.Size(252, 20);
            this.uxInOutName.TabIndex = 2;
            this.uxInOutName.TextChanged += new System.EventHandler(this.uxInOutName_TextChanged);
            // 
            // uxInOutDateTime
            // 
            this.uxInOutDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.uxInOutDateTime.Location = new System.Drawing.Point(265, 180);
            this.uxInOutDateTime.Margin = new System.Windows.Forms.Padding(2);
            this.uxInOutDateTime.Name = "uxInOutDateTime";
            this.uxInOutDateTime.Size = new System.Drawing.Size(83, 20);
            this.uxInOutDateTime.TabIndex = 3;
            // 
            // uxAddIn
            // 
            this.uxAddIn.Location = new System.Drawing.Point(354, 180);
            this.uxAddIn.Margin = new System.Windows.Forms.Padding(2);
            this.uxAddIn.Name = "uxAddIn";
            this.uxAddIn.Size = new System.Drawing.Size(30, 20);
            this.uxAddIn.TabIndex = 4;
            this.uxAddIn.Text = "In";
            this.uxAddIn.UseVisualStyleBackColor = true;
            this.uxAddIn.Click += new System.EventHandler(this.uxIn_Click);
            // 
            // uxAddOut
            // 
            this.uxAddOut.Location = new System.Drawing.Point(391, 180);
            this.uxAddOut.Margin = new System.Windows.Forms.Padding(2);
            this.uxAddOut.Name = "uxAddOut";
            this.uxAddOut.Size = new System.Drawing.Size(30, 20);
            this.uxAddOut.TabIndex = 5;
            this.uxAddOut.Text = "Uit";
            this.uxAddOut.UseVisualStyleBackColor = true;
            this.uxAddOut.Click += new System.EventHandler(this.uxOut_Click);
            // 
            // uxTitle
            // 
            this.uxTitle.AutoSize = true;
            this.uxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxTitle.Location = new System.Drawing.Point(5, 7);
            this.uxTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxTitle.Name = "uxTitle";
            this.uxTitle.Size = new System.Drawing.Size(110, 20);
            this.uxTitle.TabIndex = 9;
            this.uxTitle.Text = "In/Uit Dienst";
            // 
            // uxPeriod
            // 
            this.uxPeriod.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPeriod.CustomFormat = "MM/yyyy";
            this.uxPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uxPeriod.Location = new System.Drawing.Point(346, 9);
            this.uxPeriod.Margin = new System.Windows.Forms.Padding(2);
            this.uxPeriod.Name = "uxPeriod";
            this.uxPeriod.ShowUpDown = true;
            this.uxPeriod.Size = new System.Drawing.Size(75, 19);
            this.uxPeriod.TabIndex = 10;
            this.uxPeriod.ValueChanged += new System.EventHandler(this.uxPeriod_ValueChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 210);
            this.Controls.Add(this.uxPeriod);
            this.Controls.Add(this.uxAddOut);
            this.Controls.Add(this.uxAddIn);
            this.Controls.Add(this.uxInOutDateTime);
            this.Controls.Add(this.uxInOutName);
            this.Controls.Add(this.uxOut);
            this.Controls.Add(this.uxIn);
            this.Controls.Add(this.uxTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox uxIn;
        private System.Windows.Forms.CheckedListBox uxOut;
        private System.Windows.Forms.TextBox uxInOutName;
        private System.Windows.Forms.DateTimePicker uxInOutDateTime;
        private System.Windows.Forms.Button uxAddIn;
        private System.Windows.Forms.Button uxAddOut;
        private System.Windows.Forms.Label uxTitle;
        private System.Windows.Forms.DateTimePicker uxPeriod;
    }
}

