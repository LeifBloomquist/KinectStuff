using Sanford.Multimedia.Midi;
using SchemaFactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectMIDI
{
    class MIDIProcessor
    {
        // MIDI note values for the C Major Pentatonic Scale.
        public static byte[] pentatonic = { //C   D  E  G  A 
                                           0,  2, 4, 7, 9,       // Octave 0
                                           12,14,16,19,21,       // Octave 1
                                           24,26,28,31,33,       // Octave 2
                                           36,38,40,43,45,       // Octave 3
                                           48,50,52,55,57,       // Octave 4
                                           60,62,64,67,69,       // Octave 5
                                           72,74,76,79,81,       // Octave 6
                                           84,86,88,91,93,       // Octave 7
                                           96,98,100,103,105,    // Octave 8
                                           108,110,112,115,117,  // Octave 9
                                           120,122,124,127,      // Octave 10
                                        };

        private const String MIDIFormatString = "000";

        // MIDI Stuff
        static MIDIHandler midi = MIDIHandler.Instance;

        public static void StartMIDI()
        {
            midi.InitializeMIDI("Kinect");
        }

        public static String ProcessMIDI(List<Player3D> players)
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

            for (int i = 0; i < player_array.Length; i++)
            {
                // Body
                if (player_array[i].Head != null)
                {
                    b_x_cc = midi.ValueToMIDI((float)player_array[i].Head.X, -0.5f, 0.5f);
                    b_y_cc = midi.ValueToMIDI((float)player_array[i].Head.Y, -0.1f, 0.5f);
                    b_z_cc = midi.ValueToMIDI((float)player_array[i].Head.Z, 0.9f, 2.4f);

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

                dist_cc = midi.ValueToMIDI((float)player_array[i].HandDistance, 0f, 1f);
                midi.SendMIDI(ChannelCommand.Controller, i, 50, dist_cc);


                // TODO - Detect jumps, claps, etc.  *******


                // Update Screen
                string details = "";

                // Body
                if (player_array[i].Head != null)
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
                details += "\nDistance:\n" + player_array[i].HandDistance.ToString(MIDIFormatString);               
            }

            return "blah"; // details;
        }
    }
}
