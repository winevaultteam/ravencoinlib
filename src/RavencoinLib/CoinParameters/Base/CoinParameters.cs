// Copyright (c) 2014 - 2016 George Kimionis
// See the accompanying file LICENSE for the Software License Aggrement

using System;
using System.Configuration;
using System.Diagnostics;
using RavencoinLib.Auxiliary;
using RavencoinLib.Services.Coins.Base;
using RavencoinLib.Services.Coins.Ravencoin;

namespace RavencoinLib.Services
{
    public partial class CoinService
    {
        public CoinParameters Parameters { get; }

        public class CoinParameters
        {
            #region Constructor

            public CoinParameters(ICoinService coinService,
                string daemonUrl,
                string rpcUsername,
                string rpcPassword,
                string walletPassword,
                short rpcRequestTimeoutInSeconds)
            {
                if (!string.IsNullOrWhiteSpace(daemonUrl))
                {
                    DaemonUrl = daemonUrl;
                    UseTestnet = false; //  this will force the CoinParameters.SelectedDaemonUrl dynamic property to automatically pick the daemonUrl defined above
                    IgnoreConfigFiles = true;
                    RpcUsername = rpcUsername;
                    RpcPassword = rpcPassword;
                    WalletPassword = walletPassword;
                }

                if (rpcRequestTimeoutInSeconds > 0)
                {
                    RpcRequestTimeoutInSeconds = rpcRequestTimeoutInSeconds;
                }
                else
                {
                    short rpcRequestTimeoutTryParse = 0;

                    if (short.TryParse(ConfigurationManager.AppSettings.Get("RpcRequestTimeoutInSeconds"), out rpcRequestTimeoutTryParse))
                    {
                        RpcRequestTimeoutInSeconds = rpcRequestTimeoutTryParse;
                    }
                }

                if (IgnoreConfigFiles && (string.IsNullOrWhiteSpace(DaemonUrl) || string.IsNullOrWhiteSpace(RpcUsername) || string.IsNullOrWhiteSpace(RpcPassword)))
                {
                    throw new Exception($"One or more required parameters, as defined in {GetType().Name}, were not found in the configuration file!");
                }

                if (IgnoreConfigFiles && Debugger.IsAttached && string.IsNullOrWhiteSpace(WalletPassword))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[WARNING] The wallet password is either null or empty");
                    Console.ResetColor();
                }
								
								

                #region Smartcash

                else if (coinService is RavencoinService)
                {
                    if (!IgnoreConfigFiles)
                    {
                        DaemonUrl = ConfigurationManager.AppSettings.Get("Ravencoin_DaemonUrl");
                        DaemonUrlTestnet = ConfigurationManager.AppSettings.Get("Ravencoin_DaemonUrl_Testnet");
                        RpcUsername = ConfigurationManager.AppSettings.Get("Ravencoin_RpcUsername");
                        RpcPassword = ConfigurationManager.AppSettings.Get("Ravencoin_RpcPassword");
                        WalletPassword = ConfigurationManager.AppSettings.Get("Ravencoin_WalletPassword");
                    }

                    CoinShortName = "RVN";
                    CoinLongName = "Ravencoin";
                    IsoCurrencyCode = "RVN";

                    TransactionSizeBytesContributedByEachInput = 148;
                    TransactionSizeBytesContributedByEachOutput = 34;
                    TransactionSizeFixedExtraSizeInBytes = 10;

                    FreeTransactionMaximumSizeInBytes = 0; // free txs are not supported
                    FreeTransactionMinimumOutputAmountInCoins = 0;
                    FreeTransactionMinimumPriority = 0;
                    FeePerThousandBytesInCoins = 0.0001M;
                    MinimumTransactionFeeInCoins = 0.001M;
                    MinimumNonDustTransactionAmountInCoins = 0.00001M;

                    TotalCoinSupplyInCoins = 5000000000;
                    EstimatedBlockGenerationTimeInMinutes = 0.916667;
                    BlocksHighestPriorityTransactionsReservedSizeInBytes = 50000;

                    BaseUnitName = "Ravenoshi";
                    BaseUnitsPerCoin = 100000000;
                    CoinsPerBaseUnit = 0.00000001M;
                }

                #endregion

                else
                {
                    throw new Exception("Unknown coin!");
                }

                #endregion

                #region Invalid configuration / Missing parameters

                if (RpcRequestTimeoutInSeconds <= 0)
                {
                    throw new Exception("RpcRequestTimeoutInSeconds must be greater than zero");
                }

                if (string.IsNullOrWhiteSpace(DaemonUrl)
                    || string.IsNullOrWhiteSpace(RpcUsername)
                    || string.IsNullOrWhiteSpace(RpcPassword))
                {
                    throw new Exception($"One or more required parameters, as defined in {GetType().Name}, were not found in the configuration file!");
                }

                #endregion
            }

            public string BaseUnitName { get; set; }
            public uint BaseUnitsPerCoin { get; set; }
            public int BlocksHighestPriorityTransactionsReservedSizeInBytes { get; set; }
            public int BlockMaximumSizeInBytes { get; set; }
            public string CoinShortName { get; set; }
            public string CoinLongName { get; set; }
            public decimal CoinsPerBaseUnit { get; set; }
            public string DaemonUrl { private get; set; }
            public string DaemonUrlTestnet { private get; set; }
            public double EstimatedBlockGenerationTimeInMinutes { get; set; }
            public int ExpectedNumberOfBlocksGeneratedPerDay => (int) EstimatedBlockGenerationTimeInMinutes * GlobalConstants.MinutesInADay;
            public decimal FeePerThousandBytesInCoins { get; set; }
            public short FreeTransactionMaximumSizeInBytes { get; set; }
            public decimal FreeTransactionMinimumOutputAmountInCoins { get; set; }
            public int FreeTransactionMinimumPriority { get; set; }
            public bool IgnoreConfigFiles { get; }
            public string IsoCurrencyCode { get; set; }
            public decimal MinimumNonDustTransactionAmountInCoins { get; set; }
            public decimal MinimumTransactionFeeInCoins { get; set; }
            public decimal OneBaseUnitInCoins => CoinsPerBaseUnit;
            public uint OneCoinInBaseUnits => BaseUnitsPerCoin;
            public string RpcPassword { get; set; }
            public short RpcRequestTimeoutInSeconds { get; set; }
            public string RpcUsername { get; set; }
            public string SelectedDaemonUrl => !UseTestnet ? DaemonUrl : DaemonUrlTestnet;
            public ulong TotalCoinSupplyInCoins { get; set; }
            public int TransactionSizeBytesContributedByEachInput { get; set; }
            public int TransactionSizeBytesContributedByEachOutput { get; set; }
            public int TransactionSizeFixedExtraSizeInBytes { get; set; }
            public bool UseTestnet { get; set; }
            public string WalletPassword { get; set; }
        }
    }
}
