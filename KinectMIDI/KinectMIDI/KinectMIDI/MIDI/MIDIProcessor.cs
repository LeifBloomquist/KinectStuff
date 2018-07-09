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
                             //              0,  2, 4, 7, 9,       // Octave 0
                             //             12,14,16,19,21,       // Octave 1
                             //              24,26,28,31,33,       // Octave 2
                          //                 36,38,40,43,45,       // Octave 3
                                           48,50,52,55,57,       // Octave 4
                                           60,62,64,67,69,       // Octave 5
                                           72,74,76,79,81,       // Octave 6
                                           84,86,88,91,93       // Octave 7
                           //                96,98,100,103,105    // Octave 8
                           //                108,110,112,115,117  // Octave 9
                           //                120,122,124,127,      // Octave 10
                                        };

        private const String MIDIFormatString = "000";

        private static double[] velocity_right = new double[10];
        private static double[] velocity_left = new double[10];


        // MIDI Stuff
        static MIDIHandler midi = MIDIHandler.Instance;

        public static void StartMIDI()
        {
            midi.InitializeMIDI("Kinect");
        }

        public static String ProcessMIDI(List<Player3D> players, int num)
        {
            string details = "";

            Player3D[] player_array = players.ToArray();

          //  player_array[1] = player_array[0]; num = 2;

                
            int l_x_cc = 0;
            int l_y_cc = 0;
            int l_z_cc = 0;
            int l_v_cc = 0;

            int r_x_cc = 0;
            int r_y_cc = 0;
            int r_z_cc = 0;
            int r_v_cc = 0;

            int b_x_cc = 0;
            int b_y_cc = 0;
            int b_z_cc = 0;
            int b_v_cc = 0;

            int dist_cc = 0;

            for (int i = 0; i < num; i++) //player_array.Length; i++)
            {
              //  if (i == 0) { i = 1; details += "*"; };
                // Head

                b_x_cc = midi.ValueToMIDI((float)player_array[i].Head.X, -1f, 1f); //-0.5f, 0.5f);
                b_y_cc = midi.ValueToMIDI((float)player_array[i].Head.Y, -1f, 1f); //-0.1f, 0.5f);
                b_z_cc = midi.ValueToMIDI((float)player_array[i].Head.Z,  0f, 3f); //0.9f, 2.4f);
                b_v_cc = midi.ValueToMIDI((float)player_array[i].Head.V,  0f, 1f);

                midi.SendMIDI(ChannelCommand.Controller, i, 20, b_x_cc);
                midi.SendMIDI(ChannelCommand.Controller, i, 21, b_y_cc);
                midi.SendMIDI(ChannelCommand.Controller, i, 22, b_z_cc);
                midi.SendMIDI(ChannelCommand.Controller, i, 23, b_v_cc);

                // Left
                l_x_cc = midi.ValueToMIDI((float)player_array[i].Left.X, -1f, 1f);  // -0.5f, 0.5f);
                l_y_cc = midi.ValueToMIDI((float)player_array[i].Left.Y, -1f, 1f);  // -0.1f, 0.5f);
                l_z_cc = midi.ValueToMIDI((float)player_array[i].Left.Z,  0f, 3f);  // 0.9f, 2.4f);
                l_v_cc = midi.ValueToMIDI((float)player_array[i].Left.V, 0.0f, 3.0f);

                midi.SendMIDI(ChannelCommand.Controller, i, 30, l_x_cc);
                midi.SendMIDI(ChannelCommand.Controller, i, 31, l_y_cc);
                midi.SendMIDI(ChannelCommand.Controller, i, 32, l_z_cc);
                midi.SendMIDI(ChannelCommand.Controller, i, 33, l_v_cc);

                // Right
                r_x_cc = midi.ValueToMIDI((float)player_array[i].Right.X, -1f, 1f); // -0.5f, 0.5f);
                r_y_cc = midi.ValueToMIDI((float)player_array[i].Right.Y, -1f, 1f); // -0.1f, 0.5f);
                r_z_cc = midi.ValueToMIDI((float)player_array[i].Right.Z,  0f, 3f); // 0.9f, 2.4f);
                r_v_cc = midi.ValueToMIDI((float)player_array[i].Right.V, 0.0f, 3.0f);

                midi.SendMIDI(ChannelCommand.Controller, i, 40, r_x_cc);
                midi.SendMIDI(ChannelCommand.Controller, i, 41, r_y_cc);
                midi.SendMIDI(ChannelCommand.Controller, i, 42, r_z_cc);
                midi.SendMIDI(ChannelCommand.Controller, i, 43, r_v_cc);

                // Distance
                dist_cc = midi.ValueToMIDI((float)player_array[i].HandDistance, 0f, 1f);
                midi.SendMIDI(ChannelCommand.Controller, i, 50, dist_cc);


                // TODO - Detect jumps, claps, etc.  *******
                
                // Notes based on movement

                velocity_right[i] += player_array[i].Right.V;
                if (velocity_right[i] > 10d)
                {
                    int velocity = r_v_cc;
                    float height = (float)r_y_cc / 127f;  // Scale 0-1

                    // Map to a note
                    int offset = (int)(height * (pentatonic.Length - 1));

                    byte note = pentatonic[offset];
                    midi.SendMIDI(ChannelCommand.NoteOn,  0, note, velocity);
                    midi.SendMIDI(ChannelCommand.NoteOff, 0, note, velocity);

                    velocity_right[i] = 0;
                }

                velocity_left[i] += player_array[i].Left.V;
                if (velocity_left[i] > 8d)
                {
                    int velocity = l_v_cc;
                    float height = (float)l_y_cc / 127f;  // Scale 0-1

                    // Map to a note
                    int offset = (int)(height * (pentatonic.Length - 1));

                    byte note = pentatonic[offset];
                    midi.SendMIDI(ChannelCommand.NoteOn,  1, note, velocity);
                    midi.SendMIDI(ChannelCommand.NoteOff, 1, note, velocity);

                    velocity_left[i] = 0;
                }


                // Update Screen                

                // Head
                details += "Head:\n";
                details += "X = " + b_x_cc.ToString(MIDIFormatString) + "\n";
                details += "Y = " + b_y_cc.ToString(MIDIFormatString) + "\n";
                details += "Z = " + b_z_cc.ToString(MIDIFormatString) + "\n";
                details += "V = " + b_v_cc.ToString(MIDIFormatString) + "\n";

                // Left
                details += "\nLeft:\n";
                details += "X = " + l_x_cc.ToString(MIDIFormatString) + "\n";
                details += "Y = " + l_y_cc.ToString(MIDIFormatString) + "\n";
                details += "Z = " + l_z_cc.ToString(MIDIFormatString) + "\n";
                details += "V = " + l_v_cc.ToString(MIDIFormatString) + "\n";

                // Right
                details += "\nRight:\n";
                details += "X = " + r_x_cc.ToString(MIDIFormatString) + "\n";
                details += "Y = " + r_y_cc.ToString(MIDIFormatString) + "\n";
                details += "Z = " + r_z_cc.ToString(MIDIFormatString) + "\n";
                details += "V = " + r_v_cc.ToString(MIDIFormatString) + "\n";

                // Distance
                details += "\nDistance:\n" + dist_cc.ToString(MIDIFormatString);               

                // Delimiter
                details += "*";
            }

            return details;
        }
    }
}
