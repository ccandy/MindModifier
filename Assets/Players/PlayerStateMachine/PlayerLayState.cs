using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayState : FSMBaseState<PlayerFSM>
{
    PlayerFSM _FSM;
    public override void EnterState(PlayerFSM player)
    {
        _FSM = player;
        _FSM.Player.PlayerLaySwitch(true);
        MessageSystem.Instance.StartListening("SwitchPlayerLay", SwitchPlayerLay);
        //MessageSystem.Instance.StartListening("SwitchPlayerLay");
    }

    public override void OnColliderEnter(PlayerFSM playerFSM)
    {
        
    }

    public override void OnFixedUpate(PlayerFSM FSM)
    {
        
    }

    public override void OnUpdate(PlayerFSM playerFSM)
    {

        if (playerFSM.Player.PlayerDead())
        {
            playerFSM.Player.HPAtten();
        }
        else
        {
            playerFSM.TransToState(playerFSM.PlayerDeadStateObj);
        }
    }

    private void SwitchPlayerLay()
    {
        _FSM.Player.PlayerLaySwitch(false);
        _FSM.TransToState(_FSM.PlayerIdleStateObj);
    }
}
