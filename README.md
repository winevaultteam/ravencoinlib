# RavencoinLib

**.NET Ravencoin library**

## About
The Ravencoin library is a .NET library for Ravencoin and has a focus on the assets handling.

## Thanks to
Crypten for making the [BitcoinLib](https://github.com/cryptean/bitcoinlib) which this project is a fork of.
Since Ravencoin is based on Bitcoin it's possible to use parts of a Bitcoin library to interact with Ravencoin, but with Ravencoins focus on assets it was a need for a more adjusted library for Ravencoin.

## License

See [LICENSE](LICENSE).

## Building from source

To build BitcoinLib from source, you will need either the
[.NET Core SDK or Visual Studio](https://www.microsoft.com/net/download/).

### Building & running tests

With Visual Studio you can build RavencoincoinLib and run the tests
from inside the IDE, otherwise with the `dotnet` command-line
tool you can execute:

```sh
dotnet build
```

## Configuration

Sample configuration:

```xml
﻿<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <!-- BitcoinLib settings start -->

      <!-- Shared RPC settings start -->
      <add key="RpcRequestTimeoutInSeconds" value="10" />
      <!-- Shared RPC settings end -->

      <!-- Bitcoin settings start -->
      <add key="Bitcoin_DaemonUrl" value="http://localhost:8332" />
      <add key="Bitcoin_DaemonUrl_Testnet" value="http://localhost:18332" />
      <add key="Bitcoin_WalletPassword" value="MyWalletPassword" />
      <add key="Bitcoin_RpcUsername" value="MyRpcUsername" />
      <add key="Bitcoin_RpcPassword" value="MyRpcPassword" />
      <!-- Bitcoin settings end -->

    <!-- BitcoinLib settings end -->
  </appSettings>
</configuration>
```
