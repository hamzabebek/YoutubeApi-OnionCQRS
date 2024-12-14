using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Auth.Exceptions;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExits(User? user)
        {
            if (user is not null) throw new UserAlreadyExitsException();
            return Task.CompletedTask;
        }
    }
}
