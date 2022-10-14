
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.TCC.Scripts
{

    public class QuestsController : MonoBehaviour
    {
        public DatabaseDB banco;
        private void Start()
        {

        }


        public void verifyData(List<string> coluna, List<IList<object>> linhas)
        {


            //Proximos passos: vamos tentar transformar a List<IList<object>> numa lista de strings para 
            //poder mexer ocm ela com mais facilidade
            bool resultadoColunas = true;
            bool resultadoLinhas = true;
          
            
            List<IList<object>> linhasEsperadas = banco.dados("SELECT * FROM user;", "exemplo");

            List<string> colunasEsperadas = banco.colunas("SELECT * FROM user;", "exemplo");
            var firstNotSecondc = coluna.Except(colunasEsperadas).ToList();
            var secondNotFirstc = colunasEsperadas.Except(coluna).ToList();


            resultadoColunas = !firstNotSecondc.Any() && !secondNotFirstc.Any();

            if (!resultadoColunas)
            {
                Debug.Log("Acabou aqui, colunas erradas!");
                return;
            }

            if (linhasEsperadas.Count != linhas.Count)
            {
                Debug.Log("Acabou aqui, linhas erradas!");
                resultadoLinhas = false;
            }

            else
            {
                foreach (var linhaEsperada in linhasEsperadas)
                {
                    foreach (var linha in linhas)
                    {
                        var firstNotSecond = linha.Except(linhaEsperada).ToList();
                        var secondNotFirst = linhaEsperada.Except(linha).ToList();
                        resultadoLinhas = !firstNotSecondc.Any() && !secondNotFirstc.Any();

                        if (!resultadoLinhas)
                        {
                            Debug.Log("Acabou aqui, linhas erradas!");
                            break;
                        }
                    }
                }
            }

            if (resultadoColunas && resultadoLinhas)
            {
                Debug.Log("YEEEEY");
            }

        }
        public void verifyTalk(string entrada)
        {

        }


    }
}
