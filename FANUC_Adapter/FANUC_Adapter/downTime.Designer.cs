namespace AdapterLab
{
    partial class downTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(downTime));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maintenance = new System.Windows.Forms.RadioButton();
            this.other = new System.Windows.Forms.RadioButton();
            this.otherTextBox = new System.Windows.Forms.TextBox();
            this.endOfShift = new System.Windows.Forms.RadioButton();
            this.machineError = new System.Windows.Forms.RadioButton();
            this.cleaning = new System.Windows.Forms.RadioButton();
            this.loading = new System.Windows.Forms.RadioButton();
            this.lunch = new System.Windows.Forms.RadioButton();
            this.acceptButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maintenance);
            this.groupBox1.Controls.Add(this.other);
            this.groupBox1.Controls.Add(this.otherTextBox);
            this.groupBox1.Controls.Add(this.endOfShift);
            this.groupBox1.Controls.Add(this.machineError);
            this.groupBox1.Controls.Add(this.cleaning);
            this.groupBox1.Controls.Add(this.loading);
            this.groupBox1.Controls.Add(this.lunch);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reason For Downtime";
            // 
            // maintenance
            // 
            this.maintenance.AutoSize = true;
            this.maintenance.Location = new System.Drawing.Point(106, 41);
            this.maintenance.Name = "maintenance";
            this.maintenance.Size = new System.Drawing.Size(87, 17);
            this.maintenance.TabIndex = 7;
            this.maintenance.TabStop = true;
            this.maintenance.Text = "Maintenance";
            this.maintenance.UseVisualStyleBackColor = true;
            // 
            // other
            // 
            this.other.AutoSize = true;
            this.other.Location = new System.Drawing.Point(6, 65);
            this.other.Name = "other";
            this.other.Size = new System.Drawing.Size(51, 17);
            this.other.TabIndex = 6;
            this.other.TabStop = true;
            this.other.Text = "Other";
            this.other.UseVisualStyleBackColor = true;
            // 
            // otherTextBox
            // 
            this.otherTextBox.Location = new System.Drawing.Point(63, 65);
            this.otherTextBox.Name = "otherTextBox";
            this.otherTextBox.Size = new System.Drawing.Size(206, 20);
            this.otherTextBox.TabIndex = 1;
            // 
            // endOfShift
            // 
            this.endOfShift.AutoSize = true;
            this.endOfShift.Location = new System.Drawing.Point(6, 42);
            this.endOfShift.Name = "endOfShift";
            this.endOfShift.Size = new System.Drawing.Size(82, 17);
            this.endOfShift.TabIndex = 5;
            this.endOfShift.TabStop = true;
            this.endOfShift.Text = "End Of Shift";
            this.endOfShift.UseVisualStyleBackColor = true;
            // 
            // machineError
            // 
            this.machineError.AutoSize = true;
            this.machineError.Location = new System.Drawing.Point(234, 19);
            this.machineError.Name = "machineError";
            this.machineError.Size = new System.Drawing.Size(91, 17);
            this.machineError.TabIndex = 4;
            this.machineError.TabStop = true;
            this.machineError.Text = "Machine Error";
            this.machineError.UseVisualStyleBackColor = true;
            // 
            // cleaning
            // 
            this.cleaning.AutoSize = true;
            this.cleaning.Location = new System.Drawing.Point(234, 42);
            this.cleaning.Name = "cleaning";
            this.cleaning.Size = new System.Drawing.Size(66, 17);
            this.cleaning.TabIndex = 3;
            this.cleaning.TabStop = true;
            this.cleaning.Text = "Cleaning";
            this.cleaning.UseVisualStyleBackColor = true;
            // 
            // loading
            // 
            this.loading.AutoSize = true;
            this.loading.Location = new System.Drawing.Point(106, 18);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(122, 17);
            this.loading.TabIndex = 2;
            this.loading.TabStop = true;
            this.loading.Text = "Loading / Unloading";
            this.loading.UseVisualStyleBackColor = true;
            // 
            // lunch
            // 
            this.lunch.AutoSize = true;
            this.lunch.Location = new System.Drawing.Point(6, 19);
            this.lunch.Name = "lunch";
            this.lunch.Size = new System.Drawing.Size(94, 17);
            this.lunch.TabIndex = 1;
            this.lunch.TabStop = true;
            this.lunch.Text = "Lunch / Break";
            this.lunch.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(300, 115);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 0;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // downTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 143);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.acceptButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "downTime";
            this.Text = "Down Time";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton endOfShift;
        private System.Windows.Forms.RadioButton machineError;
        private System.Windows.Forms.RadioButton cleaning;
        private System.Windows.Forms.RadioButton loading;
        private System.Windows.Forms.RadioButton lunch;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.TextBox otherTextBox;
        private System.Windows.Forms.RadioButton maintenance;
        private System.Windows.Forms.RadioButton other;
    }
}