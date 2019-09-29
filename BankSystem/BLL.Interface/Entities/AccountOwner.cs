using BLL.Interface.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Account owner.
    /// </summary>
    /// <seealso cref="System.IEquatable{BLL.Interface.Entities.AccountOwner}" />
    public class AccountOwner : IEquatable<AccountOwner>
    {
        private string firstName;
        private string lastName;
        private string email;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        /// <exception cref="FieldException">
        /// Throws if value is null, empty or very long.
        /// </exception>
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value == null)
                {
                    throw new FieldException($"{nameof(value)} can't be null.");
                }

                if (value == "")
                {
                    throw new FieldException($"{nameof(value)} can't be empty.");
                }

                if (value.Length > 20)
                {
                    throw new FieldException($"{nameof(value)} can't be longer than 20 symbols.");
                }

                firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        /// <exception cref="FieldException">
        /// Throws if value is null, empty or very long.
        /// </exception>
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value == null)
                {
                    throw new FieldException($"{nameof(value)} can't be null.");
                }

                if (value == "")
                {
                    throw new FieldException($"{nameof(value)} can't be empty.");
                }

                if (value.Length > 20)
                {
                    throw new FieldException($"{nameof(value)} can't be longer than 20 symbols.");
                }

                lastName = value;
            }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// <exception cref="FieldException">
        /// Throws if value is null, empty or very long or isn't valid.
        /// </exception>
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value == null)
                {
                    throw new FieldException($"{nameof(value)} can't be null.");
                }

                if (value == "")
                {
                    throw new FieldException($"{nameof(value)} can't be empty.");
                }

                if (value.Length > 30)
                {
                    throw new FieldException($"{nameof(value)} can't be longer than 30 symbols.");
                }

                if (isValid(value))
                {
                    email = value;
                }
                else
                {
                    throw new FieldException($"{nameof(value)} isn't valid.");
                }
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AccountOwner)obj);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.
        /// </returns>
        public bool Equals(AccountOwner other)
        {
            return FirstName == other.FirstName && LastName == other.LastName && Email == other.Email;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (FirstName != null) ? FirstName.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ ((LastName != null) ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ((Email != null) ? LastName.GetHashCode() : 0);
                return hashCode;
            }
        }

        private bool isValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}
