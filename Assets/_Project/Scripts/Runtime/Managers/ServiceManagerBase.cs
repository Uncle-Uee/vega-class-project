using RenderHeads.Services;
using UnityEngine;

namespace Vega.Managers
{
    public abstract class ServiceManagerBase<T> : MonoBehaviour, IService where T : IService
    {
        #region UNITY METHODS

        private void OnEnable()
        {
            ServiceLocator.AddService(this);
            DoOnEnable();
        }

        private void OnDisable()
        {
            ServiceLocator.RemoveService(this);
            DoOnDisable();
        }

        #endregion

        #region CUSTOM UNITY EVENT METHODS

        public virtual void DoOnEnable()
        {
        }

        public virtual void DoOnDisable()
        {
        }

        #endregion
    }
}