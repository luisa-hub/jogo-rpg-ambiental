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
    public Vector3 posicao1;
    // Start is called before the first frame update

    public void Start()
    {
        InvokeRepeating("anima1", 0.005f, 0.005f);
        posicao1 = estrela1.transform.position;



        InvokeRepeating("anima2", 0.003f, 0.003f);


        InvokeRepeating("anima3", 0.004f, 0.004f);

    }


    public void Update()
    {
        if (estrela1.transform.position.x > 500) {
            Vector3 novaPosicao = posicao1;
            estrela1.transform.position = novaPosicao;
            Debug.Log(estrela1.transform.position);
        
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

        Vector3 novaPosicao = new Vector3(estrela.transform.position.x+x, estrela.transform.position.y + y, estrela.transform.position.z);
        estrela.transform.position = novaPosicao;
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
