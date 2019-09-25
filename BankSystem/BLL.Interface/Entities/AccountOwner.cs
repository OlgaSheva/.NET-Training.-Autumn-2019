using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Account owner.
    /// </summary>
    /// <seealso cref="System.IEquatable{BLL.Interface.Entities.AccountOwner}" />
    public class AccountOwner : IEquatable<AccountOwner>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } // TODO: валидация имени (null, empty, длина строки)
        public string Email { get; set; } // TODO: валидация с помощью Regex

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

    }
}
