using System;
using System.Globalization;
using System.Text;

namespace Graphite
{
    public class PlaintextMessage
    {
		readonly string _msg;
		
        public PlaintextMessage(string path, int value, DateTime timestamp)
        {
          
			_msg = GetMessage(path,value.ToString(),timestamp);

        }

		public PlaintextMessage(string path,double value,DateTime timestamp) {
			_msg = GetMessage(path,value.ToString(CultureInfo.InvariantCulture), timestamp);
		}

		private static string GetMessage(string path, string value, DateTime timestamp) {
			if(path == null) {
				throw new ArgumentNullException("path");
			}

			return string.Format("{0} {1} {2}\n", path,value , timestamp.ToUnixTime());
		}

        public byte[] ToByteArray()
        {
            return Encoding.UTF8.GetBytes(_msg);
        }
    }
}