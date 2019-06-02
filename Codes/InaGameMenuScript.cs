using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InaGameMenuScript : MonoBehaviour
{
    //for Text winning or loosing 
    [SerializeField]
    GameObject WinOrLoseText, GOnextbutton, GOretrybutton, GOquitbutton;

    //For Pausing
    [SerializeField]
    GameObject resumeButton, quitButton, restartButton, PauseESystem;

    [SerializeField]
    GameObject InGame, PauseMenu, GameOverMenu, InstructionsA;

    GameObject[] players;

    bool paused, gameOver;
    int finScore;
    bool WinOrLose;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        gameOver = false;
        WinOrLose = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            InGame.SetActive(false);
            GameOverMenu.SetActive(true);
            GameOver();
        }
        else if (paused)
        {
            GameIsPaused();
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            PauseMenu.gameObject.SetActive(true);
            InGame.gameObject.SetActive(false);

            paused = true;

            players = GameObject.FindGameObjectsWithTag("Player");
            
            foreach(GameObject g in players)
            {
                g.gameObject.SetActive(false);
            }
        }


    }

    void GameIsPaused()
    {
        if (Input.GetAxis("AlljoyH") > 0.1f)
        {
            PauseESystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(quitButton);
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                BackToMainMenu();
            }
        }
        else if(Input.GetAxis("AlljoyH") < -0.1f)
        {
            PauseESystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(restartButton);
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                RetryGame();
            }
        }
        else
        {
            PauseESystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(resumeButton);
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                ResumeGame();
            }
        }
    }

    void GameOver() //created a new GameOverMenu, placed gameobject on InGameMenuScriptHolder. Please put Final Score and make button be selected with GamePad
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in players)
        {
            g.gameObject.SetActive(false);
        }

        if (WinOrLose)
        {
            WinOrLoseText.GetComponent<TextMeshProUGUI>().text = "YOU WON!";
        }
        else
        {
            WinOrLoseText.GetComponent<TextMeshProUGUI>().text = "YOU LOSE!";
        }


        if (Input.GetAxis("AlljoyH") > 0.1f)
        {
            PauseESystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(quitButton);
        }
        else if (Input.GetAxis("AlljoyH") < -0.1f)
        {
            PauseESystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(restartButton);
        }
        else
        {
            PauseESystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(resumeButton); //be replaced with the nextLevelButton
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MenuDotMain");
    }

    public void ResumeGame()
    {
        foreach (GameObject g in players)
        {
            g.gameObject.SetActive(true);
        }

        PauseMenu.SetActive(false);
        paused = false;
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void FinalScore(bool winLoose)
    {
        WinOrLose = winLoose;
        gameOver = true;
    }

    public void NextLevel(Button btn)
    {
        if(btn.name == "NextLevelButton")
        {
            string activeScene = SceneManager.GetActiveScene().name;
            switch (activeScene)
            {
                case "OneDotOne":
                    SceneManager.LoadScene("OneDotTwo");
                    break;
                case "OneDotTwo":
                    SceneManager.LoadScene("OneDotThree");
                    break;
            }
        }
        
        
    }
}
