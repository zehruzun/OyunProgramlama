using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotationIMG : MonoBehaviour
{
    [SerializeField] public RawImage unlockIMG;

    private void Update()
    {
        InvokeRepeating("unlockRotate", 0, 1);
    }

    public void unlockRotate()
    {
        unlockIMG.rectTransform.eulerAngles += new Vector3(0, 10 * Time.deltaTime, 0);
    }
}
