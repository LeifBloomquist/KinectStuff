using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectMIDI
{
    public struct Player3D
    {
        public Point3D Left;   // { get; set; }
        public Point3D Right;  // { get; set; }
        public Point3D Head;   // { get; set; }
        public Point3D Spine;   // { get; set; }
        public double HandDistance { get; private set; }

        // For velocity calcs
        private Point3D Left0; 
        private Point3D Right0;
        private Point3D Head0; 

        public void calcDistance()
        {
       //     if ((Left != null) && (Right != null))
    //        {
                double diffx = Left.X - Right.X;
                double diffy = Left.Y - Right.Y;

                HandDistance = Math.Sqrt(diffx * diffx + diffy * diffy);
     //       }
     //       else
    //        {
   //             HandDistance = 0;
   //         }
        }

        public void calcVelocity(double timeDelta_s)
        {
        //    if ((Left != null) && (Right != null) && (Head != null))
       //     { 
            Left.V = calcPointVelocity(Left, Left0, timeDelta_s);
            Right.V = calcPointVelocity(Right, Right0, timeDelta_s);
            Head.V = calcPointVelocity(Head, Head0, timeDelta_s);

           // Console.WriteLine("Right.V = " + Right.V);
            
                // Save for next iteration
                Left0 = Left; 
                Right0 = Right;
                Head0 = Head;
    //        }
        }

        private double calcPointVelocity(Point3D current, Point3D last, double timeDelta_s)
        {
 //           if (last == null) // First time through
 //           {
 //               return 0d;
 //           }

            double diffx = current.X - last.X;
            double diffy = current.Y - last.Y;
            double diffz = current.Z - last.Z;

            double distanceMoved = Math.Sqrt(diffx * diffx + diffy * diffy + diffz * diffz);
            double velocity_s = distanceMoved / timeDelta_s;
            return velocity_s;
        }
    }
}
