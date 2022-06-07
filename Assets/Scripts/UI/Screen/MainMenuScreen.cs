using UnityEngine.UI;
using System;

public class MainMenuScreen : Screen
{
    public Action OnClickLogOutButton;

    public void LogOutButtonClick()
    {
        OnClickLogOutButton?.Invoke();
    }
}
