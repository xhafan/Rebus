using Rebus.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rebus.Retry.Info;

/// <summary>
/// An in-memory exception info for in-memory error tracking.
/// </summary>
public record InMemExceptionInfo : ExceptionInfo
{
    /// <summary>
    /// Constructs a new in-memory exception info from a source exception.
    /// </summary>
    /// <param name="exception">Source exception.</param>
    public InMemExceptionInfo(Exception exception) : base(
        exception?.GetType().GetSimpleAssemblyQualifiedName(),
        exception?.Message,
        exception?.ToString(),
        DateTimeOffset.Now)
    {
        Exception = exception ?? throw new ArgumentNullException(nameof(exception));
    }

    /// <summary>
    /// Constructs a new in-memory exception info from a collection of exception infos, with an option to override the message and details.
    /// </summary>
    /// <param name="exceptionInfos">Collection of exception infos</param>
    /// <param name="Message">Message</param>
    /// <param name="Details">Details</param>
    public InMemExceptionInfo(IEnumerable<ExceptionInfo> exceptionInfos, string Message, string Details) : base(
        typeof(AggregateException).GetSimpleAssemblyQualifiedName(),
        Message,
        Details,
        DateTimeOffset.Now)
    {
        Exception = new AggregateException(exceptionInfos.OfType<InMemExceptionInfo>().Select(x => x.Exception));
    }

    /// <summary>
    /// Gets or sets the original exception.
    /// </summary>
    public Exception Exception { get; }
}