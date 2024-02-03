using System.Collections.Generic;
using GameCore.ServiceLocator;

namespace GameCore.Pause
{
    public class PauseService : IPauseService, IService

    {
    private readonly List<IPauseable> _pauseables = new List<IPauseable>();
    public bool IsPaused { get; private set; }

    public void Initialize()
    {
        IsPaused = false;
    }

    public void Register(IPauseable pauseable)
    {
        if (!_pauseables.Contains(pauseable))
        {
            _pauseables.Add(pauseable);
        }
    }

    public void UnRegister(IPauseable pauseable)
    {
        if (_pauseables.Contains(pauseable))
        {
            _pauseables.Remove(pauseable);
        }
    }

    public void SetPaused(bool isPaused)
    {
        IsPaused = isPaused;
        foreach (var pauseable in _pauseables)
        {
            pauseable.SetPaused(isPaused);
        }
    }
    }
}