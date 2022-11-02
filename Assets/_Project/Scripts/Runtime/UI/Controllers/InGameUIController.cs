using UnityEngine;
using LazyJedi.Components;
using UnityEngine.UI;

namespace Vega.UI
{
    public class InGameUIController : UIControllerBase
    {
        #region FIELDS

        [Header("Persistence Buttons")]
        public Button SaveButton;
        public Button LoadButton;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            SaveButton.AddListener(OnSaveButtonClick);
            LoadButton.AddListener(OnLoadButtonClick);
        }

        private void OnDisable()
        {
            SaveButton.RemoveAllListeners();
            LoadButton.RemoveAllListeners();
        }

        #endregion

        #region METHODS

        private void OnSaveButtonClick()
        {
            PersistencePanel.UpdatePanel();
        }

        private void OnLoadButtonClick()
        {
        }

        #endregion
    }
}