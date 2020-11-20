﻿using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentCaptureTransaction
    {
        protected internal CardPaymentCaptureTransaction(Amount amount,
                                                Amount vatAmount,
                                                List<OrderItem> orderItems,
                                                string description,
                                                string payeeReference)
        {
            Amount = amount;
            VatAmount = vatAmount;
            OrderItems = orderItems;
            Description = description;
            PayeeReference = payeeReference;
        }

        /// <summary>
        /// The amount (including VAT, if any) to charge the payer,
        /// entered in the lowest monetary unit of the selected currency.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// A 40 character length textual description of the purchase.
        /// </summary>
        public string Description { get; }
        public List<OrderItem> OrderItems { get; }

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// </summary>
        public string PayeeReference { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
        /// This field is used to specify how much ofthe total amount the VAT will be.
        /// Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        public Amount VatAmount { get; }
    }
}