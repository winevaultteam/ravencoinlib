// Copyright (c) 2014 - 2016 George Kimionis
// See the accompanying file LICENSE for the Software License Aggrement

using RavencoinLib.Services.Coins.Base;

namespace RavencoinLib.ExtensionMethods
{
    public static class CoinServiceExtensionMethods
    {
        public static void SwitchNetworks(this ICoinService coinService)
        {
            coinService.Parameters.UseTestnet = !coinService.Parameters.UseTestnet;
        }
    }
}