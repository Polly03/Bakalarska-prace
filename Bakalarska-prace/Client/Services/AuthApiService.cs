using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Shared.Models.Auth;
using Urls = Shared.Constants.Constants.ServerUrls;
using Routes = Shared.Constants.Constants.Routes;
using Auth = Shared.Constants.Constants.AuthMethods;

namespace Bakalarska_prace.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(Urls.HttpUrl) };
        }

        public async Task<LoginResponseDto?> LoginAsync(string aLogin, string aPassword)
        {
            var loginDto = new LoginRequestDto { Login = aLogin, Password = aPassword };
            var response = await _httpClient.PostAsJsonAsync(Auth.Login, loginDto);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
                return result;
            }
            return null;
        }

        public async Task<RegisterResponseDto?> RegisterAsync(string aUsername, string aPassword, string aEmail)
        {
            var registerDto = new RegisterRequestDto { Username = aUsername, Password = aPassword, Email = aEmail };
            var response = await _httpClient.PostAsJsonAsync(Auth.Register, registerDto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<RegisterResponseDto>();
            }
            return null;
        }
    }
}