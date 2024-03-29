﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VanishController : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerController jogador;
    private List<GameObject> desaparecidos;
    public GameObject botoesDesbloqueaveis;
    public ComputerController computador;
    private NPCController npcController;
    public PauseController pauseController;


    void Start()
    {
        desaparecidos = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void acoes(string flag) {
        //foreach (var flag in jogador.flagMissoesConcluidas.ToList())

            //{
            switch (flag)
            {
                case "DESBLOQUEIABOTOES":
                    desbloqueiaBotoes();
                    break;
                case "BOLINHA1":
                    vanish("BolinhaDePapel1");
                    break;
                case "BOLINHA2":
                    vanish("BolinhaDePapel2");
                    break;
                case "PLANTASURGE":
                    //vanish("Edgar");
                    move("Dione", -2.218489f, 1.64565f);
                    move("Edgar", 34.07567f, 7.344794f);
                    resetaBanco();
                    computador.fechar();
                    dialogoSurpresa("Dione");
                    break;
                case "PLANTASURGEREPETE":
                    resetaBanco();
                    computador.fechar();
                    dialogoSurpresa("Dione");
                    jogador.removeTag("PLANTASURGEREPETE");
                    break;
                case "GRACE5":
                    move("ComputadorLal", 13.78f, 5.22f);
                    break;
                case "LOVELACE8":
                    move("Srt. Lovelace",12.99561f, 3.1079f);
                    move("ComputadorLal", -45.6f, 5.22f);
                    move("ComputadorLovelace", -21.73f, -24.36f);
                    break;
                case "FIM":
                    fim();
                    break;
                default:
                    // code block
                    break;
            }


        //}


    }

    void resetaBanco() {
        computador.resetaBanco();
    }

    void dialogoSurpresa(string nome) {
        GameObject npc = GameObject.Find(nome).gameObject;
        npcController = npc.GetComponent<NPCController>();
        Player.Instance.PlayerPauseInteraction();
        npcController.InitInteraction(jogador.flagMissoesConcluidas);

    }

    void vanish(string nome) {

        try {
            GameObject npc = GameObject.Find(nome).gameObject;
            npc.SetActive(false);
            desaparecidos.Add(npc);
        } catch { }
        

    }

    void appear(string nome) {
        try
        {
            desaparecidos.Find(item => item.name == nome).SetActive(true);
        }
        catch { }
    }

    void move(string nome, float x, float y) {
        try
        {
            GameObject npc = GameObject.Find(nome).gameObject;
            //Vector3 novaPosicao = new Vector3(npc.transform.position.x+x, npc.transform.position.y + y, npc.transform.position.z);
            Vector3 novaPosicao = new Vector3(x, y, npc.transform.position.z);
            npc.transform.position = novaPosicao;
        }
        catch { }

    }

    public void desbloqueiaBotoes() {
        jogador.desbloqueouBotoes = true;
        botoesDesbloqueaveis.SetActive(true);
    }

    public void fim() {
        pauseController.menu();
    }
}
