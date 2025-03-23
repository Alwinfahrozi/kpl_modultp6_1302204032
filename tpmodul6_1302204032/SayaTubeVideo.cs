using System;
using System.Text;

namespace tpmodul6_1302204032

public class SayaTubeVideo
{
    // Properties
    private int id;
    private string title;
    private int playCount;

    // Constructor
    public SayaTubeVideo(string title)
    {
        // Validasi parameter title
        if (title == null || title == "")
        {
            throw new ArgumentNullException("Judul video tidak boleh null");
        }

        if (title.Length > 100)
        {
            throw new ArgumentException("Judul video tidak boleh lebih dari 100 karakter");
        }

        // Generate ID secara random
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        
        this.title = title;
        this.playCount = 0; // Inisialisasi playCount dengan 0
    }

    // Method untuk menambah playCount
    public void IncreasePlayCount(int count)
    {
        // Validasi parameter count
        if (count < 0)
        {
            throw new ArgumentException("Count tidak boleh negatif");
        }
        
        try
        {
            // Cek overflow (playCount + count > int.MaxValue)
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            throw new OverflowException("Play count melebihi batas maksimum");
        }
    }

    // Method untuk menampilkan detail video
    public void PrintVideoDetails()
    {
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Title: " + this.title);
        Console.WriteLine("Play Count: " + this.playCount);
    }

    // Main method untuk mencoba kelas
    static void Main(string[] args)
    {
        // Membuat instance SayaTubeVideo dengan judul
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – [ALWIN FAHROZI MARBUN]");
        
        // Memanggil method PrintVideoDetails
        video.PrintVideoDetails();
        
        // Menambah playCount
        video.IncreasePlayCount(10);
        
        // Menampilkan detail setelah diubah
        Console.WriteLine("\nSetelah diputar 10 kali:");
        video.PrintVideoDetails();
    }
}