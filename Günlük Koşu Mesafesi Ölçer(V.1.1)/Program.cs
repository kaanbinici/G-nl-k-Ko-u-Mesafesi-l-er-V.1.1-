namespace Günlük_Koşu_Mesafesi_Ölçer_V._1._1_
{
    internal class Program
    {
        static int[] turSureleri = new int[5]; // tur sürelerini kaydettiğim diziyi burada olusturdum opsiyonel soru .
        static int saat, dakika, adimSayisi, adimUzunlugu, saatDonusum, toplamDakika, toplamKosuMesafesi; // alınan değerleri burada topladım.
        static void Main(string[] args)
        {
            AnaMenu();
            AdimBoyu(); // adiminin boyunu aldigim metot
            AdimSayisi(); // adim sayisini aldigim metot
            KosuSuresi(); // kosu suresini aldigim metot
            KosuMesafesi(); // mesafeyi ölcüp ekrana yazdırdıgım metot.
            TurSuresiKaydet();  // opsiyonel ek sorunun çözümü.  uygulamanın devamında soruyorum tur süresini kaydetmek istiyor musun? 
            Cikis(); // cikis yapmak istiyor mu kullanıcıya sordugum metot
            Main(null);
        }

        static void AnaMenu() // Giriş Menümüz görüntünün güzel olması için tasarladım.
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("***************************Kaan Binici Koşu Ölçer Uygulamasına Hoş Geldiniz****************************");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void AdimBoyu() // Adım boyunu cm cinsinden aldığım metot.
        {
            Console.WriteLine("Adım uzunluğunuzu cm cinsinden giriniz:");

            try
            {
                adimUzunlugu = int.Parse(Console.ReadLine());
                if (adimUzunlugu <= 0)  // eksi bir deger girerse hata fırlatmak için.
                {
                    Console.WriteLine("Adım Uzunluğu Negatif veya Sıfır Olamaz Lütfen Tekrar Giriniz."); //  kullanıcı hatalarını düzeltecek hata fırlatmaları .
                    AdimBoyu();
                }
            }
            catch (FormatException)    // harf girerse hata fırlatıyorum.
            {
                Console.WriteLine("Adım Uzunluğu Harf İçeremez Lütfen sayısal değer giriniz.");
                AdimBoyu();
            }
        }
        static void AdimSayisi() // Adım sayısını aldığım metot.
        {
            Console.WriteLine("Bir Dakikada Attığınız Adım Sayısını Giriniz : ");

            try
            {
                adimSayisi = int.Parse(Console.ReadLine());
                if (adimSayisi <= 0)
                {
                    Console.WriteLine("Adım Sayısı Negatif veya Sıfır Olamaz Lütfen Tekrar Giriniz.");
                    AdimSayisi();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Adım Sayısı Harf İçeremez Lütfen sayısal değer giriniz.");
                AdimSayisi();
            }
        }

        static void KosuSuresi() // koşu sürelerini aldığım metot saat ve dakikaları ayrı ayrı alıyorum.
        {
            Saat();
            Dakika();
        }
        static void Saat() // kaç saat koştuğunu aldığım metot.
        {
            Console.WriteLine("Koşunuz Kaç Saat Sürdü : ");

            try
            {
                saat = int.Parse(Console.ReadLine());
                if (saat <= 0)
                {
                    Console.WriteLine("Saat Negatif veya Sıfır Olamaz.");    // kullanıcı hatalı deger girerse hata fırlatmaları yapıyorum.
                    Saat();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Saat Harf İçeremez Lütfen sayısal değer giriniz.");
                Saat();
            }
        }
        static void Dakika() // kaç dakika koştuğunu aldığım metot.
        {
            Console.WriteLine("Koşunuz Kaç Dakika Sürdü: ");

            try
            {
                dakika = int.Parse(Console.ReadLine());
                if (dakika <= 0 || dakika > 60)
                {
                    Console.WriteLine("Dakika Negatif Olamaz ve 60'dan büyük olamaz.");    // kullanıcı hatalı deger girerse hata fırlatmaları yapıyorum.
                    Dakika();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Geçersiz bir giriş yaptınız. Lütfen sayısal bir değer girin.");
                Dakika();
            }
        }
        static void KosuMesafesi() // girilen değerleri alıp derledigim alan. Koşu mesafesini bulup ekrana yazdırıyorum.
        {
            saatDonusum = saat * 60; // saati dakikaya çeviriyorum.
            toplamDakika = saatDonusum + dakika;  // dakikaya dönüştürdüğüm saati ve kullanıcıdan aldığım dakikayı topluyorum toplam dakikayı buluyorum.
            toplamKosuMesafesi = toplamDakika * adimSayisi * adimUzunlugu; // koşu mesafesi için hepsini çarpıyorum.
            Console.WriteLine($"Toplam Koştuğunuz Mesafe {toplamKosuMesafesi} metredir.  ");
        }
        static void TurSuresiKaydet() // opsiyonel soru tur süresini kaydetmek için soruyorum.
        {
            Console.WriteLine("Tur süresini kaydetmek istiyor musunuz? Kayıt İçin 'e' tuşuna basınız.");
            string cevap = Console.ReadLine().ToLower();

            if (cevap == "e")
            {
                for (int i = 0; i < turSureleri.Length; i++)     // diziyi döndürüyorum her bir cevabı dizinin içine kaydediyorum.
                {
                    Console.WriteLine($" {i + 1}. Turda Parkuru Kaç Dakikada koştunuz.");
                    turSureleri[i] = int.Parse(Console.ReadLine());
                    Console.WriteLine("Tur süresi kaydedildi.");
                }
                HızlıdanYavasaSureler(); // girilen degerleri asagida düzenledim ve cagirdim.
            }
        }
        static void HızlıdanYavasaSureler()
        {
            Array.Sort(turSureleri); // tur sürelerini küçükten büyüge dogru sıraladım.
            Console.WriteLine($"En hızlı olduğunuz turdan en yavaş oldunuz turların sıralaması:");
            foreach (var turSure in turSureleri)
            {
                Console.WriteLine(turSure);
            }
        }
        private static void Cikis() // Kullanıcı çıkış yapmak isterse exit yazmasını istiyorum herhangi bir tuşa basarsa uygulamayı kullanmaya devam ediyor.
        {
            Console.WriteLine("Uygulamadan Çıkmak İçin 'exit' Yazınız.");
            string cevap = Console.ReadLine().ToLower();  // girilen değeri küçük harfe çeviriyorum.
            if (cevap == "exit") Environment.Exit(0); // exit yazdıysa uygulama kapanıyor.
        }
    }
}