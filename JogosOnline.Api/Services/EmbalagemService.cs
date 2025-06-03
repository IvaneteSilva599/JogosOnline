using JogosOnline.Api.Dtos;
using JogosOnline.Api.Models;
using JogosOnline.Api.Repositories;

namespace JogosOnline.Api.Services
{
    public class EmbalagemService : IEmbalagemService
    {
        private readonly IEmbalagemRepository _embalagemRepository;

        public EmbalagemService(IEmbalagemRepository embalagemRepository)
        {
            _embalagemRepository = embalagemRepository;
        }

        public PedidosEmbaladosResponseDto EmbalarPedidos(List<PedidoEmbalagemRequestDto> pedidosInput)
        {
            if (pedidosInput == null || !pedidosInput.Any())
            {
                throw new ArgumentException("A lista de pedidos para embalagem está vazia ou nula.");
            }

            var caixasDisponiveis = _embalagemRepository.GetAllCaixasParaEmbalagem();
            var resultadoPedidosEmbalados = new List<PedidoEmbaladoResponseDto>();

            foreach (var pedido in pedidosInput)
            {
                if (!int.TryParse(pedido.PedidoId, out var pedidoIdInt))
                {
                    throw new ArgumentException($"PedidoId inválido: {pedido.PedidoId}");
                }

                var pedidoEmbalado = new PedidoEmbaladoResponseDto
                {
                    PedidoId = pedidoIdInt,
                    Caixas = new List<CaixaEmbaladaDto>()
                };

                var produtosNoPedido = pedido.Produtos ?? new List<ProdutoEmbalagemRequestDto>();

                // Mapeia ProdutoId -> Dimensões para cálculo de volume
                var mapaProdutos = produtosNoPedido
                    .Where(p => p.ProdutoId != null && p.Dimensoes != null)
                    .ToDictionary(p => p.ProdutoId!, p => p.Dimensoes!);

                var produtosOrdenados = produtosNoPedido
                    .Where(p => p.Dimensoes != null)
                    .OrderByDescending(p => CalcularVolume(p.Dimensoes!))
                    .ToList();

                foreach (var produto in produtosOrdenados)
                {
                    bool encaixado = false;

                    // Tenta colocar o produto em uma caixa já usada no pedido
                    foreach (var caixaAtual in pedidoEmbalado.Caixas)
                    {
                        var caixaModelo = caixasDisponiveis.FirstOrDefault(c => c.Nome == caixaAtual.CaixaId);
                        if (caixaModelo != null &&
                            produto.Dimensoes != null &&
                            caixaModelo.ComportaProduto(produto.Dimensoes) &&
                            VolumeRestante(caixaAtual, caixaModelo, mapaProdutos) >= CalcularVolume(produto.Dimensoes))
                        {
                            // TODO: Melhorar para validar também encaixe físico e não só por volume
                            caixaAtual.Produtos?.Add(produto.Nome!);
                            encaixado = true;
                            break;
                        }
                    }

                    // Caso não caiba em nenhuma caixa já utilizada, tenta nova caixa
                    if (!encaixado)
                    {
                        var caixaApropriada = caixasDisponiveis
                            .Where(c => produto.Dimensoes != null && c.ComportaProduto(produto.Dimensoes))
                            .OrderBy(c => c.CalcularVolume())
                            .FirstOrDefault();

                        if (caixaApropriada != null)
                        {
                            pedidoEmbalado.Caixas.Add(new CaixaEmbaladaDto
                            {
                                CaixaId = caixaApropriada.Nome,
                                Produtos = new List<string> { produto.Nome! }
                            });
                        }
                        else
                        {
                            // Produto não cabe em nenhuma caixa
                            pedidoEmbalado.Caixas.Add(new CaixaEmbaladaDto
                            {
                                CaixaId = null,
                                Produtos = new List<string> { produto.Nome! },
                                Observacao = "Produto não cabe em nenhuma caixa disponível."
                            });
                        }
                    }
                }

                resultadoPedidosEmbalados.Add(pedidoEmbalado);
            }

            return new PedidosEmbaladosResponseDto { Pedidos = resultadoPedidosEmbalados };
        }

        private int VolumeRestante(CaixaEmbaladaDto caixaDto, Caixa modelo, Dictionary<string, DimensoesDto> mapaProdutos)
        {
            int volumeUsado = 0;
            if (caixaDto.Produtos != null)
            {
                foreach (var produtoNome in caixaDto.Produtos)
                {
                    var produto = mapaProdutos.FirstOrDefault(p => p.Key == produtoNome || p.Value != null);
                    if (mapaProdutos.TryGetValue(produto.Key, out var dimensoes))
                    {
                        volumeUsado += CalcularVolume(dimensoes);
                    }
                }

            }
            return modelo.CalcularVolume() - volumeUsado;
        }

        private int CalcularVolume(DimensoesDto d) =>
            d.Altura * d.Largura * d.Comprimento;

    }
}