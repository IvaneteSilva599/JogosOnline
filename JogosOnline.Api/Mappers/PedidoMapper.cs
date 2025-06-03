using JogosOnline.Api.Dtos;
using JogosOnline.Api.Models;

namespace JogosOnline.Api.Mappers
{
    public static class PedidoMapper
    {
        public static PedidoCrudDto ToPedidoCrudDto(this Pedido pedido)
        {
            if (pedido == null) return null;

            return new PedidoCrudDto
            {
                Id = pedido.Id,
                DataDoPedido = pedido.DataDoPedido,
                Status = pedido.Status ?? "Pendente",
                Produtos = pedido.Produtos?
                               .Select(p => p.ToProdutoCrudDto())
                               .ToList() ?? new List<ProdutoCrudDto>()
            };
        }

        public static Pedido ToPedido(this PedidoCrudDto pedidoCrudDto)
        {
            if (pedidoCrudDto == null) return null;

            return new Pedido
            {
                Id = pedidoCrudDto.Id ?? 0,
                DataDoPedido = pedidoCrudDto.DataDoPedido,
                Status = pedidoCrudDto.Status ?? "Pendente",
                Produtos = pedidoCrudDto.Produtos?
                                     .Select(pDto => pDto.ToProduto())
                                     .ToList() ?? new List<Produto>()
            };
        }

        public static ProdutoCrudDto ToProdutoCrudDto(this Produto produto)
        {
            if (produto == null) return null;

            return new ProdutoCrudDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Altura = produto.Altura,
                Largura = produto.Largura,
                Comprimento = produto.Comprimento
            };
        }

        public static Produto ToProduto(this ProdutoCrudDto produtoCrudDto)
        {
            if (produtoCrudDto == null) return null;

            return new Produto
            {
                Id = produtoCrudDto.Id ?? 0,
                Nome = produtoCrudDto.Nome,
                Altura = produtoCrudDto.Altura,
                Largura = produtoCrudDto.Largura,
                Comprimento = produtoCrudDto.Comprimento
            };
        }

        public static Produto ToProduto(this ProdutoEmbalagemRequestDto dto)
        {
            if (dto == null) return null;

            return new Produto
            {
                Id = 0,
                Nome = dto.ProdutoId, 
                Altura = dto.Dimensoes?.Altura ?? 0,
                Largura = dto.Dimensoes?.Largura ?? 0,
                Comprimento = dto.Dimensoes?.Comprimento ?? 0
            };
        }
    }
}
