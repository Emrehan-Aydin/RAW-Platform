using MediatR;
using RAWAPI.Domain.Dtos.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAWAPI.Domain.Dtos.Request.User {
    public class UserTopbarInfoRequest : CommandBase<CommandResult<UserTopbarInfoResponse>> {
        public string UserId { get; set; }
    }
}
