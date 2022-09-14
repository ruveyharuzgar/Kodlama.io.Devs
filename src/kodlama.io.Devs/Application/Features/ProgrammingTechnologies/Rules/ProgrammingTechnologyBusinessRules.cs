using Application.Services.Repositories;
using Core.Application.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologyBusinessRules
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;

        public ProgrammingTechnologyBusinessRules(IProgrammingTechnologyRepository programmingTechnologyRepository)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
        }

        public async Task ProgrammingTechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingTechnology> result = await _programmingTechnologyRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException(Messages.SameProgrammingTechnologyCannotBeAdded);
        }

        public async Task ProgrammingTechnologyShouldExistWhenRequested(int id)
        {
            ProgrammingTechnology? programmingTechnology = await _programmingTechnologyRepository.GetAsync(b => b.Id == id);
            if (programmingTechnology == null) throw new BusinessException(Messages.RequestedProgrammingTechnologyIsNotAvailable);
        }
    }
}
