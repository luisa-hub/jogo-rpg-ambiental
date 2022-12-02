
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.TCC.Scripts
{

    public class QuestsController : MonoBehaviour
    {
        public DatabaseController database;
        private string bancoReserva = "missao1Banckup"; //"missao1Backup"
        public PlayerController jogador;

        private List<IList<object>> expectedLines;
        private List<string> expectedColumns;

        private void Start()
        {

        }

     
        /// <summary>
        /// Verifica a missão que o usuário está realizando e a consulta esperada
        /// </summary>
        /// <param name="colunas">Colunas da consulta do usuário</param>
        /// <param name="linhas">LInhas da consulta do usuário</param>
        public void verifyMissionDB(List<string> colunas, List<IList<object>> linhas, string banco)
        {
            bancoReserva = banco; //se criarmos um segundo pra conferir, adicionar string no final

            foreach (var flag in jogador.flagMissoesConcluidas.ToList())
            {
                if (bancoReserva == "missao1Banckup")
                {
                    switch (flag)
                    {
                        case "CORAMISSAO2":
                            var consulta = "SELECT * FROM doacoes_3879;";
                            if (verifyData(colunas, linhas, consulta))
                            {
                                jogador.updateTags("CORAMISSAO3");
                            }

                            break;

                        case "MISSAO3":
                            // jogador.updateTags("MISSAO4");
                            break;
                        case "MISSAO5":
                            // code block
                            break;
                        default:
                            // code block
                            break;
                    }
                }

            }


        }

        /// <summary>
        /// Verifica se a consulta digitada pelo usuário é igual à consulta esperada na missão
        /// </summary>
        private bool verifyData(List<string> columns, List<IList<object>> lines, string query)
        {
            bool isMissionCompleted = false;

            expectedLines = database.dados(query, bancoReserva);
            expectedColumns = database.colunas(query, bancoReserva);

            if (compare(columns, lines))
            {

                Debug.Log("Missão concluída");
                isMissionCompleted = true;
                return isMissionCompleted;
            }
            else
            {
                Debug.Log("Missão não concluída");
                return isMissionCompleted;
            }



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
                case "BOLINHA1":
                    jogador.updateTags("BOLINHA1");
                    break;
                case "BOLINHA2":
                    jogador.updateTags("BOLINHA2");
                    break;
                case "PRIVADA1":
                    jogador.updateTags("PRIVADA2");
                    break;
                case "PRIVADA2":
                    jogador.updateTags("PRIVADA3");
                    break;
                case "PRIVADA3":
                    jogador.updateTags("PRIVADA4");
                    break;
                case "LEAO1":
                    jogador.updateTags("LEAO2");
                    break;
                case "LEAO2":
                    jogador.updateTags("BOLINHOS2");
                    break;
                case "BOLINHOS2":
                    jogador.updateTags("COMBOLINHO");
                    jogador.updateTags("PEGOUBOLINHO");
                    break;
                case "COMBOLINHO":
                    jogador.updateTags("COMBOLINHO2");
                    break;
                case "LOVELACE1":
                    jogador.updateTags("NEWS1");
                    jogador.updateTags("DESBLOQUEIABOTOES");
                    break;
                case "FRANK1":
                    jogador.updateTags("NEWS2");
                    break;
                default:
                    // code block
                    break;
            }

        }

        private bool compare(List<string> colunas, List<IList<object>> linhas) {

            bool resultadoColunas = false;
            bool resultadoLinhas = false;
            List<bool> resultadosLinhaBool;

            //COMPARAÇÃO COLUNAS:
            //checa se há elementos que tem em uma que não tem em outra
            var colunasSemColunasEsperadas = colunas.Except(expectedColumns).ToList();
            var colunasEsperadasSemColunas = expectedColumns.Except(colunas).ToList();

            //vê se ficou vazio, sem nenhum elemento diferente. Se comparação deu que são iguais, vai ficar true!
            resultadoColunas = !colunasSemColunasEsperadas.Any() && !colunasEsperadasSemColunas.Any();

            //Se comparação de colunas deu certo, tenta comparar linhas. Se não, nem precisa tentar
            if (resultadoColunas) { 

                //ai, checa se número bate. Se não, nem precisa continuar
                if (expectedLines.Count == linhas.Count)
                {
                    //percorre pela listde list
                    foreach (var linhaEsperada in expectedLines)
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
