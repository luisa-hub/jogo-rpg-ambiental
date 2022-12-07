using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Assets.TCC.Scripts
{
    public class NewsController : MonoBehaviour
    {
        public GameObject botoes;
        public GameObject objeto;
        public bool isOpen = false;
        public GameObject noticiasSlider;
        public GameObject original;
        public List<string> news;
        public char stringSeparator;
        public char stringSeparetor2;
        public TextMeshProUGUI textoPrincipal;
        public GameObject exclamacao;
        public GameObject content;

        public void atualizar(string flag) {

            string[] novidade;
            string[] encontrada = null;
            foreach (string texto in news) 
            {
                novidade = texto.Split(stringSeparator);
                if (novidade[0]==flag) 
                    encontrada = novidade;
            }

            if (encontrada != null)
            {
                adicionarNovidade(encontrada);
            }

        }


        public void adicionarNovidade(string[] novidade) {
            GameObject clone = criaObjetoSlider();
            TextMeshProUGUI texto = clone.GetComponentInChildren<TextMeshProUGUI>();
            texto.text = novidade[1];
            Text texto2 = clone.GetComponentInChildren<Text>();
            texto2.text = novidade[2];
            exclamacao.SetActive(true);
            

        }

        public GameObject criaObjetoSlider() {
            GameObject clone = Instantiate(original, noticiasSlider.transform);
            //clone.transform.SetParent(noticiasSlider.transform);
            clone.SetActive(true);
            return clone;

        }

        public void setaMainText(Button button) {
            string texto;
            texto = button.GetComponentInChildren<Text>().text;
            textoPrincipal.text = texto;
            highlight(button);
        }

        public void highlight(Button button) {
            foreach (Transform child in content.transform) { 
                var cor = child.GetComponent<Image>().color;
                cor.a = 1f;
                child.GetComponent<Image>().color = cor;
            }

            var cor2 = button.GetComponent<Image>().color;
            cor2.a = 0.5f;
            button.GetComponent<Image>().color = cor2;

        }

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

            desativaExclamacao();
        }

        public void abreFecha() {
            if (isOpen)
            {
                fecha();
                desativaExclamacao();
            }
            else {
                abre();
            }
        
        }

        public void desativaExclamacao() {
            exclamacao.SetActive(false);
        }

    }
}
