﻿using SwedbankPay.Sdk.Payments.CardPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class CardPaymentsResource : ResourceBase, ICardPaymentsResource
    {
        public CardPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<ICardPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return CardPayment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public Task<ICardPayment> Create(CardPayments.CardPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return CardPayment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
