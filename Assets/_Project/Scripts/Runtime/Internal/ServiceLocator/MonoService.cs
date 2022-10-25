using UnityEngine;

namespace RenderHeads.Services
{
	public abstract class MonoService : MonoBehaviour, IService
    {
	    private void OnEnable()
	    {
		    ServiceLocator.AddService(this);
	    }

	    private void OnDisable()
	    {
		    ServiceLocator.RemoveService(this);
	    }
    }
}
