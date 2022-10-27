using StateMachine;
using UnityEngine;
using Vega.Cursor;


namespace Vega.Character
{
    public class IdleState : StateBase
    {
        private readonly int _idleFront;
        private readonly int _idleBack;
        private readonly FsmBase _fsm;
        private readonly Animator _animator;
        private readonly SpriteRenderer _spriteRenderer;

        public IdleState(FsmBase fsm, Animator animator, 
            InputController inputController, SpriteRenderer spriteRenderer, CursorController cursorController) : base(fsm)
        {
            _fsm = fsm;
            _animator = animator;
            _spriteRenderer = spriteRenderer;
            _idleFront = Animator.StringToHash("IdleFront");
            _idleBack = Animator.StringToHash("IdleBack");
    
            
            
            inputController.horizontalDirectionChange.AddListener(OnHorizontalChange);
            inputController.verticalDirectionChange.AddListener(OnVerticalChange);
            cursorController.mouseClick.AddListener(OnMouseClick);
        }

        private void OnMouseClick(Vector3 vec3)
        {
            if (_fsm.CurrentState != this) return;
            
            _fsm.TransitionToState<WalkState>().MoveToPosition(vec3);
        }

        private void OnHorizontalChange(bool facingRight)
        {
            if (_fsm.CurrentState != this) return;
            
            _spriteRenderer.flipX = _animator.GetCurrentAnimatorStateInfo(0).shortNameHash == _idleBack ? 
                    !facingRight : facingRight;
        }

        private void OnVerticalChange(bool facingUp)
        {
            if (_fsm.CurrentState != this) return;
            
            _animator.Play(facingUp ? _idleBack : _idleFront);
        }

        public override void OnEnter()
        {
            _animator.Play(_idleFront);
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
