// Copyright (c) 2014 - 2016 George Kimionis, Modified 2019 WiVTech
// See the accompanying file LICENSE for the Software License Aggrement

using System.Collections;
using System.Collections.Generic;
using RavencoinLib.Requests.AddNode;
using RavencoinLib.Requests.CreateRawTransaction;
using RavencoinLib.Requests.SignRawTransaction;
using RavencoinLib.Responses;

namespace RavencoinLib.Services.RpcServices.RpcService
{
    public interface IRpcService
    {
        #region Blockchain

        string GetBestBlockHash();
        GetBlockResponse GetBlock(string hash, bool verbose = true);
        GetBlockResponseVerbose GetBlock(string hash, int verbosity);
        GetBlockchainInfoResponse GetBlockchainInfo();
        uint GetBlockCount();
        string GetBlockHash(long index);
        //  getblockheader
        //  getchaintips
        double GetDifficulty();
        List<GetChainTipsResponse> GetChainTips();
        GetMemPoolInfoResponse GetMemPoolInfo();
        GetRawMemPoolResponse GetRawMemPool(bool verbose = false);
        GetTransactionResponse GetTxOut(string txId, int n, bool includeMemPool = true);
        //  gettxoutproof["txid",...] ( blockhash )
        GetTxOutSetInfoResponse GetTxOutSetInfo();
        bool VerifyChain(ushort checkLevel = 3, uint numBlocks = 288); //  Note: numBlocks: 0 => ALL

        #endregion

        #region Control

        GetInfoResponse GetInfo();
        string Help(string command = null);
        string Stop();

        #endregion

        #region Generating

        //  generate numblocks
        bool GetGenerate();
        string SetGenerate(bool generate, short generatingProcessorsLimit);

        #endregion

        #region Mining

        GetBlockTemplateResponse GetBlockTemplate(params object[] parameters);
        GetMiningInfoResponse GetMiningInfo();
        ulong GetNetworkHashPs(uint blocks = 120, long height = -1);
        bool PrioritiseTransaction(string txId, decimal priorityDelta, decimal feeDelta);
        string SubmitBlock(string hexData, params object[] parameters);

        #endregion

        #region Network

        void AddNode(string node, NodeAction action);
        //  clearbanned
        //  disconnectnode
        GetAddedNodeInfoResponse GetAddedNodeInfo(string dns, string node = null);
        int GetConnectionCount();
        GetNetTotalsResponse GetNetTotals();
        GetNetworkInfoResponse GetNetworkInfo();
        List<GetPeerInfoResponse> GetPeerInfo();
        //  listbanned
        void Ping();
        //  setban

        #endregion

        #region Rawtransactions

        string CreateRawTransaction(CreateRawTransactionRequest rawTransaction);
        DecodeRawTransactionResponse DecodeRawTransaction(string rawTransactionHexString);
        DecodeScriptResponse DecodeScript(string hexString);
        //  fundrawtransaction
        GetRawTransactionResponse GetRawTransaction(string txId, int verbose = 0);
        string SendRawTransaction(string rawTransactionHexString, bool? allowHighFees = false);
        SignRawTransactionResponse SignRawTransaction(SignRawTransactionRequest signRawTransactionRequest);
        SignRawTransactionWithKeyResponse SignRawTransactionWithKey(SignRawTransactionWithKeyRequest signRawTransactionWithKeyRequest);
        SignRawTransactionWithWalletResponse SignRawTransactionWithWallet(SignRawTransactionWithWalletRequest signRawTransactionWithWalletRequest);
        GetFundRawTransactionResponse GetFundRawTransaction(string rawTransactionHex);

        #endregion

        #region Util

        CreateMultiSigResponse CreateMultiSig(int nRquired, List<string> publicKeys);
        decimal EstimateFee(ushort nBlocks);
        EstimateSmartFeeResponse EstimateSmartFee(ushort nBlocks);
        decimal EstimatePriority(ushort nBlocks);
        //  estimatesmartfee
        //  estimatesmartpriority
        ValidateAddressResponse ValidateAddress(string ravencoinAddress);
        bool VerifyMessage(string ravencoinAddress, string signature, string message);

        #endregion

        #region Wallet

