using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_ClusKey
{
    public class Fonksiyon
    {
        public int DegisenSayi(string pr1,string pr2)
        {
            string bir = pr1;
            string iki = pr2;
            int adimSayac = -1;
            int degisenSayi = 0;
            foreach (var item in bir.ToArray())
            {
                adimSayac += 1;
                string temp2Data = iki[adimSayac].ToString();
                if (item.ToString() != temp2Data)
                {
                    degisenSayi += 1;
                }
            }
            return degisenSayi;
        }
        public bool IcerisindeVarmi(string koleksiyon,int ara)
        {
            string dizi = koleksiyon;
            string aranan = ara.ToString();
            bool sonuc = false;
            foreach (var item in dizi.Split(','))
            {
                if (item.ToString() == aranan)
                {
                    sonuc = true;
                    return true;
                }
                else if (item.ToString() != aranan)
                {
                    sonuc = false;
                    continue;
                }
            }
            if (sonuc == false)
            {
                return false;
            }
            else if (sonuc == true)
            {
                return true;
            }
            else return false;
        }
    }
}
