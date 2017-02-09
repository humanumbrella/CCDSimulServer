using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCDSimulServer
{
    public class ExposePackage
    {
        public bool isDark { get; set; }
        public ushort epsilon { get; set; }
        public double expTime { get; set; }
        public bool saveImages { get; set; }
        public string saveInfo { get; set; }
        public string savepath { get; set; }
        public ushort stringByteCount = 0;
        public string filter { get; set; }
        public int orderPos { get; set; }

        public ExposePackage(bool dark, ushort eps, double exp)
        {
            isDark = dark;
            epsilon = eps;
            expTime = exp;
        }


        public ExposePackage(bool dark, ushort eps, double exp, bool save, string spath)
        {
            isDark = dark;
            epsilon = eps;
            expTime = exp;
            saveImages = save;
            savepath = spath;
            stringByteCount = (ushort)System.Text.ASCIIEncoding.ASCII.GetByteCount(spath);
        }

        public ExposePackage(byte[] setupData)
        {
            isDark = BitConverter.ToBoolean(setupData, 0);
            epsilon = BitConverter.ToUInt16(setupData, 1);
            expTime = BitConverter.ToDouble(setupData, 3);
            saveImages = BitConverter.ToBoolean(setupData, 11);
            stringByteCount = BitConverter.ToUInt16(setupData,12);
            saveInfo = Encoding.ASCII.GetString(setupData, 14, stringByteCount);
            string[] saveParts = saveInfo.Split(',');
            savepath = saveParts[0];
            filter = saveParts[1];
            int test;
            Int32.TryParse(saveParts[2], out test) ;
            orderPos = test;

        }

        public byte[] toByteArray()
        {

            List<byte> byteList = new List<byte>();
            byteList.AddRange(BitConverter.GetBytes(isDark));
            byteList.AddRange(BitConverter.GetBytes(epsilon));
            byteList.AddRange(BitConverter.GetBytes(expTime));
            byteList.AddRange(BitConverter.GetBytes(saveImages));
            byteList.AddRange(BitConverter.GetBytes(stringByteCount));
            byteList.AddRange(Encoding.ASCII.GetBytes(savepath));
            

            return byteList.ToArray();
            /*
            byte[] bytearray = new byte[5];

            Array.Copy(BitConverter.GetBytes(isDark),bytearray,1);
            Array.Copy(BitConverter.GetBytes(epsilon),bytearray,2);
            Array.Copy(BitConverter.GetBytes(expTime),bytearray,2);

            return bytearray;*/
        }
    }
}
