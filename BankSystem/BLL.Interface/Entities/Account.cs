using BLL.Interface.Exceptions;
using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Abstract account.
    /// </summary>
    /// <seealso cref="System.IEquatable{BLL.Interface.Entities.Account}" />
    public abstract class Account : IEquatable<Account>
    {
        public string Number { get; set; }
        public AccountOwner Owner { get; set; }

        private AccountState state; // or public State?
        private decimal balance;
        private int benefitPoints;

        public Account()
        {
            // ?
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Account number: {Number.ToString()}, owner: {Owner.ToString()}";
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
            return Equals((Account)obj);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Account other)
        {
            return Number == other.Number && Owner == other.Owner;
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
                var hashCode = (Number != null) ? Number.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ ((Owner != null) ? Owner.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        /// <summary>
        /// Deposits the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="AmountException">The {nameof(amount)} can not be less than zero.</exception>
        /// <exception cref="ClosedAccountException">The account is closed.</exception>
        /// <exception cref="FreezedAccountException">The account is freezed.</exception>
        public void Deposit(decimal amount)
        {
            //1.
            if (amount < 0)
            {
                throw new AmountException($"The {nameof(amount)} can not be less than zero.");
            }

            if (this.state == AccountState.closed)
            {
                throw new ClosedAccountException();
            }

            if (this.state == AccountState.freezed)
            {
                throw new FreezedAccountException();
            }

            //2.
            this.balance += amount;

            //3.
            CalculateBenefitPointsWithDeposit(amount);
        }

        /// <summary>
        /// Withdraws the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="AmountException">The {nameof(amount)} can not be less than zero.</exception>
        /// <exception cref="BalanceValidException">This {nameof(amount)} is not available on the balance sheet.</exception>
        /// <exception cref="ClosedAccountException">The account is closed.</exception>
        /// <exception cref="FreezedAccountException">The account is freezed.</exception>
        public void Withdraw(decimal amount)
        {
            //1.
            if (amount < 0)
            {
                throw new AmountException($"The {nameof(amount)} can not be less than zero.");
            }

            if (!IsBalanceValid(amount))
            {
                throw new BalanceValidException($"This {nameof(amount)} is not available on the balance sheet.");
            }

            if (this.state == AccountState.closed)
            {
                throw new ClosedAccountException();
            }

            if (this.state == AccountState.freezed)
            {
                throw new FreezedAccountException();
            }

            //2.
            this.balance -= amount;

            //3.
            CalculateBenefitPointsWithWithdraw(amount);
        }

        /// <summary>
        /// Transfers the specified amount to specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="amount">The amount.</param>
        public void Transfer(Account account, decimal amount)
        {
            this.Withdraw(amount);
            account.Deposit(amount);
        }

        /// <summary>
        /// Actives this account.
        /// </summary>
        public void ToActive()
        {
            this.state = AccountState.active;
        }

        /// <summary>
        /// Closes this account.
        /// </summary>
        public void ToClose()
        {
            this.state = AccountState.closed;
        }

        /// <summary>
        /// Freezes this account.
        /// </summary>
        public void ToFreeze()
        {
            this.state = AccountState.freezed;
        }

        /// <summary>
        /// Determines whether is balance valid.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns>
        ///   <c>true</c> if [is balance valid] [the specified amount]; otherwise, <c>false</c>.
        /// </returns>
        protected abstract bool IsBalanceValid(decimal amount);

        /// <summary>
        /// Calculates the benefit points with deposit.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected abstract void CalculateBenefitPointsWithDeposit(decimal amount);

        /// <summary>
        /// Calculates the benefit points with withdraw.
        /// </summary>
        /// <param name="amount">The amount.</param>
        protected abstract void CalculateBenefitPointsWithWithdraw(decimal amount);                
    }
}
