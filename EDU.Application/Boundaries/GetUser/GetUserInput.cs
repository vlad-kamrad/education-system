namespace EDU.Application.Boundaries.GetUser
{
    public sealed class GetUserInput
    {
        public int UserId { get; }
        public GetUserInput(int userId) => UserId = userId;
    }
}
