using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost()]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationModel authModel)
        {
            var result = new GenericResult<dynamic>();
            try
            {

                var data = await _authService.Authenticate(authModel.UserName, authModel.UserPassword);
                if (data == null)
                {
                    result.Message = "Invalid UserName or Password";
                    return BadRequest(result);
                }
                else
                {
                    string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                    string otp = GenerateRandomOTP(6, saAllowedCharacters);

                    var response = await _authService.CreateOTP(data.UserId, otp);
                    if (response == 1)
                    {
                        /*
                         Write Logic to send otp to user phone
                         */
                        data.UserOTP = otp; // this is shown as of now to see in response and use this OTP to verify in next OTP Verification API

                        data.Message = "OTP has been sent and it will be valid for 5 mins.";
                        result.Data = data;
                        result.Success = true;
                        return BadRequest(result);
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpPost("VerifyOTP")]
        public async Task<IActionResult> VerifyOTP([FromBody] OTPModel otpModel)
        {
            var result = new GenericResult<dynamic>();
            try
            {

                var data = await _authService.VerifyOTP(otpModel.UserId, otpModel.UserOTP);
                if (data == null)
                {
                    result.Message = "Invalid OTP or Time is expired";
                    return BadRequest(result);
                }
                result.Data = data;
                result.Success = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return BadRequest(result);
            }
        }

        private string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)
        {

            string sOTP = String.Empty;
            string sTempChars = String.Empty;
            Random rand = new Random();
            for (int i = 0; i < iOTPLength; i++)
            {
                int p = rand.Next(0, saAllowedCharacters.Length);
                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];
                sOTP += sTempChars;
            }
            return sOTP;
        }
    }
}
