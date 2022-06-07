public abstract class BaseState
{
    private StateMachine stateMachine;

    public StateMachine StateMachine { get => stateMachine; set => stateMachine = value; }

    public virtual void EnterState()
    {
        
    }

    public virtual void UpdateState()
    {
        
    }

    public virtual void ExitState()
    {
        
    }
}
