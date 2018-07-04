namespace KinectMIDI
{
    partial class Form1
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
            this.bStart = new System.Windows.Forms.Button();
            this.lDebug = new System.Windows.Forms.Label();
            this.lDetails = new System.Windows.Forms.Label();
            this.lMIDI = new System.Windows.Forms.Label();
            this.cbSeated = new System.Windows.Forms.CheckBox();
            this.lFrame = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStart.ForeColor = System.Drawing.Color.Green;
            this.bStart.Location = new System.Drawing.Point(427, 12);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(112, 48);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // lDebug
            // 
            this.lDebug.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDebug.ForeColor = System.Drawing.Color.White;
            this.lDebug.Location = new System.Drawing.Point(12, 12);
            this.lDebug.Name = "lDebug";
            this.lDebug.Size = new System.Drawing.Size(335, 23);
            this.lDebug.TabIndex = 1;
            this.lDebug.Text = "--";
            this.lDebug.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lDetails
            // 
            this.lDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lDetails.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDetails.ForeColor = System.Drawing.Color.White;
            this.lDetails.Location = new System.Drawing.Point(12, 79);
            this.lDetails.Name = "lDetails";
            this.lDetails.Size = new System.Drawing.Size(159, 537);
            this.lDetails.TabIndex = 2;
            this.lDetails.Text = "--";
            // 
            // lMIDI
            // 
            this.lMIDI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lMIDI.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMIDI.ForeColor = System.Drawing.Color.White;
            this.lMIDI.Location = new System.Drawing.Point(184, 79);
            this.lMIDI.Name = "lMIDI";
            this.lMIDI.Size = new System.Drawing.Size(163, 537);
            this.lMIDI.TabIndex = 3;
            this.lMIDI.Text = "--";
            // 
            // cbSeated
            // 
            this.cbSeated.AutoSize = true;
            this.cbSeated.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSeated.ForeColor = System.Drawing.Color.White;
            this.cbSeated.Location = new System.Drawing.Point(701, 113);
            this.cbSeated.Name = "cbSeated";
            this.cbSeated.Size = new System.Drawing.Size(172, 27);
            this.cbSeated.TabIndex = 4;
            this.cbSeated.Text = "Seated Mode";
            this.cbSeated.UseVisualStyleBackColor = true;
            // 
            // lFrame
            // 
            this.lFrame.BackColor = System.Drawing.Color.Transparent;
            this.lFrame.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFrame.ForeColor = System.Drawing.Color.White;
            this.lFrame.Location = new System.Drawing.Point(688, 12);
            this.lFrame.Name = "lFrame";
            this.lFrame.Size = new System.Drawing.Size(253, 23);
            this.lFrame.TabIndex = 5;
            this.lFrame.Text = "--";
            this.lFrame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Player 1 Track/MIDI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(953, 625);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lFrame);
            this.Controls.Add(this.cbSeated);
            this.Controls.Add(this.lMIDI);
            this.Controls.Add(this.lDetails);
            this.Controls.Add(this.lDebug);
            this.Controls.Add(this.bStart);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Schema Factor Kinect MIDI Tracker Maker Festival 2018";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label lDebug;
        private System.Windows.Forms.Label lDetails;
        private System.Windows.Forms.Label lMIDI;
        private System.Windows.Forms.CheckBox cbSeated;
        private System.Windows.Forms.Label lFrame;
        private System.Windows.Forms.Label label1;
    }
}

