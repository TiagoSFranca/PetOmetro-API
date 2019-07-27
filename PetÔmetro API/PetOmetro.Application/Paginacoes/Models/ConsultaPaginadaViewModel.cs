using System;
using System.Collections.Generic;
using System.Text;

namespace PetOmetro.Application.Paginacoes.Models
{
    public class ConsultaPaginadaViewModel<TModel> : PaginacaoViewModel
        where TModel : class
    {
        public ConsultaPaginadaViewModel(int pagina, int itensPorPagina)
            : base(pagina, itensPorPagina)
        {
        }

        public int TotalItens { get; set; }
        public ICollection<TModel> Itens { get; set; }

    }
}
