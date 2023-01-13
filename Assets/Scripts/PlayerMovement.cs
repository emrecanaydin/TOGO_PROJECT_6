using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    private bool _isGameStarted;
    public float moveSpeed;

    public GameObject winPanel;
    public GameObject lostPanel;
    public TextMeshProUGUI scoreText;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _isGameStarted = true;
        }
        if (_isGameStarted)
        {
            transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        float collectedCount = StackManager.instance.collectedList.Count - 1;

        if (other.tag == "FinishLine")
        {
            if (collectedCount <= 0)
            {
                HandleFailStatus();
            }
            else
            {
                StartCoroutine(HandleFinishLine(collectedCount));
            }
        }
        if(other.tag == "Obstacle")
        {
            if(collectedCount <= 0)
            {
                HandleFailStatus();
            }
        }
    }


    private void HandleFailStatus()
    {
        lostPanel.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator HandleFinishLine(float count)
    {
        float waitingTime = count * 1f;

        yield return new WaitForSeconds(waitingTime);

        for (int i = 1; i < StackManager.instance.collectedList.Count; i++)
        {
            GameObject currentObject = StackManager.instance.collectedList[i];
            Destroy(currentObject.gameObject, 0f);
        }

        StackManager.instance.collectedList.RemoveRange(1, StackManager.instance.collectedList.Count - 1);

        scoreText.text = $"You've collected {count} star(s). \n Waited {waitingTime} seconds for this screen.";
        winPanel.SetActive(true);
        Time.timeScale = 0;

    }

}
