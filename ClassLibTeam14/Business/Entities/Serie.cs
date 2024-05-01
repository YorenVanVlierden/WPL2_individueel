using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam14.Business.Entities
{
    public class Serie
    {
        public int SerieId { get; set; }
        public string SerieTitle { get; set; }
        public string SerieDescription { get; set;}
        public string SerieGenre { get; set; }
        public int NumberOfSeasons { get; set;}
        public string ImagePath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string SoundTrack {  get; set; }
        public decimal ImdbScore { get; set; }
        public int EpisodeCount { get; set; }
        public Serie()
        {
            
        }

        public Serie(string serieTitle, string serieDescription, string serieGenre, int numberOfSeasons, string imagePath, DateTime releaseDate, string soundTrack, decimal imdbScore, int episodeCount)
        {            
            SerieTitle = serieTitle;
            SerieDescription = serieDescription;
            SerieGenre = serieGenre;
            NumberOfSeasons = numberOfSeasons;
            ImagePath = imagePath;
            ReleaseDate = releaseDate;
            SoundTrack = soundTrack;
            ImdbScore = imdbScore;
            EpisodeCount = episodeCount;
        }
        public Serie(int serieId, string serieTitle, string serieDescription, string serieGenre, int numberOfSeasons, string imagePath, DateTime releaseDate, string soundTrack, decimal imdbScore, int episodeCount)
        {
            SerieId = serieId;
            SerieTitle = serieTitle;
            SerieDescription = serieDescription;
            SerieGenre = serieGenre;
            NumberOfSeasons = numberOfSeasons;
            ImagePath = imagePath;
            ReleaseDate = releaseDate;
            SoundTrack = soundTrack;
            ImdbScore = imdbScore;
            EpisodeCount = episodeCount;
        }
    }
    
}
