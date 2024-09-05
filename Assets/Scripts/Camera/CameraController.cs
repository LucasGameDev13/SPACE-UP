using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController playerController;
    private float posY;
    private float smoothSpeed = 0.125f;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        posY = transform.position.y - playerController.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = new Vector3(playerController.transform.position.x,
                                         playerController.transform.position.y + posY, 
                                         transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
