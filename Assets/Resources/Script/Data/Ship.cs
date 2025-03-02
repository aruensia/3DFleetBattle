using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Ship : MonoBehaviour
{
    BattleMain battleMain;
    PlayerFleetAI playerFleetAi;
    EnemyFleetAI enemyFleetAi;
    BattleSceneUI sceneUI;

    List<Weapon> haveWeapon = new List<Weapon>();

    public enum ShipState
    {
        Idle, Move, Attack, Die, Search
    }

    public ShipHull shipHull;
    public ShipHead shiphead;
    public ShipBody shipBody;
    public ShipTail shipTail;

    public int hp;
    public int armor;
    public int shield;

    public float speed;
    public int usecap;
    public int cost;

    public ShipState state;
    public bool isdie = false;
    public bool isShipEngageOn = false;

    float minDistance = 30f;

    [SerializeField] Ship useWeaponTarget;

    private void Start()
    {
        battleMain = GameObject.Find("BattleManager").GetComponent<BattleMain>();
        playerFleetAi = GameObject.Find("PlayerFleet").GetComponent<PlayerFleetAI>();
        enemyFleetAi = GameObject.Find("EnemyFleet").GetComponent<EnemyFleetAI>();
        sceneUI = GameObject.Find("BattleManager").GetComponent<BattleSceneUI>();

        state = ShipState.Idle;
        WeaponFireReady();
        StartCoroutine(CheckState());
        StartCoroutine(ShipAction());
        sceneUI.ChangeShipCount();
    }

    public void Update()
    {
        if (state == ShipState.Idle)
        {
            playerFleetAi.PatrolMove();
            enemyFleetAi.PatrolMove();
        }
        else if(state == ShipState.Attack)
        {
            CombatMove();
        }
    }

    void WeaponFireReady()
    {
        if (shiphead.weapons == null)
        {
            Debug.Log(transform.name + " 의 머리 무기가 없어요!!!");
        }
        else if(shiphead.weapons.Count > 0)
        {
            foreach (var weapon in shiphead.weapons)
            {
                if (weapon != null)
                {
                    var newWeapon = Instantiate(weapon);
                    newWeapon.weaponFireOn = true;
                    haveWeapon.Add(newWeapon);
                }
            }
        }

        if (shipBody.weapons == null)
        {
            Debug.Log(transform.name + " 의 몸 무기가 없어요!!!");
        }
        else if (shipBody.weapons.Count > 0)
        {
            foreach (var weapon in shipBody.weapons)
            {
                if (weapon != null)
                {
                    var newWeapon = Instantiate(weapon);
                    newWeapon.weaponFireOn = true;
                    haveWeapon.Add(newWeapon);
                }
            }
        }

        if (shipTail.weapons == null)
        {
            Debug.Log(transform.name + " 의 꼬리 무기가 없어요!!!");
        }
        else if (shipTail.weapons.Count > 0)
        {
            foreach (var weapon in shipTail.weapons)
            {
                if (weapon != null)
                {
                    var newWeapon = Instantiate(weapon);
                    newWeapon.weaponFireOn = true;
                    haveWeapon.Add(newWeapon);
                }
            }
        }
    }

    public void CombatMove()
    {
        float distance = Vector3.Distance(transform.position, useWeaponTarget.transform.position);

        switch (shipHull.shipClass)
        {
            case ShipClass.Corvette:
                if (distance > minDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, useWeaponTarget.transform.position, speed * Time.deltaTime);
                }

                break;

            case ShipClass.Frigate:
                if (distance > minDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, useWeaponTarget.transform.position, speed * Time.deltaTime);
                }

                break;

            case ShipClass.Destroyer:
                if (distance > minDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, useWeaponTarget.transform.position, speed * Time.deltaTime);
                }

                break;

            case ShipClass.Cruiser:
                if( distance > minDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, useWeaponTarget.transform.position, speed * Time.deltaTime);
                }
                break;

            case ShipClass.Battleship:
                minDistance = 100f;
                if (distance > minDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, useWeaponTarget.transform.position, speed * Time.deltaTime);
                }
                break;

            case ShipClass.AircraftCarrier:
                minDistance = 150f;
                if (distance > minDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, useWeaponTarget.transform.position, speed * Time.deltaTime);
                }
                break;
        }
    }

    void DefalutSeaching()
    {
        if (transform.CompareTag("Player"))
        {
            for (int i = 0; i < playerFleetAi.enemyBattleGroup.Count; i++)
            {
                if (playerFleetAi.enemyBattleGroup[i].transform.childCount > 0)
                {
                    this.useWeaponTarget = playerFleetAi.enemyBattleGroup[i].transform.GetChild(Random.Range(0, playerFleetAi.enemyBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                    battleMain.playerEngage = true;
                    isShipEngageOn = true;
                    break;
                }
            }
            if(useWeaponTarget == null)
            {
                battleMain.playerEngage = false;
                Debug.Log("적이없다!!!!!!!");
            }
        }
        else if (transform.CompareTag("Enemy"))
        {
            for (int i = 0; i < enemyFleetAi.playerBattleGroup.Count; i++)
            {
                if (enemyFleetAi.playerBattleGroup[i].transform.childCount > 0)
                {
                    this.useWeaponTarget = enemyFleetAi.playerBattleGroup[i].transform.GetChild(Random.Range(0, playerFleetAi.enemyBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                    break;
                }
            }
            if (useWeaponTarget == null)
            {
                battleMain.enemyEngage = false;
                Debug.Log("적이없다!!!!!!!");
            }
        }
    }

    public void SearchTarget()
    {
        Debug.Log("적을 찾는중!!!!!");
        switch (shipHull.shipClass)
        {
            case ShipClass.Corvette:
                DefalutSeaching();
                break;

            case ShipClass.Frigate:
                DefalutSeaching();
                break;

            case ShipClass.Destroyer:

                if (transform.CompareTag("Player"))
                {
                    if (playerFleetAi.enemyBattleGroup[3].transform.childCount > 0)
                    {
                        this.useWeaponTarget = playerFleetAi.enemyBattleGroup[3].transform.GetChild(Random.Range(0, playerFleetAi.enemyBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.playerEngage = true;
                        isShipEngageOn = true;
                    }
                    else
                    {
                        DefalutSeaching();
                    }
                }
                else if (transform.CompareTag("Enemy"))
                {
                    if (enemyFleetAi.playerBattleGroup[3].transform.childCount > 0)
                    {
                        this.useWeaponTarget = enemyFleetAi.playerBattleGroup[3].transform.GetChild(Random.Range(0, enemyFleetAi.playerBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.enemyEngage = true;
                        isShipEngageOn = true;
                    }
                    else
                    {
                        DefalutSeaching();
                    }
                }
                break;

            case ShipClass.Cruiser:
                if (transform.CompareTag("Player"))
                {
                    if (playerFleetAi.enemyBattleGroup[4].transform.childCount > 0)
                    {
                        this.useWeaponTarget = playerFleetAi.enemyBattleGroup[4].transform.GetChild(Random.Range(0, playerFleetAi.enemyBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.playerEngage = true;
                        isShipEngageOn = true;
                    }
                    else if (playerFleetAi.enemyBattleGroup[5].transform.childCount > 0)
                    {
                        this.useWeaponTarget = playerFleetAi.enemyBattleGroup[5].transform.GetChild(Random.Range(0, playerFleetAi.enemyBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.playerEngage = true;
                        isShipEngageOn = true;
                    }
                    else
                    {
                        DefalutSeaching();
                    }
                }
                else if (transform.CompareTag("Enemy"))
                {
                    if (enemyFleetAi.playerBattleGroup[4].transform.childCount > 0)
                    {
                        this.useWeaponTarget = enemyFleetAi.playerBattleGroup[4].transform.GetChild(Random.Range(0, enemyFleetAi.playerBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.enemyEngage = true;
                        isShipEngageOn = true;
                    }
                    else if (enemyFleetAi.playerBattleGroup[5].transform.childCount > 0)
                    {
                        this.useWeaponTarget = enemyFleetAi.playerBattleGroup[5].transform.GetChild(Random.Range(0, enemyFleetAi.playerBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.enemyEngage = true;
                        isShipEngageOn = true;
                    }
                    else
                    {
                        DefalutSeaching();
                    }
                }
                break;

            case ShipClass.Battleship:
                if (transform.CompareTag("Player"))
                {
                    if (playerFleetAi.enemyBattleGroup[5].transform.childCount > 0)
                    {
                        this.useWeaponTarget = playerFleetAi.enemyBattleGroup[5].transform.GetChild(Random.Range(0, playerFleetAi.enemyBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.playerEngage = true;
                        isShipEngageOn = true;
                    }
                    else if (playerFleetAi.enemyBattleGroup[4].transform.childCount > 0)
                    {
                        this.useWeaponTarget = playerFleetAi.enemyBattleGroup[4].transform.GetChild(Random.Range(0, playerFleetAi.enemyBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.playerEngage = true;
                        isShipEngageOn = true;
                    }
                    else if (playerFleetAi.enemyBattleGroup[6].transform.childCount > 0)
                    {
                        this.useWeaponTarget = playerFleetAi.enemyBattleGroup[6].transform.GetChild(Random.Range(0, playerFleetAi.enemyBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.playerEngage = true;
                        isShipEngageOn = true;
                    }
                    else
                    {
                        DefalutSeaching();
                    }
                }
                else if (transform.CompareTag("Enemy"))
                {
                    if (enemyFleetAi.playerBattleGroup[4].transform.childCount > 0)
                    {
                        this.useWeaponTarget = enemyFleetAi.playerBattleGroup[4].transform.GetChild(Random.Range(0, enemyFleetAi.playerBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.enemyEngage = true;
                        isShipEngageOn = true;
                    }
                    else if (enemyFleetAi.playerBattleGroup[3].transform.childCount > 0)
                    {
                        this.useWeaponTarget = enemyFleetAi.playerBattleGroup[3].transform.GetChild(Random.Range(0, enemyFleetAi.playerBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.enemyEngage = true;
                        isShipEngageOn = true;
                    }
                    else if (enemyFleetAi.playerBattleGroup[5].transform.childCount > 0)
                    {
                        useWeaponTarget = enemyFleetAi.playerBattleGroup[5].transform.GetChild(Random.Range(0, enemyFleetAi.playerBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.enemyEngage = true;
                        isShipEngageOn = true;
                    }
                    else
                    {
                        DefalutSeaching();
                    }
                }
                break;

            case ShipClass.AircraftCarrier:
                if(transform.CompareTag("Player"))
                {
                    if (playerFleetAi.enemyBattleGroup[6].transform.childCount > 0)
                    {
                        this.useWeaponTarget = playerFleetAi.enemyBattleGroup[6].transform.GetChild(Random.Range(0, playerFleetAi.enemyBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.playerEngage = true;
                        isShipEngageOn = true;
                    }
                    else if (playerFleetAi.enemyBattleGroup[5].transform.childCount > 0)
                    {
                        this.useWeaponTarget = playerFleetAi.enemyBattleGroup[5].transform.GetChild(Random.Range(0, playerFleetAi.enemyBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.playerEngage = true;
                        isShipEngageOn = true;
                    }
                    else if (playerFleetAi.enemyBattleGroup[4].transform.childCount > 0)
                    {
                        this.useWeaponTarget = playerFleetAi.enemyBattleGroup[4].transform.GetChild(Random.Range(0, playerFleetAi.enemyBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.playerEngage = true;
                        isShipEngageOn = true;
                    }
                    else
                    {
                        DefalutSeaching();
                    }
                }
                if (transform.CompareTag("Enemy"))
                {
                    if (enemyFleetAi.playerBattleGroup[6].transform.childCount > 0)
                    {
                        this.useWeaponTarget = enemyFleetAi.playerBattleGroup[6].transform.GetChild(Random.Range(0, enemyFleetAi.playerBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.enemyEngage = true;
                        isShipEngageOn = true;
                    }
                    else if (enemyFleetAi.playerBattleGroup[5].transform.childCount > 0)
                    {
                        this.useWeaponTarget = enemyFleetAi.playerBattleGroup[5].transform.GetChild(Random.Range(0, enemyFleetAi.playerBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.enemyEngage = true;
                        isShipEngageOn = true;
                    }
                    else if (enemyFleetAi.playerBattleGroup[4].transform.childCount > 0)
                    {
                        this.useWeaponTarget = enemyFleetAi.playerBattleGroup[4].transform.GetChild(Random.Range(0, enemyFleetAi.playerBattleGroup[0].transform.childCount)).GetComponent<Ship>();
                        battleMain.enemyEngage = true;
                        isShipEngageOn = true;
                    }
                    else
                    {
                        DefalutSeaching();
                    }
                }
                break;
        }
    }

    public void WeaponFire()
    {
        float dist = Vector3.Distance(transform.position, useWeaponTarget.transform.position);
        Debug.Log(haveWeapon.Count + " 보유 무기 수 !!!!");

        foreach (var weapon in haveWeapon)
        {
            if(weapon.attackLoadCount > weapon.attackMinCool)
            {
                weapon.attackLoadCount -= 1;
                Debug.Log($"{weapon.defaultShipPartName} 무기 장전중!!!! {weapon.attackLoadCount}");
            }
            else if ( weapon.attackLoadCount <= weapon.attackMinCool)
            {
                weapon.weaponFireOn = true;
                Debug.Log($"{weapon.defaultShipPartName} 무기 장전 완료!!!!");
            }

            if ( weapon.weaponFireOn == true)
            {
                if (weapon.attackRange > dist)
                {

                    useWeaponTarget.TakeDamage(weapon.damage);
                    Debug.Log($"{useWeaponTarget.name}을 향해 공격을 해서 피해를 입혔음!!! ");
                    weapon.attackLoadCount = weapon.attackMaxCool;
                    weapon.weaponFireOn = false;
                }
            }
        }

        if( haveWeapon.Count == 0)
        {
            Debug.Log($"{gameObject.name}이 가진 무기가 없습니다.!!");
        }
    }

    public void TakeDamage(int damage)
    {
        if (shield > 0)
        {
            shield -= damage;
        }
        else if (shield <= 0)
        {
            if (armor > 0)
            {
                armor -= damage;
            }
            else if (armor <= 0)
            {
                if (hp > 0)
                {
                    hp -= damage;
                }
                else if(hp <= 0)
                {
                    state = ShipState.Die;
                }
            }
        }
    }

    void ShipDestroy()
    {
        Debug.Log("나 죽었어요!!!!" + gameObject.name);
        Destroy(this.gameObject);
        isdie = true;
    }

    IEnumerator CheckState()
    {
        while(!isdie)
        {
            yield return new WaitForSeconds(0.3f);

            if (isShipEngageOn == true)
            {
                Debug.Log("현재 상태는 공격중!!");
                state = ShipState.Attack;
            }
            else if (battleMain.playerContect == true)
            {
                Debug.Log("현재 상태는 찾는 중!!");
                state = ShipState.Search;
            }
            else if (battleMain.playerEngage == false)
            {
                Debug.Log("현재 상태는 대기중!!");
                state = ShipState.Idle;
            }
        }
    }

    IEnumerator ShipAction()
    {
        while(!isdie)
        {
            switch (state)
            {
                case ShipState.Idle:
                    break;

                case ShipState.Search:
                    SearchTarget();
                    break;

                case ShipState.Attack:
                    WeaponFire();
                    break;

                case ShipState.Die:
                    ShipDestroy();
                    sceneUI.ChangeShipCount();
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
 