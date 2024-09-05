using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRig;
    private Animator playerAnim;
    [SerializeField] private float inpulseForce;
    [SerializeField] private float speedRotation;
    private bool isMoving;
    private bool isThrusting;
    private bool isPlaying;

    public bool IsMoving
    {
        get { return isMoving; }
    }

    public bool IsThrusting
    {
        get { return isThrusting; }
        set { isThrusting = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRig = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        FreezeRotations();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotate();
        PlayerInpulse();
    }

    private void PlayerRotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GetPlayerRotation(speedRotation);
            ChangePlayerSide(1);
            isMoving = true;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            GetPlayerRotation(-speedRotation);
            ChangePlayerSide(-1);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void GetPlayerRotation(float _rotate)
    {
        playerRig.freezeRotation = true;
        transform.Rotate(Vector3.right * _rotate * Time.deltaTime);
        playerRig.freezeRotation = false;

    }

    private void FreezeRotations()
    {
        playerRig.constraints = RigidbodyConstraints.FreezePositionZ |
                                RigidbodyConstraints.FreezeRotationY |
                                RigidbodyConstraints.FreezeRotationZ;
    }

    private void ChangePlayerSide(float _z)
    {
        transform.localScale = new Vector3(1f, 1f, _z);
    }

    private void PlayerInpulse()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isThrusting = true;
            playerRig.AddRelativeForce(Vector3.up * inpulseForce * Time.deltaTime);

            if (isThrusting && !isPlaying)
            {
                SoundController.instance.ThrustSounds();
                isPlaying = true;
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            
            isThrusting = false;

            if (!isThrusting && isPlaying)
            {
                SoundController.instance.ThrustSoundsStop();
                isPlaying = false;
            }
        }

    }
}
