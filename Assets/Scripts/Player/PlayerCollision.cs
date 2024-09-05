using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameController gameController;
    private PlayerAnim playerAnim;

    private bool hasTrigged;
    [SerializeField] private float timeDelay;
    private bool isCrashed;
    private bool isSuccess;


    public bool IsCrashed
    {
        get { return isCrashed; }
        set { isCrashed = value; }
    }

    public bool IsSuccess
    {
        get { return isSuccess; }
        set { isSuccess = value; }
    }

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<PlayerAnim>();
        transform.position = gameController.GetPlayerPosition();
        gameController.GameOverSelection(0, false);
        gameController.GameOverSelection(1, false);
        gameController.GameOverSelection(2, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && !hasTrigged)
        {
            switch (collision.gameObject.tag)
            {
                case "Begin":

                    break;

                case "CheckPoint":

                    break;

                case "Destiny":
                    AchievedDestiny();
                    break ;

                default:
                    CrashCollision();
                    break;
            }
        }
    }



    private void AchievedDestiny()
    {
        hasTrigged = true;
        isSuccess = true;
        SoundController.instance.SuccessSound();
        GetComponent<PlayerController>().enabled = false;
        gameController.IsGamePlaying = false;
        Invoke("DelayGameOverSuccess", timeDelay);
    }

    private void CrashCollision()
    {
        if (gameController.GameRounds > 0)
        {
            hasTrigged = true;
            isCrashed = true;
            gameController.GameRounds--;
            SoundController.instance.CrashSound();
            SoundController.instance.ThrustSoundsStop();
            GetComponent<PlayerController>().enabled = false;
            Invoke("GameReloadStatus", timeDelay+1);
        }
        else
        {
            hasTrigged = true;
            isCrashed = true;
            SoundController.instance.CrashSound();
            SoundController.instance.ThrustSoundsStop();
            GetComponent<PlayerController>().enabled = false;
            gameController.IsGamePlaying = false;
            Invoke("DelayGameOverCrashed", timeDelay);
        } 
    }

    private void DelayGameOverSuccess()
    {
        gameController.GameOverSelection(0, true);
        gameController.GameOverSelection(1, false);
        gameController.GameOverSelection(2, false);
    }

    private void GameReloadStatus()
    {
        transform.position = gameController.GetPlayerPosition();
        transform.rotation = gameController.GetPlayerRotation();
        hasTrigged = false;
        isCrashed = false;
        isSuccess = false;
        playerAnim.AnimationControl = false;
        GetComponent<PlayerController>().enabled = true;
    }

    private void DelayGameOverCrashed()
    {
        gameController.GameOverSelection(0, false);
        gameController.GameOverSelection(1, true);
        gameController.GameOverSelection(2, false);
    }

    
}
