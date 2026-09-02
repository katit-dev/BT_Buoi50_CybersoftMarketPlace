


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
        "Email, username, or phone number already exists.";



    // Login
    public const string SuccessLogin =
        "User logged in successfully.";

    public const string InvalidLogin =
        "Invalid email, username, phone number, or password.";



    // User
    public const string UserNotFound =
        "User not found.";

    public const string InvalidToken =
        "Invalid token.";



    // Profile
    public const string GetProfileSuccess =
        "Get user profile successfully.";

    public const string UpdateProfileSuccess =
        "Update user profile successfully.";

    public const string UpdateProfileFailed =
        "Update user profile failed.";



    // Avatar
    public const string UpdateAvatarSuccess =
        "Update avatar successfully.";

    public const string UpdateAvatarFailed =
        "Update avatar failed.";



    // Change Password
    public const string ChangePasswordSuccess =
        "Change password successfully.";

    public const string OldPasswordIncorrect =
        "Current password is incorrect.";

    public const string ChangePasswordFailed =
        "Change password failed.";

    public const string InvalidOldPassword =
        "Old password is incorrect.";

    public const string PasswordConfirmNotMatch =
        "Password confirmation does not match.";

    public const string NewPasswordCannotBeOldPassword =
        "New password cannot be the same as the old password.";
}

public static class OrderResponseMessageDTO
{
    public const string GetMyOrdersSuccess =
        "Get order history successfully.";

    public const string GetMyOrdersFailed =
        "Failed to get order history.";

    public const string OrderNotFound =
        "Order not found.";
}