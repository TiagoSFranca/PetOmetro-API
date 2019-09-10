using System;
using System.Collections.Generic;

namespace PetOmetro.Application.Paginacoes.Models
{
    public class ConsultaPaginadaViewModel<TModel> : PaginacaoViewModel
        where TModel : class
    {
        public ConsultaPaginadaViewModel(int? pagina, int? itensPorPagina)
            : base(pagina, itensPorPagina)
        {
        }

        public int TotalItens { get; set; }
        public ICollection<TModel> Itens { get; set; }
        public int TotalPaginas
        {
            get
            {
                var valor = Math.Ceiling((double)TotalItens / ItensPorPagina);
                int total = (int)valor;
                return total < 1 ? 1 : total;
            }
        }

    }
}
