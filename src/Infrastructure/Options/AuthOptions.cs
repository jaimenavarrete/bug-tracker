namespace Infrastructure.Options
{
    public class AuthOptions
    {
        public static string SectionName { get; set; } = "Authentication";

        public string SecretKey { get; set; } = null!;

        public string Issuer { get; set; } = null!;

        public string Audience { get; set; } = null!;
    }
}