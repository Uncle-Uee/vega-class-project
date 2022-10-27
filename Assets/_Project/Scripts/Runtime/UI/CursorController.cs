using StateMachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using Vega.Character;

namespace Vega.Cursor
{
    public class CursorController : MonoBehaviour
    {
        private Camera _camera;
        
        [SerializeField] private Tilemap tilemap;
        [SerializeField] private GameObject visualContainer;
        [HideInInspector] public UnityEvent<Vector3> mouseClick;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void OnPlayerStateChange(StateBase state)
        {
            switch (state)
            {
                case IdleState:
                    ToggleView(true);
                    break;
                case WalkState:
                    ToggleView(false);
                    break;
            }
        }

        private void ToggleView(bool shouldShow)
        {
            visualContainer.SetActive(shouldShow);
        }

        private void LateUpdate()
        {
            if (_camera is null) return;
            
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var cellPosition = tilemap.WorldToCell(mousePosition);
            transform.position = tilemap.GetCellCenterWorld(cellPosition);

            if (Input.GetMouseButtonDown(0))
            {
                mouseClick.Invoke(mousePosition);
            }
        }
    }
}
