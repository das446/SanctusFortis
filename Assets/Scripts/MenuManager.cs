using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Button m_play, m_quit;

    void Start()
    {
        Button playButton = m_play.GetComponent<Button>();
        Button exitButton = m_quit.GetComponent<Button>();

        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        playButton.onClick.AddListener(PlayGameButton);
        exitButton.onClick.AddListener(QuitGame);
    }


    public void QuitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    public void PlayGameButton()
    {
        //Placeholder name for next scene - Supposed to load up the controls menu
        //SceneManager.LoadScene("Controls Menu"); 
        //Assuming it wont be in the same scene
        SceneManager.LoadScene(1); ;
    }

}
