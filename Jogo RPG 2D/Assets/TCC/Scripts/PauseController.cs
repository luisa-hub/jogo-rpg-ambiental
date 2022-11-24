using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.TCC.Scripts;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject configButton;
    public GameObject creditWindow;
    GameObject pauseMenu;
    public bool isPaused = false;

    private void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu").transform.GetChild(0).gameObject;
    }


    public void Pause()
    {
        pauseMenu.SetActive(true);
        configButton.SetActive(false);
        Player.Instance.PlayerPauseInteraction(isMenu: true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        configButton.SetActive(true);
        Player.Instance.PlayerReturnInteraction();
        Time.timeScale = 1;
        isPaused = false;
    }

    public void esc() {
        if (!isPaused)
            Pause();
        
        else
            UnPause();
    }


    public void creditos() {

        creditWindow.SetActive(true);
    }

    public void fechaCreditos() {
        creditWindow.SetActive(false);
    }

    public void menu() {
        UnPause();
        SceneManager.LoadScene(0);



    }

    public void sair() {

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
