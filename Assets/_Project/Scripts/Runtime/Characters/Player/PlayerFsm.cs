using System;
using StateMachine;
using UnityEngine;
using Vega.Cursor;
using UnityEngine.Tilemaps;
using Vega.ScriptableObjects;


namespace Vega.Character
{
    public class PlayerFsm : FsmBase
    {
        [Header("Required ScriptableObjects")]
        public PlayerData PlayerData;

        [SerializeField]
        private Animator animator;
        [SerializeField]
        private InputController inputController;
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private Rigidbody2D rb2D;
        [SerializeField]
        private CursorController cursorController;
        [SerializeField]
        private Tilemap tilemap;

        public TileAndMovementCost[] tiles;

        [Serializable]
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
            transform.position = PlayerData.LastPosition;
        }

        private void AddStates()
        {
            AddState(new IdleState(this, animator, inputController, spriteRenderer, cursorController));
            AddState(new WalkState(this, animator, rb2D, tilemap, spriteRenderer, PlayerData));
        }
    }
}