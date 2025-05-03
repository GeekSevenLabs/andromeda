using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace Andromeda.ProblemDetails;

public class ProblemDetailsExceptionMessageHandler(NavigationManager navigationManager) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var httpResponseMessage = await base.SendAsync(request, cancellationToken);

        if (httpResponseMessage.StatusCode == HttpStatusCode.OK) return httpResponseMessage;

        if (httpResponseMessage.Content.Headers.ContentType?.MediaType == "application/problem+json")
        {
            var problemDetailsException = await httpResponseMessage
                .Content
                .ReadFromJsonAsync<ProblemDetailsException>(cancellationToken: cancellationToken);
            
            throw problemDetailsException!;
        }

        var title = httpResponseMessage.StatusCode switch
        {
            HttpStatusCode.Unauthorized => "É necessário autenticar para realizar esta operação",
            HttpStatusCode.BadRequest => "Operação inválida",
            HttpStatusCode.Forbidden => "Sem permissão para realizar esta operação",
            HttpStatusCode.NotFound => "A operação solicitada não existe",
            HttpStatusCode.InternalServerError => "Ocorreu um erro interno no servidor",
            HttpStatusCode.ServiceUnavailable => "Serviço temporariamente indisponível",
            HttpStatusCode.GatewayTimeout => "Serviço temporariamente indisponível",
            HttpStatusCode.TooManyRequests => "Limite de requisições atingido",
            HttpStatusCode.RequestTimeout => "O tempo de espera da requisição expirou",
            HttpStatusCode.MethodNotAllowed => "Requisição não permitida",
            _ => "Ocorreu um erro inesperado"
        };
        
        var detail = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
        detail = string.IsNullOrEmpty(detail) ? "Nenhum detalhe adicional sobre o erro." : detail;
        
        // Se chamou uma API sem ter autorização, redireciona para a tela de login
        if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
        {
            if (navigationManager.Uri.Contains("login")) { return httpResponseMessage; }
            navigationManager.NavigateTo("/login", forceLoad: true);
            return httpResponseMessage;
        }
        
        throw new ProblemDetailsException("0", title, httpResponseMessage.StatusCode, detail, null);
    }
}
