using Microsoft.AspNetCore.Components;

namespace PortalGalaxy.Client.Shared
{
    public partial class LoadingComponent
    {
        [Parameter]
        public bool IsLoading { get; set; }
    }
}
