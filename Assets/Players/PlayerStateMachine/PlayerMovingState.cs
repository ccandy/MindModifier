using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : FSMBaseState<PlayerFSM>
{
    PlayerFSM _FSM;
    public override void EnterState(PlayerFSM FSM)
    {
        _FSM = FSM;
        FSM.Player.PlayerLaySwitch(false);
        FSM.Player.ResponseToDamage();
        MessageSystem.Instance.StartListening("SwitchPlayerLay", SwitchPlayerLay);
        
    }

    public override void OnColliderEnter(PlayerFSM FSM)
    {
       
    }

    public override void OnFixedUpate(PlayerFSM FSM)
    {
        
    }

    public override void OnUpdate(PlayerFSM FSM)
    {
        if (FSM.Player.PlayerDead())
        {
            FSM.TransToState(FSM.PlayerDeadStateObj);
        }
        else
        {
            if (FSM.Player.MoveToPosition())
            {
                _FSM.TransToState(_FSM.PlayerIdleStateObj);
            }
        }
    }

    private void SwitchPlayerLay()
    {
        _FSM.TransToState(_FSM.PlayerLayStateObj);
    }

    
}
