using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPointCollision : MonoBehaviour
{
    private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if(other.gameObject.CompareTag("CheckPoint"))
            {
                Debug.Log("TEST");
                UpdateCheckPoint();
            }
        }
    }

    public void UpdateCheckPoint()
    {
        Vector3 newPos = transform.position;
        gameController.SetCheckPointPosition(newPos);
    }
}
