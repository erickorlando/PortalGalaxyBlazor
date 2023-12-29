using Microsoft.AspNetCore.Components;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Shared.Inscripciones;

public partial class InscripcionMasivaComponent
{
    private string Participante { get; set; } = string.Empty;
    private string NroDocumento { get; set; } = string.Empty;
    public int TallerSeleccionado { get; set; }
    [Parameter] public ICollection<AlumnoSimpleDtoResponse>? Alumnos { get; set; }
    [Parameter] public ICollection<TallerSimpleDtoResponse>? Talleres { get; set; }

    [Parameter] public EventCallback<Tuple<string, string>> BuscarEvent { get; set; }

    [Parameter]
    [EditorRequired]
    public EventCallback<InscripcionMasivaDtoRequest> InscribirEvent { get; set; }

    private void Buscar()
    {
        BuscarEvent.InvokeAsync(new Tuple<string, string>(Participante, NroDocumento));
    }

    private void Inscribir()
    {
        if (Alumnos is null || Talleres is null) return;

        var request = new InscripcionMasivaDtoRequest
        {
            TallerId = TallerSeleccionado,
            Situacion = 0,
            Inscritos = Alumnos.Where(x => x.Seleccionado).Select(p => p.Id).ToList()
        };

        InscribirEvent.InvokeAsync(request);
    }
}