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

            System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();            
            aTimer.Tick += new EventHandler(OnTimedEvent);
            aTimer.Interval=10;
            aTimer.Enabled=true;
        }   

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, EventArgs e)
        {
            Animate();            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Animate();           
        }

        private void Animate()
        {
          if (graphicsObj == null) return;
          graphicsObj.Clear(Color.Black);

          Pen pos_pen = whitePen;
          Pen vel_pen = whitePen;

          /*foreach (myHand hand in leap.hands)
          {
            if (hand.isLeft)
            {
              pos_pen = redPen;
              vel_pen = yellowPen;
            }
            else if (hand.isRight)
            {
              pos_pen = greenPen;
              vel_pen = bluePen;
            }
            else // ?
            {
              return;
            }

            // Position

            float px = (pictureBox1.Width / 2f) + hand.posX;
            float py = (pictureBox1.Height) - hand.posY;
            float psize = 50 + (hand.posZ);
            try
            {
              graphicsObj.DrawEllipse(pos_pen, px, py, psize, psize);
            }
            catch { }

            // Motion

            float mx = (pictureBox1.Width / 2f) + hand.velX;
            float my = (pictureBox1.Height / 2f) - hand.velY;
            float msize = 5 + (hand.pinch * 10f);

            float kx = (float)kal_x.update(mx);
            float ky = (float)kal_y.update(my);

            graphicsObj.DrawEllipse(vel_pen, kx, ky, msize, msize);
          }
           * 
           * */
        }

        private void DoJoystick(List<Player3D> players)
        {
            var motion = new byte[2] {0,0};

            if (udp == null)
            {
                return;
            }

            if (players.Count == 0)
            {
                motion[0] = 0;
                motion[1] = 0;
            }
            else
            {
                switch (activePort)
                {
                    case 1:
                        motion[0] = getMotions(players.ElementAt(0));
                        break;

                    case 2:
                        motion[1] = getMotions(players.ElementAt(0));
                        break;

                     case 3:
                        motion[0] = getMotions(players.ElementAt(0));
                        motion[1] = getMotions(players.ElementAt(1));
                        break;
                }
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

            byte temp=0;
            bool up = false, down = false, left = false, right = false, fire = false;

            if ((player.Right.X - player.Head.X)  > threshold) right = true;
            if ((player.Head.X  - player.Right.X) > threshold) left = true;
            if ((player.Right.Y - player.Head.Y)  > threshold) up = true;
            if ((player.Head.Y  - player.Right.Y) > threshold) down = true;

            toggle(Up, up);
            toggle(Down, down);
            toggle(Left, left);
            toggle(Right, right);
            toggle(Fire, fire, Color.Red);

            if (up) temp |= 0x01;
            if (down) temp |= 0x02;
            if (left) temp |= 0x04;
            if (right) temp |= 0x08;
            if (fire) temp |= 0x10;

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

            // Joystick Emulation
            DoJoystick(players);
        }

        private void UpdateTrackingDetails(List<Player3D> players, int framenum, long delta)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate   // runs on UI thread
                {
                    lDebug.Text = "Tracked: " + kinect.num_tracked.ToString();
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
