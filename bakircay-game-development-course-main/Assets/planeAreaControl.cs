using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeAreaControl : MonoBehaviour
{

    /*public Transform plane;
    public bool isControl = true;
    

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Plane")
        {
            Debug.Log(isControl);
            if (isControl)
            {
                getOfThePlane();
            }

            else
            {
                getOnThePlane();
            }
        }
    }

    void getOfThePlane()
    {
        //uçaða binmek
        for (int i = 0; i < plane.childCount; i++)
        {
            Transform child = plane.GetChild(i);
            if (child.name == "PlayerMan")
            {
                plane.GetComponent<PlaneController>().enabled = true;
                if (Input.GetKeyDown(KeyCode.B))
                {
                    isControl = !isControl;
                }
                break;
            }

            else
            {
                plane.GetComponent<PlaneController>().enabled = false;
            }
        }
    }

    void getOnThePlane()
    {
        //uçaktan inmek
        for (int i = 0; i < plane.childCount; i++)
        {
            Transform child = plane.GetChild(i);
            if (child.name == "PlayerMan")
            {
                plane.GetComponent<PlaneController>().enabled = false;
                if (Input.GetKeyDown(KeyCode.B))
                {
                    isControl = !isControl;
                }
                break;
            }

            else
            {
                plane.GetComponent<PlaneController>().enabled = true;
            }
        }
    }*/
}
