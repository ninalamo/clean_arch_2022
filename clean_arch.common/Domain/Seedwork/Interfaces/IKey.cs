namespace SAFRA.SMCMS.SharedKernel.Domain.Seedwork
{
    using System;

    /// <summary>
    /// Defines the <see cref="IKey{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public interface IKey<T> where T : struct, IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Gets the Id
        /// Gets or sets the Id..
        /// </summary>
        T Id { get; }
    }
}
