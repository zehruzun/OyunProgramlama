using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airPortControl : MonoBehaviour
{
    //plane enter controller kodunu iptal eder,
    //player child olursa uçak hareketi baþlar, 
    //tekrar airport giriþi olursa hýz tekrar 0 olur.
    // Start is called before the first frame update
    public GameObject plane;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "airPort")
        {
            plane.GetComponent<PlaneController>().enabled = false;
            Debug.Log("plane move scriptini kapat");
            plane.transform.position = new Vector3(-115f, 5f, -45f);
            plane.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
