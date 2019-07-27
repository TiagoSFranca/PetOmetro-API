namespace PetOmetro.Application.Paginacoes.Models
{
    public class PaginacaoViewModel
    {
        public int Pagina { get; private set; }
        public int ItensPorPagina { get; private set; }

        public PaginacaoViewModel(int pagina, int itensPorPagina)
        {
            Pagina = pagina;
            ItensPorPagina = itensPorPagina;
        }
    }
}
