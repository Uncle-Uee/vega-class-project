using UnityEngine;

namespace Vega.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 90)]
    public class GameSettings : ScriptableObject
    {
        #region FIELDS

        [Header("Master Volume")]
        [Range(-80f, 0f)]
        public float CurrentMasterVolume;

        [Header("Sound Volume")]
        [Range(-80f, 0f)]
        public float CurrentSoundVolume;

        [Header("Music Volume")]
        [Range(-80f, 0f)]
        public float CurrentMusicVolume;

        #endregion

        #region METHODS

        #endregion
    }
}