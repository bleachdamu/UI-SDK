using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
[DisallowMultipleComponent]
public class ScreenController : MonoBehaviour
{
    private bool initalized;

    private Stack<Screen> ScreenStack = new Stack<Screen>();

    protected StateMachine stateMachine;

    public virtual void Initialize(bool clearStack, StateMachine stateMachine)
    {
        initalized = true;
        this.stateMachine = stateMachine;
        if (clearStack)
        {
            ScreenStack.Clear();
        }
        ShowScreenController();
    }

    public virtual void ShowScreenController()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if(initalized && Input.GetKey(KeyCode.Escape))
        {
            Screen currentScreen = ScreenStack.Peek();
            if(currentScreen.HideOnClickBack)
            {
                PopScreen();
            }
        }
    }

    public bool IsScreenInStack(Screen Screen)
    {
        return ScreenStack.Contains(Screen);
    }

    public bool IsScreenOnTopOfStack(Screen Screen)
    {
        return ScreenStack.Count > 0 && Screen == ScreenStack.Peek();
    }

    public void PushScreen(Screen Screen)
    {
        if(!initalized)
        {
            Debug.Log("Screen not initialized");
        }

        Screen.Show();

        if (ScreenStack.Count > 0)
        {
            Screen currentScreen = ScreenStack.Peek();

            if (currentScreen.HideOnNewScreen)
            {
                currentScreen.Hide();
            }
        }

        ScreenStack.Push(Screen);
    }

    public void PopScreen()
    {
        if (ScreenStack.Count > 1)
        {
            Screen Screen = ScreenStack.Pop();
            Screen.Hide();

            Screen newCurrentScreen = ScreenStack.Peek();
            if (newCurrentScreen.HideOnNewScreen)
            {
                newCurrentScreen.Show();
            }
        }
        else
        {
            Debug.LogWarning("Trying to pop a Screen but only 1 Screen remains in the stack!");
        }
    }

    public void PopAllScreens()
    {
        for (int i = 1; i < ScreenStack.Count; i++)
        {
            PopScreen();
        }
    }

    public virtual void HideScreenController()
    {
        gameObject.SetActive(false);
    }

    public virtual void DeInitialize()
    {
        initalized = false;
        HideScreenController();
    }
}