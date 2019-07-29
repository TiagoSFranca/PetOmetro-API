using PetOmetro.Common.Helpers;

namespace PetOmetro.Application.Paginacoes.Models
{
    public class PaginacaoViewModel
    {
        public int Pagina { get; private set; }
        public int ItensPorPagina { get; private set; }

        public PaginacaoViewModel(int? pagina = null, int? itensPorPagina = null)
        {
            var paginaAtual = pagina ?? ConstantsHelper.PaginaDefault;

            if (paginaAtual <= 0)
                paginaAtual = ConstantsHelper.PaginaDefault;

            var qtdItens = itensPorPagina ?? ConstantsHelper.ItensPorPaginaDefault;

            if (qtdItens <= 0)
                qtdItens = ConstantsHelper.ItensPorPaginaDefault;

            Pagina = paginaAtual;
            ItensPorPagina = qtdItens;
        }
    }
}
