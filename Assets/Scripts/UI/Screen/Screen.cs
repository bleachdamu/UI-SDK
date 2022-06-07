using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField]
    private bool _hideOnNewScreen = true;
    public bool HideOnNewScreen { get => _hideOnClickBack; }

    [SerializeField]
    private bool _hideOnClickBack = true;
    public bool HideOnClickBack { get => _hideOnClickBack; }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
