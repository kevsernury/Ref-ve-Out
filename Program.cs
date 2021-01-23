using System;


///REf ve Out'u anlatmadan önce değişkenleri ve nasıl kullanıldıklarını biraz anlamaya çalışalım.
///C#'da referans ve değer olmak üzere iki veri tipi vardır. Refarans tipler bir bilginin yerini gösterirken
///değer tipler bilgiyi içinde tutar diyebiliriz. Değer tipler sadece kendi üretildikleri kod blokları 
///arasında kullanabilirler, buranın dışına çıkamazlar. Kod bloğundan kasıt { ve } arasında kalan kısımlardır. 
///Aşağıdaki örnekte main, Topla ve Topla2 kendi farklı kod bloklarına sahiptirler. 


namespace RefVeOut
{
    class Program
    {
        static void Main(string[] args)
        {
            //Değer tipte iki değişken tanımlıyoruz. Bu değişkenler sadece main içinde kullanılabilirler.
            int sayi1 = 7;
            int sayi2 = 8;
            int toplam;

            //Biz Topla fonksiyonunu sayi1 ve sayi2 ile kullanmak istediğimizde parametre olarak
            //bu sayıları metoda gönderiyouz. Metodun içinde sayi1 ve sayi2 ile işlemler yapıldığını
            //görebiliriz. Acaba bu işlemler sayi1 ve sayi2'yi etkiler mi?
            toplam = Topla(sayi1, sayi2);

            //Topla metodu çalıştıktan sonra sayi1 ve sayi2'ye bakalım
            Console.WriteLine("Topladan sonra \nsayi1 = " + sayi1 + "\nSayi2 = " + sayi2);
            //sayi1'in hala 7 ve sayi2'in hala 8 olduğunu görüyoruz. Neden?
            //Çünkü aslında biz parametre olarak bu sayiları verdiğimizde metoddaki (Topla(int sayi1, int sayi2))
            //sayi1 maindeki sayi1'in değeri neyse onu alıyor. Burada yapılan isimlendirme keyfidir, yani 
            //topla2'deki gibi i ve j isimleriyle kullanmış olsak da birşey değişmezdi.

            //ref ve out'a gelirsek bu anahtar kelimeler bir değer tipli değişkenin kendi kod bloğunun dışına
            //çıkmasını sağlar, onları referans tip olarak kullanmamızı sağlar. 

            //iki yeni değişken tanımlayalım
            int sayi3 = 7;
            int sayi4;

            //ref olarak gönderdiğimiz sayinin değeri 7 fakat out olarak gönderdiğimiz sayiya bir değer
            //ataması main'de yapılmadı. ref ve out arasında ki fark da budur. 
            toplam = Topla3(ref sayi3, out sayi4);

            //Şimdi referans tip gibi gönderdiğimiz sayiların durumuna bakalım.
            Console.WriteLine("Topla3'ten sonra \nsayi3 = " + sayi3 + "\nSayi4 = " + sayi4);

            //Çıktıdan görebileceğimiz gibi ref ve out'la gönderilen değişkenler metod içinde yapılan
            //işlemlerden etkilendi. 

        }

        public static int Topla(int sayi1, int sayi2)
        {
            sayi1 *= 5; //sayi1'i 5 katına çıkarıyoruz.
            sayi2 *= 3; //sayi2'de artık 3 katına eşitleniyor.

            //Bu işlemlerden sonraki sayi1 ve sayi2'yi yazdıralım
            Console.WriteLine("Topla içinde \nsayi1 = " + sayi1 + "\nsayi2 = " + sayi2);

            //bu iki sayının toplamını sonuç olarak gönderiyoruz.
            return sayi1 + sayi2;
        }

        public static int Topla2(int i , int j)
        {
            i *= 5;
            j *= 3;

            return i + j;
        }

        public static int Topla3(ref int sayi3, out int sayi4)
        {
            sayi3 *= 5;

            //sayi4' değer ataması yapıyoruz
            sayi4 = 8;
            sayi4 *= 3;

            //Metod içindeki sayiların durumuna bakalım
            Console.WriteLine("Topla3 içinde \nsayi3 = " + sayi3 + "\nSayi4 = " + sayi4);
            return sayi3 + sayi4;
        }
    }
}
