using ClassLibTeam14.Data;
using ClassLibTeam14.Data.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibTeam14.Business.Entities;

namespace ClassLibTeam14.Business
{
    public static class Series 
    {
        public static string TableName { get; set; }

        public static SelectResult GetSeries()
        {
            SerieData serieData = new SerieData();
            SelectResult result = serieData.Select();
            return result;
        }
        public static InsertResult Add( string SerieTitle, string SerieDescription, string SerieGenre,int NumberOfSeasons,string ImagePath, DateTime ReleaseDate, string soundTrack, decimal ImdbScore, int EpisodeCount)
        {
            Serie serie = new Serie
            {
               // SerieId = SerieID,
                SerieTitle = SerieTitle,
                SerieDescription = SerieDescription,
                SerieGenre = SerieGenre,
                NumberOfSeasons = NumberOfSeasons,
                ImagePath = ImagePath,
                ReleaseDate = ReleaseDate,
                SoundTrack = soundTrack,
                ImdbScore = ImdbScore,
                EpisodeCount = EpisodeCount
            };
            SerieData serieData = new SerieData();
            InsertResult result = serieData.Insert(serie);
            return result;
        }
   



    }
}
