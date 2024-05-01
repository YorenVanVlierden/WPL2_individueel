using ClassLibTeam14.Business.Entities;
using ClassLibTeam14.Data.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam14.Data
{
    internal class SerieData : SqlServer
    {
        public string TableName { get; set; }
        public SerieData()
        {
            TableName = "Series";
        }

        public SelectResult Select()
        {
            return base.Select(TableName);
        }
        public InsertResult Insert(Serie serie)
        {
            var result = new InsertResult(); try
            {
                //SQLCommand 
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {TableName} ");
                insertQuery.Append($"(SerieTitle, SerieDescription, SerieGenre, NumberOfSeasons, ImagePath, ReleaseDate, SoundTrack, ImdbScore, EpisodeCount) VALUES ");
                insertQuery.Append($"(@SerieTitle, @SerieDescription, @SerieGenre, @NumberOfSeasons, @ImagePath, @ReleaseDate, @SoundTrack, @ImdbScore, EpisodeCount); ");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                   // insertCommand.Parameters.Add("@SerieID", SqlDbType.Int).Value = serie.SerieId;
                    insertCommand.Parameters.Add("@SerieTitle", SqlDbType.VarChar).Value = serie.SerieTitle;
                    insertCommand.Parameters.Add("@SerieDescription", SqlDbType.VarChar).Value = serie.SerieDescription;
                    insertCommand.Parameters.Add("@SerieGenre", SqlDbType.VarChar).Value = serie.SerieGenre;
                    insertCommand.Parameters.Add("@NumberOfSeasons", SqlDbType.Int).Value = serie.NumberOfSeasons;
                    insertCommand.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = serie.ImagePath;
                    insertCommand.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = serie.ReleaseDate;
                    insertCommand.Parameters.Add("@SoundTrack", SqlDbType.VarChar).Value = serie.SoundTrack;
                    insertCommand.Parameters.Add("@ImdbScore", SqlDbType.Decimal).Value = serie.ImdbScore;
                    insertCommand.Parameters.Add("@EpisodeCount", SqlDbType.Int).Value = serie.EpisodeCount;

                    result = InsertRecord(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
    }
}
