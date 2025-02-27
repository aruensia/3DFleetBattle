using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMain : MonoBehaviour
{
    public bool playerEngage = false;
    PlayerInfo playerInfo;
    public float BattleGroupWaitMoveSpeed = 10f;


    private void Start()
    {
        playerInfo = GameObject.Find("DataManager").GetComponent<PlayerInfo>();
    }

}
