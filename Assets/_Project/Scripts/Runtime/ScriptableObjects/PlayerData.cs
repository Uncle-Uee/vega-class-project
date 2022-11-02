using UnityEngine;

namespace Vega.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 90)]
    public class PlayerData : ScriptableObject
    {
        #region FIELDS

        [Header("Player Information")]
        public string Name = string.Empty;

        [Header("Player Wealth Information")]
        public int Money;

        [Header("Player Experience Information")]
        public int Level = 0;
        public int CurrentExperience;

        [Header("Player Health & Mana Information")]
        public int CurrentHealth;
        public int CurrentMana;

        [Header("Player Location Information")]
        public Vector2 LastPosition = Vector2.zero;

        [Header("Save Preview Image")]
        public string ImageString = string.Empty;

        #endregion

        #region METHODS

        #endregion
    }
}