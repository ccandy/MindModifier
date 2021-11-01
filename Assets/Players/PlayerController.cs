using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerControl PlayerContrlIns;

    public PlayerSO PlayerData;

    public Vector3 DestPoint;

    private int _playerHP;

    private int _playerScore;
    public int PlayerScore
    {
        set
        {
            _playerScore = value;
        }
        get
        {
            return _playerScore;
        }
    }

    public int PlayerHP
    {
        get
        {
            return _playerHP;
        }
    }

    private float _playerRunningSpeed;
    public float PlayerRunningSpeed
    {
        get
        {
            return _playerRunningSpeed;
        }
    }
    private int _hpAtten;
    private float _playerLaySpeed;

    private void Start()
    {
        
    }
    public void PlayerInit()
    {
        if (PlayerData == null)
        {
            Debug.LogError("need player data");
        }
        else
        {
            _playerRunningSpeed = 10;
            _playerHP = 1000;
            _hpAtten = 1;
            _playerLaySpeed = 10;
        }

        MessageSystem.Instance.TriggerEvent("PlayerHPChange", _playerHP);
    }

    private void Awake()
    {
        
    }

   public void HPAtten()
    {
        if(_playerHP >= 0)
        {
            _playerHP -= _hpAtten;
        }
        MessageSystem.Instance.TriggerEvent("PlayerHPChange", _playerHP);

    }
    public void ResponseToDamage()
    {
        MessageSystem.Instance.StartListening("PlayerDamage", PlayerDamage);
    }

    private void PlayerDamage(int h)
    {
        _playerHP -= h;
        MessageSystem.Instance.TriggerEvent("PlayerHPChange", _playerHP);
    }

    public bool PlayerDead()
    {
        return _playerHP <= 0;
    }

    public void PlayerLaySwitch(bool lay)
    {
        Quaternion target; //= gameObject.transform.rotation;
        Quaternion currentQuat = gameObject.transform.rotation;
        if (lay)
        {
            target = Quaternion.Euler( -90f, currentQuat.eulerAngles.y, currentQuat.eulerAngles.z);
        }
        else
        {
            target = Quaternion.Euler(0, currentQuat.eulerAngles.y, currentQuat.eulerAngles.z);
        }

        transform.rotation = target;

    }
    public bool MoveToPosition()
    {
        Vector3 pos = gameObject.transform.position;

        if (Vector3.Distance(pos, DestPoint) < 0.001f)
        {
            return true;
        }
        gameObject.transform.LookAt(DestPoint);
        float step = _playerRunningSpeed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, DestPoint, step);

        return false;
    }

}
