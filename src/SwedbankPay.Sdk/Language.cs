﻿using System;
using System.Globalization;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Contains information about a payers prefered langauge.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Instantiates a new <seealso cref="Language"/>.
        /// </summary>
        /// <param name="language">A string in the format of xx-YY</param>
        public Language(string language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            Culture = new CultureInfo(language);
            if (Culture.IsNeutralCulture)
            {
                throw new ArgumentException($"Must be given in a xx-YY format.", nameof(language));
            }
        }

        private CultureInfo Culture { get; }

        public override string ToString()
        {
            return Culture.Name;
        }
    }
}
