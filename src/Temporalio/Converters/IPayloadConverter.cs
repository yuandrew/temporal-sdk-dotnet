using System;
using Temporalio.Api.Common.V1;

namespace Temporalio.Converters
{
    /// <summary>
    /// Representation of a converter from a value to/from a payload.
    /// </summary>
    /// <remarks>
    /// This converter should be deterministic since it is used for workflows. For the same reason,
    /// this converter should be immediate and avoid any network calls or any asynchronous/slow code
    /// paths.
    /// </remarks>
    /// <remarks>
    /// Implementations of this interface can also implement
    /// <see cref="IWithSerializationContext{TResult}"/> for <c>IPayloadConverter</c> to customize
    /// the converter based on context.
    /// </remarks>
    /// <seealso cref="DefaultPayloadConverter" />
    public interface IPayloadConverter
    {
        /// <summary>
        /// Convert the given value to a payload.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted payload.</returns>
        /// <remarks>
        /// Implementers are expected to be able just return the payload for
        /// <see cref="IRawValue" />.
        /// </remarks>
        Payload ToPayload(object? value);

        /// <summary>
        /// Convert the given payload to a value of the given type.
        /// </summary>
        /// <param name="payload">The payload to convert.</param>
        /// <param name="type">The type to convert to.</param>
        /// <returns>The converted value.</returns>
        /// <remarks>
        /// Implementers are expected to be able to support types of <see cref="IRawValue" />.
        /// </remarks>
        object? ToValue(Payload payload, Type type);
    }
}
