﻿using System.Net.Http.Json;
using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Services;

public class TallerProxy : CrudRestHelperBase<TallerDtoRequest, TallerDtoResponse>, ITallerProxy
{
    public TallerProxy(HttpClient httpClient) 
        : base("api/Talleres", httpClient)
    {
    }

    public async Task<PaginationResponse<TallerDtoResponse>> ListAsync(BusquedaTallerRequest request)
    {
        var response =
            await ListAsync(
                $"?nombre={request.Nombre}&categoriaId={request.CategoriaId}&situacion={request.Situacion}&pagina={request.Pagina}&filas={request.Filas}");

        if (response is { Success: true })
        {
            return response;
        }

        return await Task.FromResult(new PaginationResponse<TallerDtoResponse>());
    }

    public async Task<PaginationResponse<InscritosPorTallerDtoResponse>> ListAsync(BusquedaInscritosPorTallerRequest request)
    {
        var response = await HttpClient.GetFromJsonAsync<PaginationResponse<InscritosPorTallerDtoResponse>>(
            $"{BaseUrl}/inscritos?instructorId={request.InstructorId}&taller={request.Taller}&situacion={request.Situacion}&fechaInicio={request.FechaInicio}&fechaFin={request.FechaFin}&pagina={request.Pagina}&filas={request.Filas}");

        if (response is { Success: false })
        {
            throw new InvalidOperationException(response.ErrorMessage);
        }

        return response!;
    }
}