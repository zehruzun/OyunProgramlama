using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockArea : MonoBehaviour
{
    public UnlockData unlockableData;
    public TextMeshPro NameText;
    public TextMeshPro PriceText;
    public List<GameObject> ObjectsToUnlock = new List<GameObject>();
    

    private void OnEnable()
    {
        CheckUnlocked();
    }

    void Start()
    { 
        ObjectsToUnlock.ForEach((x) => x.SetActive(false));
        //ObjectToUnlock.SetActive(false);
        NameText.text = "UNLOCK " + unlockableData.unlockableName.ToUpper();
        PriceText.text = unlockableData.RemainingPrice.ToString();  
    }

    public void Pay(Stashable stashable)
    {
        if (unlockableData.RemainingPrice <= 0)
            return;

        unlockableData.CollectedPrice++;
        stashable.PayStashable(transform, PaymentCompleted);
         
    }

    private void PaymentCompleted()
    {
        //�deme yap�ld�k�a price de�i�
        PriceText.text = unlockableData.RemainingPrice.ToString();
        //checkUnlocked �al��t�r. 
        CheckUnlocked();
    }

    private void CheckUnlocked()
    {
        //unlockableData'n�n fiyat� 0'dan k���kse
        if (unlockableData.RemainingPrice <= 0)
        {
            //objectsToUnlock i�erisinde gezin
            ObjectsToUnlock.ForEach((x) =>
            {
                //transform.parent de�erini bo� yap
                x.transform.parent = null;
                //x'i g�r�n�r yap
                x.SetActive(true);
            });
            //gameobject'i false yap
            gameObject.SetActive(false);
        }
    }
}
