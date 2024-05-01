using ClassLibTeam14.Business.Entities;
using Plugin.Maui.Audio;

namespace MauiAppTeam14;

public partial class SerieDetails : ContentPage
{
    private IAudioManager audioManager;  // Reference to audio manager
    private Dictionary<string, IAudioPlayer> audioPlayers;  // Dictionary to manage audio players
    public SerieDetails(Serie serie)
    {
		InitializeComponent();
        BindingContext = serie;  // Set the BindingContext to the passed series
        audioManager = new AudioManager();  // Assigned in constructor
        audioPlayers = new Dictionary<string, IAudioPlayer>();  // Initialize the dictionary

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        BtnStop.IsVisible = true;
        var currentSerie = (Serie)BindingContext;

        if (currentSerie == null || string.IsNullOrWhiteSpace(currentSerie.SoundTrack))
        {
            Console.WriteLine("SoundTrack is null or empty.");
            return;
        }

        try
        {
            // Stop other players to avoid audio overlap
            foreach (var player in audioPlayers.Values)
            {
                if (player.IsPlaying)
                {
                    player.Stop();
                }
            }

            var soundPath = currentSerie.SoundTrack;

            if (!audioPlayers.ContainsKey(soundPath))
            {
                var newPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(soundPath));

                // Subscribe to PlaybackCompleted to handle audio end
                newPlayer.PlaybackEnded += (s, args) =>
                {
                    BtnStop.IsVisible = false;  // Hide the stop button when playback ends
                };

                audioPlayers[soundPath] = newPlayer;
            }

            var audioPlayer = audioPlayers[soundPath];

            if (!audioPlayer.IsPlaying)
            {
                audioPlayer.Play();  // Start playing audio
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error playing soundtrack: {ex.Message}");
        }
    }
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        BtnStop.IsVisible = false;
        foreach (var player in audioPlayers.Values)
        {
            if (player.IsPlaying)
            {
                player.Stop();  // Stop playing sounds
            }
        }
    }
}
