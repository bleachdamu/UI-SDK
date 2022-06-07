using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStateScreenController : ScreenController
{
    public MainMenuScreen menuScreen;
    public Screen settingsScreen;

    public override void Initialize(bool clearStack, StateMachine stateMachine)
    {
        base.Initialize(clearStack, stateMachine);
        PushScreen(menuScreen);

        menuScreen.OnClickLogOutButton = ChangeState;
    }

    private void ChangeState()
    {
        stateMachine.ChangeState(new LoginState());
    }
}
