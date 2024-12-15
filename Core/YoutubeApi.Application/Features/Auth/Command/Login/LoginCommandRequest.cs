using System.ComponentModel;
using MediatR;

namespace YoutubeApi.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        [DefaultValue("hamza@gmail.com")]
        public string Email { get; set; }
        [DefaultValue("123456")]
        public string Password { get; set; }
    }
}
