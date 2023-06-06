using CRPR.Client.Data;
using System.Net.Http.Json;

namespace CRPR.Client
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _httpClient;

        public MainPage()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var response = await _httpClient.GetAsync("https://localhost:7298/api/book/all");
            var data = await response.Content.ReadFromJsonAsync<List<Book>>();
            collectionView.ItemsSource = data;
        }
    }
}