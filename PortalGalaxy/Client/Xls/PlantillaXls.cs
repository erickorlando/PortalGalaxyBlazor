using ClosedXML.Report;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Xls;

public class PlantillaXls
{
    public byte[] GenerarPlantillaTaller(Stream plantilla, ICollection<TallerDtoResponse> data)
    {
        var template = new XLTemplate(plantilla);
        
        template.AddVariable("Talleres", data);
        template.Generate();
        
        using var ms = new MemoryStream();
        template.SaveAs(ms);
        
        return ms.ToArray();
    }
}