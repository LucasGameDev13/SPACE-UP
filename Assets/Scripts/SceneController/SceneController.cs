using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    [SerializeField] private bool isSelected;
    [SerializeField] private GameObject gameCommandsObj;
    [SerializeField] private GameObject[] gameCommandsLanguages;

    private void Start()
    {
        gameCommandsLanguages[0].SetActive(true);
        gameCommandsLanguages[1].SetActive(false);
    }

    private void Update()
    {
        gameCommandsObj.SetActive(isSelected);
    }


    public void SelectButton()
    {
        isSelected = !isSelected;
    }

    public void SelectPortugueseLanguage()
    {
        gameCommandsLanguages[0].SetActive(true);
        gameCommandsLanguages[1].SetActive(false);
    }

    public void SelectEnglishLanguage()
    {
        gameCommandsLanguages[0].SetActive(false);
        gameCommandsLanguages[1].SetActive(true);
    }

    public void GamePlay(string _scene)
    {
        SoundController.instance.ButtonsSounds();
        StartCoroutine(GamePlayAction(_scene));
    }

    public void ExitGame()
    {
        SoundController.instance.ButtonsSounds();
        Invoke("QuitAction", 1f);
    }

    private void QuitAction()
    {
        Application.Quit();
    }

    IEnumerator GamePlayAction(string _scene)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(_scene);
    }
}
