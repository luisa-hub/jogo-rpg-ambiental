using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.TCC.Scripts
{
    public class NewsController : MonoBehaviour
    {
        public GameObject botoes;
        public GameObject objeto;
        public bool isOpen = false;


        public void abre()
        {

            objeto.SetActive(true);

            Player.Instance.PlayerPauseInteraction();

            botoes.SetActive(false);

            isOpen = true;
        }


        public void fecha()
        {
            objeto.SetActive(false);

            Player.Instance.PlayerReturnInteraction();

            botoes.SetActive(true);

            isOpen = false;
        }

        public void abreFecha() {
            if (isOpen)
            {
                fecha();
            }
            else {
                abre();
            }
        
        }

    }
}
