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
            string details = "";
            string midi_details = "";

            Point3D left = null;
            Point3D right = null;

            int l_x_cc = 0;
            int l_y_cc = 0;
            int l_z_cc = 0;

            int r_x_cc = 0; 
            int r_y_cc = 0; 
            int r_z_cc = 0;

            int dist_cc = 0;

            double distance = 0;

            // Extract and convert to Point3D format

            foreach (Skeleton ske in skeletons)
            {
                if (ske.TrackingState == SkeletonTrackingState.Tracked)
                {
                    foreach (Joint joint in ske.Joints)
                    {
                        if (joint.JointType == JointType.HandLeft)
                        {
                            left = KinectHelper.JointToPoint3D(joint);
                        }
                        
                        if (joint.JointType == JointType.HandRight)
                        {
                            right = KinectHelper.JointToPoint3D(joint);
                        }
                    }
                }
            }

            // MIDI Stuff

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
            if ((left != null) && (right != null))
            {
                double diffx = left.X - right.X;
                double diffy = left.Y - right.Y;

                distance = Math.Sqrt(diffx * diffx + diffy * diffy);

                dist_cc = midi.ValueToMIDI((float)distance, 0, 1f);
                midi.SendMIDI(ChannelCommand.Controller, 3, 30, dist_cc);
            }


            // Update Screen

            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lDebug.Text = skeletons.Length.ToString() + " :: " + framenum.ToString(); // runs on UI thread

                    // Left
                    if (left != null)
                    {
                        details += "Left:\n";

                        details += left.X.ToString("X = 00.##") + "\n";
                        details += left.Y.ToString("00.##") + "\n";
                        details += left.Z.ToString("00.##") + "\n";
                    }

                    // Right
                    if (right != null)
                    {
                        details += "\nRight:\n";

                        details += right.X.ToString("00.##") + "\n";
                        details += right.Y.ToString("00.##") + "\n";
                        details += right.Z.ToString("00.##") + "\n";
                    }

                    details += "\nDistance: " + distance.ToString("00.##");

                    lDetails.Text = details;

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
            catch (Exception)
            {
                ;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
