﻿using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class SwishSaleResponse
    {
        public SwishSaleResponse(Uri payment, ISwishSaleList sales)
        {
            Payment = payment;
            Sales = sales;
        }

        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this sale payment.
        /// </summary>
        public Uri Payment { get; }

        /// <summary>
        /// The current sales resource.
        /// </summary>
        public ISwishSaleList Sales { get; }
    }
}