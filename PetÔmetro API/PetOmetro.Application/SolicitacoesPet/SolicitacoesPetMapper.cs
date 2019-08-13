using AutoMapper;
using PetOmetro.Application.Settings.AutoMapper;
using PetOmetro.Application.SolicitacoesPet.Command.CreateSolicitacaoPet;
using PetOmetro.Application.SolicitacoesPet.Command.FinalizeSolicitacaoPet;
using PetOmetro.Application.SolicitacoesPet.Models;
using PetOmetro.Domain.Entities;

namespace PetOmetro.Application.SolicitacoesPet
{
    public class SolicitacoesPetMapper : BaseMapper
    {
        public SolicitacoesPetMapper(Profile profile) : base(profile)
        {
        }

        protected override void Map(Profile profile)
        {
            profile.CreateMap<SolicitacaoPet, SolicitacaoPetViewModel>();
            profile.CreateMap<CreateSolicitacaoPet, CreateSolicitacaoPetCommand>();
            profile.CreateMap<CreateSolicitacaoPetCommand, SolicitacaoPet>();
            profile.CreateMap<FinalizeSolicitacaoPet, FinalizeSolicitacaoPetCommand>();
        }
    }
}
