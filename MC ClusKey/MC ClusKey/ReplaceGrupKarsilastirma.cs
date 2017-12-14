using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_ClusKey
{
    public class ReplaceGrupKarsilastirma
    {
        public string repGrupDeger(string pr1,string pr2)
        {
            string bir = pr1;
            string iki = pr2;            
            int diziSayac = -1;
            string tempKarakter = null;
            string result = null;
            foreach (var item in bir.ToArray())
            {
                diziSayac += 1;
                string compData = item.ToString();
                tempKarakter = compData.ToString();
                string comp2Data = iki[diziSayac].ToString();
                if (compData == comp2Data)
                {
                    result +=" "+tempKarakter;
                    //MessageBox.Show(diziSayac+".deger aynı");
                }
                else
                {
                    result +=" "+"_";
                    //MessageBox.Show(diziSayac + ".deger değil");
                }
            }
            return result;
        }
        public string repGrupDeger2(string pr1, string pr2)
        {
            string bir = pr1;
            string iki = pr2;
            int diziSayac = -1;
            string tempKarakter = null;
            string result = null;
            foreach (var item in bir.ToArray())
            {
                diziSayac += 1;
                string compData = item.ToString();
                tempKarakter = compData.ToString();
                string comp2Data = iki[diziSayac].ToString();
                
                if (compData == comp2Data)
                {
                    result += " " + tempKarakter;
                    //MessageBox.Show(diziSayac+".deger aynı");
                }
                else
                {
                    result += " " + "_";
                    //MessageBox.Show(diziSayac + ".deger değil");
                }
            }
            return result;
        }
    }
}
