// Copyright (c) 2014 - 2016 George Kimionis
// See the accompanying file LICENSE for the Software License Aggrement

using RavencoinLib.CoinParameters.Base;
using RavencoinLib.Services.RpcServices.RpcExtenderService;
using RavencoinLib.Services.RpcServices.RpcService;

namespace RavencoinLib.Services.Coins.Base
{
    public interface ICoinService : IRpcService, IRpcExtenderService, ICoinParameters
    {
    }
}