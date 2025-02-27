using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFleetMove : MonoBehaviour
{
    [SerializeField] float MaxFleetWaitSpeed = 15f;

    BattleMain battleMain;


    public GameObject TargetPoint;
    public Transform enemyBattleGroup;
    bool maxSpeedOn = false;

    private void Awake()
    {
        battleMain = GameObject.Find("BattleManager").GetComponent<BattleMain>();
    }

    private void Update()
    {
        PatrolMove();
    }

    void PatrolMove()
    {
        if (maxSpeedOn == false)
        {
            battleMain.BattleGroupWaitMoveSpeed += 0.01f;

            if (battleMain.BattleGroupWaitMoveSpeed >= MaxFleetWaitSpeed)
            {
                maxSpeedOn = true;
            }
        }
        else if (maxSpeedOn == true)
        {
            battleMain.BattleGroupWaitMoveSpeed = MaxFleetWaitSpeed;
        }

        transform.LookAt(TargetPoint.transform.position);
        enemyBattleGroup.transform.Translate(Vector3.forward * battleMain.BattleGroupWaitMoveSpeed * Time.deltaTime);
    }

    void EngageMove()
    {

    }
}
