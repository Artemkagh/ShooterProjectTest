using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.ServiceLocator
{
    public class ServiceLocator
    {

        private static readonly Dictionary<Type, IService> _registeredServices = new Dictionary<Type, IService>();
        

        public static T GetService<T>() where T : IService
        {
            Type type = typeof(T);
            if (!_registeredServices.ContainsKey(type))
            {
                Debug.Log($"Service type {type} doesn`t exist");
                return default(T);
            }
            return (T)_registeredServices[type];
        }
        
        public static void RegisterService<T>() where T : IService, new()
        {
            Type type = typeof(T);
            if (!_registeredServices.ContainsKey(type))
            {
                _registeredServices.Add(type, new T());
                Debug.Log($"Service type {type} registered");
            }
        }
        
        public static void UnRegisterService<T>() where T : IService, new()
        {
            Type type = typeof(T);
            if (_registeredServices.ContainsKey(type))
            {
                _registeredServices.Remove(type);
                Debug.Log($"Service type {type} Unregistered");
            }
        
        }
        
        

        // private ISceneLoaderService _sceneLoaderService;
        // private IPlayerInputService _playerInputService;
        // private IPlayerHealthService _playerHealthService;
        // private IPauseService _pauseService;
        //
        // public ISceneLoaderService SceneLoaderService => _sceneLoaderService;
        //
        // public IPlayerInputService PlayerInputService => _playerInputService;
        //
        // public IPlayerHealthService PlayerHealthService => _playerHealthService;
        //
        // public IPauseService PauseService => _pauseService;
        //
        // public void Initialize()
        // {
        //     _sceneLoaderService = new SceneLoaderService();
        //     _playerInputService = new PlayerInputService();
        //     _playerHealthService = new PlayerHealthService();
        //     _pauseService = new PauseService();
        // }
        public static void Check()
        {
            Debug.Log("ServiceLocator active");
        }
        
    }
}