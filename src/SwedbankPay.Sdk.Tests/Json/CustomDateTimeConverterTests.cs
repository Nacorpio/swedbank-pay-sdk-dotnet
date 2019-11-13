﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwedbankPay.Sdk.PaymentOrders;
using Xunit;
namespace SwedbankPay.Sdk.Tests.Json
{
    public class CustomDateTimeConverterTests
    {
        
        [Fact]
        public async Task CanConvert_DateTime()
        {
            //ARRANGE
            var riskIndicator = new RiskIndicator
            {
                PreOrderDate = new DateTime(2020,1,1)
            };
            
            //ACT
            var result = JsonConvert.SerializeObject(riskIndicator);
            JObject obj = JObject.Parse(result);
            
            var dateTimeAsString = obj.GetValue("PreOrderDate").ToString();
            //ASSERT
            Assert.Equal("20200101", dateTimeAsString);
            
        }
    }
}