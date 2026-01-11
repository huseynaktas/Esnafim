using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Dto.FakeLoginDtos
{
    public class FakeAuthDto
    {
        public sealed record FakeLoginRequest(string Email, string Password);

        public sealed record FakeLoginResponse(int BusinessOwnerId, string Email, string FullName);

    }
}
