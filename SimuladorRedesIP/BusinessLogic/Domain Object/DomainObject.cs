using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BusinessObjects
{
	/// <summary>
	/// The class all domain objects must inherit from. Allows changes via a BeginEdit()/EndEdit() combination, and 
	/// provides rollbacks for cancels.
	/// </summary>
	[Serializable()]

	public abstract class DomainObject : INotifyPropertyChanged, IDataErrorInfo
	{

		private List<Rule> _rules;

		/// <summary>
		/// Constructor.
		/// </summary>

		protected DomainObject()
		{

		}






		/// <summary>
		/// Gets a value indicating whether or not this domain object is valid. 
		/// </summary>
		public virtual bool IsValid
		{
			get
			{
				return this.Error == null;
			}
		}

		/// <summary>
		/// Gets an error message indicating what is wrong with this domain object. The default is an empty string ("").
		/// </summary>
		public virtual string Error
		{
			get
			{
				string result = this[string.Empty];
				if (result != null && result.Trim().Length == 0)
				{
					result = null;
				}
				return result;
			}
		}

		/// <summary>
		/// Gets the error message for the property with the given name.
		/// </summary>
		/// <param name="propertyName">The name of the property whose error message to get.</param>
		/// <returns>The error message for the property. The default is an empty string ("").</returns>
		/// 

		public bool SonValidasLasReglas(ReadOnlyCollection<Rule> rules)
		{
			return GetBrokenRules(rules).Count == 0;
		}

		public virtual string this[string columnName]
		{
			get
			{
				string result = string.Empty;

				columnName = CleanString(columnName);

				if (_rules == null)
				{
					_rules = new List<Rule>();
					_rules.AddRange(this.CreateRules());
				}

				foreach (Rule r in GetBrokenRules(columnName, _rules.AsReadOnly()))
				{
					if (columnName.Length == 0 || r.PropertyName == columnName)
					{
						result += r.Description;
						result += Environment.NewLine;
					}
				}
				result = result.Trim();
				if (result.Length == 0)
				{
					result = null;
				}
				return result;
			}
		}

		/// <summary>
		/// Validates all rules on this domain object, returning a list of the broken rules.
		/// </summary>
		/// <returns>A read-only collection of rules that have been broken.</returns>
		public  ReadOnlyCollection<Rule> GetBrokenRules(ReadOnlyCollection<Rule> rules)
		{
			return GetBrokenRules(string.Empty, rules);
		}

		/// <summary>
		/// Validates all rules on this domain object for a given property, returning a list of the broken rules.
		/// </summary>
		/// <param name="property">The name of the property to check for. If null or empty, all rules will be checked.</param>
		/// <returns>A read-only collection of rules that have been broken.</returns>
		public ReadOnlyCollection<Rule> GetBrokenRules(string property,ReadOnlyCollection<Rule> rules)
		{
			property = CleanString(property);

			// If we haven't yet created the rules, create them now.

			List<Rule> broken = new List<Rule>();


			foreach (Rule r in rules)
			{
				// Ensure we only validate a rule 
				if (r.PropertyName == property || property.Length == 0)
				{
					bool isRuleBroken = !r.ValidateRule(this);
					if (isRuleBroken)
					{
						broken.Add(r);
					}
				}
			}

			return broken.AsReadOnly();
		}

		/// <summary>
		/// Occurs when any properties are changed on this object.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Override this method to create your own rules to validate this business object. These rules must all be met before 
		/// the business object is considered valid enough to save to the data store.
		/// </summary>
		/// <returns>A collection of rules to add for this business object.</returns>
		protected virtual ReadOnlyCollection<Rule> CreateRules()
		{
			return new List<Rule>().AsReadOnly();
		}

		/// <summary>
		/// A helper method that raises the PropertyChanged event for a property.
		/// </summary>
		/// <param name="propertyNames">The names of the properties that changed.</param>
		protected virtual void NotifyChanged(params string[] propertyNames)
		{
			foreach (string name in propertyNames)
			{
				OnPropertyChanged(new PropertyChangedEventArgs(name));
			}
			OnPropertyChanged(new PropertyChangedEventArgs("IsValid"));
		}

		/// <summary>
		/// Cleans a string by ensuring it isn't null and trimming it.
		/// </summary>
		/// <param name="s">The string to clean.</param>
		protected static string CleanString(string cadena)
		{
			return (cadena ?? string.Empty).Trim();
		}

		/// <summary>
		/// Raises the PropertyChanged event.
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (this.PropertyChanged != null) this.PropertyChanged(this, e);
		}
	}
}
