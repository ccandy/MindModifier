using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GManagerBaseState 
{
    public abstract void EnterState(GameManager GM);
    public abstract void OnUpdate(GameManager GM);
    public abstract void ExitState(GameManager GM);

}
