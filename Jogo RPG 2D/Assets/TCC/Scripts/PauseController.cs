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
    public GameObject botoes;
    private bool botoesPausados = false;

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
        
        if (configButton.activeSelf) {
            botoes.SetActive(false);
            botoesPausados = true;
        }
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        
        Player.Instance.PlayerReturnInteraction();
        Time.timeScale = 1;
        isPaused = false;
        configButton.SetActive(true);
        if (botoesPausados) {
            botoes.SetActive(true);
            botoesPausados = false;
        }
        
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
