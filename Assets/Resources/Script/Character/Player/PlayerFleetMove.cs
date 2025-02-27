using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerFleetMove : MonoBehaviour
{
    [SerializeField] float MaxFleetWaitSpeed = 15f;

    BattleMain battleMain;

    public GameObject playerStartingPoint;
    public GameObject TargetPoint;
    public Transform PlayerBattleGroup;
    
    bool maxSpeedOn = false;

    public Collider[] Engage;

    float tempradius = 400f;

    void Start()
    {
        battleMain = GameObject.Find("DataManager").GetComponent<BattleMain>();
        StartCoroutine(FleetBattleState());
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

            if (battleMain.BattleGroupWaitMoveSpeed >= MaxFleetWaitSpeed )
            {
                maxSpeedOn = true;
            }
        }

        else if ( maxSpeedOn == true )
        {
            battleMain.BattleGroupWaitMoveSpeed = MaxFleetWaitSpeed;
        }

        transform.LookAt(TargetPoint.transform.position);
        PlayerBattleGroup.transform.Translate(Vector3.forward * battleMain.BattleGroupWaitMoveSpeed * Time.deltaTime);
    }

    IEnumerator FleetBattleState()
    {
        while(true)
        {
            if (battleMain.ShipSettingOn == true)
            {
                yield return new WaitForSeconds(1);
                if (battleMain.playerEngage == false)
                {
                    Debug.Log("적 탐색중 !!!!");
                    EnemyContect();
                }
                if (battleMain.playerEngage == true)
                {
                    Debug.Log("적과 교전중!!!!!");
                    StopCoroutine(FleetBattleState());
                }
            }
            else
            {
                Debug.Log("함대가 준비되지 않음");
            }
        }
    }

    void EnemyContect()
    {
        Engage = Physics.OverlapSphere(this.transform.position, tempradius);
        foreach (Collider item in Engage)
        {
            if (item.CompareTag("Enemy"))
            {
                Debug.Log("에너미 컨텍트!!!!");
                battleMain.playerEngage = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, tempradius);
    }
}
