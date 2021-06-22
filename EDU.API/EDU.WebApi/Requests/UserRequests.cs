namespace EDU.WebApi.Requests
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class ChangePasswordRequest
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }

    public class ChangeRoleRequest
    {
        public int UserId { get; }
        public int[] RolesId { get; }
    }
}
