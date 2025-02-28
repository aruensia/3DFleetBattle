using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFleetAI : MonoBehaviour
{
    [SerializeField] float MaxFleetWaitSpeed = 15f;
    public List<GameObject> playerBattleGroup = new List<GameObject>();

    BattleMain battleMain;

    public List<List<GameObject>> corvetteGroup = new List<List<GameObject>>();
    public List<List<GameObject>> frigateGroup = new List<List<GameObject>>();
    public List<List<GameObject>> destroyerGroup = new List<List<GameObject>>();
    public List<List<GameObject>> cruiserGroup = new List<List<GameObject>>();
    public List<List<GameObject>> battleshipeGroup = new List<List<GameObject>>();
    public List<List<GameObject>> aircraftCarrierGroup = new List<List<GameObject>>();

    public GameObject EnemyStartingPoint;
    public GameObject TargetPoint;
    public Transform EnemyBattleGroup;

    bool maxSpeedOn = false;

    public Collider[] Engage;

    float tempradius = 400f;

    private void Awake()
    {
        battleMain = GameObject.Find("BattleManager").GetComponent<BattleMain>();
    }



    public void PatrolMove()
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
        EnemyBattleGroup.transform.Translate(Vector3.forward * battleMain.BattleGroupWaitMoveSpeed * Time.deltaTime);
    }

    public void StartFleetMove()
    {
        StartCoroutine(FleetBattleState());
    }

    IEnumerator FleetBattleState()
    {
        while (true)
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, tempradius);
    }

    IEnumerator FleetState()
    {


        yield return new WaitForSeconds(0.3f);
    }
}
