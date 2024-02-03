using GameCore.ServiceLocator;
using UnityEngine;

namespace GameCore.SceneLoading
{
    public interface ISceneLoaderService : IService
    {
        AsyncOperation LoadMainMenu();
        AsyncOperation UnloadMainMenu();
        AsyncOperation LoadGame();
        AsyncOperation UnloadGame();
    }
}