using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MC_ClusKey
{
    class Program
    {
       
        public static List<Eleman> terimler = new List<Eleman>();
        public static List<Eleman> grup0 = new List<Eleman>();
        public static List<Eleman> grup1 = new List<Eleman>();
        public static List<Eleman> grup2 = new List<Eleman>();
        public static List<Eleman> grup3 = new List<Eleman>();
        public static List<Eleman> grup4 = new List<Eleman>();

        public static List<ReplaceEleman> replaceGrp0 = new List<ReplaceEleman>();
        public static List<ReplaceEleman> replaceGrp1 = new List<ReplaceEleman>();
        public static List<ReplaceEleman> replaceGrp2 = new List<ReplaceEleman>();
        public static List<ReplaceEleman> replaceGrp3 = new List<ReplaceEleman>();

        public static List<SonReplaceEleman> srGrup0 = new List<SonReplaceEleman>();

        public static List<KarnoElemanlar> karno = new List<KarnoElemanlar>();
        static void Main(string[] args)
        {
           
            tekrar:
            #region Listeleri Temizliyoruz
            terimler.Clear();
            grup0.Clear();grup1.Clear();grup2.Clear();grup3.Clear();
            replaceGrp0.Clear();replaceGrp1.Clear();replaceGrp2.Clear();replaceGrp3.Clear();
#endregion

            int sayi = 0;
            Console.Write("\t\tMax-Min term sayısı:");
            sayi = int.Parse(Console.ReadLine());
            for (int i = 0; i < sayi; i++)
            {
                Eleman yeniTerim = new Eleman();
                Console.Write(string.Format("\t\t{0}.sayı[0'dan 15'e kadar]:", i + 1));
                yeniTerim.Sayi = int.Parse(Console.ReadLine());
                yeniTerim.Grubu = string.Format("M"+yeniTerim.Sayi.ToString());
                yeniTerim.ByteTip = new BinaryDonustur().Binary(yeniTerim.Sayi);
                terimler.Add(yeniTerim);
                                
            }
            Console.Write("\t\t===>>PROBLEM:Ey(");
            terimler.ForEach(sa => Console.Write("{0},", sa.Sayi));
            Console.Write(")\n");
            foreach (var item in terimler)
            {
                int birsayisi = new Gruplama().BirSayisi(item.ByteTip.ToString());
                switch (birsayisi)
                {
                    case 0:item.BirSayisi = 0; grup0.Add(item);
                        break;
                    case 1:
                        item.BirSayisi = 1;
                        grup1.Add(item);
                        break;
                    case 2:
                        item.BirSayisi = 2;
                        grup2.Add(item);
                        break;
                    case 3:
                        item.BirSayisi = 3;
                        grup3.Add(item);
                        break;
                    case 4:
                        item.BirSayisi = 4;
                        grup4.Add(item);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("\t\t==============================TABLO-1==============================");
            Console.Write("\t\tData\t\t | Grup\t\t | Terim\t\t |ABCD\t\t\n");
            foreach (var item in grup0.Union(grup1.Union(grup2.Union(grup3.Union(grup4)))))
            {
                string tabloFormat = string.Format("\t\t{0}\t\t |{1} \t\t | {2} \t\t\t| {3}\t\t", item.Sayi,
                    item.Grubu, item.Grubu.Replace("M", ""), item.ByteTip);
                Console.WriteLine(tabloFormat);
                Console.WriteLine("\t\t--------------------------------------------------------------");
              
                
            }
            Console.WriteLine("\t\t===============================================================");


            foreach (var once in grup0)
            {
                foreach (var sonra in grup1)
                {
                    if (new Fonksiyon().DegisenSayi(once.ByteTip, sonra.ByteTip) == 1)
                    {
                        ReplaceEleman yeni = new ReplaceEleman();
                        yeni.Indis1 = once;
                        yeni.Indis2 = sonra;
                        yeni.Grup = "0";
                        yeni.ByteCikti =
                            new ReplaceGrupKarsilastirma().repGrupDeger(once.ByteTip, sonra.ByteTip);
                        replaceGrp0.Add(yeni);
                    }
                    else continue;
                    
                }
            }
            foreach (var once in grup1)
            {
                foreach (var sonra in grup2)
                {
                    if (new Fonksiyon().DegisenSayi(once.ByteTip, sonra.ByteTip) == 1)
                    {
                        ReplaceEleman yeni = new ReplaceEleman();
                        yeni.Indis1 = once;
                        yeni.Indis2 = sonra;
                        yeni.Grup = "1";
                        yeni.ByteCikti =
                            new ReplaceGrupKarsilastirma().repGrupDeger(once.ByteTip, sonra.ByteTip);
                        replaceGrp1.Add(yeni);
                    }
                    else continue;
                }
            }
            foreach (var once in grup2)
            {
                foreach (var sonra in grup3)
                {
                    if (new Fonksiyon().DegisenSayi(once.ByteTip, sonra.ByteTip) == 1)
                    {
                        ReplaceEleman yeni = new ReplaceEleman();
                        yeni.Indis1 = once;
                        yeni.Indis2 = sonra;
                        yeni.Grup = "2";
                        yeni.ByteCikti =
                            new ReplaceGrupKarsilastirma().repGrupDeger(once.ByteTip, sonra.ByteTip);
                        replaceGrp2.Add(yeni);
                    }
                    else continue;
                }
            }
            foreach (var once in grup3)
            {
                foreach (var sonra in grup4)
                {
                    if (new Fonksiyon().DegisenSayi(once.ByteTip, sonra.ByteTip) == 1)
                    {
                        ReplaceEleman yeni = new ReplaceEleman();
                        yeni.Indis1 = once;
                        yeni.Indis2 = sonra;
                        yeni.Grup = "3";
                        yeni.ByteCikti =
                            new ReplaceGrupKarsilastirma().repGrupDeger(once.ByteTip, sonra.ByteTip);
                        replaceGrp3.Add(yeni);
                    }
                    else continue;
                }
            }

            Console.WriteLine("\t\t==============================TABLO-2==============================");
            Console.Write("\t\tGrup\t\t | Terim\t\t |ABCD\t\t\n");
            foreach (var item in replaceGrp0.Union(replaceGrp1.Union(replaceGrp2.Union(replaceGrp3))))
            {
                string terimFormat = string.Format("{0} - {1}", item.Indis1.Grubu, item.Indis2.Grubu);
                string repFormat = string.Format("\t\t{0}\t\t | {1}\t\t | {2}\t\t", item.Grup, terimFormat, item.ByteCikti);
                Console.WriteLine(repFormat);
                Console.WriteLine("\t\t--------------------------------------------------------------");
            }
            Console.WriteLine("\t\t===============================================================");

            foreach (var on in replaceGrp0)
            {
                foreach (var arka in replaceGrp1)
                {
                    if (new Fonksiyon().DegisenSayi(on.ByteCikti, arka.ByteCikti) == 1)
                    {
                        SonReplaceEleman yeni = new SonReplaceEleman();
                        yeni.ByteCikti
                            = new ReplaceGrupKarsilastirma().repGrupDeger(on.ByteCikti, arka.ByteCikti);
                        yeni.Grup = "0";
                        yeni.Indis1 = on;
                        yeni.Indis2 = arka;
                        srGrup0.Add(yeni);
                    }
                    else continue;
                   
                }
            }
            foreach (var on in replaceGrp1)
            {
                foreach (var arka in replaceGrp2)
                {
                    if (new Fonksiyon().DegisenSayi(on.ByteCikti, arka.ByteCikti) == 1)
                    {
                        SonReplaceEleman yeni = new SonReplaceEleman();
                        yeni.ByteCikti
                            = new ReplaceGrupKarsilastirma().repGrupDeger(on.ByteCikti, arka.ByteCikti);
                        yeni.Grup = "1";
                        yeni.Indis1 = on;
                        yeni.Indis2 = arka;
                        srGrup0.Add(yeni);
                    }
                    else continue;

                }
            }
            foreach (var on in replaceGrp2)
            {
                foreach (var arka in replaceGrp3)
                {
                    if (new Fonksiyon().DegisenSayi(on.ByteCikti, arka.ByteCikti) == 1)
                    {
                        SonReplaceEleman yeni = new SonReplaceEleman();
                        yeni.ByteCikti
                            = new ReplaceGrupKarsilastirma().repGrupDeger(on.ByteCikti, arka.ByteCikti);
                        yeni.Grup = "2";
                        yeni.Indis1 = on;
                        yeni.Indis2 = arka;
                        srGrup0.Add(yeni);
                    }
                    else continue;

                }
            }
            Console.WriteLine("\t\t==============================TABLO-3==============================");
            Console.Write("\t\tGrup\t\t | Terim\t\t\t\t |ABCD\t\t\t | Mantıksal\t\n");
            foreach (var item in srGrup0)
            {
                string onFormat = string.Format("{0}-{1}", item.Indis1.Indis1.Grubu,
                    item.Indis1.Indis2.Grubu);
                string arkaFormat= string.Format("{0}-{1}", item.Indis2.Indis1.Grubu,
                    item.Indis2.Indis2.Grubu);
                string grpFormat = string.Format("{0} - {1}", onFormat, arkaFormat);
                //Console.WriteLine("{0} = {1}", grpFormat, item.ByteCikti);
                string tabloFormat = string.Format("\t\t{0}\t\t | {1}\t\t\t | {2}\t\t | {3}",
                    item.Grup, grpFormat, item.ByteCikti, new LojikCikti().GetCikti(item.ByteCikti)
                    );
                Console.WriteLine("\t\t-------------------------------------------------------------------------------------------------------");
                Console.WriteLine(tabloFormat);

                KarnoElemanlar yeni = new KarnoElemanlar();
                yeni.LojikDeger = new LojikCikti().GetCikti(item.ByteCikti);
                yeni.Terimler = grpFormat.Replace("-", ",").Replace(" ","").Replace("M","");
                var lojikKontrol = karno.Where(sa => sa.LojikDeger == yeni.LojikDeger).FirstOrDefault();
                if (lojikKontrol!=null)
                {
                    continue;
                }else
                {
                    karno.Add(yeni);
                }
            }
            Console.WriteLine("\t\t==============================SON INDİRGEME==============================");



            Console.Write("\t\tLOJİK\t | Terimler\t | ");
            terimler.ForEach(a => Console.Write(string.Format(" {0}\t |", a.Sayi)));
            Console.WriteLine("\n");

            foreach (var item in karno)
            {
                string isaretFormat = null;
                foreach (var isaretleme in terimler)
                {
                    //item.Terimler.Contains(isaretleme.Sayi.ToString())
                    if (new Fonksiyon().IcerisindeVarmi(item.Terimler,isaretleme.Sayi))
                    {
                        isaretFormat += " X\t |";
                    }else
                    {
                        isaretFormat += "  \t |";
                    }
                }
                string karnoFormat = string.Format("\t\t{0}\t | {1}\t |{2}", item.LojikDeger, item.Terimler,isaretFormat);
                Console.WriteLine(karnoFormat);
                 Console.WriteLine("\t\t-------------------------------------------------------------------------------------------------------");
            }
           
            Console.WriteLine("\t\t==============SONUC=====================");
            Console.Write("\t\t\t F=");
            karno.ForEach(a => Console.Write(string.Format(" {0}\t +", a.LojikDeger)));
            

            Console.WriteLine("\n\nTekrar İşlem İçin T-t'ye basın Çıkış için Ç-ç ye basın");
            string girilen = Console.ReadLine();
            if (girilen=="T"||girilen=="t")
            {
                var fileName = Assembly.GetExecutingAssembly().Location;
                System.Diagnostics.Process.Start(fileName);
                Environment.Exit(0);
                goto tekrar;
            }
          
            else if (girilen=="Ç"||girilen=="ç")
            {
                Environment.Exit(0);
            }
           
        }
    }
    class Eleman
    {
        public int Sayi { get; set; }
        public string ByteTip { get; set; }
        public string Grubu { get; set; }
        public int BirSayisi { get; set; }

    }
    class ReplaceEleman
    {
        public string Grup { get; set; }
        public string ByteCikti { get; set; }
        public Eleman Indis1 { get; set; }
        public Eleman Indis2 { get; set; }
    }
    class SonReplaceEleman
    {
        public string Grup { get; set; }
        public string ByteCikti { get; set; }
        public ReplaceEleman Indis1 { get; set; }
        public ReplaceEleman Indis2 { get; set; }
    }
    class KarnoElemanlar
    {
        public string LojikDeger { get; set; }
        public string Terimler { get; set; } 
    }
}
