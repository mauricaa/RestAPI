using Microsoft.AspNetCore.Mvc;
using SchoolManagement;
using Test_2;

namespace MyFirstWebApplication.Controllers
{
    [ApiController]         //deklariert die klasse als api-controller
    [Route("[controller]")]     //schule im browser
    public class SchuleController : Controller
    {
        private static Schule schule = new Schule(); //objekt schule
                                                    //statisch das die daten während der das programm läuft erhalten bleiben
        [HttpGet("GetAllSchueler")]                //endpunkt über Get /Schule/GetAllSchueler erreichbar
        public ActionResult<List<Schueler>> GetAllSchueler() 
        {
            return Ok(schule.Schueler);     //OK gibt aktuelle schülerliste als JSON
        }

        [HttpPost("AddSchueler")]
        public ActionResult AddSchueler([FromBody] Schueler neuerSchueler) //erwartet JSON Objekt mir schülerdaten
        {
            schule.Schueler.Add(neuerSchueler); //fügt den neuen schüler hinzu
            return Ok(neuerSchueler);
        }

        [HttpGet("AvgAge")]
        public ActionResult<double> GetAverageAge() //ActionResut gibt Typ double (speichert mehr nachkommastellen)
        {
             return Ok(schule.GetAverageAge());
        }

        [HttpGet("Gender")] 
        public ActionResult<object> GetGenderCount() 
        {
            var (male, female) = schule.GetMaleAndFemaleCount();
            return Ok(new { Maennlich = male, Weiblich = female });
        }
    }
}
