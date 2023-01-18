using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takePlayer : MonoBehaviour
{
    private GameObject obje;
    public GameObject players;
    changePlayer script;
    public GameObject myPlayer;

    private void Update()
    {
        /*float number_of_rays = 500;
        float totalAngle = 360;

        float delta = totalAngle / number_of_rays;
        Vector3 pos = transform.position;
        const float magnitude = 8;

        for (int i = 0; i < number_of_rays; i++)
        {
            var dir = Quaternion.Euler(0, i * delta, 0) * transform.right;
            RaycastHit hit;
            if (Physics.Raycast(pos, dir, out hit, magnitude))
            {
                if (hit.collider.tag == "Player")
                {
                    script = players.GetComponent<changePlayer>();
                    script.enabled = true;
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        Debug.Log(transform.gameObject.tag);
                        script.playerAnother(transform.gameObject.tag);
                    }
                }

                else
                {
                    script = players.GetComponent<changePlayer>();
                    script.enabled = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                script.playerManActive();
            }
            Debug.DrawRay(pos, dir * magnitude, Color.green);
        }*/


    }
}

