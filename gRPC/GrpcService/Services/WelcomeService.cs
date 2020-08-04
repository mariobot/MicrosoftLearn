using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    public class WelcomeService : Welcome.WelcomeBase
    {
        public override Task<WelcomeReply> SayWelcome(WelcomeRequest request, ServerCallContext context)
        {
            return Task.FromResult(new WelcomeReply
            {
                Message = "WELCOME TO gRPC " + request.Name
            });
        }
    }
}
