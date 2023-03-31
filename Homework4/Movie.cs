using System.Runtime.InteropServices.JavaScript;

namespace Homework4;

public class Movie
{
    private String title;
    private String original_language;
    private double vote_average;

    public Movie(String str)
    {
        String[] arr = str.Split(',');
        this.title = arr[1];
        original_language = arr[2];
        vote_average = double.Parse(arr[4].Replace('.',','));
    }

    public string Title
    {
        get => title;
        set => title = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string OriginalLanguage
    {
        get => original_language;
        set => original_language = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double VoteAverage
    {
        get => vote_average;
        set => vote_average = value;
    }

    public override string ToString()
    {
        return $"{title} {original_language} {vote_average}";
    }
}