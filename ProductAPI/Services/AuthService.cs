using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.DataAccessLayer.Entities;
using Product.DataAccessLayer.Repository;
using ProductAPI.Models;

namespace ProductAPI.Services
{
    public interface IAuthService
    {
        Task<AuthDetailModel> Authenticate(string userName, string password);
        Task<AuthDetailModel> VerifyOTP(long UserId, string OTP);
        Task<int> CreateOTP(long UserId, string OTP);
    }

    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;

        public AuthService(IAuthRepository authRepository, IMapper mapper)
        {
            _mapper = mapper;
            _authRepository = authRepository;
        }

        public async Task<AuthDetailModel> Authenticate(string userName, string password)
        {
            var result = await _authRepository.Authenticate(userName, password);
            return _mapper.Map<AuthDetailModel>(result);
        }

        public async Task<int> CreateOTP(long UserId, string OTP)
        {
            return await _authRepository.CreateOTP(UserId, OTP);
        }

        public async Task<AuthDetailModel> VerifyOTP(long UserId, string OTP)
        {
            var result = await _authRepository.VerifyOTP(UserId, OTP);
            return _mapper.Map<AuthDetailModel>(result);
        }
    }
}
