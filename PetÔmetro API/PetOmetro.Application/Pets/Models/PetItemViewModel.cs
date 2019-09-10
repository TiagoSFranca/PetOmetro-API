using PetOmetro.Application.GenerosPet.Models;
using System;

namespace PetOmetro.Application.Pets.Models
{
    public class PetItemViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public DateTime? DtNascimento { get; set; }
        public int IdGeneroPet { get; set; }
        public int IdUsuario { get; set; }

        public string Comentario { get; set; }
        public string UrlImagem { get; set; }

        public virtual GeneroPetViewModel GeneroPet { get; set; }
    }
}
