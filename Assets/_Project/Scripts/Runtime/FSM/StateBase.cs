namespace StateMachine
{
    public abstract class StateBase
    {
        private FsmBase _fsm;

        protected StateBase(FsmBase fsm)
        {
            _fsm = fsm;
        }
        
        public abstract void OnEnter();
        public abstract void OnUpdate(float delta);
        public abstract void OnFixedUpdate(float fixedDeltaTime);
        public abstract void OnExit();

        

    }
}