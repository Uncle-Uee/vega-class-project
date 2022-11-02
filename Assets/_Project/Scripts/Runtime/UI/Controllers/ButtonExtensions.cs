using UnityEngine.Events;
using UnityEngine.UI;

namespace Vega.UI
{
    public static class ButtonExtensions
    {
        public static void AddListener(this Button button, UnityAction buttonAction)
        {
            if (buttonAction == null) return;
            button.onClick.AddListener(buttonAction);
        }

        public static void RemoveListener(this Button button, UnityAction buttonAction)
        {
            if (buttonAction == null) return;
            button.onClick.RemoveListener(buttonAction);
        }

        public static void RemoveAllListeners(this Button button)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}