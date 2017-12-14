using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_ClusKey
{
     public class BinaryDonustur
    {
        public string Binary(int deger)
        {
            string data = null;
            data=Convert.ToString(deger, 2);
            return string.Format("{0:0000}", int.Parse(data));
        }
    }
}
