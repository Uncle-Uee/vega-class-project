using UnityEngine;
using LazyJedi.Components;
using RenderHeads.Services;
using UnityEngine.Audio;
using UnityEngine.UI;
using Vega.Managers;
using Vega.ScriptableObjects;

namespace Vega.UI
{
    public class OptionsUIController : UIControllerBase
    {
        #region FIELDS

        [Header("Game Settings")]
        public GameSettings GameSettings;

        [Header("Audio Mixers")]
        public AudioMixerGroup MasterAudioMixer;
        public AudioMixerGroup MusicAudioMixer;
        public AudioMixerGroup SoundAudioMixer;

        [Header("Buttons")]
        public Button BackButton;

        [Header("Volume Sliders")]
        public Slider MasterVolumeSlider;
        public Slider MusicVolumeSlider;
        public Slider SoundVolumeSlider;

        private bool _isDirty = false;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            MasterVolumeSlider.value = GameSettings.CurrentMasterVolume;
            MusicVolumeSlider.value  = GameSettings.CurrentMusicVolume;
            SoundVolumeSlider.value  = GameSettings.CurrentSoundVolume;

            BackButton.onClick.AddListener(OnBackButtonClick);
        }

        private void OnDisable()
        {
            BackButton.onClick.RemoveAllListeners();
        }

        private void Start()
        {
            MasterAudioMixer.audioMixer.SetFloat("MasterVolume", GameSettings.CurrentMasterVolume);
            MusicAudioMixer.audioMixer.SetFloat("MusicVolume", GameSettings.CurrentMusicVolume);
            SoundAudioMixer.audioMixer.SetFloat("SoundVolume", GameSettings.CurrentSoundVolume);
        }

        #endregion

        #region BUTTON METHODS

        private void OnBackButtonClick()
        {
            DeactivateCanvas();
            CallingController.ActivateCanvas();
            // Only Write new Game Settings if a Change was made.
            if (_isDirty) ServiceLocator.GetService<PersistenceManager>().SaveGameSettings();
        }

        #endregion

        #region SLIDER METHODS

        public void OnMasterVolumeChanged(float value)
        {
            GameSettings.CurrentMasterVolume = value;
            MasterAudioMixer.audioMixer.SetFloat("MasterVolume", value);
            SettingsAreDirty();
        }

        public void OnMusicVolumeChanged(float value)
        {
            GameSettings.CurrentMusicVolume = value;
            MusicAudioMixer.audioMixer.SetFloat("MusicVolume", value);
            SettingsAreDirty();
        }

        public void OnSoundVolumeChanged(float value)
        {
            GameSettings.CurrentSoundVolume = value;
            SoundAudioMixer.audioMixer.SetFloat("SoundVolume", value);
            SettingsAreDirty();
        }

        #endregion

        #region HELPER METHODS

        private void SettingsAreDirty()
        {
            _isDirty = true;
        }

        #endregion
    }
}