using aPi_AC.Data;
using aPi_AC.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aPi_AC.Controllers
{
    [ApiController]
    [Route("api/AC")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class AcreditacionesController : Controller
    {
        [HttpGet("JsonRespuest")]
        //[AllowAnonymous]
        public IEnumerable<ERespuesta> JsonRespuest(string RFID, int ACCESO)
        {
            using (var BD = new DataSql())
            {
                return BD.ERespuest(RFID, ACCESO);

            }
        }


        [HttpGet("Respuesta")]
        //[AllowAnonymous]
        public int Respuesta(string RFID, int IDEQUIP)
        {
            using (var BD = new DataSql())
            {
                return BD.ObRespu(RFID, IDEQUIP);
            }
        }

        [HttpGet("FOLIOS_AC")]
        //[AllowAnonymous]
        public IEnumerable<EFoliosAC> FOLIOS_AC()
        {
            using (var BD = new DataSql())
            {
                return BD.OBTFOLIOS_AC(); 
            }
        }

        [HttpGet("ACCESOS")]
        //[AllowAnonymous]
        public IEnumerable<EAcceso> ACCESOS()
        {
            using(var BD = new DataSql())
            {
                return BD.OBTACCESOS();
            }
        }

        [HttpGet("PERMISOS")]
        //[AllowAnonymous]
        public IEnumerable<EPersmisos> PERMISOS()
        {
            using (var BD = new DataSql())
            {
                return BD.OBTPERMISOS();
            }
        }

        [HttpGet("HARDCARDS")]
        //[AllowAnonymous]
        public IEnumerable<EHardCard> HARDCARDS()
        {
            using (var BD = new DataSql())
            {
                return BD.OBTHARDCARDS();
            }
        }


        [HttpPost ("SaveLocal")]
        //[AllowAnonymous]
        public string Savelocal(string Json)
        {
            using(var BD = new DataSql())
            {
                return BD.Savelocal(Json);
            }
        }



    }
}
