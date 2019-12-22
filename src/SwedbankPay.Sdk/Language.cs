﻿using System;
using System.Globalization;
using System.Linq;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk
{
    public class Language
    {
        public Language(CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                throw new ArgumentException(nameof(cultureInfo));
            }
          
            Value = cultureInfo.Name;
        }


        [JsonConstructor]
        internal Language(string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                throw new ArgumentNullException(nameof(languageCode), "Language code can't be null or empty");
            if (!IsValidLanguage(languageCode))
                throw new ArgumentException($"Invalid language: {languageCode}", nameof(languageCode));
            Value = languageCode;
        }


        private string Value { get; }


        public static bool IsValidLanguage(string languageCode)
        {
            if (string.IsNullOrWhiteSpace(languageCode))
                return false;

            return CultureInfo.GetCultures(CultureTypes.AllCultures).Any(c => c.Name.Equals(languageCode));
        }


        public override string ToString()
        {
            return Value;
        }
    }
}