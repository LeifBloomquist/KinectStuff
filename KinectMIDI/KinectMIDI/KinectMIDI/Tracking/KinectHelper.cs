﻿using System;
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
        Action<Skeleton[], int> callback;

        public void Initialize(Action<Skeleton[], int> callback)
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

        private void Stop()
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
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                    callback(skeletons, skeletonFrame.FrameNumber);
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

        // Place *Tracked Skeletons Only* into a List
        public static List<Player3D> SkeletonsToPlayer3D(Skeleton[] skeletons)
        {
            List<Player3D> players = new List<Player3D>();

            foreach (Skeleton ske in skeletons)
            {
                if (ske.TrackingState == SkeletonTrackingState.Tracked)
                {
                    Player3D new_player = new Player3D();
                    new_player.Body = SkeletonToPoint3D(ske);

                    foreach (Joint joint in ske.Joints)
                    {
                        switch (joint.JointType)
                        {
                            case JointType.HandLeft:
                                new_player.Left = JointToPoint3D(joint);
                                break;

                            case JointType.HandRight:
                                new_player.Right = JointToPoint3D(joint);
                                break;
                        }
                    }

                    new_player.calcDistance();
                    players.Add(new_player);
                }
            }

            return players;
        }

        private static Point3D SkeletonToPoint3D(Skeleton ske)
        {
            Point3D ret = new Point3D();
            ret.X = (double)ske.Position.X;
            ret.Y = (double)ske.Position.Y;
            ret.Z = (double)ske.Position.Z;
            return ret;
        }

        public static Point3D JointToPoint3D(Joint joint)
        {
            Point3D ret = new Point3D();
            ret.X = (double)joint.Position.X;
            ret.Y = (double)joint.Position.Y;
            ret.Z = (double)joint.Position.Z;
            return ret;
        }
    }
}