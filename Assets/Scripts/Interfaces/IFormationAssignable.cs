using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFormationAssignable
{
    void OnFormationAssigned(Transform spotT);
    void OnFormationUnassigned();
    Vector2 GetPosition();
}