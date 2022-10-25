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

        #endregion

        #region UNITY METHODS

        public override void Awake()
        {
            base.Awake();
            ServiceLocator.GetService<PersistenceManager>().LoadGameSettings();
        }

        private void OnEnable()
        {
            MasterVolumeSlider.value = GameSettings.CurrentMasterVolume;
            MusicVolumeSlider.value  = GameSettings.CurrentMusicVolume;
            SoundVolumeSlider.value  = GameSettings.CurrentSoundVolume;

            BackButton.onClick.AddListener(OnBackButtonClick);
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
            ServiceLocator.GetService<PersistenceManager>().SaveGameSettings();
        }

        #endregion

        #region SLIDER METHODS

        public void OnMasterVolumeChanged(float value)
        {
            GameSettings.CurrentMasterVolume = value;
            MasterAudioMixer.audioMixer.SetFloat("MasterVolume", value);
        }

        public void OnMusicVolumeChanged(float value)
        {
            GameSettings.CurrentMusicVolume = value;
            MusicAudioMixer.audioMixer.SetFloat("MusicVolume", value);
        }

        public void OnSoundVolumeChanged(float value)
        {
            GameSettings.CurrentSoundVolume = value;
            SoundAudioMixer.audioMixer.SetFloat("SoundVolume", value);
        }

        #endregion
    }
}