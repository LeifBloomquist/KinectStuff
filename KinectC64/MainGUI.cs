using KinectC64.Network;
using KinectMIDI;
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

namespace KinectC64
{
    public partial class MainGUI : Form
    {
        private const String ADDRESS = "192.168.4.1";
        UDPSender udp = new UDPSender(ADDRESS, 6464);

        public const String FormatString = "+00.00;-00.00";   

        KinectHelper kinect = new KinectHelper();

        System.Drawing.Graphics graphicsObj = null;
        Pen whitePen = new Pen(System.Drawing.Color.White, 5);
        Pen redPen = new Pen(System.Drawing.Color.Red, 5);
        Pen yellowPen = new Pen(System.Drawing.Color.Yellow, 5);
        Pen greenPen = new Pen(System.Drawing.Color.Green, 5);
        Pen bluePen = new Pen(System.Drawing.Color.LightBlue, 5);

        byte activePort = 0;

        float tempx, tempy, tempz;

        public MainGUI()
        {
            InitializeComponent();

            graphicsObj = pictureBox1.CreateGraphics();

            tempx = (pictureBox1.Width / 2f);
            tempy = (pictureBox1.Height / 2f);
            tempz = 100f;
        }   

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Animate();           
        }

        private void DrawPoint(Point3D J, Pen color)
        {
            float cx = (pictureBox1.Width / 2f);
            float cy = (pictureBox1.Height / 2f);

            // Left Hand Position

            float px = cx + (float)J.X * 500f;
            float py = cy - (float)J.Y * 500f;  // Invert for graphicsObj
            float ps = (float) J.Z * 40f;

            try
            {
                graphicsObj.DrawEllipse(color, px, py, ps, ps);
            }
            catch { }
        }        

        private void Animate(List<Player3D> players)
        {
          if (graphicsObj == null) return;

          try
          {
              graphicsObj.Clear(Color.Black);
          }
          catch { }

          Pen vel_pen = whitePen;

          foreach (Player3D p3d in players)
          {
              DrawPoint(p3d.Left, greenPen);
              DrawPoint(p3d.Right, bluePen);
              DrawPoint(p3d.Head, whitePen);
              DrawPoint(p3d.Spine, yellowPen);


              // Motion

              /*
            float mx = (pictureBox1.Width / 2f) + hand.velX;
            float my =  - hand.velY;
            float msize = 5 + (hand.pinch * 10f);

            float kx = (float)kal_x.update(mx);
            float ky = (float)kal_y.update(my);
          

            graphicsObj.DrawEllipse(vel_pen, kx, ky, msize, msize);
          
           * 
           * */
          }
        }

        private void DoJoystick(List<Player3D> players)
        {
            var motion = new byte[2] {0,0};

            toggle(Up, false);
            toggle(Down, false);
            toggle(Left, false);
            toggle(Right, false);
            toggle(Fire, false, Color.Red);

            if (udp == null)
            {
                return;
            }

            switch (activePort)
            {
                case 1:
                    if (players.Count >= 1)
                    {
                        motion[0] = getMotions(players.ElementAt(0));
                    }
                    break;

                case 2:
                    if (players.Count >= 1)
                    {
                        motion[1] = getMotions(players.ElementAt(0));
                    }
                    motion[1] = getMotions(players.ElementAt(0));
                    break;

                case 3:
                    motion[0] = getMotions(players.ElementAt(0));
                    motion[1] = getMotions(players.ElementAt(1));
                    break;
            }
          
            // UniJoysticle Protocol V2
            byte[] packet = new byte[4];
            packet[0] = 2;                 // V2
            packet[1] = activePort; 
            packet[2] = motion[0];
            packet[3] = motion[1];
            udp.sendData(packet);

            SerialLabel.Text = "Sending: " + BitConverter.ToString(packet) + " to " + ADDRESS;
        }

        
        private byte getMotions(Player3D player)
        {       
            const float threshold = 0.1f;
            const float thresholdf = 0.4f;

            byte temp=0;
            bool up = false, down = false, left = false, right = false, fire = false;

            if ((player.Right.X - player.Spine.X) > threshold) right = true;
            if ((player.Spine.X - player.Right.X) > threshold) left = true;
            if ((player.Right.Y - player.Spine.Y) > threshold) up = true;
            if ((player.Spine.Y - player.Right.Y) > threshold) down = true;
            if ((player.Spine.Z - player.Right.Z) > (thresholdf)) fire = true;

            toggle(Up, up);
            toggle(Down, down);
            toggle(Left, left);
            toggle(Right, right);
            toggle(Fire, fire, Color.Red);

            if (up) temp    |= 0x01;
            if (down) temp  |= 0x02;
            if (left) temp  |= 0x04;
            if (right) temp |= 0x08;
            if (fire) temp  |= 0x10;

            return temp;
        }

        private void toggle(Control c, Boolean state, Color color)
        {
            if (state)
            {
                c.BackColor = color;
            }
            else
            {
                c.BackColor = Color.Black;
            }
        }

        private void toggle(Control c, Boolean state)
        {
            toggle(c, state, Color.Green);
        }

        private void JoystickPort1Button_Click(object sender, EventArgs e)
        {
          activePort = 1;
          UpdateModeButtons();
        }

        private void JoystickPort2Button_Click(object sender, EventArgs e)
        {
          activePort = 2;
          UpdateModeButtons();
        }

        private void JoystickBothPortsButton_Click(object sender, EventArgs e)
        {
          activePort = 3;
          UpdateModeButtons();
        }

        private void UpdateModeButtons()
        {
            switch (activePort)
            {
              case 0: 
                JoystickPort1Button.BackColor = SystemColors.Control;
                JoystickPort2Button.BackColor = SystemColors.Control;
                JoystickBothPortsButton.BackColor = SystemColors.Control;
                break;

              case 1:
                JoystickPort1Button.BackColor = Color.LightGreen;
                JoystickPort2Button.BackColor = SystemColors.Control;
                JoystickBothPortsButton.BackColor = SystemColors.Control;
                break;

              case 2:
                JoystickPort1Button.BackColor = SystemColors.Control;
                JoystickPort2Button.BackColor = Color.LightGreen;
                JoystickBothPortsButton.BackColor = SystemColors.Control;
                break;

              case 3:
                JoystickPort1Button.BackColor = SystemColors.Control;
                JoystickPort2Button.BackColor = SystemColors.Control;
                JoystickBothPortsButton.BackColor = Color.LightGreen;
                break;

              default:
                JoystickPort1Button.BackColor = Color.Red;
                JoystickPort2Button.BackColor = Color.Red;
                JoystickBothPortsButton.BackColor = Color.Red;
                break;
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            kinect.Initialize(HandleFrame);
            kinect.SetSeatedMode(cbSeated.Checked);
            bStart.Enabled = false;
            bStop.Enabled = true;
        }

        private void HandleFrame(Skeleton[] skeletons, int framenum, long timeDelta_ms)
        {
            // Extract and convert to Point3D format
            List<Player3D> players = kinect.SkeletonsToPlayer3D(skeletons, timeDelta_ms);

            // Update Screen
            UpdateTrackingDetails(players, framenum, timeDelta_ms);

            // Animation
            Animate(players);

            // Joystick Emulation
            DoJoystick(players);
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

                    //if (players.Count >= 1) lDetails0.Text = UpdatePlayerDetails(players[0]);
                   // if (players.Count >= 2) lDetails1.Text = UpdatePlayerDetails(players[1]);
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

        private void bStop_Click(object sender, EventArgs e)
        {
            kinect.Stop();
            bStart.Enabled = true;
            bStop.Enabled = false;
        }
    }
}
