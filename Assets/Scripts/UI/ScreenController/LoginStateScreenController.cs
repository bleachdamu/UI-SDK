using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginStateScreenController : ScreenController
{
    public LoginScreen loginScreen;
    public SignUpScreen signUpScreen;

    public override void Initialize(bool clearStack,StateMachine stateMachine)
    {
        base.Initialize(clearStack, stateMachine);
        PushScreen(loginScreen);

        loginScreen.OnClickSignUp = OpenSignUpScreen;
        loginScreen.OnClickLogin = ChangeState;

        signUpScreen.OnClickLogin = ChangeState;
    }

    public void OpenSignUpScreen()
    {
        PushScreen(signUpScreen);
    }

    private void ChangeState()
    {
        PopScreen();
        stateMachine.ChangeState(new MainMenuState());
    }
}
