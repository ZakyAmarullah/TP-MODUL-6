using System;
using System.Diagnostics.CodeAnalysis;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if(string.IsNullOrEmpty(title) || title.Length > 100)
        {
            throw new ArgumentException("Judul tidak boleh NULL (kosong) dan maksimal hanya 100 karakter!");
        }
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if(count > 10000000 || count < 0)
        {
            throw new ArgumentException("Input play count maksimal 10.000.000 dan tidak boleh bernilai negatif!");
        }

        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch(OverflowException e)
        {
            Console.WriteLine("Error: terjadi over flow saat melakukan play count! " + e.Message);
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Muhammad Zaky Amarullah");
            for(int i = 0; i < 10; i++)
            {
                video.IncreasePlayCount(10000000);
            }
            video.PrintVideoDetails();
        }
        catch(ArgumentException e)
        {
            Console.WriteLine("ERROR: " + e.Message);
        }
    }
}