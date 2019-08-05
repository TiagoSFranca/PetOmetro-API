using System.Collections.Generic;

namespace PetOmetro.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            Pets = new HashSet<Pet>();
            PetUsuarios = new HashSet<PetUsuario>();
            SolicitacoesPetSolicitado = new HashSet<SolicitacaoPet>();
            SolicitacoesPetSolicitante = new HashSet<SolicitacaoPet>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<PetUsuario> PetUsuarios { get; set; }
        public virtual ICollection<SolicitacaoPet> SolicitacoesPetSolicitado { get; set; }
        public virtual ICollection<SolicitacaoPet> SolicitacoesPetSolicitante { get; set; }
    }
}
