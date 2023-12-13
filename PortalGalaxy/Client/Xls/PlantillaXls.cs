using ClosedXML.Report;

namespace PortalGalaxy.Client.Xls;

public class PlantillaXls
{
    public byte[] GenerarPlantilla(Stream plantilla, object data, string variable = "Talleres")
    {
        var template = new XLTemplate(plantilla);
        
        template.AddVariable(variable, data);
        template.Generate();
        
        using var ms = new MemoryStream();
        template.SaveAs(ms);
        
        return ms.ToArray();
    }
}