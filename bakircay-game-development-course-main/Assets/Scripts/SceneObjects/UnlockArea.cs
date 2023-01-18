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
        //ödeme yapýldýkça price deðiþ
        PriceText.text = unlockableData.RemainingPrice.ToString();
        //checkUnlocked çalýþtýr. 
        CheckUnlocked();
    }

    private void CheckUnlocked()
    {
        //unlockableData'nýn fiyatý 0'dan küçükse
        if (unlockableData.RemainingPrice <= 0)
        {
            //objectsToUnlock içerisinde gezin
            ObjectsToUnlock.ForEach((x) =>
            {
                //transform.parent deðerini boþ yap
                x.transform.parent = null;
                //x'i görünür yap
                x.SetActive(true);
            });
            //gameobject'i false yap
            gameObject.SetActive(false);
        }
    }
}
