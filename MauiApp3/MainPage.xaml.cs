using System;
using System.Net;
using System.IO;

namespace MauiApp3;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        try
        {
            Console.WriteLine("Making API Call...");
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri("https://api.stackexchange.com/2.2/");
                HttpResponseMessage response = client.GetAsync("answers?order=desc&sort=activity&site=stackoverflow").Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
            }

        }
        catch
        {
            DisplayAlert("Alert", "You have been alerted", "OK");
        }
	}
}

