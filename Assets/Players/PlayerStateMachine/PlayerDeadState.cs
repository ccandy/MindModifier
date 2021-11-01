using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : FSMBaseState<PlayerFSM>
{
    

    public override void EnterState(PlayerFSM FSM)
    {
        
        MessageSystem.Instance.TriggerEvent("PlayerDead");
    }

    public override void OnColliderEnter(PlayerFSM FSM)
    {
        ;
    }

    public override void OnFixedUpate(PlayerFSM FSM)
    {
        
    }

    public override void OnUpdate(PlayerFSM FSM)
    {
        
    }

    private void PlayerDead()
    {

    }
}
