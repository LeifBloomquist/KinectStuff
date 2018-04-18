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
            kinect.SetSeatedMode(false);
            midi.InitializeMIDI("Kinect");
        }

        private void HandleFrame(Skeleton[] skeletons, int framenum)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lDebug.Text = skeletons.Length.ToString() + " :: " + framenum.ToString(); // runs on UI thread

                    string details = "";

                    foreach (Skeleton ske in skeletons)
                    {
                        if (ske.TrackingState == SkeletonTrackingState.Tracked)
                        {
                            details += "Tracked!\n\n";

                            foreach (Joint joint in ske.Joints)
                            {
                                //on regarde si ce joint nous intéresse (en l’occurrence, la main gauche ici)
                                if (joint.JointType == JointType.HandLeft)
                                {
                                    float x = joint.Position.X;
                                    float y = joint.Position.Y;
                                    float z = joint.Position.Z;

                                    //on récupère les coordonnées de ce joint. Perso j'affiche ça dans des label.
                                    details += x.ToString("00.##") + "\n";
                                    details += y.ToString("00.##") + "\n";
                                    details += z.ToString("00.##");

                                    int x_cc = midi.ValueToMIDI(x, -0.5f, 0.5f);
                                    int y_cc = midi.ValueToMIDI(y, -0.1f, 0.5f);
                                    int z_cc = midi.ValueToMIDI(z, 0.9f, 1.4f);

                                    midi.SendMIDI(ChannelCommand.Controller, 1, 20, x_cc);
                                    midi.SendMIDI(ChannelCommand.Controller, 1, 21, y_cc);
                                    midi.SendMIDI(ChannelCommand.Controller, 1, 22, z_cc);

                                    lMIDI.Text = x_cc.ToString() + "\n" +
                                        y_cc.ToString() + "\n" +
                                        z_cc.ToString() + "\n";
                                }

                                //autres squelettes, etc
                            }
                        }
                    }

                    lDetails.Text = details;
                });

            }
            catch (Exception)
            {
                ;
            }
        }
    }
}
