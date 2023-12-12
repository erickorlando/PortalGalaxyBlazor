namespace PortalGalaxy.Services.Utils;

public static class Helper
{
    public static int GetTotalPages(int totalRows, int rowsPerPage)
    {
        return (int)Math.Ceiling((decimal)totalRows / rowsPerPage);
    }
}