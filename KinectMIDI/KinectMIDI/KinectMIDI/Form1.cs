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
        public const String MIDIFormatString = "000";

        KinectHelper kinect = new KinectHelper();
        MIDIHandler midi = MIDIHandler.Instance;

        public Form1()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            kinect.Initialize(HandleFrame);
            kinect.SetSeatedMode(cbSeated.Checked);
            midi.InitializeMIDI("Kinect");
        }

        private void HandleFrame(Skeleton[] skeletons, int framenum)
        {
            // Extract and convert to Point3D format
            List<Player3D> players = KinectHelper.SkeletonsToPlayer3D(skeletons);

            // Update Screen
            UpdateTrackingDetails(players, framenum);

            // MIDI Processing + Updates Screen
            ProcessMIDI(players);
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
                            details += "\nLeft:\n";

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
                        details += "\nDistance:\n" + player.Distance.ToString("00.##");

                        lDetails.Text = details;
                    }
                });
            }
            catch (Exception)
            {
                ;
            }
        }

        // MIDI Stuff

        private void ProcessMIDI(List<Player3D> players)
        {
            Player3D[] player_array = players.ToArray();

            int l_x_cc = 0;
            int l_y_cc = 0;
            int l_z_cc = 0;

            int r_x_cc = 0;
            int r_y_cc = 0;
            int r_z_cc = 0;

            int b_x_cc = 0;
            int b_y_cc = 0;
            int b_z_cc = 0;

            int dist_cc = 0;

            for (int i=0; i< player_array.Length; i++)
            {
                // Body
                if (player_array[i].Body != null)
                {
                    b_x_cc = midi.ValueToMIDI((float)player_array[i].Body.X, -0.5f, 0.5f);
                    b_y_cc = midi.ValueToMIDI((float)player_array[i].Body.Y, -0.1f, 0.5f);
                    b_z_cc = midi.ValueToMIDI((float)player_array[i].Body.Z, 0.9f, 2.4f);

                    midi.SendMIDI(ChannelCommand.Controller, i, 20, b_x_cc);
                    midi.SendMIDI(ChannelCommand.Controller, i, 21, b_y_cc);
                    midi.SendMIDI(ChannelCommand.Controller, i, 22, b_z_cc);
                }

                // Left
                if (player_array[i].Left != null)
                {
                    l_x_cc = midi.ValueToMIDI((float)player_array[i].Left.X, -0.5f, 0.5f);
                    l_y_cc = midi.ValueToMIDI((float)player_array[i].Left.Y, -0.1f, 0.5f);
                    l_z_cc = midi.ValueToMIDI((float)player_array[i].Left.Z, 0.9f, 2.4f);

                    midi.SendMIDI(ChannelCommand.Controller, i, 30, l_x_cc);
                    midi.SendMIDI(ChannelCommand.Controller, i, 31, l_y_cc);
                    midi.SendMIDI(ChannelCommand.Controller, i, 32, l_z_cc);
                }

                // Right
                if (player_array[i].Right != null)
                {
                    r_x_cc = midi.ValueToMIDI((float)player_array[i].Right.X, -0.5f, 0.5f);
                    r_y_cc = midi.ValueToMIDI((float)player_array[i].Right.Y, -0.1f, 0.5f);
                    r_z_cc = midi.ValueToMIDI((float)player_array[i].Right.Z, 0.9f, 2.4f);

                    midi.SendMIDI(ChannelCommand.Controller, i, 40, r_x_cc);
                    midi.SendMIDI(ChannelCommand.Controller, i, 41, r_y_cc);
                    midi.SendMIDI(ChannelCommand.Controller, i, 42, r_z_cc);
                }

                // Distance

                dist_cc = midi.ValueToMIDI((float)player_array[i].Distance, 0f, 1f);
                midi.SendMIDI(ChannelCommand.Controller, i, 50, dist_cc);
           

                // TODO - Detect jumps, claps, etc.  *******


                // Update Screen
                string details = "";

                // Body
                if (player_array[i].Body != null)
                {
                    details += "Body:\n";

                    details += "X = " + b_x_cc.ToString(MIDIFormatString) + "\n";
                    details += "Y = " + b_y_cc.ToString(MIDIFormatString) + "\n";
                    details += "Z = " + b_z_cc.ToString(MIDIFormatString) + "\n";
                }

                // Left
                if (player_array[i].Left != null)
                {
                    details += "\nLeft:\n";

                    details += "X = " + l_x_cc.ToString(MIDIFormatString) + "\n";
                    details += "Y = " + l_y_cc.ToString(MIDIFormatString) + "\n";
                    details += "Z = " + l_z_cc.ToString(MIDIFormatString) + "\n";
                }

                // Right
                if (player_array[i].Right != null)
                {
                    details += "\nRight:\n";

                    details += "X = " + r_x_cc.ToString(MIDIFormatString) + "\n";
                    details += "Y = " + r_y_cc.ToString(MIDIFormatString) + "\n";
                    details += "Z = " + r_z_cc.ToString(MIDIFormatString) + "\n";
                }

                // Distance
                details += "\nDistance:\n" + player_array[i].Distance.ToString(MIDIFormatString);
                lMIDI.Text = details;
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
    }
}
