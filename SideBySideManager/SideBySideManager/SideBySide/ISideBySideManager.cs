﻿namespace SideBySideManagerNuget.SideBySide;

public interface ISideBySideManager
{
    public Task<T> RunSideBySideAsync<T>(Func<Task<T>> task1, Func<Task<T>> task2, bool runParallel = true, bool breakFlow = false) where T : class;
}