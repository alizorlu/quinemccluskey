using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_ClusKey
{
    public class Gruplama
    {
        public int BirSayisi(string data)
        {
            return data.Count(sa => sa == '1');
        }
    }
}
