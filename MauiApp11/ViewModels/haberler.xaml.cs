using MauiApp11.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MauiApp11;

public partial class Haberler : ContentPage
{
   

    public Haberler()
    {
        InitializeComponent();
    }
    private static Haberler instance;
    public static Haberler Page
    {
        get
        {
            if (instance == null)
                instance = new Haberler();
            return instance;
        }
    }
   


        public static async Task<string> HaberleriGetir(Kategori ctg)
{
    try
    {
        HttpClient client = new HttpClient();
        string url = $"https://api.rss2json.com/v1/api.json?rss_url={ctg.Link}";
        using HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string jsondata = await response.Content.ReadAsStringAsync();
        return jsondata;
    }
    catch
    {
        return null;
    }
}
public string Baslik { get; private set; }


    private void ContentPage_Loaded(object sender, EventArgs e)
    {

    }
    private void lstKategoriler_SelectionChanged(object sender, EventArgs e)
    {

    }
    private void lstHaberler_SelectionChanged(object sender, EventArgs e)
    {

    }
}


