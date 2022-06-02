using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance { get; private set; }
    [SerializeField] GameObject pauseMenu;
    
    [SerializeField]
    TextMeshProUGUI timer;
    float time;
    float seconds = 0;
    float minutes = 0;
  
    string output_timer;
    public class TwoStringArray
    {
        public string speaker;
        public string textContext;

        public TwoStringArray(string s , string t)
        {
            this.speaker = s;
            this.textContext = t;
        }

    }

    List <TwoStringArray> chatLog = new List<TwoStringArray>();

   
     void Start()
    {
        instance= this;
    }

    // Update is called once per frame
    void Update()
    {
       
        time+=Time.deltaTime;
        seconds = Mathf.FloorToInt(time%60);
        minutes = Mathf.FloorToInt(time/60);
        output_timer = string.Format("{00:00}:{1:00}" ,minutes , seconds);
        timer.text = output_timer;
       /*  if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeMenu();
        } */
    }

    public void EscapeMenu()
    {
       
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        
    }

    /* public void OpenOptionsMenu()
    {
        GameObject.FindGameObjectWithTag("OptionsMenu").GetComponent<EnableAChild>().EnableMyChild();
    }
     public void OpenSaveMenu()
    {
        GameObject.FindGameObjectWithTag("SaveLoadMenu").GetComponent<SaveLoad_Functions>().EnableSaveMenu();
    }
    public void OpenLoadMenu()
    {
        GameObject.FindGameObjectWithTag("SaveLoadMenu").GetComponent<SaveLoad_Functions>().EnableLoadMenu();
    } */ 


    public void BackToMainMenu()
    {
        SceneManager.LoadScene (0);
        Time.timeScale = 1f;
    }
}
