using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockAreaMe : MonoBehaviour
{
    public TextMeshPro NameText;
    public TextMeshPro PriceText;
    [SerializeField] float price = 0.0f;
    [SerializeField] string name = "";
    public List<GameObject> ObjectsToUnlock = new List<GameObject>();
    void Start()
    {
        ObjectsToUnlock.ForEach((x) => x.SetActive(false));
        NameText.text = name;
        PriceText.text = price.ToString();
    }

    private void OnEnable()
    {
        CheckUnlocked();
    }

    public void Pay(Stashable stashable)
    {
        if (price <= 0)
            return;

        stashable.PayStashable(transform, PaymentCompleted);
    }

    private void PaymentCompleted()
    {
        PriceText.text = price.ToString();
        CheckUnlocked();
    }

    private void CheckUnlocked()
    {
        if (price <= 0)
        {
            ObjectsToUnlock.ForEach((x) =>
            {
                x.transform.parent = null;
                x.SetActive(true);
            });
            gameObject.SetActive(false);
        }
    }
}
