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


    // Start is called before the first frame update
    void Start()
    {
        DefaultCameraSetting();
    }


    void DefaultCameraSetting()
    {
        camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
        camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;

    }

    public void SetPlayerCorvetteCamera(int num)
    {
        switch (num)
        {
            case 0:
                if(PlayerCameraList[1].transform.childCount > 0)
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[1].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[1].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 10;
                }
                else
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
                }

                break;

            case 1:
                if (PlayerCameraList[1].transform.childCount > 0)
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[2].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[2].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 10;
                }
                else
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
                }
                break;

            case 2:
                if (PlayerCameraList[1].transform.childCount > 0)
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[3].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[3].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 10;
                }
                else
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
                }
                break;

            case 3:
                if (PlayerCameraList[1].transform.childCount > 0)
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[4].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[4].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 10;
                }
                else
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
                }
                break;

            case 4:
                if (PlayerCameraList[1].transform.childCount > 0)
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[5].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[5].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 10;
                }
                else
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
                }
                break;

            case 5:
                if (PlayerCameraList[1].transform.childCount > 0)
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[6].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[6].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 10;
                }
                else
                {
                    camera[0].GetComponent<CinemachineVirtualCamera>().Follow = PlayerCameraList[0].transform;
                    camera[0].GetComponent<CinemachineVirtualCamera>().LookAt = PlayerCameraList[0].transform;
                }
                break;
        }

    }
}
