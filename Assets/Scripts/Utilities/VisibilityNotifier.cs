using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VisibilityNotifier : MonoBehaviour
{
    public event Action<bool> OnVisibilityChange;

    private void OnBecameVisible()
    {
        OnVisibilityChange?.Invoke(true);
    }

    private void OnBecameInvisible()
    {
        OnVisibilityChange?.Invoke(false);
    }
}