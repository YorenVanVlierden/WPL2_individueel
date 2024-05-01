using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ClassLibTeam14.Business.Entities;
using MauiAppTeam14.Services;
using Plugin.Maui.Audio; 


namespace MauiAppTeam14.ViewModels
{
    public class SeriesViewModel
    {
        
        private readonly RestService restService;  // Reference to RestService
        public ObservableCollection<Serie> Series { get; set; }  // ObservableCollection for data binding

        public SeriesViewModel()
        {
            Series = new ObservableCollection<Serie>();  // Initialize the ObservableCollection
            restService = new RestService();  // Initialize RestService with default base URL

        }

        // Method to load series asynchronously
        public async Task LoadSeriesAsync()
        {
            try
            {
                // Fetch series data from the Web API using the correct endpoint
                var seriesList = await restService.GetDeserializedAsync<List<Serie>>("Serie");  // Correct endpoint

                Series.Clear();  // Clear existing data
                foreach (var serie in seriesList)
                {
                    Series.Add(serie);  // Add fetched data to ObservableCollection
                }
            }
            catch (Exception ex)
            {
                // Handle errors and add debugging information
                Console.WriteLine($"Error loading series: {ex.Message}");
            }
        } 

    }
}
