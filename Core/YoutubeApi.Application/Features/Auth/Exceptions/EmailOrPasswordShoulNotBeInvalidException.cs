using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShoulNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShoulNotBeInvalidException() : base("Email or password wrong!") { }
    }
}
