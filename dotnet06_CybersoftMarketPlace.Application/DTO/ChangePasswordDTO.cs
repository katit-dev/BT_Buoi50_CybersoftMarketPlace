namespace dotnet06_CybersoftMarketPlace.Application.DTOs
{
    public class ChangePasswordDTO
    {
        public string OldPassword { get; set; } = null!;


        public string NewPassword { get; set; } = null!;


        public string ConfirmPassword { get; set; } = null!;
    }
}