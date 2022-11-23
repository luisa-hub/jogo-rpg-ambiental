using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.TCC.Scripts
{

    public class DoorController : MonoBehaviour
    {
        public DoorController outraPorta;
        public SpriteRenderer cobre;
        public Player player;
        public string chave = "vazia";
        public char stringSeparator = '#';
        private ChatController chatController;
        public string textoTrancando= "Porta Trancada!";
        public void InitInteraction(List<string> flagMissoesConcluidas)
        {

            if (confereTranca(flagMissoesConcluidas))
            {
                atravessar();
            }
            else {
                trancado();
            
            }

        }

        private void atravessar()
        {
            
            if (cobre.enabled)
            {
                cobre.enabled = false;
            }
            else
            {
                cobre.enabled = true;
            }
            Player.Instance.transform.position = outraPorta.transform.position;

        }

        private bool confereTranca(List<string> flagMissoesConcluidasPlayer)
        {
            if (chave == "vazia") {
                return true;
            }
            if (flagMissoesConcluidasPlayer.Count == 0)
            {
                return false;
            }
            else
            {
                if (flagMissoesConcluidasPlayer.Contains(chave))
                {
                    return true;
                }
            }
            return false;
        }

        private void trancado()
        {
            chatController = GameObject.Find("ChatBox").transform.GetChild(0).gameObject.GetComponentInChildren<ChatController>();
            List<string> dialogo = new List<string> {"aaaaa#"+textoTrancando};
            List<string> flagMissoesConcluidas = new List<string> {};
            chatController.IniciaDialogo(dialogo, flagMissoesConcluidas, null, null);

        }
    }       

}
