using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            StackManager.instance.collectedList.Remove(gameObject);
            other.GetComponent<ObstacleManager>().StackCollectable();
            Destroy(gameObject, 0f);
        }
    }
}