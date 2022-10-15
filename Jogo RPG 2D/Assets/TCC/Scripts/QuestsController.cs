
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.TCC.Scripts
{

    public class QuestsController : MonoBehaviour
    {
        public DatabaseDB banco;
        private string bancoreserva = "exemplo";
        public PlayerController jogador;
        private void Start()
        {

        }


        public void verifyData(List<string> coluna, List<IList<object>> linhas)
        {
            //-----------------------------

            //Aqui, resultado de consulta esperada
            string consulta = "SELECT *, 42 FROM user;"; 
            //Pega resultados do banco de dados
            List<IList<object>> linhasEsperadas = banco.dados(consulta, bancoreserva); 
            List<string> colunasEsperadas = banco.colunas(consulta, bancoreserva);

            //Compara se os resultados são equivalentes
            if (compara(coluna, linhas, linhasEsperadas, colunasEsperadas))
            {
                //manda pra completar missão
                jogador.updateTags("CORAMISSAO3");
                Debug.Log("YEEEEY");
            }
            else
            {
                //Só pra testes pra saber no log se deu errado. Não impacta em jogo, usuário não receberá nenhum input até que dê certo.
                Debug.Log("naaa");
            }

            //-----------------------------

        }
        public void verifyTalk(string flag)
        {
            switch (flag)
            {
                case "CORAMISSAO1":
                    jogador.updateTags("CORAMISSAO2");
                    break;
                case "CORAMISSAO3":
                    jogador.updateTags("CORAMISSAO4");
                    break;
                case "CORAMISSAO30":
                    // code block
                    break;
                default:
                    // code block
                    break;
            }

        }

        public bool compara(List<string> coluna, List<IList<object>> linhas, List<IList<object>> linhasEsperadas, List<string> colunasEsperadas) {

            bool resultadoColunas = false;
            bool resultadoLinhas = false;

            //COMPARAÇÃO COLUNAS:
            //checa se há elementos que tem em uma que não tem em outra
            var firstNotSecondc = coluna.Except(colunasEsperadas).ToList();
            var secondNotFirstc = colunasEsperadas.Except(coluna).ToList();
            //vê se ficou vazio, sem nenhum elemento diferente. Se comparação deu que são iguais, vai ficar true!
            resultadoColunas = !firstNotSecondc.Any() && !secondNotFirstc.Any();

            //Se comparação de colunas deu certo, tenta comparar linhas. Se não, nem precisa tentar
            if (resultadoColunas) { 

                //ai, checa se número bate. Se não, nem precisa continuar
                if (linhasEsperadas.Count == linhas.Count)
                {
                    //percorre pela listde list
                    foreach (var linhaEsperada in linhasEsperadas)
                    {
                        foreach (var linha in linhas)
                        {
                            //compara com resultado esperado da mesma forma
                            var firstNotSecond = linha.Except(linhaEsperada).ToList();
                            var secondNotFirst = linhaEsperada.Except(linha).ToList();
                            resultadoLinhas = !firstNotSecondc.Any() && !secondNotFirstc.Any();

                            if (!resultadoLinhas)
                            {
                                //se entrar aqui, é porque deu errado
                                break;
                            }
                        }
                    }

                }
            }

            //Checa se os dois é verdadeiro pra mandar o resultado!
            if (resultadoColunas && resultadoLinhas)
            {
                return true;
            }
            else
            {
                return false;
            }
            

            
        }

    }
}
