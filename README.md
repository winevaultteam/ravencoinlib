# RavencoinLib
[![Build Status](https://dev.azure.com/tech0152/RavencoinLib/_apis/build/status/wivtech.ravencoinlib?branchName=master)](https://dev.azure.com/tech0152/RavencoinLib/_build/latest?definitionId=2&branchName=master)

**.NET Ravencoin library**

## About
The Ravencoin library is a .NET library for Ravencoin and has a focus on the assets handling.

## Thanks to
Big thanks to Crypten for making the [BitcoinLib](https://github.com/cryptean/bitcoinlib) which this project is a fork of.
Since Ravencoin is based on Bitcoin it's possible to use parts of a Bitcoin library to interact with Ravencoin, but with Ravencoins focus on assets it was a need for a more adjusted library for Ravencoin.

## License

See [LICENSE](LICENSE).

## Building from source

To build RavencoinLib from source, you will need either the
[.NET Core SDK or Visual Studio](https://www.microsoft.com/net/download/).

### Building & running tests

With Visual Studio you can build RavencoincoinLib and run the tests
from inside the IDE, otherwise with the `dotnet` command-line
tool you can execute:

```sh
dotnet build
```

## Raven.conf

Sample conf:

server=1

listen=1

rpcuser=MyRpcUsername

rpcpassword=MyRpcPassword

rpcallowip=127.0.0.1

## Configuration

Sample configuration:

```xml
﻿<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <!-- RavencoinLib settings start -->

      <!-- Shared RPC settings start -->
      <add key="RpcRequestTimeoutInSeconds" value="10" />
      <!-- Shared RPC settings end -->

      <!-- Ravencoin settings start -->
      <add key="Ravencoin_DaemonUrl" value="http://localhost:18766" />
      <add key="Ravencoin_DaemonUrl_Testnet" value="http://localhost:18766" />
      <add key="Ravencoin_WalletPassword" value="MyWalletPassword" />
      <add key="Ravencoin_RpcUsername" value="MyRpcUsername" />
      <add key="Ravencoin_RpcPassword" value="MyRpcPassword" />
      <!-- Ravencoin settings end -->

    <!-- RavencoinLib settings end -->
  </appSettings>
</configuration>
```
