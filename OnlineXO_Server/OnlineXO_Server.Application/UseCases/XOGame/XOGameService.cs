using System;
using MediatR;
using OnlineXO_Server.Application.Abstractions.Data;
using OnlineXO_Server.Application.Abstractions.Data.ReadRepository;
using OnlineXO_Server.Application.Abstractions.Services;
using OnlineXO_Server.Application.Common.Exceptions;
using OnlineXO_Server.Application.Common.Responses;
using OnlineXO_Server.Application.UseCases.XOGame.RequestDTOs;
using OnlineXO_Server.Application.UseCases.XOGame.ResponseDTOs;
using OnlineXO_Server.Domain.Abstractions;
using OnlineXO_Server.Domain.Common.Codes;
using UserAggregate = OnlineXO_Server.Domain.Aggregates.User.User;
using XOGameAggregate = OnlineXO_Server.Domain.Aggregates.XOGame.XOGame;

namespace OnlineXO_Server.Application.UseCases.XOGame;

public class XOGameService
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGameReadRepository _gameReadRepository;
    private readonly IIdGenerator _idGenerator;
    private readonly IMediator _mediator;

    public XOGameService(
        ICurrentUserService currentUserService,
        IUnitOfWork unitOfWork,
        IIdGenerator idGenerator,
        IMediator mediator,
        IGameReadRepository gameReadRepository
    )
    {
        _currentUserService = currentUserService;
        _unitOfWork = unitOfWork;
        _idGenerator = idGenerator;
        _mediator = mediator;
        _gameReadRepository = gameReadRepository;
    }

    public async Task<BaseResponse<string>> CreateGameAsync(CancellationToken cancellationToken)
    {
        string? userId = _currentUserService.GetUserId();
        if (userId == null)
            throw new BadRequestException(AuthCodes.Error.Unauthenticated);

        var xoGame = XOGameAggregate.Create(userId, _idGenerator);
        await _unitOfWork.XOGames.AddAsync(xoGame, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        foreach (IDomainEvent @event in xoGame.DomainEvents)
            await _mediator.Publish(@event, cancellationToken);

        return new BaseResponse<string>
        {
            Success = true,
            Message = XOGameCodes.Success.Created,
            Data = xoGame.Id,
        };
    }

    public async Task<BaseResponse<object>> JoinAsync(
        string gameId,
        CancellationToken cancellationToken
    )
    {
        string? userId = _currentUserService.GetUserId();
        if (userId == null)
            throw new BadRequestException(AuthCodes.Error.Unauthenticated);

        var game = await _unitOfWork.XOGames.GetByIdAsync(gameId, cancellationToken);
        if (game == null)
            throw new NotFoundEntityException(XOGameCodes.Error.NotFound);

        game.Join(userId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        foreach (IDomainEvent @event in game.DomainEvents)
            await _mediator.Publish(@event, cancellationToken);

        return new BaseResponse<object>
        {
            Success = true,
            Message = XOGameCodes.Success.PlayerJoind,
        };
    }

    public async Task<BaseResponse<object>> LeaveAsync(
        string gameId,
        CancellationToken cancellationToken
    )
    {
        string? userId = _currentUserService.GetUserId();
        if (userId == null)
            throw new BadRequestException(AuthCodes.Error.Unauthenticated);

        var game = await _unitOfWork.XOGames.GetByIdAsync(gameId, cancellationToken);
        if (game == null)
            throw new NotFoundEntityException(XOGameCodes.Error.NotFound);

        game.Leave(userId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        foreach (IDomainEvent @event in game.DomainEvents)
            await _mediator.Publish(@event, cancellationToken);

        return new BaseResponse<object>
        {
            Success = true,
            Message = XOGameCodes.Success.PlayerLeft,
        };
    }

    public async Task<BaseResponse<GameInfoDto>> GetGameAsync(
        string gameId,
        CancellationToken cancellationToken
    )
    {
        var game = await _unitOfWork.XOGames.GetByIdAsync(gameId, cancellationToken);
        if (game == null)
            throw new NotFoundEntityException(XOGameCodes.Error.NotFound);

        UserAggregate? playerX =
            game.PlayerXId == null
                ? null
                : await _unitOfWork.Users.GetByIdAsync(game.PlayerXId, cancellationToken);

        UserAggregate? playerO =
            game.PlayerOId == null
                ? null
                : await _unitOfWork.Users.GetByIdAsync(game.PlayerOId, cancellationToken);

        var gameDto = new GameInfoDto
        {
            Id = game.Id,
            PlayerOId = game.PlayerOId,
            PlayerO = playerO?.Username,
            PlayerXId = game.PlayerXId,
            PlayerX = playerX?.Username,
            CurrentTurn = game.CurrentTurn.ToString(),
            Status = game.Status.ToString(),
            Winner = game.Winner?.ToString(),
            CreatedAt = game.CreatedAtUtc,
            EndedAt = game.EndedAtUtc,
            StartedAt = game.StartedAtUtc,
            Board = game.Board.ToArray(),
        };

        return new BaseResponse<GameInfoDto>
        {
            Success = true,
            Message = XOGameCodes.Success.Retrived,
            Data = gameDto,
        };
    }

    public async Task<BaseResponse<IEnumerable<GameItemDto>>> GetGamesAsync(
        GetGamesQueryDto query,
        CancellationToken cancellationToken
    )
    {
        var games = await _gameReadRepository.GetGamesAsync(query, cancellationToken);
        return new BaseResponse<IEnumerable<GameItemDto>>
        {
            Success = true,
            Message = XOGameCodes.Success.Retrived,
            Data = games,
        };
    }

    public async Task<BaseResponse<object>> MakeMoveAsync(
        string gameId,
        int row,
        int col,
        CancellationToken cancellationToken
    )
    {
        string? userId = _currentUserService.GetUserId();
        if (userId == null)
            throw new BadRequestException(AuthCodes.Error.Unauthenticated);

        var game = await _unitOfWork.XOGames.GetByIdAsync(gameId, cancellationToken);
        if (game == null)
            throw new NotFoundEntityException(XOGameCodes.Error.NotFound);

        game.MakeMove(userId, row, col);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        foreach (IDomainEvent @event in game.DomainEvents)
            await _mediator.Publish(@event, cancellationToken);

        return new BaseResponse<object> { Success = true, Message = XOGameCodes.Success.MadeMove };
    }
}
