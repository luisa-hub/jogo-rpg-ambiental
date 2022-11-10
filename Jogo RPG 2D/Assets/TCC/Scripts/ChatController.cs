﻿using Assets.TCC.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Chat Controller é responsável por mostrar os dados da caixa de diálogos na tela
/// </summary>
public class ChatController : MonoBehaviour
{
    private Text ObjetoTexto;
    private Image ObjetoImagem;
    private string[] textos;
    private int indexOfText = 0;
    public char stringSeparator = '#';
    public QuestsController questController;

    // Awake é chamado antes do start
    void Awake()
    {
        ObjetoTexto = GetComponentInChildren<Text>();
        ObjetoImagem = GameObject.Find("Retrato").GetComponent<Image>();
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


    /// <summary>
    /// Inicia o diálogo com o NPC e mostra a caixa de diálogos junto com o retrato do NPC
    /// </summary>
    /// <param name="textosNPCList">Falas do Npc</param>
    /// <param name="flagMissoesConcluidasPlayer">Flags das missões concluídas do jogador</param>
    /// <param name="retratoNPC">Retrato do Npc que aparecerá na tela</param>
    public void IniciaDialogo(List<string> textosNPCList, List<string> flagMissoesConcluidasPlayer, Sprite retratoNPC)
    {
        
        SetVisible(true); //ativa caixa de diálogo
        try
        {
            if (retratoNPC!= null)
            ObjetoImagem.sprite = retratoNPC; //coloca o retrato do npc
        }
        catch { }
        
        string textoMandar = ""; //seta variável que vai mandar pro chat

        //Se o jogador não realizou nenhuma missão, ele manda como padrão a primeira linha de diálogo
        if (flagMissoesConcluidasPlayer.Count == 0)
        {
            textoMandar = textosNPCList[0];
        }

        //Se o jogador já realizou alguma missão, ele procura quais que realizou.
        //Se tiver mais de uma, ele seleciona a última das flags do npc encontrada.
        else
        {
            string flag;

            foreach (string texto in textosNPCList) //pra diálogo possível do npc, repete
            {
                flag = texto.Split(stringSeparator)[0]; //pega flag que tem no começo de cada texto do npc

                if (flagMissoesConcluidasPlayer.Contains(flag)) //vê se esse diálogo tá nas flags do jogador
                    textoMandar = texto;
            }
        }

        ConfigureText(textoMandar);



        //Para o jogador
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(false);
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(false);
        GameObject.Find("Player").GetComponent<Player>().xInput = 0;
        GameObject.Find("Player").GetComponent<Player>().yInput = 0;

    }


    private void ConfigureText(string text)
    {
        // Divide a string recebida
        textos = text.Split(stringSeparator);
        //manda pro questcontroller checar se isso muda uma flag
        questController.verifyTalk(textos[0]);
        //Inicia o índice de texto (começa com 1, pois o index 0 é a flag da missão)
        indexOfText = 1;
        
        // Define o texto inicial
        ObjetoTexto.text = textos[indexOfText];

    }








}