        //  abandontransaction
        string AddMultiSigAddress(int nRquired, List<string> publicKeys, string account = null);
        string AddWitnessAddress(string address);
        void BackupWallet(string destination);
        string DumpPrivKey(string ravencoinAddress);
        void DumpWallet(string filename);
        string GetAccount(string ravencoinAddress);
        string GetAccountAddress(string account);
        List<string> GetAddressesByAccount(string account);
        Dictionary<string, GetAddressesByLabelResponse> GetAddressesByLabel(string label);
        GetAddressInfoResponse GetAddressInfo(string ravencoinAddress);
        decimal GetBalance(string account = null, int minConf = 1, bool? includeWatchonly = null);
        string GetNewAddress(string account = "");
        string GetRawChangeAddress();
        decimal GetReceivedByAccount(string account, int minConf = 1);
        decimal GetReceivedByAddress(string ravencoinAddress, int minConf = 1);
        decimal GetReceivedByLabel(string account, int minConf = 1);
        GetTransactionResponse GetTransaction(string txId, bool? includeWatchonly = null);
        decimal GetUnconfirmedBalance();
        GetWalletInfoResponse GetWalletInfo();
        void ImportAddress(string address, string label = null, bool rescan = true);
        string ImportPrivKey(string privateKey, string label = null, bool rescan = true);
        //  importpubkey
        void ImportWallet(string filename);
        string KeyPoolRefill(uint newSize = 100);
        Dictionary<string, decimal> ListAccounts(int minConf = 1, bool? includeWatchonly = null);
        List<List<ListAddressGroupingsResponse>> ListAddressGroupings();
        List<string> ListLabels();
        string ListLockUnspent();
        List<ListReceivedByAccountResponse> ListReceivedByAccount(int minConf = 1, bool includeEmpty = false, bool? includeWatchonly = null);
        List<ListReceivedByAddressResponse> ListReceivedByAddress(int minConf = 1, bool includeEmpty = false, bool? includeWatchonly = null);
        List<ListReceivedByLabelResponse> ListReceivedByLabel(int minConf = 1, bool includeEmpty = false, bool? includeWatchonly = null);
        ListSinceBlockResponse ListSinceBlock(string blockHash = null, int targetConfirmations = 1, bool? includeWatchonly = null);
        List<ListTransactionsResponse> ListTransactions(string account = null, int count = 10, int from = 0, bool? includeWatchonly = null);
        List<ListUnspentResponse> ListUnspent(int minConf = 1, int maxConf = 9999999, List<string> addresses = null);
        bool LockUnspent(bool unlock, IList<ListUnspentResponse> listUnspentResponses);
        bool Move(string fromAccount, string toAccount, decimal amount, int minConf = 1, string comment = "");
        string SendFrom(string fromAccount, string toravencoinAddress, decimal amount, int minConf = 1, string comment = null, string commentTo = null);
        string SendMany(string fromAccount, Dictionary<string, decimal> toravencoinAddress, int minConf = 1, string comment = null);
        string SendToAddress(string ravencoinAddress, decimal amount, string comment = null, string commentTo = null, bool subtractFeeFromAmount = false);
        string SetAccount(string ravencoinAddress, string account);
        string SetLabel(string ravencoinAddress, string label);
        string SetTxFee(decimal amount);
        string SignMessage(string ravencoinAddress, string message);
        string WalletLock();
        string WalletPassphrase(string passphrase, int timeoutInSeconds);
        string WalletPassphraseChange(string oldPassphrase, string newPassphrase);

        #endregion

        #region Ravencoin assets
        //https://github.com/RavenProject/Ravencoin/blob/master/src/rpc/assets.cpp
        
        //  category    name                          actor (function)             argNames
  //  ----------- ------------------------      -----------------------      ----------
  //  { "assets",   "issue",                      &issue,                      {"asset_name","qty","to_address","change_address","units","reissuable","has_ipfs","ipfs_hash"} },
  //  { "assets",   "issueunique",                &issueunique,                {"root_name", "asset_tags", "ipfs_hashes", "to_address", "change_address"}},
  //  { "assets",   "listassetbalancesbyaddress", &listassetbalancesbyaddress, {"address", "onlytotal", "count", "start"} },
  //  { "assets",   "getassetdata",               &getassetdata,               {"asset_name"}},
  //  { "assets",   "listmyassets",               &listmyassets,               {"asset", "verbose", "count", "start"}},
  //  { "assets",   "listaddressesbyasset",       &listaddressesbyasset,       {"asset_name", "onlytotal", "count", "start"}},
  //  { "assets",   "transfer",                   &transfer,                   {"asset_name", "qty", "to_address"}},
  //  { "assets",   "reissue",                    &reissue,                    {"asset_name", "qty", "to_address", "change_address", "reissuable", "new_unit", "new_ipfs"}},
  //  { "assets",   "listassets",                 &listassets,                 {"asset", "verbose", "count", "start"}},
  //  { "assets",   "getcacheinfo",               &getcacheinfo,               {}}
  
        List<string> ListMyAssets(string asset); //TODO: make a version with verbose
        List<string> ListAssets(string asset); //TODO: make a version with verbose
        List<ListAddressesByAssetResponse> ListAddressesByAsset(string asset, bool onlyTotal = false, int count = 50000, int start = 0);
        List<ListAssetBalancesByAddressResponse> ListAssetBalancesByAddress(string ravenCoinAddress, bool onlyTotal = false, int count = 50000, int start = 0);
        GetAssetDataResponse GetAssetData(string assetName);
        TransferResult Transfer(string assetName, double qty, string toAddress);
        string Reissue(string assetName, int qty, string toAddress, string changeAddress = "", bool reIssuable = true, int newUnit = -1,  string newIpfs = "");
        string IssueUnique(string rootName, ArrayList assetTags, ArrayList ipfsHashes = null, string toAddress = "", string changeAddress = "");
        List<string> Issue(string assetName, int qty = 1, string toAddress = "", string changeAddress = "", int units = 0, bool reIssuable = true, bool hasIpfs = false, string ipfsHash = null);
        List<string> GetCacheInfo();      
        
        #endregion
    }
}