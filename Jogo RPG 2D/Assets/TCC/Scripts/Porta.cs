using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.TCC.Scripts { 

public class Porta : MonoBehaviour
{
        public Porta outraPorta;
        public SpriteRenderer cobre;
        public Player player;
    public void InitInteraction()
    {

            player = GameObject.Find("Player").GetComponent<Player>();
            if (cobre.enabled)
            {
                cobre.enabled = false;
            }
            else { 
                cobre.enabled = true;
            }
            player.gameObject.transform.position = outraPorta.transform.position;

        }


}

}
