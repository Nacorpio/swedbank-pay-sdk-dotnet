﻿namespace SwedbankPay.Sdk.Models.Vipps.TransactionAPI.Response
{
    internal class ReversalTransactionResponseContainer
    {
        public string Payment { get; set; }
        public TransactionContainer Reversal { get; set; }
    }
}