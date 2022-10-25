using RenderHeads.Services;
using UnityEngine;

namespace Vega.Managers
{
    public abstract class ManagersBase<T> : MonoBehaviour, IService where T : IService
    {
        #region FIELDS

        #endregion

        #region UNITY METHODS

        public virtual void OnEnable()
        {
            ServiceLocator.AddService(this);
        }

        public virtual void OnDisable()
        {
            ServiceLocator.RemoveService(this);
        }

        #endregion
    }
}