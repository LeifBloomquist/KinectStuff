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
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 12);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(112, 48);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // lDebug
            // 
            this.lDebug.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lDebug.Location = new System.Drawing.Point(130, 25);
            this.lDebug.Name = "lDebug";
            this.lDebug.Size = new System.Drawing.Size(217, 23);
            this.lDebug.TabIndex = 1;
            this.lDebug.Text = "--";
            this.lDebug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lDetails
            // 
            this.lDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDetails.Location = new System.Drawing.Point(12, 76);
            this.lDetails.Name = "lDetails";
            this.lDetails.Size = new System.Drawing.Size(335, 475);
            this.lDetails.TabIndex = 2;
            this.lDetails.Text = "--";
            // 
            // lMIDI
            // 
            this.lMIDI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lMIDI.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMIDI.Location = new System.Drawing.Point(371, 76);
            this.lMIDI.Name = "lMIDI";
            this.lMIDI.Size = new System.Drawing.Size(335, 475);
            this.lMIDI.TabIndex = 3;
            this.lMIDI.Text = "--";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 560);
            this.Controls.Add(this.lMIDI);
            this.Controls.Add(this.lDetails);
            this.Controls.Add(this.lDebug);
            this.Controls.Add(this.bStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label lDebug;
        private System.Windows.Forms.Label lDetails;
        private System.Windows.Forms.Label lMIDI;
    }
}

