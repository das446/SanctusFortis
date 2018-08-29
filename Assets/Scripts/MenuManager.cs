using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Button m_YourFirstButton, m_YourSecondButton;

    void Start()
    {
        Button btn1 = m_YourFirstButton.GetComponent<Button>();
        Button btn2 = m_YourSecondButton.GetComponent<Button>();

        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        btn1.onClick.AddListener(PlayGameButton);
        btn2.onClick.AddListener(QuitGame);
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
