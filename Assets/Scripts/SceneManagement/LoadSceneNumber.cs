using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneNumber : MonoBehaviour
{
    void Awake()
    {
        
    }
    public void PlayGame(int chosenlvl)
	{
        SceneManager.LoadScene(chosenlvl);
	}

    public void QuitGame()
	{
		Application.Quit ();
	}
}
