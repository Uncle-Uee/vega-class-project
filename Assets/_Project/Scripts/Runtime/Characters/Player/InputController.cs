using UnityEngine;
using UnityEngine.Events;

namespace Vega.Character
{
    public class InputController : MonoBehaviour
    {
        public float Horizontal
        {
            get => Input.GetAxis("Horizontal");
        }
        public float Vertical
        {
            get => Input.GetAxis("Vertical");
        }

        // up = true
        [HideInInspector]
        public UnityEvent<bool> verticalDirectionChange;

        // right = true
        [HideInInspector]
        public UnityEvent<bool> horizontalDirectionChange;


        [Tooltip("Threshold for changing direction")]
        [SerializeField]
        [Range(0, 0.8f)]
        private float sensitivity;

        private void Update()
        {
            if (Input.GetAxis("Vertical") > sensitivity)
            {
                verticalDirectionChange.Invoke(true);
            }
            else if (Input.GetAxis("Vertical") < -sensitivity)
            {
                verticalDirectionChange.Invoke(false);
            }

            if (Input.GetAxis("Horizontal") > sensitivity)
            {
                horizontalDirectionChange.Invoke(true);
            }
            else if (Input.GetAxis("Horizontal") < -sensitivity)
            {
                horizontalDirectionChange.Invoke(false);
            }
        }
    }
}