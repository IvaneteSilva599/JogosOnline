using JogosOnline.Api.Models;

namespace JogosOnline.Api.Repositories
{
    public class EmbalagemRepository : IEmbalagemRepository
    {
        private readonly List<Caixa> _caixasPadrao = new()
        {
            new Caixa("Caixa 1", 30, 40, 80),
            new Caixa("Caixa 2", 80, 50, 40),
            new Caixa("Caixa 3", 50, 80, 80)
        };

        public List<Caixa> GetAllCaixasParaEmbalagem()
        {
            return new List<Caixa>(_caixasPadrao);
        }
    }
}