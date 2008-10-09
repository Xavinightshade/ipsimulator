using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    /// <summary>
    /// An abstract class that contains information about a rule as well as a method to validate it.
    /// </summary>
    /// <remarks>
    /// This class is primarily designed to be used on a domain object to validate a business rule. In most cases, you will want to use the 
    /// concrete class SimpleRule, which just needs you to supply a delegate used for validation. For custom, complex business rules, you can 
    /// extend this class and provide your own method to validate the rule.
    /// </remarks>
    public abstract class Rule {
        private string _description;
        private string _propertyName;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="propertyName">The name of the property the rule is based on. This may be blank if the rule is not for any specific property.</param>
        /// <param name="brokenDescription">A description of the rule that will be shown if the rule is broken.</param>
        protected Rule(string propertyName, string brokenDescription) {
            this.Description = brokenDescription;
            this.PropertyName = propertyName;
        }

        /// <summary>
        /// Gets descriptive text about this broken rule.
        /// </summary>
        public  string Description {
            get { return _description; }
            protected set { _description = value; }
        }

        /// <summary>
        /// Gets the name of the property the rule belongs to.
        /// </summary>
        public  string PropertyName {
            get { return (_propertyName ?? string.Empty).Trim(); }
            protected set { _propertyName = value; }
        }

        /// <summary>
        /// Validates that the rule has been followed.
        /// </summary>
        public abstract bool ValidateRule(DomainObject domainObject);

        /// <summary>
        /// Gets a string representation of this rule.
        /// </summary>
        /// <returns>A string containing the description of the rule.</returns>
        public override string ToString() {
            return this.Description;
        }


    }
}
