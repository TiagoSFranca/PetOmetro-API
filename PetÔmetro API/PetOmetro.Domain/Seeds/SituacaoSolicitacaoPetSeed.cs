using PetOmetro.Domain.Entities;
using System.Collections.Generic;

namespace PetOmetro.Domain.Seeds
{
    public class SituacaoSolicitacaoPetSeed
    {
        public static SituacaoSolicitacaoPet Pendente => new SituacaoSolicitacaoPet() { Id = 1, Nome = "Pendente" };
        public static SituacaoSolicitacaoPet Aceita => new SituacaoSolicitacaoPet() { Id = 2, Nome = "Aceita" };
        public static SituacaoSolicitacaoPet Recusada => new SituacaoSolicitacaoPet() { Id = 3, Nome = "Recusada" };

        public static List<SituacaoSolicitacaoPet> Seeds => new List<SituacaoSolicitacaoPet>()
        {
            Pendente,
            Aceita,
            Recusada
        };
    }
}
