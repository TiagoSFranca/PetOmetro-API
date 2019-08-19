using System;
using System.Collections.Generic;

namespace PetOmetro.Domain.Entities
{
    public class Pet
    {
        public Pet()
        {
            PetUsuarios = new HashSet<PetUsuario>();
            SolicitacoesPet = new HashSet<SolicitacaoPet>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public DateTime? DtNascimento { get; set; }
        public string Comentario { get; set; }
        public string UrlImagem { get; set; }

        public int IdGeneroPet { get; set; }
        public int IdUsuario { get; set; }

        public virtual GeneroPet GeneroPet { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<PetUsuario> PetUsuarios { get; set; }
        public virtual ICollection<SolicitacaoPet> SolicitacoesPet { get; set; }
    }
}
