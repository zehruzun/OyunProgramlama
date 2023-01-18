using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stash : MonoBehaviour
{
    public Transform stashs;
    public Transform stashParent;
    public List<Stashable> CollectedObjects = new List<Stashable>();
    public int CollectedCount => CollectedObjects.Count;
    public float collectionHeight = 1;
    public int maxCollectableCount = 19;
    public int maxHeightCount = 5;
    public int maxWidth => maxCollectableCount / maxHeightCount;
    public int childIndex = 0;
    [SerializeField] public int lastChild = 0;
    // Start is called before the first frame update
    void Start()
    {
        stashParent = stashs.GetChild(0);
    }

    public void AddStash(Collectable collectedObject)
    {
        //Debug.Log(maxWidth);
        if (maxCollectableCount < CollectedCount)
        {

            return;
        }

        else
        {

            if(CollectedCount == 0)
            {
                childIndex = 0;
                stashParent = stashs.GetChild(childIndex);
            }
            //listeelemanýnýn collectedCount mod 5'i 0'a eþitse ve boþ deðilse
            else if((CollectedCount % 5 == 0) && CollectedCount != 0 && CollectedCount != maxCollectableCount && maxWidth > childIndex)
            {
                    //child arttýr

                childIndex++;

                
                
                stashParent = stashs.GetChild(childIndex);

                
                //stashParent'ý bir sonraki child deðerine eþitle
            }


            var yLocalPosition = (CollectedCount % 5) * collectionHeight;
            
            var stashable = collectedObject.Collect();
            stashable.CollectStashable(stashParent, yLocalPosition, CompleteCollection);
            CollectedObjects.Add(stashable);
           
        }

    }

    private void CompleteCollection()
    {

    }

    public Stashable RemoveStash()
    {
        if (CollectedCount <= 0)
            return null;

        var stashable = CollectedObjects[CollectedCount - 1];

        CollectedObjects.Remove(stashable);
        stashable.transform.parent = null;

        return stashable;

    }
}
