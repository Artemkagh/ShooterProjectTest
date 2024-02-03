namespace GameCore.Pause
{
    public interface IPauseService : IPauseable
    {
        public bool IsPaused { get; }
        public void Register(IPauseable pauseable);
        public void UnRegister(IPauseable pauseable);
    }
}