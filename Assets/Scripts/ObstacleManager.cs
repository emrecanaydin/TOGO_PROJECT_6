using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleManager : MonoBehaviour
{

    public float collectedCount = 0;
    public TextMeshProUGUI collectedCountText;

    public void StackCollectable()
    {
        collectedCount = collectedCount + 1;
        collectedCountText.text = collectedCount.ToString();
    }

}
