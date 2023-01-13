using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackManager : MonoBehaviour
{

    public static StackManager instance;
    public List<GameObject> collectedList = new List<GameObject>();

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if(collectedList.Count > 1)
        {
            UpdateCollectedPositions();
        }
    }

    public void StackCollectable(GameObject other)
    {
        other.transform.parent = transform;
        collectedList.Add(other);
    }

    void UpdateCollectedPositions()
    {
        for (int i = 1; i < collectedList.Count; i++)
        {
            int index = i;
            GameObject currentGameObject = collectedList[index];
            Vector3 position = new Vector3(collectedList[index - 1].transform.localPosition.x, 0.407f, collectedList[0].transform.position.z + index * 2f);
            currentGameObject.transform.DOMove(position, .5f);
        }
    }

}