using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developer.Rules
{
    public class DeveloperBusinessRules
    {
        private readonly IUserEntityRepository _userRepository;

        public DeveloperBusinessRules(IUserEntityRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void UserExists(User user)
        {
            if (user == null) throw new BusinessException("There is no user");
        }
        public void UserPasswordIsIncorrect(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result) throw new BusinessException("Wrong Password");
        }

        public async void EmailCanNotBeDuplicatedWhenInserted(string email)
        {
            User? result = await _userRepository.GetAsync(u => u.Email == email);
            if (result != null) throw new BusinessException("This Email address already exists");
        }
    }
}
