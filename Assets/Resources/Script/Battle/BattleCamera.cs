using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class BattleCamera : MonoBehaviour
{
    public CinemachineVirtualCamera[] camera;
    public Button[] cameraButton;

    public List<GameObject> PlayerCameraList = new List<GameObject>();
    public List<GameObject> EnemyCameraList = new List<GameObject>();

    int tempCount = 0;
    int CheckNum;

    // Start is called before the first frame update
    void Start()
    {
        DefaultCameraSetting();
    }


    void DefaultCameraSetting()
    {
        camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
        camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
        camera[0].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 60;

    }

    public void SetGlobalCamera()
    {
        camera[2].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[1].transform;
        camera[2].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 60;
        camera[0].gameObject.SetActive(false);
        camera[1].gameObject.SetActive(false);
        camera[2].gameObject.SetActive(true);
    }

    public void FleetViewCamera(int num)
    {
        if( num == 0)
        {
            camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
            camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
            camera[0].gameObject.SetActive(true);
            camera[1].gameObject.SetActive(false);

        }
        else
        {
            camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
            camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
            camera[0].gameObject.SetActive(false);
            camera[1].gameObject.SetActive(true);
        }
    }


    public void SetPlayerCorvetteCamera(int num)
    {
        if( CheckNum == num)
        {
            tempCount++;
        }
        camera[0].gameObject.SetActive(true);
        camera[1].gameObject.SetActive(false);
        switch (num)
        {
            case 1:
                if(PlayerCameraList[1].transform.childCount <= tempCount)
                {
                    tempCount = 0;
                }

                if(PlayerCameraList[1].transform.childCount > 0)
                {

                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[1].transform.GetChild(tempCount).transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[1].transform.GetChild(tempCount).transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 20;
                }
                else
                {

                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
                }
                CheckNum = num;

                break;

            case 2:
                if (PlayerCameraList[2].transform.childCount <= tempCount)
                {
                    tempCount = 0;
                }

                if (PlayerCameraList[1].transform.childCount > 0)
                {

                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[2].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[2].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 20;
                }
                else
                {

                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
                }
                CheckNum = num;
                break;

            case 3:
                if (PlayerCameraList[3].transform.childCount <= tempCount)
                {
                    tempCount = 0;
                }

                if (PlayerCameraList[1].transform.childCount > 0)
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[3].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[3].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 20;
                }
                else
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
                }
                CheckNum = num;
                break;

            case 4:
                if (PlayerCameraList[4].transform.childCount <= tempCount)
                {
                    tempCount = 0;
                }

                if (PlayerCameraList[1].transform.childCount > 0)
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[4].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[4].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 20;
                }
                else
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
                }
                CheckNum = num;
                break;

            case 5:
                if (PlayerCameraList[5].transform.childCount <= tempCount)
                {
                    tempCount = 0;
                }

                if (PlayerCameraList[1].transform.childCount > 0)
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[5].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[5].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 40;
                }
                else
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
                }
                CheckNum = num;
                break;

            case 6:
                if (PlayerCameraList[6].transform.childCount <= tempCount)
                {
                    tempCount = 0;
                }

                if (PlayerCameraList[1].transform.childCount > 0)
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[6].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[6].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 40;
                }
                else
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
                }
                CheckNum = num;
                break;
        }

    }

    public void SetEnemyCorvetteCamera(int num)
    {
        if (CheckNum == num)
        {
            tempCount++;
        }

        camera[0].gameObject.SetActive(false);
        camera[1].gameObject.SetActive(true);

        switch (num)
        {
            case 1:
                if (EnemyCameraList[1].transform.childCount <= tempCount)
                {
                    tempCount = 0;
                }

                if (EnemyCameraList[1].transform.childCount > 0)
                {

                    camera[1].GetComponent<CinemachineVirtualCamera>().Follow = EnemyCameraList[1].transform.GetChild(tempCount).transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().LookAt = EnemyCameraList[1].transform.GetChild(tempCount).transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 10;
                }
                else
                {

                    camera[1].GetComponent<CinemachineVirtualCamera>().Follow = EnemyCameraList[0].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().LookAt = EnemyCameraList[0].transform;
                }
                CheckNum = num;

                break;

            case 2:
                if (EnemyCameraList[2].transform.childCount <= tempCount)
                {
                    tempCount = 0;
                }

                if (EnemyCameraList[1].transform.childCount > 0)
                {

                    camera[1].GetComponent<CinemachineVirtualCamera>().Follow = EnemyCameraList[2].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().LookAt = EnemyCameraList[2].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 10;
                }
                else
                {

                    camera[1].GetComponent<CinemachineVirtualCamera>().Follow = EnemyCameraList[0].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().LookAt = EnemyCameraList[0].transform;
                }
                CheckNum = num;
                break;

            case 3:
                if (EnemyCameraList[3].transform.childCount <= tempCount)
                {
                    tempCount = 0;
                }

                if (EnemyCameraList[1].transform.childCount > 0)
                {
                    camera[1].GetComponent<CinemachineVirtualCamera>().Follow = EnemyCameraList[3].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().LookAt = EnemyCameraList[3].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 10;
                }
                else
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = EnemyCameraList[0].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = EnemyCameraList[0].transform;
                }
                CheckNum = num;
                break;

            case 4:
                if (EnemyCameraList[4].transform.childCount <= tempCount)
                {
                    tempCount = 0;
                }

                if (EnemyCameraList[1].transform.childCount > 0)
                {
 
                    camera[1].GetComponent<CinemachineVirtualCamera>().Follow = EnemyCameraList[4].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().LookAt = EnemyCameraList[4].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 10;
                }
                else
                {

                    camera[1].GetComponent<CinemachineVirtualCamera>().Follow = EnemyCameraList[0].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().LookAt = EnemyCameraList[0].transform;
                }
                CheckNum = num;
                break;

            case 5:
                if (EnemyCameraList[5].transform.childCount <= tempCount)
                {
                    tempCount = 0;
                }

                if (EnemyCameraList[1].transform.childCount > 0)
                {

                    camera[1].GetComponent<CinemachineVirtualCamera>().Follow = EnemyCameraList[5].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().LookAt = EnemyCameraList[5].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 10;
                }
                else
                {
                    camera[1].GetComponent<CinemachineVirtualCamera>().Follow = EnemyCameraList[0].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().LookAt = EnemyCameraList[0].transform;
                }
                CheckNum = num;
                break;

            case 6:
                if (EnemyCameraList[6].transform.childCount <= tempCount)
                {
                    tempCount = 0;
                }

                if (EnemyCameraList[1].transform.childCount > 0)
                {
                    camera[1].GetComponent<CinemachineVirtualCamera>().Follow = EnemyCameraList[6].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().LookAt = EnemyCameraList[6].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 10;
                }
                else
                {
                    camera[1].GetComponent<CinemachineVirtualCamera>().Follow = EnemyCameraList[0].transform;
                    camera[1].GetComponent<CinemachineVirtualCamera>().LookAt = EnemyCameraList[0].transform;
                }
                CheckNum = num;
                break;
        }

    }
}
