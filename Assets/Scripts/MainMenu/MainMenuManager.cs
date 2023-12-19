using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public float delay;
    private void Start()
    {
        delay = 0.4f;
    }
    public void ChangeScene()
    {
        StartCoroutine(LoadSceneWithDelay());
    }


    public IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }
}
