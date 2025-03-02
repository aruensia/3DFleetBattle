using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSceneUI : MonoBehaviour
{
    public List<Text> playerFleetCount;
    public List<Text> enemyFleetCount;

    public GameObject playerUnit;
    public GameObject enemyUnit;

    public void ChangeShipCount()
    {
        playerFleetCount[0].text = "초계함 : " + playerUnit.transform.GetChild(0).childCount;
        playerFleetCount[1].text = "호위함 : " + playerUnit.transform.GetChild(1).childCount;
        playerFleetCount[2].text = "구축함 : " + playerUnit.transform.GetChild(2).childCount;
        playerFleetCount[3].text = "순양함 : " + playerUnit.transform.GetChild(3).childCount;
        playerFleetCount[4].text = "전  함 : " + playerUnit.transform.GetChild(4).childCount;
        playerFleetCount[5].text = "항공모함 : " + playerUnit.transform.GetChild(5).childCount;

        enemyFleetCount[0].text = "초계함 : " + enemyUnit.transform.GetChild(0).childCount;
        enemyFleetCount[1].text = "호위함 : " + enemyUnit.transform.GetChild(1).childCount;
        enemyFleetCount[2].text = "구축함 : " + enemyUnit.transform.GetChild(2).childCount;
        enemyFleetCount[3].text = "순양함 : " + enemyUnit.transform.GetChild(3).childCount;
        enemyFleetCount[4].text = "전  함 : " + enemyUnit.transform.GetChild(4).childCount;
        enemyFleetCount[5].text = "항공모함 : " + enemyUnit.transform.GetChild(5).childCount;
    }
}
