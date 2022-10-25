using UnityEngine;

#if UNITY_EDITOR
namespace LazyJedi.Editors.Internal
{
    public static class LazyEditorArt
    {
        #region ARTWORK

        public static string LazyJediLiteLogo
        {
            get => "Icons/light-saber-light";
        }

        public static string LazyJediDarkLogo
        {
            get => "Icons/light-saber-dark";
        }

        #endregion

        #region FONT

        /// <summary>
        /// Kenney Mini Square Font
        /// </summary>
        public static string KenneyMiniSquareFont
        {
            get => "Fonts/kenney-fonts/MiniSquare";
        }

        #endregion
    }
}
#endif