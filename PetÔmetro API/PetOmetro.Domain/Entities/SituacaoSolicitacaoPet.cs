using System.Collections.Generic;

namespace PetOmetro.Domain.Entities
{
    public class SituacaoSolicitacaoPet
    {
        public SituacaoSolicitacaoPet()
        {
            SolicitacoesPet = new HashSet<SolicitacaoPet>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<SolicitacaoPet> SolicitacoesPet { get; set; }
    }
}
