public class MainMenuState : BaseState
{
    public override void EnterState()
    {
        StateMachine.UIRootForStates.MainMenuStateScreenController.Initialize(true, StateMachine);
    }

    public override void ExitState()
    {
        StateMachine.UIRootForStates.MainMenuStateScreenController.DeInitialize();
    }

    public override void UpdateState()
    {

    }
}
