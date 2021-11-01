using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPLowerCondition : LevelCondition
{
    public int PlayerHPLevel;
    //private PlayerController _player;
    private bool _playerLose;
    public HPLowerCondition(int hp)
    {

        MessageSystem.Instance.StartListening("PlayerHPChange", PlayerHPChange);
        PlayerHPLevel = hp;
    }
    public override bool ReachCondition()
    {
        return _playerLose;
        //return _player.PlayerHP <= PlayerHPLevel;
    }


    private void PlayerHPChange(int n)
    {
        _playerLose = (n <= PlayerHPLevel);
    }
}
