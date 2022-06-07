using UnityEngine.UI;
using System;

public class LoginScreen : Screen
{
    public Action OnClickSignUp;
    public Action OnClickLogin;

    public void SignUpButtonClick()
    {
        OnClickSignUp?.Invoke();
    }

    public void LogInButtonClick()
    {
        OnClickLogin?.Invoke();
    }
}
