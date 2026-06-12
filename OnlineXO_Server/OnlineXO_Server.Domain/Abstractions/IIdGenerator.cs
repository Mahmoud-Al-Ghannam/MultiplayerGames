using System;

namespace OnlineXO_Server.Domain.Abstractions;

public interface IIdGenerator
{
    string NewId();
}
