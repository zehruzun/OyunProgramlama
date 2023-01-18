using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using Vector3 = UnityEngine.Vector3;

public class changePlayer : MonoBehaviour
{
    public bool isControl = true;
    public GameObject playerMan;
    public GameObject newPlayer;
    [SerializeField] float newVectorX;
    [SerializeField] float newVectorZ;
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Debug.Log(isControl);
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("here");
                if (isControl)
                {
                    playerManActive();
                }

                else
                {
                    playerManPassive();
                }
            }            
        }
    }


    void playerManActive()
    {
        playerMan.SetActive(true);
        playerMan.GetComponent<Stash>().enabled = false;
        playerMan.GetComponent<Movement>().enabled = false;
        playerMan.GetComponent<Collector>().enabled = false;
        playerMan.GetComponent<Payer>().enabled = false;

        MonoBehaviour[] scripts = newPlayer.GetComponents<MonoBehaviour>();
        for (int j = 0; j < scripts.Length; j++)
        {
            scripts[j].enabled = true;
        }


        foreach (Transform child in playerMan.transform)
        {
            child.gameObject.SetActive(false);
        }
        playerMan.transform.SetParent(newPlayer.transform);
        playerMan.transform.localPosition = new Vector3(0, 0,0);

        isControl = !isControl;
    }

    void playerManPassive()
    {
        playerMan.transform.localPosition = new Vector3(newVectorX, 0, newVectorZ);

        playerMan.GetComponent<Stash>().enabled = true;
        playerMan.GetComponent<Movement>().enabled = true;
        playerMan.GetComponent<Collector>().enabled = true;
        playerMan.GetComponent<Payer>().enabled = true;

        MonoBehaviour[] scripts = newPlayer.GetComponents<MonoBehaviour>();
        for (int j = 0; j < scripts.Length; j++)
        {
            scripts[j].enabled = false;
        }

        foreach (Transform child in playerMan.transform)
        {
            child.gameObject.SetActive(true);
        }
        playerMan.transform.SetParent(null);
        isControl = !isControl;


    }
}
