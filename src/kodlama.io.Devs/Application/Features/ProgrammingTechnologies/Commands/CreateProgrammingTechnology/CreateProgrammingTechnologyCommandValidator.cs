using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Core.Application.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommandValidator : AbstractValidator<CreateProgrammingTechnologyCommand>
    {
        public CreateProgrammingTechnologyCommandValidator()
        {
            //RuleFor(p => p.Name).NotEmpty().WithMessage(Messages.ProgrammingTechnologyCannotBeEmpty);
        }
    }
}
