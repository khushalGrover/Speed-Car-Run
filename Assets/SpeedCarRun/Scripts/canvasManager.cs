using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class canvasManager : MonoBehaviour
{
    public static canvasManager instance;



    // [Header("_______Joysticks________")]
    // [Tooltip("Joysticks")]
    // public Joystick leftJoystick;
    // public Joystick rightJoystick;

    [Header("______Canvas_____")]
    [Tooltip("Canvas")]    
    public GameObject pauseCanvas;
    public GameObject optionCanvas;
    public GameObject scoreCanvas;
    public GameObject MoibleInputCanvas;
    public GameObject gameOverCanvas;
    public GameObject exitConfirmCanvas;
    bool isPause = false;

    
    

    private void Start() 
    {
        // if(SceneManager.GetActiveScene().buildIndex == 1)
        // {
        //     DeActivateAllCanvas();
        // }
        
        Time.timeScale = 1;
    }

    void DeActivateAllCanvas()
    {
        pauseCanvas.SetActive(false);
        scoreCanvas.SetActive(false);
        MoibleInputCanvas.SetActive(false);

    }

    public void loadMenu()
    {       
        SceneManager.LoadScene(0);
    }
    public void loadFirstScene()
    {       
        SceneManager.LoadScene(1);
        Debug.Log("trying to load");
    }
    public void loadSecondScene()
    {       
        SceneManager.LoadScene(2);
    }
    public void loadThirdScene()
    {       
        SceneManager.LoadScene(3);
        Debug.Log("trying to load");
    }
    public void APPQUIT()
    {
        Application.Quit();
    }

    public void pauseGame()
    {
        // activate AND deactive screen 
        pauseCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
        MoibleInputCanvas.SetActive(false);      
        // pause/slow game
        Time.timeScale = 0.05f;

    }

    public void gameOver()
    {
        Movement.isAlive = false;
        
        pauseCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
        MoibleInputCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0.8f;

    }

    public void resumeGame()
    {
        // Depactivate AND active Screen
        pauseCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
        MoibleInputCanvas.SetActive(true);
        // resume game
        Time.timeScale = 1;

    }

    public void option()
    {
        DeActivateAllCanvas();
        optionCanvas.SetActive(true);
        Debug.Log("Option button press");
    }

    public void Restart()
    {
        // reload current screen and deacivate all canvas...
        Movement.isAlive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    
}
