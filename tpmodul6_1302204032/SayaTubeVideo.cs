using System;
using System.Text;
using System.Diagnostics;

public class SayaTubeVideo
{
    // Properties
    private int id;
    private string title;
    private int playCount;

    // Getter untuk playCount
    public int PlayCount
    {
        get { return playCount; }
    }

    // Constructor
    public SayaTubeVideo(string title)
    {
        // Prekondisi: judul video memiliki panjang maksimal 100 karakter dan tidak null
        Debug.Assert(title != null, "Judul video tidak boleh null");
        Debug.Assert(title.Length <= 100, "Judul video tidak boleh lebih dari 100 karakter");

        // Validasi parameter title
        if (title == null)
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
        // Prekondisi: input penambahan playCount maksimal 10.000.000 per panggilan method
        Debug.Assert(count <= 10000000, "Input penambahan play count tidak boleh lebih dari 10.000.000");
        Debug.Assert(count >= 0, "Input penambahan play count tidak boleh negatif");

        // Validasi parameter count
        if (count < 0)
        {
            throw new ArgumentException("Count tidak boleh negatif");
        }

        if (count > 10000000)
        {
            throw new ArgumentException("Input penambahan play count maksimal 10.000.000 per panggilan");
        }

        try
        {
            // Cek overflow (playCount + count > int.MaxValue)
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Exception terjadi: " + ex.Message);
            throw new OverflowException("Play count melebihi batas maksimum integer", ex);
        }
    }

    // Method untuk menampilkan detail video
    public void PrintVideoDetails()
    {
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Title: " + this.title);
        Console.WriteLine("Play Count: " + this.playCount);
    }
}