using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace gRPC.GrpcService.Services {
    public class WelcomeService {
        public async Task<string> Hi5(ServerCallContext context) {
            return "HI gRPC";
        }
    }
}