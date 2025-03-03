using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleObj : MonoBehaviour
{
    Ship ship;
    public List<Transform> muzzle = new List<Transform>();
    public LineRenderer lineRenderer;

    void Start()
    {
        ship = transform.parent.GetComponent<Ship>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        //AddMuzzle();
    }


    public void AddMuzzle()
    {
        if (muzzle.Count == 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                muzzle.Add(transform.GetChild(i));
            }
        }
    }


    public void FireLaser()
    {
        RaycastHit hit;
        Vector3 targetpoint = ship.useWeaponTarget.transform.position;

        if (Physics.Raycast(muzzle[0].transform.position, muzzle[0].forward, out hit))
        {
            targetpoint = hit.point;
        }

        lineRenderer.SetPosition(0, muzzle[0].position);
        lineRenderer.SetPosition(1, targetpoint);
        lineRenderer.enabled = true;

        Invoke("DisableLaser", 2f);
    }

    void DisableLaser()
    {
        lineRenderer.enabled = false;
    }
}
