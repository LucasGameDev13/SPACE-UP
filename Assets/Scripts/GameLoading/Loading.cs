using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CallingCoroutine", 2f);
    }

    private void CallingCoroutine()
    {
        StartCoroutine("LoadingGamePlay");
    }

    IEnumerator LoadingGamePlay()
    {
        AsyncOperation asynLoad = SceneManager.LoadSceneAsync("GamePlay");

        while(!asynLoad.isDone)
        {
            yield return null;
        }
    }
}
