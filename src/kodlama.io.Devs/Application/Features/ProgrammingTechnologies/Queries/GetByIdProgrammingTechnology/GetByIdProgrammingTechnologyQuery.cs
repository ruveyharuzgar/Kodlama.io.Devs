using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Queries.GetByIdProgrammingTechnology
{
    public class GetByIdProgrammingTechnologyQuery : IRequest<ProgrammingTechnologyGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdProgrammingTechnologyQueryHandler : IRequestHandler<GetByIdProgrammingTechnologyQuery, ProgrammingTechnologyGetByIdDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public GetByIdProgrammingTechnologyQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<ProgrammingTechnologyGetByIdDto> Handle(GetByIdProgrammingTechnologyQuery request, CancellationToken cancellationToken)
            {
                ProgrammingTechnology? programmingTechnology = await _programmingTechnologyRepository.GetAsync(p => p.Id == request.Id);
                //ProgrammingTechnology? technology = await _programmingTechnologyRepository.Query().Include(p => p.ProgrammingLanguage).FirstOrDefaultAsync(x => x.Id == request.Id);
                //_programmingTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(programmingTechnology);
                ProgrammingTechnologyGetByIdDto programmingTechnologyGetByIdDto = _mapper.Map<ProgrammingTechnologyGetByIdDto>(programmingTechnology);
                return programmingTechnologyGetByIdDto;
            }
        }
    }
}
