using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFleetMove : MonoBehaviour
{
    float fleetMoveSpeed = 2f;
    bool check = false;


    // Update is called once per frame
    void Update()
    {
        if( check == false)
        {
            transform.Translate(Vector3.forward * fleetMoveSpeed * Time.deltaTime);

            if( transform.position.x == 320)
            {
                check = true;
            }
        }
        else if ( check == true)
        {
            transform.position = new Vector3(-20, 0, 0);
            check = false;
        }
    }
}
