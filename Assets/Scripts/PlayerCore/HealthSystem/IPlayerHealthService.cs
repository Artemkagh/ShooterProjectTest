using GameCore.Pause;

namespace PlayerCore.HealthSystem
{
    public interface IPlayerHealthService : IPauseable
    {
        void AddHealth(float heal);
        void AddDamage(float damage);
        void SetHealthStartState();
        void EnableDamage(bool isDamageAllowed);
        bool IsPlayerDead();
    }
}