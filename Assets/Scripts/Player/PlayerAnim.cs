using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    [SerializeField] private ParticleSystem thrustEffect;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private ParticleSystem sucessEffect;

    private PlayerController playerController;
    private PlayerCollision playerCollision;
    private bool animationControl;

    public bool AnimationControl
    {
        get { return animationControl; } 
        set { animationControl = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerCollision = playerController.GetComponent<PlayerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAnimation();
        ThrustEffect();
        SuccessEffect();
        CrashEffect();
    }

    private void PlayerAnimation()
    {
        playerAnim.SetBool("isMoving", playerController.IsMoving);
    }

    private void ThrustEffect()
    {
        if(playerController.IsThrusting)
        {
            thrustEffect.Play();
        }
        else if(!playerController.IsThrusting)
        {
            thrustEffect.Stop();
        }
    }

    private void SuccessEffect()
    {
        if (playerCollision.IsSuccess && !animationControl)
        {
            sucessEffect.Play();
            sucessEffect.Play();
            animationControl = true;
        }
    }

    private void CrashEffect()
    {
        if (playerCollision.IsCrashed && !animationControl)
        {
            crashEffect.Play();
            crashEffect.Play();
            animationControl = true;
        }
    }
}
