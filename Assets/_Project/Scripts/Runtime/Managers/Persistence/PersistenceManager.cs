using System;
using System.IO;
using UnityEngine;
using Vega.ScriptableObjects;

namespace Vega.Managers
{
    public class PersistenceManager : ServiceManagerBase<PersistenceManager>
    {
        #region FIELDS

        [Header("Required ScriptableObjects")]
        public GameSettings GameSettings;
        public PlayerData PlayerData;

        #endregion

        #region PROPERTIES

        private string GameSettingsPath
        {
            get => Path.Combine(Application.persistentDataPath, $"{GameSettings.name}.json");
        }

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            // Load Game Settings upon Creation of this Instance.
            LoadGameSettings();
        }

        #endregion

        #region METHODS

        public void SaveGameSettings()
        {
            File.WriteAllText(GameSettingsPath, JsonUtility.ToJson(GameSettings, true));
            print("Saving Game Settings");
        }

        public void LoadGameSettings()
        {
            if (!File.Exists(GameSettingsPath)) return;
            JsonUtility.FromJsonOverwrite(File.ReadAllText(GameSettingsPath), GameSettings);
            print("Loading Game Settings");
        }

        #endregion
    }
}