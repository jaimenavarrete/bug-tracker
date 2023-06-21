namespace Application.DTOs.Response
{
    public class LoginUserResponseDto
    {
        public LoginUserResponseDto(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
