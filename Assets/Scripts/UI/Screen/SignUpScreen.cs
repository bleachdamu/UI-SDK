using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SignUpScreen : Screen
{
    public Action OnClickLogin;

    public void LogInButtonClick()
    {
        OnClickLogin?.Invoke();
    }
}
