﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Interface.AutoMapper;
using YoutubeApi.Application.Interface.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Command.RevokeAll
{
    public class RevokeAllCommandHandler : BaseHandler, IRequestHandler<RevokeAllCommandRequest,Unit>
    {
        private readonly UserManager<User> userManager;

        public RevokeAllCommandHandler(IMapper mapper,
            UserManager<User> userManager,
            IUnitOfWork unitOfWork, 
            IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
        {
            List<User> users = await userManager.Users.ToListAsync(cancellationToken);

            foreach (User user in users) {
                user.RefreshToken = null;
                await userManager.UpdateAsync(user);
            }

            return Unit.Value;
        }
    }
}
