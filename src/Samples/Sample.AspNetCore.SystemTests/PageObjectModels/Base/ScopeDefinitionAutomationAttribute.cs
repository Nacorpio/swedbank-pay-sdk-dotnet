﻿using System.Linq;

using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Base
{

    /// <summary>
    ///     Represents the base attribute class for component scope definition.
    ///     The basic definition is represented with XPath.
    /// </summary>
    public abstract class ScopeDefinitionAutomationAttribute : MulticastAttribute
    {
        /// <summary>
        ///     The default scope XPath, which is <c>"*"</c>.
        /// </summary>
        public const string DefaultScopeXPath = "*";

        private readonly string baseScopeXPath;


        protected ScopeDefinitionAutomationAttribute(string type = DefaultScopeXPath, string automationAttribute = "")
        {
            baseScopeXPath = string.Format("{0}[@automation='{1}']", type, automationAttribute);
        }


        /// <summary>
        ///     Gets or sets the containing CSS class name.
        /// </summary>
        public string ContainingClass
        {
            get => ContainingClasses?.FirstOrDefault();
            set => ContainingClasses = value == null ? null : new[] { value };
        }

        /// <summary>
        ///     Gets or sets the containing CSS class names.
        ///     Multiple class names are used in XPath as conditions joined with <c>and</c> operator.
        /// </summary>
        public string[] ContainingClasses { get; set; }

        /// <summary>
        ///     Gets the XPath of the scope element which is a combination of XPath passed through the constructor and
        ///     <see cref="ContainingClasses" /> property values.
        /// </summary>
        public string ScopeXPath => BuildScopeXPath();


        /// <summary>
        ///     Builds the complete XPath of the scope element which is a combination of XPath passed through the constructor and
        ///     <see cref="ContainingClasses" /> property values.
        /// </summary>
        /// <returns>The built XPath.</returns>
        protected virtual string BuildScopeXPath()
        {
            var scopeXPath = baseScopeXPath ?? DefaultScopeXPath;

            if (ContainingClasses?.Any() ?? false)
            {
                var classConditions = ContainingClasses.Select(x => $"contains(concat(' ', normalize-space(@class), ' '), ' {x.Trim()} ')");
                return $"{scopeXPath}[{string.Join(" and ", classConditions)}]";
            }

            return scopeXPath;
        }
    }
}