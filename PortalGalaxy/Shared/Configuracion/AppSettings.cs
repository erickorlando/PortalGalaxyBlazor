#nullable disable

namespace PortalGalaxy.Shared.Configuracion;

public class AppSettings
{
    public Jwt Jwt { get; set; }
    public SmtpConfiguration SmtpConfiguration { get; set; }
    public StorageConfiguration StorageConfiguration { get; set; }
}

public class Jwt
{
    public string SecretKey { get; set; }
    public string Emisor { get; set; }
    public string Audiencia { get; set; }
}

public class SmtpConfiguration
{
    public string Server { get; set; }
    public string FromName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int Port { get; set; }
    public bool EnableSsl { get; set; }
}

public class StorageConfiguration
{
    public string Path { get; set; }
    public string PublicUrl { get; set; }
}