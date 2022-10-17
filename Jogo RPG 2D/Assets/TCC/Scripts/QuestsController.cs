
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.TCC.Scripts
{

    public class QuestsController : MonoBehaviour
    {
        public DatabaseDB banco;
        private string bancoReserva = "exemplo";
        public PlayerController jogador;

        private List<IList<object>> linhasEsperadas;
        private List<string> colunasEsperadas;

        private void Start()
        {

        }


        public void verifyData(List<string> colunas, List<IList<object>> linhas)
        {
            //-----------------------------

            //Aqui, resultado de consulta esperada
            string consulta = "SELECT *, 42 FROM user;"; 

            //Pega resultados do banco de dados
            linhasEsperadas = banco.dados(consulta, bancoReserva); 
            colunasEsperadas = banco.colunas(consulta, bancoReserva);

            //Compara se os resultados são equivalentes
            if (compara(colunas, linhas))
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

        public bool compara(List<string> colunas, List<IList<object>> linhas) {

            bool resultadoColunas = false;
            bool resultadoLinhas = false;
            List<bool> resultadosLinhaBool;

            //COMPARAÇÃO COLUNAS:
            //checa se há elementos que tem em uma que não tem em outra
            var colunasSemColunasEsperadas = colunas.Except(colunasEsperadas).ToList();
            var colunasEsperadasSemColunas = colunasEsperadas.Except(colunas).ToList();
            //vê se ficou vazio, sem nenhum elemento diferente. Se comparação deu que são iguais, vai ficar true!
            resultadoColunas = !colunasSemColunasEsperadas.Any() && !colunasEsperadasSemColunas.Any();

            //Se comparação de colunas deu certo, tenta comparar linhas. Se não, nem precisa tentar
            if (resultadoColunas) { 

                //ai, checa se número bate. Se não, nem precisa continuar
                if (linhasEsperadas.Count == linhas.Count)
                {
                    //percorre pela listde list
                    foreach (var linhaEsperada in linhasEsperadas)
                    {
                        resultadosLinhaBool = new List<bool>();

                        foreach (var linha in linhas)
                        {
                            //compara com resultado esperado da mesma forma
                            var linhaSemLinhaEsperada = linha.Except(linhaEsperada).ToList();
                            var linhaEsperadaSemLinha = linhaEsperada.Except(linha).ToList();
                            resultadosLinhaBool.Add(!linhaSemLinhaEsperada.Any() && !linhaEsperadaSemLinha.Any());
                        }

                        resultadoLinhas = resultadosLinhaBool.Contains(true) ? true : false;
                   
                        if (!resultadoLinhas) break;
                            
                            
                    }

                }
            }

            //Checa se os dois é verdadeiro pra mandar o resultado!
            if (resultadoColunas && resultadoLinhas)
                return true;
            else
                return false;
            
        }

    }
}
