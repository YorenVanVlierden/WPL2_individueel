using MauiAppTeam14.ViewModels;
namespace MauiAppTeam14;
using System.Collections.ObjectModel;
using ClassLibTeam14.Business.Entities;
using Plugin.Maui.Audio;
using System.IO;
public partial class SeriesPage : ContentPage
{
    private IAudioManager audioManager;  // Reference to audio manager
    private Dictionary<string, IAudioPlayer> audioPlayers;  // Dictionary to manage audio players
    private SeriesViewModel viewModel;

    public SeriesPage()
    {
        InitializeComponent();
        viewModel = new SeriesViewModel();  // Initialize the ViewModel
        BindingContext = viewModel;  // Set the binding context for the page
        audioManager = new AudioManager();  // Assigned in constructor
        audioPlayers = new Dictionary<string, IAudioPlayer>();  // Initialize the dictionary

    }

    private async void OnLoadRecordsClicked(object sender, EventArgs e)
    {
        try
        {
            var viewModel = (SeriesViewModel)BindingContext;  // Get the ViewModel
            await viewModel.LoadSeriesAsync();  // Load the series data
        }
        catch (Exception ex)
        {
            // Handle errors to avoid breaking the event handler
            Console.WriteLine($"Error in click handler: {ex.Message}");
        }
    }

    private async void SeriesListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null || !(e.Item is Serie tappedSerie))  // Validate tapped item
            return;

        // Navigate to the new page with the selected series as a parameter
        await Navigation.PushAsync(new SerieDetails(tappedSerie));  // Navigate to details page

        ((ListView)sender).SelectedItem = null;  // Reset selected item to avoid unintended re-taps
        //if (e.Item == null || !(e.Item is Serie tappedSerie))  // Validate the tapped item
        //    return;

        //if (string.IsNullOrWhiteSpace(tappedSerie.SoundTrack))  // Validate 'SoundTrack'
        //{
        //    Console.WriteLine("SoundTrack is null or empty.");
        //    return;
        //}

        //try
        //{
        //    // Stop any currently playing audio
        //    foreach (var player in audioPlayers.Values)
        //    {
        //        if (player.IsPlaying)
        //        {
        //            player.Stop();  // Stop any active players
        //        }
        //    }

        //    var soundPath = tappedSerie.SoundTrack;  // Get the SoundTrack property

        //    // If the player for this series doesn't exist, create it
        //    if (!audioPlayers.ContainsKey(soundPath))
        //    {
        //        var newPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(soundPath));
        //        audioPlayers[soundPath] = newPlayer;  // Add the player to the dictionary
        //    }

        //    // Play the soundtrack for the tapped series
        //    var audioPlayer = audioPlayers[soundPath];
        //    if (!audioPlayer.IsPlaying)
        //    {
        //        audioPlayer.Play();  // Play the soundtrack
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Error playing soundtrack: {ex.Message}");  // Handle exceptions
        //}

        //// Reset selected item to avoid unintended re-taps
        //((ListView)sender).SelectedItem = null;
    }
}


