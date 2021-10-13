using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    // Start is called before the first frame update

    public Killplayer kp;

    public AutoSpawmObject change;

    public GameObject dontDestroy;

    public int setLives = 3;
   
    public static bool isEasy = true;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public bool curreEasy
    {
        get
        {
            return isEasy;
        }
        set
        {
            isEasy = value;
        }
    }

    public void quit()
    {
        Application.Quit();
    }

    public void retry()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        dontDestroy.SetActive(false);
        Destroy(dontDestroy);
        kp = new Killplayer(setLives);
    }
  
    public void changeMode()
    {
        if (curreEasy)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
            curreEasy = false;
            dontDestroy.SetActive(false);
            Destroy(dontDestroy);
            kp = new Killplayer(setLives);
        }
        else
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
            curreEasy = true;
            dontDestroy.SetActive(false);
            Destroy(dontDestroy);
            kp = new Killplayer(setLives);
        }
        
        
    }

}
