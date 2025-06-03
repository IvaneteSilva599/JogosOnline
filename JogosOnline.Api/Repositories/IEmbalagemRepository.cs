using JogosOnline.Api.Models;

namespace JogosOnline.Api.Repositories
{
    public interface IEmbalagemRepository
    {
        List<Caixa> GetAllCaixasParaEmbalagem();
    }
}