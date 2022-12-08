
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.TCC.Scripts
{

    public class QuestsController : MonoBehaviour
    {
        public DatabaseController database;
        private string bancoReserva = "missao1Backup"; //"missao1Backup"
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
                if (bancoReserva == "missao1Backup")
                {
                    switch (flag)
                    {
                        case "EDGAR4":
                            var consulta = "SELECT * FROM doacoes_3989;";
                            if (verifyData(colunas, linhas, consulta))
                            {
                                jogador.updateTags("EDGAR5");
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
                //------------EDGAR------------
                case "EDGAR1":
                    jogador.updateTags("EDGAR2");
                    break;
                case "EDGAR2":
                    jogador.updateTags("NEWS1");
                    jogador.updateTags("NEWS2");
                    jogador.updateTags("DESBLOQUEIABOTOES");
                    jogador.updateTags("EDGAR3");
                    break;
                case "EDGAR3":
                    jogador.updateTags("EDGAR4");
                    break;
                //------------LOVELACE------------
                case "LOVELACE1":
                    jogador.updateTags("LOVELACE2");
                    break;
                case "LOVELACE2":
                    jogador.updateTags("LOVELACE3");
                    break;
                case "LOVELACE3":
                    jogador.updateTags("LOVELACE4");
                    break;
                //------------FRANK------------
                case "FRANK1":
                    jogador.updateTags("FRANK2");
                    break;
                case "FRANK2":
                    jogador.updateTags("FRANK3");
                    break;
                //------------GEORGE------------
                case "GEORGE1":
                    jogador.updateTags("GEORGE2");
                    break;
                case "GEORGE2":
                    jogador.updateTags("GEORGE3");
                    break;
                case "GEORGE3":
                    jogador.updateTags("GEORGE4");
                    break;
                //------------GRACE------------
                case "GRACE1":
                    jogador.updateTags("GRACE2");
                    break;
                case "GRACE2":
                    jogador.updateTags("GRACE3");
                    break;
                case "GRACE3":
                    jogador.updateTags("GRACE4");
                    break;
                //------------HOPPER------------
                case "HOPPER1":
                    jogador.updateTags("HOPPER2");
                    break;
                case "HOPPER2":
                    jogador.updateTags("HOPPER3");
                    break;
                //------------DIONE------------
                case "DIONE1":
                    jogador.updateTags("DIONE2");
                    break;
                //------------VAN HOSSUN------------
                case "VANHOSSUN1":
                    jogador.updateTags("VANHOSSUN2");
                    break;
                case "VANHOSSUN2":
                    jogador.updateTags("VANHOSSUN3");
                    break;
                //------------OBJETOS------------
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
                //------------QUEST LEÃO------------
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
