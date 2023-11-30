using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq; 

namespace Coolyeah_App.ViewModels
{
    class HomePageViewModel : INotifyPropertyChanged
    {
        private string _quote;
        public HomePageViewModel()
        {
            _quote = "Loading...";
        }

        public string CurrentQuote
        {
            get => _quote;
            set
            {
                if (_quote != value)
                {
                    _quote = value;
                    OnPropertyChanged(nameof(CurrentQuote));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        public async Task FetchQuote()
        {
            string apiUrl = "https://quotes15.p.rapidapi.com/quotes/random/";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "ccaa924ef2msh8607fa52ed7f3e8p1218a0jsn1ede0cf381e1");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "quotes15.p.rapidapi.com");

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();

                        JObject json = JObject.Parse(responseData);

                        CurrentQuote = json["content"]?.ToString();
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
