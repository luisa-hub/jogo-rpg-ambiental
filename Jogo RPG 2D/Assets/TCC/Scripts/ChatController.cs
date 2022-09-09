using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatController : MonoBehaviour
{
    private Text ObjetoTexto;
    private string[] textos;
    private int indexOfText = 0;
    public char stringSeparator = '#';

    // Awake é chamado antes do start
    void Awake()
    {
        ObjetoTexto = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            try
            {
                ObjetoTexto.text = textos[++indexOfText];
            }
            catch
            {
                // Retorna o movimento ao jogador
                GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(true);
                // Desabilita o Canvas de Chat
                gameObject.SetActive(false);

                GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(true);
            }
        }
    }

    public void SetVisible(bool status)
    {
        gameObject.SetActive(status);
    }

    public void ConfigureText( string text )
    {
        
        // Reseta o índice de texto (começa com 1, pois o index 0 é a flag da missão)
        indexOfText = 1;
        // Divide a string recebida
        textos = text.Split(stringSeparator);
        // Define o texto inicial
        ObjetoTexto.text = textos[indexOfText];
        GameObject.Find("Player").GetComponent<PlayerController>().updateTags("CORAMISSAO2");
        
    }
}
