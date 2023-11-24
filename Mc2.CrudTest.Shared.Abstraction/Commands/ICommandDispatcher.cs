﻿using System;

namespace Mc2.CrudTest.Shared.Abstraction.Commands;

public interface ICommandDispatcher
{
    Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
}
