using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject janelaCreditos;
    public GameObject janelaConfig;
    public GameObject botoes;
    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;
    public Vector2 posicao1;
    public Vector2 posicao2;
    public Vector3 posicao3;
    // Start is called before the first frame update

    public void Start()
    {
        InvokeRepeating("anima1", 0.03f, 0.03f);
        posicao1 = estrela1.GetComponent<RectTransform>().anchoredPosition;


        InvokeRepeating("anima2", 0.015f, 0.015f);
        posicao2 = estrela2.GetComponent<RectTransform>().anchoredPosition;


        InvokeRepeating("anima3", 0.02f, 0.02f);
        posicao3 = estrela3.GetComponent<RectTransform>().anchoredPosition;

    }


    public void Update()
    {
        if (estrela1.GetComponent<RectTransform>().anchoredPosition.y < 0) {
            Vector2 novaPosicao = posicao1;
            estrela1.GetComponent<RectTransform>().anchoredPosition = novaPosicao;
        }

        if (estrela2.GetComponent<RectTransform>().anchoredPosition.y < 0)
        {
            Vector2 novaPosicao = posicao2;
            estrela2.GetComponent<RectTransform>().anchoredPosition = novaPosicao;
        }

        if (estrela3.GetComponent<RectTransform>().anchoredPosition.y < 0)
        {
            Vector2 novaPosicao = posicao3;
            estrela3.GetComponent<RectTransform>().anchoredPosition = novaPosicao;
        }
    }

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

    public void animaEstrela(int x, int y, GameObject estrela) {

        Vector2 novaPosicao = new Vector3(estrela.GetComponent<RectTransform>().anchoredPosition.x + x, estrela.GetComponent<RectTransform>().anchoredPosition.y + y);
        //Vector3 novaPosicao = new Vector3(estrela.transform.position.x+x, estrela.transform.position.y + y, estrela.transform.position.z);

        estrela.GetComponent<RectTransform>().anchoredPosition = novaPosicao;
        //estrela.transform.position = novaPosicao;
    }

    public void anima1() {
        animaEstrela(1, -1, estrela1);
    }

    public void anima2()
    {
        animaEstrela(1, -1, estrela2);
    }

    public void anima3()
    {
        animaEstrela(1, -1, estrela3);
    }
}
