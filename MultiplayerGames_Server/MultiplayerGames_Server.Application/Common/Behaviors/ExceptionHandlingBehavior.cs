using System;
using MediatR;
using MultiplayerGames_Server.Application.Common.Exceptions;
using MultiplayerGames_Server.Domain.Common.Exceptions;

namespace MultiplayerGames_Server.Application.Common.Behaviors;

public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : MediatR.IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        try
        {
            return await next();
        }
        catch (DomainException ex)
        {
            throw new BadRequestException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
