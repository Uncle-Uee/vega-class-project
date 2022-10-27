using StateMachine;
using UnityEngine;
using Vega.Cursor;
using UnityEngine.Tilemaps;


namespace Vega.Character
{
    public class PlayerFsm : FsmBase
    {
        [SerializeField] private Animator animator;
        [SerializeField] private InputController inputController;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Rigidbody2D rb2D;
        [SerializeField] private CursorController cursorController;
        [SerializeField] private Tilemap tilemap;

        
        public TileAndMovementCost[] tiles;
        
        [System.Serializable]
        public struct TileAndMovementCost
        {
            public Tile tile;
            public bool movable;
            public float movementCost;
        }
        
        
        private void Awake()
        {
            AddStates();
        }
        
        private void Start()
        {
            TransitionToState<IdleState>();
        }

        private void AddStates()
        {
            AddState(new IdleState(this, animator, inputController, spriteRenderer, cursorController));
            AddState(new WalkState(this, animator, rb2D, tilemap, spriteRenderer));
        }
    }
    
    
}
