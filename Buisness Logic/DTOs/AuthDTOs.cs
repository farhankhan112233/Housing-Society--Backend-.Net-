namespace Housing_Society.DTOs
{
    public class LoginRequestDto
    {
        public int? id { get; set; }
        public string username { get; set; } = null!;
        public string password { get; set; } = null!;
        public string? email { get; set; }
        public string? role { get; set; }
    }
    public class LoginResponsetDto
    {
        public int? id { get; set; }
        public string username { get; set; } = null!;
        
    }

    public class SignupRequestDto
    {
        public int? id { get; set; }
        public string name { get; set; } = null!;
        public string email { get; set; } = null!;
        public string password { get; set; } = null!;
        public string? role { get; set; } 
    }
    public class SignupResponseDto
    {
        public int? id { get; set; }
        public string name { get; set; } = null!;
        public string email { get; set; } = null!;
        
    }
}
