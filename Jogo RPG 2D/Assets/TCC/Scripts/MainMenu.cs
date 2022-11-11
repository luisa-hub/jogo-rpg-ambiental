using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject janelaCreditos;
    public GameObject janelaConfig;
    public GameObject botoes;
    // Start is called before the first frame update
    public void PlayGame (){
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }

    public void creditos()
    {

        janelaCreditos.SetActive(true);
        botoes.SetActive(false);
    }

    public void fechaCreditos()
    {
        janelaCreditos.SetActive(false);
        botoes.SetActive(true);
    }

    public void config()
    {

        janelaConfig.SetActive(true);
        botoes.SetActive(false);
    }

    public void fechaConfig()
    {
        janelaConfig.SetActive(false);
        botoes.SetActive(true);
    }

    public void sair()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
