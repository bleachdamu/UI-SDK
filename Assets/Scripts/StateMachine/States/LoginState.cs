public class LoginState : BaseState
{

    public override void EnterState()
    {
        StateMachine.UIRootForStates.LoginStateScreenController.Initialize(true, StateMachine);
    }

    public override void ExitState()
    {
        StateMachine.UIRootForStates.LoginStateScreenController.DeInitialize();
    }

    public override void UpdateState()
    {
        
    }
}
