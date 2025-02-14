﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.SettingsModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NodeSelectionMethod
    {
        Static,
        Random,
        Sequential
    }

    public class Settings
    {
        public static string defaultUrlApiServer = "https://autosendfunds.ddns.net:5001";
        public static string defaultGoShimmerDashboardUrl = "https://dashboards.nectar.iota.cafe";

        public string WalletName { get; set; }
        public bool PublishReceiveAddress { get; set; }
        public string CliWalletFullpath { get; set; }
        public string AccessManaId { get; set; }
        public string ConsensusManaId { get; set; }
        public string UrlWalletReceiveAddresses { get; set; }
        public string UrlWalletNodes { get; set; }
        public bool VerifyIfReceiveAddressesExist { get; set; }
        public string GoShimmerDashboardUrl { get; set; }
        public int MinAmountToSend { get; set; }
        public int MaxAmountToSend { get; set; }
        public List<string> TokensToSent { get; set; }
        public bool StopWhenNoBalanceWithCreditIsAvailable { get; set; }
        public int WaitingTimeInSecondsBetweenTransactions { get; set; }
        public string WaitForPreviousTransactionToFinish { get; set; }
        public bool ShowOutputCliWallet { get; set; }
        public bool PickRandomDestinationAddress { get; set; }
        public NodeSelectionMethod NodeSelectionMethod { get; set; }
        public string NodeToUseWhenStaticNodeSelectionMethod { get; set; }
        public int MaxWaitingTimeInSecondsForRequestingFunds { get; set; }

        public Logging Logging { get; set; }
    }
}
