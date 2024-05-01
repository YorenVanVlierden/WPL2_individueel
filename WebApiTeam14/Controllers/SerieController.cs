using ClassLibTeam14.Business;
using ClassLibTeam14.Business.Entities;
using ClassLibTeam14.Data.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Data.SqlClient;


namespace WebApiTeam14.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetSerie()
        {
            var series = Series.GetSeries();
            List<Serie> serieList = new List<Serie>();
            foreach (var datarow in series.DataTable.AsEnumerable())
            {
                Serie serie = new Serie(
                    Convert.ToInt32(datarow["SerieID"]),
                    Convert.ToString(datarow["SerieTitle"]),
                    Convert.ToString(datarow["SerieDescription"]),
                    Convert.ToString(datarow["SerieGenre"]),
                    Convert.ToInt32(datarow["NumberOfSeasons"]),
                    Convert.ToString(datarow["ImagePath"]),
                    Convert.ToDateTime(datarow["ReleaseDate"]),
                    Convert.ToString(datarow["SoundTrack"]),
                    Convert.ToDecimal(datarow["ImdbScore"]),
                    Convert.ToInt32(datarow["EpisodeCount"])
                    );
                serieList.Add(serie);
            }
            return Ok(serieList);
        }

        [HttpPost]
        public ActionResult InsertSerie( string SerieTitle, string SerieDescription, string SerieGenre, int NumberOfSeasons, string ImagePath, DateTime ReleaseDate, string SoundTrack, decimal ImdbScore, int EpisodeCount)
        {
            InsertResult insertResults = Series.Add(SerieTitle, SerieDescription, SerieGenre, NumberOfSeasons, ImagePath, ReleaseDate, SoundTrack, ImdbScore, EpisodeCount);
            return Ok(insertResults);

        }
    }
}
