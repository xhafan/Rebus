using System;
using System.Collections.Generic;
using Rebus.Extensions;

namespace Rebus.Retry.Info;

/// <summary>
/// Creates <see cref="ExceptionInfo"/>s using a simple ToString() method.
/// </summary>
public class ToStringExceptionInfoFactory : IExceptionInfoFactory
{
    /// <summary>
    /// Create an <see cref="ExceptionInfo"/> from <see cref="Exception.ToString()"/>.
    /// </summary>
    /// <param name="exception">Source exception.</param>
    /// <returns>An <see cref="ExceptionInfo"/> containing information from the supplied exception.</returns>
    public ExceptionInfo CreateInfo(Exception exception) => ExceptionInfo.FromException(exception);

    /// <summary>
    /// Create an <see cref="ExceptionInfo"/> from a collection of exception infos.
    /// </summary>
    /// <param name="exceptionInfos">Collection of exception infos</param>
    /// <param name="message">Message</param>
    /// <param name="details">Details</param>
    /// <returns></returns>
    public ExceptionInfo CreateInfo(IEnumerable<ExceptionInfo> exceptionInfos, string message, string details)
    {
        return new ExceptionInfo(
            Type: typeof(AggregateException).GetSimpleAssemblyQualifiedName(),
            Message: message,
            Details: details,
            Time: DateTimeOffset.Now
        );
    }
}