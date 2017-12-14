using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_ClusKey
{
    public class LojikCikti
    {
        public string GetCikti(string data)
        {
            string bir = data.Replace(" ", "");
            int harfSayac = -1;
            string lojikCikti = null;
            foreach (var item in bir.ToArray())
            {
                if (item.ToString() != "_")
                {
                    harfSayac += 1;
                    if (harfSayac == 0)
                    {
                        if (item.ToString() == "0")
                        {
                            lojikCikti += "¬A";
                        }
                        else if (item.ToString() == "1")
                        {
                            lojikCikti += "A";

                        }
                    }
                    else if (harfSayac == 1)
                    {
                        if (item.ToString() == "0")
                        {
                            lojikCikti += "¬B";
                        }
                        else if (item.ToString() == "1")
                        {
                            lojikCikti += "B";

                        }
                    }
                    else if (harfSayac == 2)
                    {
                        if (item.ToString() == "0")
                        {
                            lojikCikti += "¬C";
                        }
                        else if (item.ToString() == "1")
                        {
                            lojikCikti += "C";

                        }
                    }
                    else if (harfSayac == 3)
                    {
                        if (item.ToString() == "0")
                        {
                            lojikCikti += "¬D";
                        }
                        else if (item.ToString() == "1")
                        {
                            lojikCikti += "D";

                        }
                    }

                }
                else harfSayac += 1;
            }
            return lojikCikti;
        }
    }
}
