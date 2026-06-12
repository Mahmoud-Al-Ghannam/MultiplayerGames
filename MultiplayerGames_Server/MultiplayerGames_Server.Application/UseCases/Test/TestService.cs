using System;
using System.Data;
using System.Security.Principal;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Abstractions.Data.Repositories;
using TestAggregate = MultiplayerGames_Server.Domain.Aggregates.Test.Test;

namespace MultiplayerGames_Server.Application.UseCases.Test;

public class TestService
{
    private IUnitOfWork _unitOfWork;

    public TestService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> IncreaseCounterAsync()
    {
        int maxAttempts = 10;
        while (maxAttempts > 0)
        {
            var test = await GetOrCreateAsync();
            try
            {
                maxAttempts--;

                test.Counter++;
                await _unitOfWork.SaveChangesAsync(default);
                return test.Counter;
            }
            catch (Exception ex)
            {
                await _unitOfWork.Tests.ReloadAsync(test, default);
            }
        }
        return -1;
    }

    public async Task<TestAggregate> GetOrCreateAsync()
    {
        var test = (await _unitOfWork.Tests.GetAllAsync(default)).FirstOrDefault();
        if (test == null)
        {
            test = new TestAggregate { Counter = 0 };
            await _unitOfWork.Tests.AddAsync(test, default);
            await _unitOfWork.SaveChangesAsync(default);
        }
        await Task.Delay(TimeSpan.FromSeconds(2));

        return test;
    }
}
