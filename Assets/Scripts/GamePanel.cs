using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GamePanel : MonoBehaviour, IDragHandler
{
    public Transform player;

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = player.position;
        position.x = Mathf.Clamp(position.x + (eventData.delta.x / 100), -2.05f, 2.05f);
        player.position = position;
    }
}
