using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchemaFactor;
using Sanford.Multimedia.Midi;

namespace KinectMIDI
{
    public partial class Form1 : Form
    {
        public const String FormatString = "+00.00;-00.00";     

        KinectHelper kinect = new KinectHelper();     

        public Form1()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            MIDIProcessor.StartMIDI();
            kinect.Initialize(HandleFrame);
            kinect.SetSeatedMode(cbSeated.Checked);
            bStart.Enabled = false;
            bStop.Enabled = true;
        }

        private void HandleFrame(Skeleton[] skeletons, int framenum, long timeDelta_ms)
        {
            // Extract and convert to Point3D format
            List<Player3D> players = kinect.SkeletonsToPlayer3D(skeletons, timeDelta_ms);

          //  kinect.num_tracked = 2;
         //   players[1] = players[0];

            // Update Screen
            UpdateTrackingDetails(players, framenum, timeDelta_ms);

            // MIDI Processing
            
            // TODO String midi_output = MIDIProcessor.ProcessMIDI(players, kinect.num_tracked);

            // Update Screen
            //UpdateMIDIDetails(players, midi_output);
        }

        private void UpdateTrackingDetails(List<Player3D> players, int framenum, long delta)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate   // runs on UI thread
                {
                    lDebug.Text = "Tracked: " + players.Count;
                    lFrame.Text = "Frame: " + framenum.ToString();
                    lDelta.Text = "Delta: " + delta.ToString();

                    if (players.Count >= 1) lDetails0.Text = UpdatePlayerDetails(players[0]);
                    if (players.Count >= 2) lDetails1.Text = UpdatePlayerDetails(players[1]);
                });
            }
            catch (Exception)
            {
                ;
            }
        }

        private String UpdatePlayerDetails(Player3D player)
        {
            string details = "";

            details += "Head:\n";
            details += "X = " + player.Head.X.ToString(FormatString) + "\n";
            details += "Y = " + player.Head.Y.ToString(FormatString) + "\n";
            details += "Z = " + player.Head.Z.ToString(FormatString) + "\n";
            details += "V = " + player.Head.V.ToString(FormatString) + "\n";

            details += "\nLeft:\n";
            details += "X = " + player.Left.X.ToString(FormatString) + "\n";
            details += "Y = " + player.Left.Y.ToString(FormatString) + "\n";
            details += "Z = " + player.Left.Z.ToString(FormatString) + "\n";
            details += "V = " + player.Left.V.ToString(FormatString) + "\n";

            details += "\nRight:\n";
            details += "X = " + player.Right.X.ToString(FormatString) + "\n";
            details += "Y = " + player.Right.Y.ToString(FormatString) + "\n";
            details += "Z = " + player.Right.Z.ToString(FormatString) + "\n";
            details += "V = " + player.Right.V.ToString(FormatString) + "\n";

            // Distance
            details += "\nDistance:\n" + player.HandDistance.ToString(FormatString);

            return details;
        }

        private void UpdateMIDIDetails(List<Player3D> players, String details)
        {
            if (details == "") return;

            try
            {
                this.Invoke((MethodInvoker)delegate   // runs on UI thread
                {
                    String[] details_ = details.Split('*');
                    lMIDI0.Text = details_[0];
                    lMIDI1.Text = details_[1];
                });
            }
            catch (Exception)
            {
                ;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            kinect.Stop();
            bStart.Enabled = true;
            bStop.Enabled = false;
        }
    }
}
