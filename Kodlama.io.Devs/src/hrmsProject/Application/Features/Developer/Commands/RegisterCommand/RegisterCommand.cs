using Application.Features.Developer.Dtos;
using Application.Features.Developer.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developer.Commands.RegisterCommand
{
    public class RegisterCommand : UserForRegisterDto, IRequest<AccessTokenDto>
    {
        public class RegisterDeveloperCommandHandler : IRequestHandler<RegisterCommand, AccessTokenDto>
        {
            private readonly IDeveloperEntityRepository _developerEntityRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public RegisterDeveloperCommandHandler(IDeveloperEntityRepository developerEntityRepository, IMapper mapper, ITokenHelper tokenHelper, DeveloperBusinessRules developerBusinessRules)
            {
                _developerEntityRepository = developerEntityRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<AccessTokenDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                _developerBusinessRules.EmailCanNotBeDuplicatedWhenInserted(request.Email);

                byte[] PasswordHash, PasswordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out PasswordHash, out PasswordSalt);

                DeveloperEntity developer = _mapper.Map<DeveloperEntity>(request);
                developer.PasswordHash = PasswordHash;
                developer.PasswordSalt = PasswordSalt;

                DeveloperEntity CreateDeveloper = await _developerEntityRepository.AddAsync(developer);

                AccessToken token = _tokenHelper.CreateToken(developer, new List<OperationClaim>() { new OperationClaim() { Name = "USER" } } ) ;

                AccessTokenDto createToken = _mapper.Map<AccessTokenDto>(token);

                return createToken;
            }
        }

    }
}
