using System.Security.Principal;

namespace aPi_AC.Entidades
{
    public class ERespuesta
    {
        public int VAL { get; set; }
        public string NOMBRE { get; set; }
        public string OBSERVACION { get; set; }
    }




    public class EFoliosAC
    {
        public string RFID { get; set; }
        public int IDINVENTARIOACREDITACIONES { get; set; }
    }

    public class EAcceso
    {
        public int ID { get; set; }
        public string NOMBREACCESO { get; set; }
        public int ACTIVO { get; set; }
        public int IDINMUEBLE { get; set; }

    }

    public class EPersmisos
    {
        public int IDINVENTARIOACREDITACIONES { get; set; }
        public int IDACCESO { get; set; }
        public int IDINMUEBLE { get; set; }
        public string NOMBREACREDITACION { get; set; }
        public string NOMBREACCESO { get; set; }
        public int ACTIVO { get; set; }
    }

    public class EHardCard
    {
        public string RFID { get; set; }
        public string NOMBRE { get; set; }
        public int ACTIVO { get; set; }
        public int IDINVENTARIOACREDITACIONES { get; set; }
    }

    public class UserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class User
    {
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }

        public byte[] PassswordSalt { get; set; }
    }
}
