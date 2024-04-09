/* 
* This script manages the canvas UI elements in the game.
* It handles functionalities such as pausing the game, displaying game over screen, and loading different scenes.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvasManager : MonoBehaviour
{
    public static canvasManager instance;

    [Header("______Canvas_____")]
    [Tooltip("Canvas")]
    public GameObject pauseCanvas; // The canvas for pausing the game
    public GameObject optionCanvas; // The canvas for displaying options
    public GameObject scoreCanvas; // The canvas for displaying the score
    public GameObject MoibleInputCanvas; // The canvas for mobile input
    public GameObject gameOverCanvas; // The canvas for displaying game over screen
    public GameObject exitConfirmCanvas; // The canvas for confirming exit
    bool isPause = false;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void DeActivateAllCanvas()
    {
        pauseCanvas.SetActive(false);
        scoreCanvas.SetActive(false);
        MoibleInputCanvas.SetActive(false);
    }

    /// <summary>
    /// Loads the main menu scene.
    /// </summary>
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Loads the first scene.
    /// </summary>
    public void loadFirstScene()
    {
        SceneManager.LoadScene(1);
        Debug.Log("trying to load");
    }

    /// <summary>
    /// Loads the second scene.
    /// </summary>
    public void loadSecondScene()
    {
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// Loads the third scene.
    /// </summary>
    public void loadThirdScene()
    {
        SceneManager.LoadScene(3);
        Debug.Log("trying to load");
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void APPQUIT()
    {
        Application.Quit();
    }

    /// <summary>
    /// Pauses the game.
    /// </summary>
    public void pauseGame()
    {
        // activate AND deactive screen 
        pauseCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
        MoibleInputCanvas.SetActive(false);
        // pause/slow game
        Time.timeScale = 0.05f;
    }

    /// <summary>
    /// Displays the game over screen.
    /// </summary>
    public void gameOver()
    {
        Movement.isAlive = false;

        pauseCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
        MoibleInputCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0.8f;
    }

    /// <summary>
    /// Resumes the game.
    /// </summary>
    public void resumeGame()
    {
        // Depactivate AND active Screen
        pauseCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
        MoibleInputCanvas.SetActive(true);
        // resume game
        Time.timeScale = 1;
    }

    /// <summary>
    /// Displays the options screen.
    /// </summary>
    public void option()
    {
        DeActivateAllCanvas();
        optionCanvas.SetActive(true);
        Debug.Log("Option button press");
    }

    /// <summary>
    /// Restarts the current scene.
    /// </summary>
    public void Restart()
    {
        // reload current screen and deacivate all canvas...
        Movement.isAlive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
