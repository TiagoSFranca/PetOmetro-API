using AutoMapper;
using PetOmetro.Application.Settings.AutoMapper;
using PetOmetro.Application.SituacoesSolicitacaoPet.Models;
using PetOmetro.Domain.Entities;

namespace PetOmetro.Application.SituacoesSolicitacaoPet
{
    public class SituacoesSolicitacaoPetMapper : BaseMapper
    {
        public SituacoesSolicitacaoPetMapper(Profile profile) : base(profile)
        {
        }

        protected override void Map(Profile profile)
        {
            profile.CreateMap<SituacaoSolicitacaoPet, SituacaoSolicitacaoPetViewModel>();
        }
    }
}
