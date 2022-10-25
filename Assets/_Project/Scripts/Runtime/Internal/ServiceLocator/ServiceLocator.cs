using UnityEngine;
using System.Collections.Generic;

namespace RenderHeads.Services
{
    public static class ServiceLocator
    {
        private static List<IService> _services = new List<IService>();
        
        public static T GetService<T>() where T: IService
        {
            foreach (IService service in _services)
            {
                if (typeof(T) == service.GetType())
                {
                    return (T) service;
                }
            }
            return default;
        }

        public static void AddService<T>(T service) where T : IService
        {
            foreach (IService existing in _services)
            {
                if (typeof(T) == existing.GetType())
                {
                    Debug.LogError($"[ServiceLocator] Cannot register multiple services of the same type: {typeof(T)}. Not registering duplicate.");
                    return;
                }
            }
            _services.Add(service);
        }
        
        public static void RemoveService(IService service)
        {
            for ( int i =0; i < _services.Count; i++)
            {
                IService existing = _services[i];
                if ( service.GetType() == existing.GetType())
                {
                    _services.RemoveAt(i);
                }
            }
        }
        
        public static void RemoveService<T>() where T : IService
        {
            for ( int i =0; i < _services.Count; i++)
            {
                IService existing = _services[i];
                if (typeof(T) == existing.GetType())
                {
                    _services.RemoveAt(i);
                }
            }
        }
    }
}