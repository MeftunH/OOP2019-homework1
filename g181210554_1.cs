/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2019-2020 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........:1
**				ÖĞRENCİ ADI............:Maftun Hashimli
**				ÖĞRENCİ NUMARASI.......:G181210554
**                         DERSİN ALINDIĞI GRUP...:
****************************************************************************/

using System;
using System.IO;
class Students
{
    //Get setler ve degiskenleri olusturuyorum
    public string isim { get; set; }
    public string soyisim { get; set; }
    public string numara { get; set; }
    public int odev1 { get; set; }
    public int odev2 { get; set; }
    public int vize { get; set; }
    public int final { get; set; }
    public Students(String Isim, String Soyisim, String Numara, int Odev1, int Odev2, int Vize, int Final)
    {
        Isim = isim;
        Soyisim = soyisim;
        Numara = numara;
        Odev1 = odev1;
        Odev2 = odev2;
        Vize = vize;
        Final = final;
    }
}
namespace NdpOdev
{

    class Program
    {
        static void Main(string[] args)
        {
            //Okuyacagim dosyayi aciyorum
            var fileStream = new FileStream(@"..\..\students.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream))
            { //degiskenleri olusturuyorum
                float studentcounter = 0;
                string[] wordlist;
                string[] words = null;
                string lines;
                string harfnotu;
                int ffsayac = 0, fdsayac = 0, ddsayac = 0, dcsayac = 0, ccsayac = 0, cbsayac = 0, bbsayac = 0, basayac = 0, aasayac = 0;
                float ffyuzde = 0, fdyuzde = 0, ddyuzde = 0, dcyuzde = 0, ccyuzde = 0, cbyuzde = 0, bbyuzde = 0, bayuzde = 0, aayuzde = 0;
                Console.Write("Odev1 %10 ,Odev2 %10 ,Vize %30 ,Final %50 etkiliyor");
                Console.WriteLine("\n");
                while ((lines = streamReader.ReadLine()) != null)
                {
                    studentcounter++;
                    wordlist = lines.Split(' ');
                    words = lines.Split('\n');
                    for (int i = 0; i < words.Length; i++)
                    {
                        //OKuduklarimi parcalayarak Ogrencinin bilgilerine atiyorum
                        Students s = new Students(wordlist[0], wordlist[1], Convert.ToString(wordlist[2]), Convert.ToInt32(wordlist[3]), Convert.ToInt32(wordlist[4]), Convert.ToInt32(wordlist[5]), Convert.ToInt32(wordlist[6]));
                        s.isim = wordlist[0];
                        s.soyisim = wordlist[1];
                        s.numara = Convert.ToString(wordlist[2]);
                        s.odev1 = Convert.ToInt32(wordlist[3]);
                        s.odev2 = Convert.ToInt32(wordlist[4]);
                        s.vize = Convert.ToInt32(wordlist[5]);
                        s.final = Convert.ToInt32(wordlist[6]);
                        double toplamnot;
                        toplamnot = (s.odev1 * 0.1) + (s.odev2 * 0.1) + (s.vize * 0.3) + (s.final * 0.5);
                        //Not kontrollerini yapiyorum ve her not geldiignde kendilerine ozgu tanimlanmis sayaclari 1 arttir diyorum
                        if (toplamnot > 0 && toplamnot <= 39.99)
                        {
                            harfnotu = "FF";
                            ffsayac++;
                        }
                        else if (toplamnot >= 40 && toplamnot <= 49.99)
                        {
                            harfnotu = "FD";
                            fdsayac++;
                        }
                        else if (toplamnot >= 50 && toplamnot <= 57.99)
                        {
                            harfnotu = "DD";
                            ddsayac++;
                        }
                        else if (toplamnot >= 58 && toplamnot <= 64.99)
                        {
                            harfnotu = "DC";
                            dcsayac++;
                        }
                        else if (toplamnot >= 65 && toplamnot <= 74.99)
                        {
                            harfnotu = "CC";
                            ccsayac++;
                        }
                        else if (toplamnot >= 75 && toplamnot <= 79.99)
                        {
                            harfnotu = "CB";
                            cbsayac++;
                        }
                        else if (toplamnot >= 80 && toplamnot <= 84.99)
                        {
                            harfnotu = "BB";
                            bbsayac++;
                        }

                        else if (toplamnot >= 85 && toplamnot <= 89.99)
                        {
                            harfnotu = "BA";
                            basayac++;
                        }
                        else
                        {
                            harfnotu = "AA";
                            aasayac++;
                        }
                        Console.WriteLine(s.isim + " " + s.soyisim + " " + s.numara + " " + toplamnot + " " + harfnotu);

                    }
                }
                //yuzdeleri hesapliyorum
                ffyuzde = ((ffsayac / studentcounter) * 100);
                fdyuzde = ((fdsayac / studentcounter) * 100);
                ddyuzde = ((ddsayac / studentcounter) * 100);
                dcyuzde = ((dcsayac / studentcounter) * 100);
                ccyuzde = ((ccsayac / studentcounter) * 100);
                cbyuzde = ((cbsayac / studentcounter) * 100);
                bbyuzde = ((bbsayac / studentcounter) * 100);
                bayuzde = ((basayac / studentcounter) * 100);
                aayuzde = ((aasayac / studentcounter) * 100);
                Console.WriteLine("\n");
                Console.WriteLine("FF sayisi " + ffsayac + " FF yuzdesi " + ffyuzde + " %");
                Console.WriteLine("FD sayisi " + fdsayac + " FD yuzdesi " + fdyuzde + " %");
                Console.WriteLine("DD sayisi " + ddsayac + " DD yuzdesi " + ddyuzde + " %");
                Console.WriteLine("DC sayisi " + dcsayac + " DC yuzdesi " + dcyuzde + " %");
                Console.WriteLine("CC sayisi " + ccsayac + " CC yuzdesi " + ccyuzde + " %");
                Console.WriteLine("CB sayisi " + cbsayac + " CB yuzdesi " + cbyuzde + " %");
                Console.WriteLine("BB sayisi " + bbsayac + " BB yuzdesi " + bbyuzde + " %");
                    Console.WriteLine("BA sayisi " + basayac + " BA yuzdesi " + bayuzde + " %");
                Console.WriteLine("AA sayisi " + aasayac + " AA yuzdesi " + aayuzde + " %");
                //yazdirma islemlerine basliyorum
                string dosya_yolu = @"..\..\output.txt";
                //İşlem yapacağımız dosyanın yolunu belirtiyoruz.
                FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
                //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
                //2.parametre dosya varsa açılacağını yoksa oluşturulacağını belirtir,
                //3.parametre dosyaya erişimin veri yazmak için olacağını gösterir.
                StreamWriter sw = new StreamWriter(fs);
                //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
                sw.WriteLine(aasayac + " Kişi AA aldı.\n%" + aayuzde);
                sw.WriteLine(basayac + " Kişi BA aldı.\n%" + bayuzde);
                sw.WriteLine(bbsayac + " Kişi BB aldı.\n%" + bbyuzde);
                sw.WriteLine(cbsayac + " Kişi CB aldı.\n%" + cbyuzde);
                sw.WriteLine(ccsayac + " Kişi CC aldı.\n%" + ccyuzde);
                sw.WriteLine(dcsayac + " Kişi DC aldı.\n%" + dcyuzde);
                sw.WriteLine(ddsayac + " Kişi DD aldı.\n%" + ddyuzde);
                sw.WriteLine(fdsayac + " Kişi FD aldı.\n%" + fdyuzde);
                sw.WriteLine(ffsayac + " Kişi FF Aldı. \n%" + ffyuzde);

                //Dosyaya ekleyeceğimiz iki satırlık yazıyı WriteLine() metodu ile yazacağız.
                sw.Flush();
                //Veriyi tampon bölgeden dosyaya aktardık.
                sw.Close();
                fs.Close();
                //İşimiz bitince kullandığımız nesneleri iade ettik.
                Console.ReadKey();
            }

        }
    }
}

