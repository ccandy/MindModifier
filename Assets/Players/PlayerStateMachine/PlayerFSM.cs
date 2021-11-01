

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM:MonoBehaviour
{

    #region PlayerStates
    private FSMBaseState<PlayerFSM> _currentState;
    public readonly PlayerIdleState PlayerIdleStateObj = new PlayerIdleState();
    public readonly PlayerLayState PlayerLayStateObj = new PlayerLayState();
    public readonly PlayerDeadState PlayerDeadStateObj = new PlayerDeadState();
    public readonly PlayerMovingState PlayerMovingStateObj = new PlayerMovingState();
    #endregion

    PlayerController _player;
    public PlayerController Player
    {
        get
        {
            return _player;
        }
    }

    private void Awake()
    {
        _player = gameObject.GetComponent<PlayerController>();
    }

    void Start()
    {
        TransToState(PlayerIdleStateObj);
    }
    void Update()
    {
        _currentState.OnUpdate(this);
    }


    public void TransToState(FSMBaseState<PlayerFSM> state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }

    

}
