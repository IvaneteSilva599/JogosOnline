using JogosOnline.Api.Dtos;
using System.Collections.Generic;

namespace JogosOnline.Api.Services
{
    public interface IEmbalagemService
    {
        // The method receives the list of individual order requests for packaging
        PedidosEmbaladosResponseDto EmbalarPedidos(List<PedidoEmbalagemRequestDto> pedidos);
    }
}