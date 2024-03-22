using System;
using System.Collections.Generic;

namespace Rebus.Retry.Info;

/// <summary>
/// Creates <see cref="ExceptionInfo"/>s by storing the original exception.
/// </summary>
public class InMemExceptionInfoFactory : IExceptionInfoFactory
{
    /// <summary>
    /// Create an <see cref="ExceptionInfo"/> and store the original exception.
    /// </summary>
    /// <remarks>
    /// This factory only works/makes sense using an in-memory error tracker
    /// such as <see cref="ErrorTracking.InMemErrorTracker"/>.
    /// </remarks>
    /// <param name="exception">Source exception.</param>
    /// <returns>An <see cref="ExceptionInfo"/> containing information from the supplied exception.</returns>
    public ExceptionInfo CreateInfo(Exception exception) => new InMemExceptionInfo(exception);

    /// <summary>
    /// Create an <see cref="ExceptionInfo"/> from a collection of exception infos and store the original exceptions.
    /// </summary>
    /// <param name="exceptionInfos">Collection of exception infos</param>
    /// <param name="message">Message</param>
    /// <param name="details">Details</param>
    /// <returns></returns>
    public ExceptionInfo CreateInfo(IEnumerable<ExceptionInfo> exceptionInfos, string message, string details)
    {
        return new InMemExceptionInfo(exceptionInfos, message, details);
    }
}