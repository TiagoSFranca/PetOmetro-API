using PetOmetro.Application.Pets.Models;
using PetOmetro.Application.SituacoesSolicitacaoPet.Models;
using PetOmetro.Application.Usuarios.Models;
using System;

namespace PetOmetro.Application.SolicitacoesPet.Models
{
    public class SolicitacaoPetViewModel
    {
        public int Id { get; set; }
        public int IdUsuarioSolicitante { get; set; }
        public int IdUsuarioSolicitado { get; set; }
        public int IdPet { get; set; }
        public int IdSituacaoSolicitacao { get; set; }
        public bool Visualizado { get; set; }

        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }

        public UsuarioItemViewModel UsuarioSolicitante { get; set; }
        public UsuarioItemViewModel UsuarioSolicitado { get; set; }
        public PetItemViewModel Pet { get; set; }
        public SituacaoSolicitacaoPetViewModel SituacaoSolicitacao { get; set; }
    }
}
