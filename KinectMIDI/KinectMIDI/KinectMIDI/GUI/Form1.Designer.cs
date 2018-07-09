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
            this.lDetails0 = new System.Windows.Forms.Label();
            this.lMIDI0 = new System.Windows.Forms.Label();
            this.cbSeated = new System.Windows.Forms.CheckBox();
            this.lFrame = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lDetails1 = new System.Windows.Forms.Label();
            this.bStop = new System.Windows.Forms.Button();
            this.lDelta = new System.Windows.Forms.Label();
            this.lMIDI1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStart.ForeColor = System.Drawing.Color.ForestGreen;
            this.bStart.Location = new System.Drawing.Point(374, 216);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(112, 69);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // lDebug
            // 
            this.lDebug.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDebug.ForeColor = System.Drawing.Color.White;
            this.lDebug.Location = new System.Drawing.Point(8, 9);
            this.lDebug.Name = "lDebug";
            this.lDebug.Size = new System.Drawing.Size(335, 23);
            this.lDebug.TabIndex = 1;
            this.lDebug.Text = "--";
            this.lDebug.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lDetails0
            // 
            this.lDetails0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lDetails0.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDetails0.ForeColor = System.Drawing.Color.White;
            this.lDetails0.Location = new System.Drawing.Point(12, 79);
            this.lDetails0.Name = "lDetails0";
            this.lDetails0.Size = new System.Drawing.Size(163, 537);
            this.lDetails0.TabIndex = 2;
            this.lDetails0.Text = "--";
            // 
            // lMIDI0
            // 
            this.lMIDI0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lMIDI0.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMIDI0.ForeColor = System.Drawing.Color.White;
            this.lMIDI0.Location = new System.Drawing.Point(184, 79);
            this.lMIDI0.Name = "lMIDI0";
            this.lMIDI0.Size = new System.Drawing.Size(163, 537);
            this.lMIDI0.TabIndex = 3;
            this.lMIDI0.Text = "--";
            // 
            // cbSeated
            // 
            this.cbSeated.AutoSize = true;
            this.cbSeated.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSeated.ForeColor = System.Drawing.Color.White;
            this.cbSeated.Location = new System.Drawing.Point(374, 288);
            this.cbSeated.Name = "cbSeated";
            this.cbSeated.Size = new System.Drawing.Size(114, 17);
            this.cbSeated.TabIndex = 4;
            this.cbSeated.Text = "Seated Mode";
            this.cbSeated.UseVisualStyleBackColor = true;
            // 
            // lFrame
            // 
            this.lFrame.BackColor = System.Drawing.Color.Transparent;
            this.lFrame.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFrame.ForeColor = System.Drawing.Color.White;
            this.lFrame.Location = new System.Drawing.Point(603, 9);
            this.lFrame.Name = "lFrame";
            this.lFrame.Size = new System.Drawing.Size(253, 23);
            this.lFrame.TabIndex = 5;
            this.lFrame.Text = "--";
            this.lFrame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Player 1 Track/MIDI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lDetails1
            // 
            this.lDetails1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lDetails1.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDetails1.ForeColor = System.Drawing.Color.White;
            this.lDetails1.Location = new System.Drawing.Point(515, 79);
            this.lDetails1.Name = "lDetails1";
            this.lDetails1.Size = new System.Drawing.Size(163, 537);
            this.lDetails1.TabIndex = 8;
            this.lDetails1.Text = "--";
            // 
            // bStop
            // 
            this.bStop.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStop.ForeColor = System.Drawing.Color.Red;
            this.bStop.Location = new System.Drawing.Point(374, 311);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(112, 69);
            this.bStop.TabIndex = 9;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // lDelta
            // 
            this.lDelta.BackColor = System.Drawing.Color.Transparent;
            this.lDelta.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDelta.ForeColor = System.Drawing.Color.White;
            this.lDelta.Location = new System.Drawing.Point(600, 32);
            this.lDelta.Name = "lDelta";
            this.lDelta.Size = new System.Drawing.Size(253, 23);
            this.lDelta.TabIndex = 10;
            this.lDelta.Text = "--";
            this.lDelta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lMIDI1
            // 
            this.lMIDI1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lMIDI1.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMIDI1.ForeColor = System.Drawing.Color.White;
            this.lMIDI1.Location = new System.Drawing.Point(691, 79);
            this.lMIDI1.Name = "lMIDI1";
            this.lMIDI1.Size = new System.Drawing.Size(163, 537);
            this.lMIDI1.TabIndex = 11;
            this.lMIDI1.Text = "--";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(521, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(335, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Player 2 Track/MIDI";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(873, 625);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lMIDI1);
            this.Controls.Add(this.lDelta);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.lDetails1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lFrame);
            this.Controls.Add(this.cbSeated);
            this.Controls.Add(this.lMIDI0);
            this.Controls.Add(this.lDetails0);
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
        private System.Windows.Forms.Label lDetails0;
        private System.Windows.Forms.Label lMIDI0;
        private System.Windows.Forms.CheckBox cbSeated;
        private System.Windows.Forms.Label lFrame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lDetails1;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Label lDelta;
        private System.Windows.Forms.Label lMIDI1;
        private System.Windows.Forms.Label label3;
    }
}

