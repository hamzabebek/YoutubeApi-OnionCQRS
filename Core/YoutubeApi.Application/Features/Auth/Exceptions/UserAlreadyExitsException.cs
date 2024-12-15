using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExitsException : BaseException
    {
        public UserAlreadyExitsException() : base("User is already exits!") { }
    }
}
