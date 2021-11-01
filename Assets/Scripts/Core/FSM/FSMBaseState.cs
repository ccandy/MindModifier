using System;

public abstract class FSMBaseState<T>
{
    public abstract void EnterState(T FSM);
    public abstract void OnUpdate(T FSM);
    public abstract void OnColliderEnter(T FSM);
    public abstract void OnFixedUpate(T FSM);


}
