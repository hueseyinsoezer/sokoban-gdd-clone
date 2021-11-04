using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelManager : MonoBehaviour
{
    public redCubeController _redCubeController;
    public greenCubeController _greenCubeController;
    public limitedMoveCube _limitedMoveCube;
    public bool GameIsPaused;
    public GameObject firstPanel, pausePanel, winPanel, losePanel, endGamePanel;
    public int lastScene, sceneNumber;
    private void Start()
    {
        lastScene = 0;
        GameIsPaused = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent < playerController >().enabled = true;
        _redCubeController = GameObject.FindGameObjectWithTag("redCube").GetComponent<redCubeController>();
        _greenCubeController = GameObject.FindGameObjectWithTag("greenCube").GetComponent<greenCubeController>();
        _limitedMoveCube = GameObject.Find("limited-steps-red-cube").GetComponent<limitedMoveCube>();
        lastScene = PlayerPrefs.GetInt("sceneNumber");

    }
    private void Update()
    {
        PlayerPrefs.SetInt("sceneNumber", SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (GameIsPaused == true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = true;
        }
   
        if (SceneManager.GetActiveScene().buildIndex == 1 && _redCubeController.RedIsInPosition() == true)
        {
            ChapterEnd();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2 && (_redCubeController.RedIsInPosition() == true && _greenCubeController.GreenIsInPosition() == true ))
        {
            ChapterEnd();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3 && (_redCubeController.RedIsInPosition() == true && _greenCubeController.GreenIsInPosition() == true && _limitedMoveCube.limitedIsInTarget == true))
        {
            EndGame();
        }
    }

    public void MainMenu()
    {
        GameIsPaused = true;
        SceneManager.LoadScene(0);
        firstPanel.SetActive(true);
    }
    public void NewGame()
    {
        GameIsPaused = false;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);      
    }

    public void ContinueFromLastSave()
    {
        GameIsPaused = false;
        SceneManager.LoadScene(lastScene);
        firstPanel.SetActive(false);
    }
    public void Pause()
    {
        GameIsPaused = true;
        pausePanel.SetActive(true);      
    }
    public void ContinueFromPause()
    {
        GameIsPaused = false;
        pausePanel.SetActive(false);
    }
    public void NextLevel()
    {
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Restart()
    {
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ChapterEnd()
    {       
        winPanel.SetActive(true);
        GameIsPaused = true;
    }
    public void LosePanel()
    {

        losePanel.SetActive(true);
        GameIsPaused = true;
    }

    public void EndGame()
    {
        endGamePanel.SetActive(true);
        GameIsPaused = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
