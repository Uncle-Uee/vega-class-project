using System;
using System.Collections;
using System.Collections.Generic;
using Aoiti.Pathfinding;
using StateMachine;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Vega.Character
{
    public class WalkState : StateBase
    {
        private List<Vector3Int> _pathBlocks;
        private Pathfinder<Vector3Int> _pathfinder;
        
        private readonly Animator _animator;
        private readonly FsmBase _fsm;
        private readonly Rigidbody2D _rb2D;
        private readonly Tilemap _tilemap;
        private readonly PlayerFsm _playerFsm;
        private readonly SpriteRenderer _spriteRenderer;



        private readonly int _walkFront = Animator.StringToHash("WalkFront");
        private readonly int _walkBack = Animator.StringToHash("WalkBack");
        
        
        public WalkState(FsmBase fsm, Animator animator, Rigidbody2D rigidbody2D, Tilemap tilemap, SpriteRenderer spriteRenderer) : base(fsm)
        {
            _fsm = fsm;
            _rb2D = rigidbody2D;
            _tilemap = tilemap;
            _animator = animator;
            _playerFsm = fsm.GetComponent<PlayerFsm>();
            _spriteRenderer = spriteRenderer;
        }

        public override void OnEnter()
        {
            _pathfinder = new Pathfinder<Vector3Int>(DistanceFunc, ConnectionsAndCosts);
        }
        
        public void MoveToPosition(Vector3 mousePosition)
        {
            var currentCellPos = _tilemap.WorldToCell(_fsm.transform.position);
            var target = _tilemap.WorldToCell(mousePosition);
            target.z = 0;
            
            _pathfinder.GenerateAstarPath(currentCellPos, target, out _pathBlocks);
            
            var moveRoutine = Move(OnMoveComplete);
            _fsm.StartCoroutine(moveRoutine);
        }

        
        private void OnMoveComplete()
        {
            _fsm.TransitionToState<IdleState>();
        }
        
        private IEnumerator Move(Action onComplete)
        {
            while (_pathBlocks.Count > 0)
            {
                var direction = _pathBlocks[0] - _tilemap.WorldToCell(_fsm.transform.position);
                HandleAnimation(direction);
                
                _fsm.transform.position = _tilemap.CellToWorld(_pathBlocks[0]);
                
                _pathBlocks.RemoveAt(0);
                yield return new WaitForSeconds(0.3f);
            }
            
            
            onComplete.Invoke();
        }

        private void HandleAnimation(Vector3Int direction)
        {
            if (direction.x > 0)
            {
                _animator.Play(_walkBack);
                _spriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                _animator.Play(_walkFront);
                _spriteRenderer.flipX = false;
            }
                
            else if (direction.y > 0)
            {
                _animator.Play(_walkBack);
                _spriteRenderer.flipX = true;
                   
            }
            else if (direction.y < 0)
            {
                _animator.Play(_walkFront);
                _spriteRenderer.flipX = true;
            }
        }


        private float DistanceFunc(Vector3Int a, Vector3Int b)
        {
            return (a-b).sqrMagnitude;
        }
        
        private Dictionary<Vector3Int,float> ConnectionsAndCosts(Vector3Int a)
        {
            var result = new Dictionary<Vector3Int, float>();
            
            var directions = new [] {
                Vector3Int.left, 
                Vector3Int.right,
                Vector3Int.up,
                Vector3Int.down
            };
            
            foreach (var dir in directions)
            {
                foreach (var tmc in _playerFsm.tiles)
                {
                    if (_tilemap.GetTile(a + dir) != tmc.tile) continue;
                    
                    if (tmc.movable)
                    {
                        result.Add(a + dir, tmc.movementCost);
                    }
                }
                
            }
            return result;
        }
        
        public override void OnUpdate(float delta)
        {
            
        }

        public override void OnFixedUpdate(float fixedDeltaTime)
        {
           
        }

        public override void OnExit()
        {
            
        }
    }
}