using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : FSMBaseState<PlayerFSM>
{
    PlayerFSM _FSM;
    public override void EnterState(PlayerFSM FSM)
    {
        _FSM = FSM;
        FSM.Player.ResponseToDamage();
        FSM.Player.PlayerLaySwitch(false);
        MessageSystem.Instance.StartListening("SwitchPlayerLay", SwitchPlayerLay);
        MessageSystem.Instance.StartListening("SwitchPlayerMove", SwitchPlayerMoving);
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
    }

    private void SwitchPlayerLay()
    {
        _FSM.TransToState(_FSM.PlayerLayStateObj);
    }

    private void SwitchPlayerMoving()
    {
        _FSM.TransToState(_FSM.PlayerMovingStateObj);
    }
}
