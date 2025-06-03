namespace JogosOnline.Api.Models
{
    using JogosOnline.Api.Dtos;

    public class Caixa
    {
        public string Nome { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }

        public Caixa(string nome, int altura, int largura, int comprimento)
        {
            Nome = nome;
            Altura = altura;
            Largura = largura;
            Comprimento = comprimento;
        }

        public int CalcularVolume() => Altura * Largura * Comprimento;

        public bool ComportaProduto(DimensoesDto produtoDimensoes)
        {
            if (CalcularVolume() < (produtoDimensoes.Altura * produtoDimensoes.Largura * produtoDimensoes.Comprimento))
            {
                return false;
            }

            if (produtoDimensoes.Altura <= Altura && produtoDimensoes.Largura <= Largura && produtoDimensoes.Comprimento <= Comprimento) return true;
            if (produtoDimensoes.Altura <= Altura && produtoDimensoes.Largura <= Comprimento && produtoDimensoes.Comprimento <= Largura) return true;
            if (produtoDimensoes.Altura <= Largura && produtoDimensoes.Largura <= Altura && produtoDimensoes.Comprimento <= Comprimento) return true;
            if (produtoDimensoes.Altura <= Largura && produtoDimensoes.Largura <= Comprimento && produtoDimensoes.Comprimento <= Altura) return true;
            if (produtoDimensoes.Altura <= Comprimento && produtoDimensoes.Largura <= Altura && produtoDimensoes.Comprimento <= Largura) return true;
            if (produtoDimensoes.Altura <= Comprimento && produtoDimensoes.Largura <= Largura && produtoDimensoes.Comprimento <= Altura) return true;

            return false;
        }
    }
}