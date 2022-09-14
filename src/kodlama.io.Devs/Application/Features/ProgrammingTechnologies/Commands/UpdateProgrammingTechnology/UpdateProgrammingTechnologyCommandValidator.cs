using Core.Application.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommandValidator : AbstractValidator<UpdateProgrammingTechnologyCommand>
    {
        public UpdateProgrammingTechnologyCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage(Messages.ProgrammingTechnologyIdCannotBeEmpty);
            RuleFor(p => p.Name).NotEmpty().WithMessage(Messages.ProgrammingTechnologyNameCannotBeEmpty);
            RuleFor(p => p.ProgrammingLanguageId).NotEmpty().WithMessage(Messages.ProgrammingLanguageIdCannotBeEmpty);
        }
    }
}
