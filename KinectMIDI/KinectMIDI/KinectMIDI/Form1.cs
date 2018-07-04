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
        MIDIHandler midi = MIDIHandler.Instance;

        public Form1()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            kinect.Initialize(HandleFrame);
            kinect.SetSeatedMode(true);
            midi.InitializeMIDI("Kinect");
        }

        private void HandleFrame(Skeleton[] skeletons, int framenum)
        {
            int l_x_cc = 0;
            int l_y_cc = 0;
            int l_z_cc = 0;

            int r_x_cc = 0; 
            int r_y_cc = 0; 
            int r_z_cc = 0;

            int dist_cc = 0;

            

            // Extract and convert to Point3D format
            List<Player3D> players = KinectHelper.SkeletonsToPlayer3D(skeletons);           

            // MIDI Stuff

            /*
            // Left
            if (left != null)
            { 
                l_x_cc = midi.ValueToMIDI((float)left.X, -0.5f, 0.5f);
                l_y_cc = midi.ValueToMIDI((float)left.Y, -0.1f, 0.5f);
                l_z_cc = midi.ValueToMIDI((float)left.Z, 0.9f, 2.4f);

                midi.SendMIDI(ChannelCommand.Controller, 1, 20, l_x_cc);
                midi.SendMIDI(ChannelCommand.Controller, 1, 21, l_y_cc);
                midi.SendMIDI(ChannelCommand.Controller, 1, 22, l_z_cc);
            }

            // Right
            if (right != null)
            {
                r_x_cc = midi.ValueToMIDI((float)right.X, -0.5f, 0.5f);
                r_y_cc = midi.ValueToMIDI((float)right.Y, -0.1f, 0.5f);
                r_z_cc = midi.ValueToMIDI((float)right.Z, 0.9f, 2.4f);

                midi.SendMIDI(ChannelCommand.Controller, 2, 20, r_x_cc);
                midi.SendMIDI(ChannelCommand.Controller, 2, 21, r_y_cc);
                midi.SendMIDI(ChannelCommand.Controller, 2, 22, r_z_cc);
            }

            // Distance
            xxxx

                dist_cc = midi.ValueToMIDI((float)distance, 0, 1f);
                midi.SendMIDI(ChannelCommand.Controller, 3, 30, dist_cc);
        
            */

            // Update Screen
            UpdateTrackingDetails(players, framenum);

          
        }

        private void UpdateTrackingDetails(List<Player3D> players, int framenum)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate   // runs on UI thread
                {
                    String details = "";
                    lDebug.Text = "Tracked: " + players.Count.ToString();
                    lFrame.Text = "Frame: " + framenum.ToString();

                    foreach (Player3D player in players)
                    {
                        // Body
                        if (player.Body != null)
                        {
                            details += "Body:\n";

                            details += "X = " + player.Body.X.ToString(FormatString) + "\n";
                            details += "Y = " + player.Body.Y.ToString(FormatString) + "\n";
                            details += "Z = " + player.Body.Z.ToString(FormatString) + "\n";
                        }

                        // Left
                        if (player.Left != null)
                        {
                            details += "\n Left:\n";

                            details += "X = " + player.Left.X.ToString(FormatString) + "\n";
                            details += "Y = " + player.Left.Y.ToString(FormatString) + "\n";
                            details += "Z = " + player.Left.Z.ToString(FormatString) + "\n";
                        }

                        // Right
                        if (player.Right != null)
                        {
                            details += "\nRight:\n";

                            details += "X = " + player.Right.X.ToString(FormatString) + "\n";
                            details += "Y = " + player.Right.Y.ToString(FormatString) + "\n";
                            details += "Z = " + player.Right.Z.ToString(FormatString) + "\n";
                        }

                        // Distance
                        details += "\nDistance: " + player.Distance.ToString("00.##");

                        lDetails.Text = details;
                    }
                });
            }
            catch (Exception)
            {
                ;
            }
        }

        /*

                    midi_details += "Left:\n";

                    midi_details +=
                        l_x_cc.ToString() + "\n" +
                        l_y_cc.ToString() + "\n" +
                        l_z_cc.ToString() + "\n";

                    midi_details += "\nRight:\n";

                    midi_details +=
                        r_x_cc.ToString() + "\n" +
                        r_y_cc.ToString() + "\n" +
                        r_z_cc.ToString() + "\n";

                    midi_details += "\nDistance: " + dist_cc.ToString();

                    lMIDI.Text = midi_details;
                });
            }
            
        }
         * 
         */

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
