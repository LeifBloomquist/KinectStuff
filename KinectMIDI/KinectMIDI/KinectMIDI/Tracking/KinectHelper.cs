using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace KinectMIDI
{
    class KinectHelper
    {
        private KinectSensor sensor;
        Action<Skeleton[], int, long> callback;

        private long lastTimeStamp = 0;  // milliseconds

        // The array of players
        Player3D[] players = new Player3D[1];

        public void Initialize(Action<Skeleton[], int, long> callback)
        {
            this.callback = callback;

            // Look through all sensors and start the first connected one.
            // This requires that a Kinect is connected at the time of app startup.
            // To make your app robust against plug/unplug, 
            // it is recommended to use KinectSensorChooser provided in Microsoft.Kinect.Toolkit (See components in Toolkit Browser).
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    break;
                }
            }

            if (null != this.sensor)
            {
                // Turn on the skeleton stream to receive skeleton frames
                this.sensor.SkeletonStream.Enable();

                // Add an event handler to be called whenever there is new color frame data
                this.sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;

                // Start the sensor!
                try
                {
                    this.sensor.Start();
                }
                catch (IOException)
                {
                    this.sensor = null;
                }
            }

            if (null == this.sensor)
            {
                MessageBox.Show("Warning: No Kinect Detected!");
            }
        }

        public void Stop()
        {
            if (null != this.sensor)
            {
                this.sensor.Stop();
            }
        }

        /// <summary>
        /// Event handler for Kinect sensor's SkeletonFrameReady event
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())  // using auto-disposes when done
            {
                if (skeletonFrame != null)
                {
                    long timeDelta = skeletonFrame.Timestamp - lastTimeStamp;

                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                    callback(skeletons, skeletonFrame.FrameNumber, timeDelta);

                    lastTimeStamp = skeletonFrame.Timestamp;
                }
            }
        }

        /// <summary>
        /// Maps a SkeletonPoint to lie within our render space and converts to Point
        /// </summary>
        /// <param name="skelpoint">point to map</param>
        /// <returns>mapped point</returns>
        private Point SkeletonPointToScreen(SkeletonPoint skelpoint)
        {
            // Convert point to depth space.  
            // We are not using depth directly, but we do want the points in our 640x480 output resolution.
            DepthImagePoint depthPoint = this.sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(skelpoint, DepthImageFormat.Resolution640x480Fps30);
            return new Point(depthPoint.X, depthPoint.Y);
        }

        public void SetSeatedMode(bool seated)
        {
            if (null != this.sensor)
            {
                if (seated)
                {
                    this.sensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
                }
                else
                {
                    this.sensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Default;
                }
            }
        }

        // Place *Tracked Skeletons Only* into the player array
        public List<Player3D> SkeletonsToPlayer3D(Skeleton[] skeletons, long timeDelta_ms)
        {
            int offset = 0;

            foreach (Skeleton ske in skeletons)
            {
                if (ske.TrackingState == SkeletonTrackingState.Tracked)
                {
                    foreach (Joint joint in ske.Joints)
                    {
                        switch (joint.JointType)
                        {
                            case JointType.HandLeft:
                                JointToPoint3D(ref players[offset].Left, joint);
                                break;

                            case JointType.HandRight:
                                JointToPoint3D(ref players[offset].Right, joint);
                                break;

                            case JointType.Head:
                                JointToPoint3D(ref players[offset].Head, joint);
                                break;
                        }
                    }

                    players[offset].calcDistance();
                    offset++;
                }
            }

            // Calculate velocity of all the joints
            CalculateVelocities(timeDelta_ms);

            return new List<Player3D>(players);
        }
        
        private void CalculateVelocities(long timeDelta_ms)
        {
            double timeDelta_s = timeDelta_ms / 1000d;

            players[0].calcVelocity(timeDelta_s);
            //players[1].calcVelocity(timeDelta_s);

            /*
            foreach (Player3D player in players)
            {
                player[0].calcVelocity(timeDelta_s);
            }
             * */
        }

         

       /*
        * private static Point3D SkeletonToPoint3D(Skeleton ske)
        {
            Point3D ret = new Point3D();
            ret.X = (double)ske.Position.X;
            ret.Y = (double)ske.Position.Y;
            ret.Z = (double)ske.Position.Z;
            return ret;
        }
        * */

        public static void JointToPoint3D(ref Point3D point, Joint joint)
        {
     //       if (point == null) return;

            point.X = (double)joint.Position.X;
            point.Y = (double)joint.Position.Y;
            point.Z = (double)joint.Position.Z;          
        }
    }
}