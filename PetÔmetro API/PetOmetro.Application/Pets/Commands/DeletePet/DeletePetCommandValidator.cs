using FluentValidation;

namespace PetOmetro.Application.Pets.Commands.DeletePet
{
    public class DeletePetCommandValidator : AbstractValidator<DeletePetCommand>
    {
        public DeletePetCommandValidator()
        {
            RuleFor(e => e.Id)
                .GreaterThan(0);
        }
    }
}
