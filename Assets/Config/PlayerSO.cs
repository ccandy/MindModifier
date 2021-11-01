using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerSO : ScriptableObject
{
    public int PlayerHP;
    public float PlayerRunningSpeed;
    public float PlayerLayingSpeed;
    public int PlayerHPAtten;
   

}
