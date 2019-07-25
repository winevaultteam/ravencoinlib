// Copyright (c) 2014 - 2016 George Kimionis
// See the accompanying file LICENSE for the Software License Aggrement

using RavencoinLib.CoinParameters.Ravencoin;

namespace RavencoinLib.Services.Coins.Ravencoin
{
    public class RavencoinService : CoinService, IRavencoinService
    {
        public RavencoinService(bool useTestnet = false) : base(useTestnet)
        {
        }

        public RavencoinService(string daemonUrl, string rpcUsername, string rpcPassword, string walletPassword = null)
            : base(daemonUrl, rpcUsername, rpcPassword, walletPassword)
        {
        }

        public RavencoinService(string daemonUrl, string rpcUsername, string rpcPassword, string walletPassword, short rpcRequestTimeoutInSeconds)
            : base(daemonUrl, rpcUsername, rpcPassword, walletPassword, rpcRequestTimeoutInSeconds)
        {
        }

        public RavencoinConstants.Constants Constants => RavencoinConstants.Constants.Instance;
    }
}