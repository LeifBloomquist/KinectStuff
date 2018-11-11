namespace KinectC64
{
    partial class MainGUI
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
            this.JoystickPort2Button = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.JoystickBothPortsButton = new System.Windows.Forms.Button();
            this.JoystickPort1Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Joystick = new System.Windows.Forms.GroupBox();
            this.Right = new System.Windows.Forms.Label();
            this.Up = new System.Windows.Forms.Label();
            this.Down = new System.Windows.Forms.Label();
            this.Fire = new System.Windows.Forms.Label();
            this.Left = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lDelta = new System.Windows.Forms.Label();
            this.lDebug = new System.Windows.Forms.Label();
            this.lFrame = new System.Windows.Forms.Label();
            this.SerialLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bStop = new System.Windows.Forms.Button();
            this.cbSeated = new System.Windows.Forms.CheckBox();
            this.bStart = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Joystick.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // JoystickPort2Button
            // 
            this.JoystickPort2Button.BackColor = System.Drawing.SystemColors.Control;
            this.JoystickPort2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoystickPort2Button.Location = new System.Drawing.Point(110, 28);
            this.JoystickPort2Button.Name = "JoystickPort2Button";
            this.JoystickPort2Button.Size = new System.Drawing.Size(98, 41);
            this.JoystickPort2Button.TabIndex = 11;
            this.JoystickPort2Button.Text = "Port 2 Only\r\n(Single Hand)";
            this.JoystickPort2Button.UseVisualStyleBackColor = false;
            this.JoystickPort2Button.Click += new System.EventHandler(this.JoystickPort2Button_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.JoystickBothPortsButton);
            this.groupBox3.Controls.Add(this.JoystickPort2Button);
            this.groupBox3.Controls.Add(this.JoystickPort1Button);
            this.groupBox3.Location = new System.Drawing.Point(701, 356);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(217, 134);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Joystick Mode";
            // 
            // JoystickBothPortsButton
            // 
            this.JoystickBothPortsButton.BackColor = System.Drawing.SystemColors.Control;
            this.JoystickBothPortsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoystickBothPortsButton.Location = new System.Drawing.Point(6, 75);
            this.JoystickBothPortsButton.Name = "JoystickBothPortsButton";
            this.JoystickBothPortsButton.Size = new System.Drawing.Size(202, 41);
            this.JoystickBothPortsButton.TabIndex = 11;
            this.JoystickBothPortsButton.Text = "Joystick Port 1 and 2\r\n(Both Hands)";
            this.JoystickBothPortsButton.UseVisualStyleBackColor = false;
            this.JoystickBothPortsButton.Click += new System.EventHandler(this.JoystickBothPortsButton_Click);
            // 
            // JoystickPort1Button
            // 
            this.JoystickPort1Button.BackColor = System.Drawing.SystemColors.Control;
            this.JoystickPort1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoystickPort1Button.Location = new System.Drawing.Point(6, 28);
            this.JoystickPort1Button.Name = "JoystickPort1Button";
            this.JoystickPort1Button.Size = new System.Drawing.Size(98, 41);
            this.JoystickPort1Button.TabIndex = 11;
            this.JoystickPort1Button.Text = "Port 1 Only\r\n(Single Hand)";
            this.JoystickPort1Button.UseVisualStyleBackColor = false;
            this.JoystickPort1Button.Click += new System.EventHandler(this.JoystickPort1Button_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(136, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 48);
            this.label1.TabIndex = 5;
            this.label1.Text = " ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(77, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 48);
            this.label2.TabIndex = 2;
            this.label2.Text = " ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(77, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 48);
            this.label3.TabIndex = 3;
            this.label3.Text = " ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(77, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 48);
            this.label4.TabIndex = 6;
            this.label4.Text = " ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 48);
            this.label5.TabIndex = 4;
            this.label5.Text = " ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(490, 356);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 198);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Joystick 2";
            // 
            // Joystick
            // 
            this.Joystick.Controls.Add(this.Right);
            this.Joystick.Controls.Add(this.Up);
            this.Joystick.Controls.Add(this.Down);
            this.Joystick.Controls.Add(this.Fire);
            this.Joystick.Controls.Add(this.Left);
            this.Joystick.Location = new System.Drawing.Point(279, 356);
            this.Joystick.Name = "Joystick";
            this.Joystick.Size = new System.Drawing.Size(205, 198);
            this.Joystick.TabIndex = 16;
            this.Joystick.TabStop = false;
            this.Joystick.Text = "Joystick 1";
            // 
            // Right
            // 
            this.Right.BackColor = System.Drawing.Color.Black;
            this.Right.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Right.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Right.ForeColor = System.Drawing.Color.White;
            this.Right.Location = new System.Drawing.Point(136, 86);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(53, 48);
            this.Right.TabIndex = 5;
            this.Right.Text = "Right";
            this.Right.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Up
            // 
            this.Up.BackColor = System.Drawing.Color.Black;
            this.Up.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Up.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Up.ForeColor = System.Drawing.Color.White;
            this.Up.Location = new System.Drawing.Point(77, 31);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(53, 48);
            this.Up.TabIndex = 2;
            this.Up.Text = "Up";
            this.Up.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Down
            // 
            this.Down.BackColor = System.Drawing.Color.Black;
            this.Down.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Down.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Down.ForeColor = System.Drawing.Color.White;
            this.Down.Location = new System.Drawing.Point(77, 141);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(53, 48);
            this.Down.TabIndex = 3;
            this.Down.Text = "Down";
            this.Down.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Fire
            // 
            this.Fire.BackColor = System.Drawing.Color.Black;
            this.Fire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Fire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Fire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fire.ForeColor = System.Drawing.Color.White;
            this.Fire.Location = new System.Drawing.Point(77, 86);
            this.Fire.Name = "Fire";
            this.Fire.Size = new System.Drawing.Size(53, 48);
            this.Fire.TabIndex = 6;
            this.Fire.Text = "Fire";
            this.Fire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Left
            // 
            this.Left.BackColor = System.Drawing.Color.Black;
            this.Left.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Left.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Left.ForeColor = System.Drawing.Color.White;
            this.Left.Location = new System.Drawing.Point(18, 86);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(53, 48);
            this.Left.TabIndex = 4;
            this.Left.Text = "Left";
            this.Left.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.lDelta);
            this.groupBox1.Controls.Add(this.lDebug);
            this.groupBox1.Controls.Add(this.lFrame);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(10, 354);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 227);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kinect Tracking Data";
            // 
            // lDelta
            // 
            this.lDelta.BackColor = System.Drawing.Color.Transparent;
            this.lDelta.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDelta.ForeColor = System.Drawing.Color.White;
            this.lDelta.Location = new System.Drawing.Point(6, 66);
            this.lDelta.Name = "lDelta";
            this.lDelta.Size = new System.Drawing.Size(253, 23);
            this.lDelta.TabIndex = 23;
            this.lDelta.Text = "--";
            this.lDelta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lDebug
            // 
            this.lDebug.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDebug.ForeColor = System.Drawing.Color.White;
            this.lDebug.Location = new System.Drawing.Point(4, 20);
            this.lDebug.Name = "lDebug";
            this.lDebug.Size = new System.Drawing.Size(251, 23);
            this.lDebug.TabIndex = 24;
            this.lDebug.Text = "--";
            this.lDebug.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lFrame
            // 
            this.lFrame.BackColor = System.Drawing.Color.Transparent;
            this.lFrame.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFrame.ForeColor = System.Drawing.Color.White;
            this.lFrame.Location = new System.Drawing.Point(4, 43);
            this.lFrame.Name = "lFrame";
            this.lFrame.Size = new System.Drawing.Size(253, 23);
            this.lFrame.TabIndex = 22;
            this.lFrame.Text = "--";
            this.lFrame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SerialLabel
            // 
            this.SerialLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.SerialLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.SerialLabel.Name = "SerialLabel";
            this.SerialLabel.Padding = new System.Windows.Forms.Padding(200, 0, 0, 0);
            this.SerialLabel.Size = new System.Drawing.Size(226, 19);
            this.SerialLabel.Text = "---";
            this.SerialLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SerialLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 585);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1198, 24);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(918, 352);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // bStop
            // 
            this.bStop.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStop.ForeColor = System.Drawing.Color.Red;
            this.bStop.Location = new System.Drawing.Point(924, 107);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(112, 69);
            this.bStop.TabIndex = 21;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // cbSeated
            // 
            this.cbSeated.AutoSize = true;
            this.cbSeated.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSeated.ForeColor = System.Drawing.Color.White;
            this.cbSeated.Location = new System.Drawing.Point(924, 84);
            this.cbSeated.Name = "cbSeated";
            this.cbSeated.Size = new System.Drawing.Size(114, 17);
            this.cbSeated.TabIndex = 20;
            this.cbSeated.Text = "Seated Mode";
            this.cbSeated.UseVisualStyleBackColor = true;
            // 
            // bStart
            // 
            this.bStart.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStart.ForeColor = System.Drawing.Color.ForestGreen;
            this.bStart.Location = new System.Drawing.Point(924, 12);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(112, 69);
            this.bStart.TabIndex = 19;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 609);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.cbSeated);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Joystick);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainGUI";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.Joystick.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button JoystickPort2Button;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button JoystickBothPortsButton;
        private System.Windows.Forms.Button JoystickPort1Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox Joystick;
        private System.Windows.Forms.Label Right;
        private System.Windows.Forms.Label Up;
        private System.Windows.Forms.Label Down;
        private System.Windows.Forms.Label Fire;
        private System.Windows.Forms.Label Left;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripStatusLabel SerialLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.CheckBox cbSeated;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label lDelta;
        private System.Windows.Forms.Label lFrame;
        private System.Windows.Forms.Label lDebug;
    }
}

