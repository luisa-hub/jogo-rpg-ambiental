
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


        public void verifyData(List<string> coluna, List<IList<object>> linha) {
            coluna.Sort();
           
            //Proximos passos: vamos tentar transformar a List<IList<object>> numa lista de strings para 
            //poder mexer ocm ela com mais facilidade
            bool teste = true;
            bool teste2 = true;
            List<string> colunaEsperada = banco.colunas("SELECT * FROM user;", "exemplo");
            colunaEsperada.Sort();
            List<IList<object>> linhaEsperada = banco.dados("SELECT * FROM user;", "exemplo");

            var firstNotSecond = linha.Except(linhaEsperada).ToList();
            var secondNotFirst = linhaEsperada.Except(linha).ToList();

            var firstNotSecondc = coluna.Except(colunaEsperada).ToList();
            var secondNotFirstc = colunaEsperada.Except(coluna).ToList();


            Debug.Log($"Colunas:{!firstNotSecondc.Any() && !secondNotFirstc.Any()}");

            foreach (var listinha in linhaEsperada)
            {
                foreach (var lista in listinha)
                {
                    Debug.Log("testando");
                    if (!linha.Contains(lista))
                    {
                        teste = false;
                        return;
                    }
                }
            }

            Debug.Log($"Testando a linhaa: {teste}");
               

            

            //foreach (var item in coluna)
            //{
            //    if (!colunaEsperada.Contains(item))
            //    {
            //        teste2 = false;
            //        continue;
            //    }

            //}
            //Debug.Log($"Colunas: {coluna.Equals(colunaEsperada)} ");
            //Debug.Log($"Colunas: {teste2} ");

            //Debug.Log($"Teste: {teste} ");
            if (coluna==colunaEsperada && teste) {
                Debug.Log("YEEEEY");
            }

        }
        public void verifyTalk(string entrada) { 
        
        }

    }
}
