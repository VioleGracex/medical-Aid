using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneNumber : MonoBehaviour
{
    [SerializeField]
    GameObject loadingScreen;
    [SerializeField]
    Slider loadingSlider;
    void Awake()
    {
        
    }
    public void PlayGame(int sceneIndex)
	{
        /* SceneManager.LoadScene(chosenlvl);
        AsyncOperation operation = SceneManager.LoadSceneAsync(chosenlvl);
        operation.progress */
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchornusly(sceneIndex));
	}

    IEnumerator LoadAsynchornusly(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!operation.isDone)
        {   yield return new WaitForSeconds(0.2f);
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            loadingSlider.value=progress*10;
            //Debug.Log(progress);
            yield return null;
        }
    }
    public void QuitGame()
	{
		Application.Quit ();
	}
}
