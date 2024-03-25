using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NIM_Player
{
    internal class Serializator
    {
        private static BinaryFormatter _bin = new BinaryFormatter();

        public static void Serialize(string pathOrFileName, object objToSerialise)
        {
            using (Stream stream = File.Open(pathOrFileName, FileMode.Create))
            {
                try
                {
                    _bin.Serialize(stream, objToSerialise);
                }
                catch (SerializationException e)
                {
                   MessageBox.Show("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
            }
        }

        public static PlayLists Deserialize<T>(string pathOrFileName)
        {
            PlayLists items;

            using (Stream stream = File.Open(pathOrFileName, FileMode.Open))
            {
                try
                {
                    items = (PlayLists)_bin.Deserialize(stream);
                }
                catch (SerializationException e)
                {
                    MessageBox.Show("Failed to deserialize. Reason: " + e.Message);
                    throw;
                }
            }

            return items;
        }
    }
}
