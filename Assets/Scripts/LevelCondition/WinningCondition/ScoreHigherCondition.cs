using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHigherCondition : LevelCondition
{

    public int PlayerScoreLimit;
    //PlayerController _player;
    bool _playerWin;
    public ScoreHigherCondition(int s)
    {
        PlayerScoreLimit = s;
        MessageSystem.Instance.StartListening("PlayerHPChange", PlayerScoreChange);
    }

    private void PlayerScoreChange(int n)
    {
        _playerWin = (n >= PlayerScoreLimit);
    }

    public override bool ReachCondition()
    {
        //return _player.PlayerScore >= PlayerScoreLimit;

        return _playerWin;
    }
}
