using UnityEngine;

namespace Vega.System
{
    internal static class BeforeSceneLoader
    {
        #region METHODS

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Load()
        {
            LoadManagersHelper();
        }

        #endregion

        #region HELPER METHODS

        private static void LoadManagersHelper()
        {
            Object managerPrefab = Resources.Load("Managers/Managers");
            Object managers      = Object.Instantiate(managerPrefab);
            managers.name = "[MANAGERS]";
            Object.DontDestroyOnLoad(managers);
            Resources.UnloadUnusedAssets();
            
            Debug.unityLogger.Log("Managers have been loaded.");
        }

        #endregion
    }
}