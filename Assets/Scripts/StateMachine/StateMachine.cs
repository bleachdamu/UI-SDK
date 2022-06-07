using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private BaseState currentState;

    [SerializeField]
    private UIRootForStates uIRootForStates;
    public UIRootForStates UIRootForStates { get => uIRootForStates;}

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new LoginState());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public void ChangeState(BaseState baseState)
    {
        if(currentState != null)
        {
            currentState.ExitState();
        }

        currentState = baseState;

        if (currentState != null)
        {
            currentState.StateMachine = this;
            currentState.EnterState();
        }
    }
}
