﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Object holding a payer/consumer email address.
    /// </summary>
    public class EmailAddress
    {
        /// <summary>
        /// Constructs a <seealso cref="EmailAddress"/> after validating the input.
        /// </summary>
        /// <param name="emailAddress">A email to be validated and stored.</param>
        public EmailAddress(string emailAddress)
        {
            if (!IsValidEmail(emailAddress))
            {
                throw new ArgumentException($"Invalid email address: {emailAddress}", nameof(emailAddress));
            }

            Value = emailAddress;
        }


        private string Value { get; }

        /// <summary>
        /// Validates a email address.
        /// </summary>
        /// <param name="emailAddress">The email address to validate.</param>
        /// <returns>true if it is valid, false othervise.</returns>
        public static bool IsValidEmail(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                return false;
            }

            try
            {
                // Normalize the domain
                emailAddress = Regex.Replace(emailAddress, @"(@)(.+)$", DomainMapper,
                                             RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(emailAddress,
                                     @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                     @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                                     RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private static string DomainMapper(Match match)
        {
            // Use IdnMapping class to convert Unicode domain names.
            var idn = new IdnMapping();

            // Pull out and process domain name (throws ArgumentException on invalid)
            var domainName = idn.GetAscii(match.Groups[2].Value);

            return match.Groups[1].Value + domainName;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override string ToString()
        {
            return Value;
        }
    }
}