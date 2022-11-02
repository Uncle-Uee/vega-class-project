using TMPro;
using UnityEngine.UI;

namespace Vega.UI
{
    public static class GraphicExtensions
    {
        public static void SetText(this Graphic graphic, string text)
        {
            if (graphic is TMP_Text placeholderText)
            {
                placeholderText.SetText(text);
            }
        }
    }
}