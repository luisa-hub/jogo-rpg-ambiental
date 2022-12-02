using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VanishController : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerController jogador;
    private List<GameObject> desaparecidos;
    public GameObject botoesDesbloqueaveis;

    void Start()
    {
        desaparecidos = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void acoes() {
        foreach (var flag in jogador.flagMissoesConcluidas.ToList())
        {
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
                case "CORAMISSAO2":
                    //vanish("Edgar");
                    //move("Edgar", 3, 0);
                    break;
                case "CORAMISSAO3":
                    //appear("Edgar");
                    break;
                default:
                    // code block
                    break;
            }


        }


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

    void move(string nome, int x, int y) {
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


}
