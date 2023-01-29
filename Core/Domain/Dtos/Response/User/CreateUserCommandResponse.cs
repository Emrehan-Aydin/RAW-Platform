using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAWAPI.Domain.Dtos.Response.User
{
    public class CreateUserCommandResponse
    {
        public string UserId { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
