using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Membuat instance SayaTubeVideo dengan judul
            Console.WriteLine("Membuat video dengan judul valid...");
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – ALWIN FAHROZI MARBUN");

            // Memanggil method PrintVideoDetails
            Console.WriteLine("\nDetail video awal:");
            video.PrintVideoDetails();

            // Menambah playCount dengan nilai valid
            Console.WriteLine("\nMenambah play count sebanyak 10...");
            video.IncreasePlayCount(10);

            // Menampilkan detail setelah diubah
            Console.WriteLine("\nDetail video setelah diputar 10 kali:");
            video.PrintVideoDetails();

            // Percobaan dengan nilai invalid untuk menguji prekondisi
            Console.WriteLine("\nPercobaan dengan nilai yang melebihi batas 10.000.000:");
            try
            {
                video.IncreasePlayCount(10000001);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // Percobaan dengan judul null
            Console.WriteLine("\nPercobaan membuat video dengan judul null:");
            try
            {
                SayaTubeVideo invalidVideo = new SayaTubeVideo(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // Percobaan dengan judul terlalu panjang
            Console.WriteLine("\nPercobaan membuat video dengan judul terlalu panjang:");
            try
            {
                string longTitle = new string('a', 200); // Judul dengan 200 karakter
                SayaTubeVideo longTitleVideo = new SayaTubeVideo(longTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // Percobaan untuk menguji overflow
            Console.WriteLine("\nPercobaan untuk menguji overflow:");
            try
            {
                SayaTubeVideo overflowVideo = new SayaTubeVideo("Testing Overflow");
                Console.WriteLine("Melakukan iterasi penambahan play count...");

                // Loop untuk menguji overflow - perbaikan menggunakan PlayCount
                for (int i = 0; i < 25; i++)
                {
                    overflowVideo.IncreasePlayCount(10000000);
                    Console.WriteLine($"Iterasi {i + 1}: PlayCount = {overflowVideo.PlayCount}");
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Overflow exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error lain: " + ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nTerjadi error utama: " + ex.Message);
        }

        // Menunggu user menekan tombol sebelum menutup console
        Console.WriteLine("\nTekan sembarang tombol untuk keluar...");
        Console.ReadKey();
    }
}