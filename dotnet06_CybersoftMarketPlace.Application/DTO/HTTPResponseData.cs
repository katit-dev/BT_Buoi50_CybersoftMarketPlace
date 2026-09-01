


public class HTTPResponseData<T>
{
    public T DataResponse { get; set; }
    public string Message { get; set; }
    public int statusCode { get; set; }
    public DateTime Timestamp { get; set; }
}


public static class UserResponseMessageDTO
{
    // Register
    public const string SuccessRegister =
        "User registered successfully.";

    public const string FailedRegister =
        "User registration failed.";

    public const string EmailUsernameOrPhoneExists =
        "Email, username, or phone already exists.";


    // Login
    public const string SuccessLogin =
        "User logged in successfully.";

    public const string InvalidLogin =
        "Invalid email, username, phone, or password.";


    // User
    public const string UserNotFound =
        "Username/Phone/Email or password is incorrect.";

    public const string InvalidToken =
        "Invalid token.";


    // Profile
    public const string GetProfileSuccess =
        "Get profile successfully.";

    public const string UpdateProfileSuccess =
        "Update profile successfully.";

    public const string UpdateProfileFailed =
        "Update profile failed.";

    // avatar
    public const string UpdateAvatarSuccess =
    "Update avatar successfully.";

    public const string UpdateAvatarFailed =
        "Update avatar failed.";

    // Change password
    public const string ChangePasswordSuccess =
        "Đổi mật khẩu thành công.";

    public const string OldPasswordIncorrect =
        "Mật khẩu hiện tại không chính xác.";

    public const string ChangePasswordFailed =
        "Đổi mật khẩu thất bại.";

    public const string InvalidOldPassword =
    "Mật khẩu cũ không chính xác.";

    public const string PasswordConfirmNotMatch =
        "Mật khẩu xác nhận không khớp.";

    public const string NewPasswordCannotBeOldPassword =
        "Mật khẩu mới không được trùng với mật khẩu cũ.";

}