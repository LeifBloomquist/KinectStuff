using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectMIDI
{
    public class Player3D
    {
        public Point3D Left    { get; set; }
        public Point3D Right   { get; set; }
        public Point3D Body    { get; set; }
        public double Distance { get; private set; }

        public void calcDistance()
        {
            if ((Left != null) && (Right != null))
            {
                double diffx = Left.X - Right.X;
                double diffy = Left.Y - Right.Y;

                Distance = Math.Sqrt(diffx * diffx + diffy * diffy);
            }
            else
            {
                Distance = 0;
            }
        }
    }
}
