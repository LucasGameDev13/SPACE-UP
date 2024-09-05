using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] private Vector3 playerPosition;
    [SerializeField] private Vector3 playerFirstPosition;
    [SerializeField] private Quaternion playerRotation;

    [SerializeField] private int gameRounds;
    private int gameRoundsTotal;
    [SerializeField] private TextMeshProUGUI gameRoundsText;

    [SerializeField] private float gameTimer;
    [SerializeField] private float finalTimer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI finalTimeScore;

    [SerializeField] private GameObject[] GameOvers;

    [SerializeField] private bool isGamePlaying = true;

    public bool IsGamePlaying
    {
        get { return isGamePlaying; }
        set { isGamePlaying = value; }
    }

    public int GameRounds
    {
        get { return gameRounds; }
        set { gameRounds = value; }
    }

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerPosition = playerController.transform.position;
        playerRotation = playerController.transform.rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerFirstPosition = playerPosition;
        gameRoundsTotal = gameRounds;
        finalTimer = gameTimer;
        SetRoundsText();
    }

    private void Update()
    {
        SetTimer();
        SetRoundsText();
    }

    public Vector3 GetPlayerPosition()
    {
        return playerPosition;  
    }

    public Quaternion GetPlayerRotation()
    {
        return playerRotation;
    }

    public Vector3 SetCheckPointPosition(Vector3 _position)
    {
        playerPosition = _position;
        return playerPosition;
    }

    private void SetTimer()
    {
        if(IsGamePlaying)
        {
            gameTimer += Time.deltaTime;
        }

        int minutes = Mathf.FloorToInt(gameTimer / 60);
        int seconds = Mathf.FloorToInt(gameTimer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        finalTimer = gameTimer;
        finalTimeScore.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetRoundsText()
    {
        gameRoundsText.text = gameRounds.ToString();
    }


    public void GameOverSelection(int _i, bool _value)
    {
        GameOvers[_i].SetActive(_value);
    }

    

    public void GameReset()
    {
        SoundController.instance.ButtonsSounds();
        StartCoroutine("CallResetGame");
    }

    IEnumerator CallResetGame()
    {
        yield return new WaitForSeconds(1f);
        playerPosition = playerFirstPosition;
        gameRounds = gameRoundsTotal;
        isGamePlaying = true;
        gameTimer = 0;
        GameReload();
    }

    public void GameReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu(string _scene)
    {
        SoundController.instance.ButtonsSounds();
        StartCoroutine(LoadMainMenuAction(_scene));
    }

    IEnumerator LoadMainMenuAction(string _scene)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(_scene);
    }
}
