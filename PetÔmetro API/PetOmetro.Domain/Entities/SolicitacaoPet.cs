using PetOmetro.Identity.Models;
using System;

namespace PetOmetro.Domain.Entities
{
    public class SolicitacaoPet
    {
        public int Id { get; set; }
        public int IdUsuarioSolicitante { get; set; }
        public int IdUsuarioSolicitado { get; set; }
        public int IdPet { get; set; }
        public int IdSituacaoSolicitacao { get; set; }
        public bool Visualizado { get; set; }

        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }

        public virtual ApplicationUser UsuarioSolicitante { get; set; }
        public virtual ApplicationUser UsuarioSolicitado { get; set; }
        public virtual Pet Pet { get; set; }
        public virtual SituacaoSolicitacaoPet SituacaoSolicitacao { get; set; }
    }
}
