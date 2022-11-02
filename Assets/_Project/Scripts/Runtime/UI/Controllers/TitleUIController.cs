using LazyJedi.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Vega.UI
{
    public class TitleUIController : UIControllerBase
    {
        #region FIELDS

        [Header("Canvases")]
        public InGameUIController InGameUI;
        public OptionsUIController OptionsUI;

        [Header("Buttons")]
        public Button PlayButton;
        public Button OptionsButton;
        public Button QuitButton;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            PlayButton.AddListener(OnPlayButtonClick);
            OptionsButton.AddListener(OnOptionsButtonClick);
            QuitButton.AddListener(OnQuitButtonClick);
        }

        private void OnDisable()
        {
            PlayButton.RemoveAllListeners();
            OptionsButton.RemoveAllListeners();
            QuitButton.RemoveAllListeners();
        }

        #endregion

        #region METHODS

        private void OnPlayButtonClick()
        {
            DeactivateCanvas();
            InGameUI.ActivateCanvas();
        }

        private void OnOptionsButtonClick()
        {
            OptionsUI.CallingController = this;
        }

        private void OnQuitButtonClick()
        {
            Application.Quit();
        }

        #endregion
    }
}