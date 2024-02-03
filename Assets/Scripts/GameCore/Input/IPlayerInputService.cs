using GameCore.Input.Data;
using GameCore.Pause;

namespace GameCore.Input
{
    public interface IPlayerInputService : IPauseable
    {
        void Initialize(InputDataProvider inputDataProvider);
        void UpdateInput();
        void SetInputActive(bool state);
        void ResetInput();
    }
}