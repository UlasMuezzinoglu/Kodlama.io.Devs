using Application.Features.Developer.Dtos;
using Application.Features.Developer.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developer.Commands.LoginCommand
{
    public class LoginCommand : UserForLoginDto, IRequest<AccessTokenDto>
    {
        public class LoginDeveloperCommandHandler : IRequestHandler<LoginCommand, AccessTokenDto>
        {
            private readonly IUserEntityRepository _userEntityRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public LoginDeveloperCommandHandler(IUserEntityRepository userEntityRepository, IMapper mapper, ITokenHelper tokenHelper, DeveloperBusinessRules developerBusinessRules)
            {
                _userEntityRepository = userEntityRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<AccessTokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var user = await _userEntityRepository.GetAsync(u => u.Email.ToLower() == request.Email.ToLower(),
                    include: m => m.Include(c => c.UserOperationClaims).ThenInclude(x => x.OperationClaim));

                var operationClaims = user.UserOperationClaims.Select(x => x.OperationClaim).ToList();

                _developerBusinessRules.UserExists(user);
                _developerBusinessRules.UserPasswordIsIncorrect(request.Password, user.PasswordHash, user.PasswordSalt);


                AccessToken token = _tokenHelper.CreateToken(user, operationClaims);

                AccessTokenDto accessTokenDto = _mapper.Map<AccessTokenDto>(token);
                return accessTokenDto;
            }
        }

    }
}
