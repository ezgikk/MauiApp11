using MauiApp11.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MauiApp11
{
    public partial class Weather : ContentPage
    {

        public Weather()
        {
            InitializeComponent();
            if (File.Exists(fileName))
            {
                string data = File.ReadAllText(fileName);
                Sehirler = JsonSerializer.Deserialize<ObservableCollection<SehirHavaDurumu>>(data);
            }
            ListCity.ItemsSource = Sehirler;
        }
        string fileName = Path.Combine(FileSystem.Current.AppDataDirectory, "hdata.json");
        ObservableCollection<SehirHavaDurumu> Sehirler = new ObservableCollection<SehirHavaDurumu>();

        private async void EkleButton_Clicked(object sender, System.EventArgs e)
        {
            string sehir = await DisplayPromptAsync("Şehir:", "Şehir ismi:", "OK", "Cancel");
            sehir = sehir.ToUpper(System.Globalization.CultureInfo.CurrentCulture);

            sehir = sehir.Replace('Ç', 'C');
            sehir = sehir.Replace('Ğ', 'G');
            sehir = sehir.Replace('İ', 'I');
            sehir = sehir.Replace('Ö', 'O');
            sehir = sehir.Replace('Ü', 'U');
            sehir = sehir.Replace('Ş', 'S');
            Sehirler.Add(new SehirHavaDurumu() { Name = sehir });

            string data = JsonSerializer.Serialize(Sehirler);
            File.WriteAllText(fileName, data);

        }

      
        private void ContentPage_Unloaded(object sender, EventArgs e)
        {

        }
        private void YukleButton_Clicked(object sender, EventArgs e)
        {
            refreshView.IsRefreshing = false;
        }
        private async void SilClicked(object sender, EventArgs e)
        {
            var b = sender as ImageButton;
            if(b != null)
            {
                var t = Sehirler.First(o => o.Name == b.CommandParameter.ToString());
                var yes = await DisplayAlert("silinsin mi?", "silmeyi onayla", "ok", "cancel");
                if (yes)
                {
                    Sehirler.Remove(t);
                    string data = JsonSerializer.Serialize(Sehirler);
                    File.WriteAllText(fileName, data);
                }

            }
        }
    }
}
