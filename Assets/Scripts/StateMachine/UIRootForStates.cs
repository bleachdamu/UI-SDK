using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRootForStates : MonoBehaviour
{
    [SerializeField]
    private LoginStateScreenController _loginStateScreenController;

    public LoginStateScreenController LoginStateScreenController { get => _loginStateScreenController; }

    [SerializeField]
    private MainMenuStateScreenController _mainMenuStateScreenController;

    public MainMenuStateScreenController MainMenuStateScreenController { get => _mainMenuStateScreenController; }
}
