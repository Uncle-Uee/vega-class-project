using System;
using System.Collections;
using RenderHeads.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vega.Managers;
using Vega.ScriptableObjects;

namespace Vega.UI
{
    public class PersistencePanel : MonoBehaviour
    {
        #region FIELDS

        [Header("Required ScriptableObjects")]
        public PlayerData PlayerData;

        [Header("Input Field")]
        public TMP_InputField SaveInputText;

        [Header("Text Fields")]
        public TMP_Text NameText;
        public TMP_Text MoneyText;
        public TMP_Text LevelText;
        public TMP_Text ExperienceText;
        public TMP_Text HealthText;
        public TMP_Text ManaText;
        public TMP_Text PositionText;

        [Header("Save Preview Image")]
        public Image PreviewImage;

        [Header("Buttons")]
        public Button SaveButton;

        private static PersistencePanel _instance;

        #endregion

        #region UNITY METHODS

        private void Start()
        {
            _instance = this;
        }

        private void OnEnable()
        {
            SaveButton.AddListener(OnSaveButtonClick);
        }

        private void OnDisable()
        {
            SaveButton.RemoveAllListeners();
        }

        #endregion

        #region METHODS

        public static void UpdatePanel()
        {
            _instance.UpdatePanelHelper();
        }

        private void UpdatePanelHelper()
        {
            gameObject.Activate();
            SaveInputText.placeholder.SetText($"Save Game - {DateTime.Now:MM-dd-yy (HH-mm-ss)}");
            SaveInputText.SetTextWithoutNotify($"Save Game - {DateTime.Now:MM-dd-yy (HH-mm-ss)}");

            NameText.SetText($"Name: {PlayerData.Name}");
            MoneyText.SetText($"Money: {PlayerData.Money}");
            LevelText.SetText($"Level: {PlayerData.Level}");
            ExperienceText.SetText($"Experience: {PlayerData.CurrentExperience}");
            HealthText.SetText($"Health: {PlayerData.CurrentHealth}");
            ManaText.SetText($"Mana: {PlayerData.CurrentMana}");
            PositionText.SetText($"Position: {PlayerData.LastPosition}");
            StartCoroutine(ScreenshotRoutine());
        }

        private IEnumerator ScreenshotRoutine()
        {
            yield return new WaitForEndOfFrame();
            Texture2D screenshot = ScreenCapture.CaptureScreenshotAsTexture();
            PreviewImage.sprite = Sprite.Create(screenshot, new Rect(0, 0, screenshot.width, screenshot.height), Vector2.zero);
            byte[] screenshotBytes = screenshot.EncodeToPNG();
            PlayerData.ImageString = Convert.ToBase64String(screenshotBytes);
        }

        private void OnSaveButtonClick()
        {
            ServiceLocator.GetService<PersistenceManager>().SavePlayerData(SaveInputText.text);
            gameObject.Deactivate();
        }

        #endregion
    }

    public static class Texture2DExtensions
    {
        public static string ToBase64(this Texture2D texture2D)
        {
            return texture2D ? Convert.ToBase64String(texture2D.EncodeToPNG()) : string.Empty;
        }
    }
}