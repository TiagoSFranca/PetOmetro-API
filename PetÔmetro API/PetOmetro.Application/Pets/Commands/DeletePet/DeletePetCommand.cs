using MediatR;

namespace PetOmetro.Application.Pets.Commands.DeletePet
{
    public class DeletePetCommand : IRequest
    {
        public int Id { get; set; }
    }
}
