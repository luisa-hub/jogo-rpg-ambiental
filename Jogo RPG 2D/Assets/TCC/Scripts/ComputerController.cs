using Assets.TCC.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.ComponentModel;
using System;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System.IO;

/// <summary>
/// Computador é o controlador do banco de dados e do componente da tabela WDataTable
/// </summary>
public class ComputerController : MonoBehaviour
{

    public TextMeshProUGUI mostra;
    public TMP_InputField consulta;
    public DatabaseController banco;
    public TableController table;
    public Button botaoTip;
    private string messagemDeErro;
    public TextMeshProUGUI textoErro;
    public QuestsController quest;
    public string bancoPrimario; //"missao1"
    public TMP_InputField input;
    

    void Awake()
    {
        banco = GetComponent<DatabaseController>();
        table = GetComponent<TableController>();
        
        
    }

    public void click() {

        try
        {
           
            List<string> colunas = banco.colunas(consulta.text, bancoPrimario);
            List <IList<object>> linhas = banco.dados(consulta.text, bancoPrimario);

            Debug.Log(linhas);

            quest.verifyMissionDB(colunas, linhas);

            table.MontarTabela(colunas, linhas);

            botaoTip.gameObject.SetActive(false);
            mostra.text = "";
           
        }
        catch (SqliteException ex) 
        {
            if (ex.ErrorCode == SQLiteErrorCode.Error)
            {
                mostra.text =  "Parece que você digitou algo errado!";

                messagemDeErro = ex.Message;
                botaoTip.gameObject.SetActive(true);
                
            }
            
        }
        catch (NullReferenceException)
        {
            mostra.text = "Cuidado, não clique levianamente em botões...!";
        }
    
    }

    public void fechar()
    {
         this.gameObject.SetActive(false);

        table.clearTable();
        mostra.text = "";
        botaoTip.gameObject.SetActive(false);

        //Retorna movimento ao Player
        Player.Instance.PlayerReturnInteraction();
    }

    public void resetaBanco() {


        String con = @"BEGIN TRANSACTION;
                        DROP TABLE IF EXISTS doacoes_3879;
                        CREATE TABLE IF NOT EXISTS doacoes_3879(
                            Id    INTEGER NOT NULL,
                            Valor REAL NOT NULL,
                            Data  TEXT NOT NULL,
                            Id_Empresa    INTEGER NOT NULL,
                            PRIMARY KEY(Id)
                        );
                    INSERT INTO doacoes_3879 VALUES(1, 24000.0, '3979-06-14', 34);
                    INSERT INTO doacoes_3879 VALUES(2, 28954.0, '3979-06-20', 19);
                    INSERT INTO doacoes_3879 VALUES(3, 0.89, '3979-07-20', 4);
                    INSERT INTO doacoes_3879 VALUES(4, 3900.0, '3979-07-28', 39);
                    INSERT INTO doacoes_3879 VALUES(5, 435.0, '3979-09-13', 16);
                    INSERT INTO doacoes_3879 VALUES(6, 3390.66, '3979-09-14', 25);
                    INSERT INTO doacoes_3879 VALUES(7, 3648.54, '3979-09-15', 8);
                    INSERT INTO doacoes_3879 VALUES(8, 1325.84, '3979-09-16', 38);
                    INSERT INTO doacoes_3879 VALUES(9, 1295.28, '3979-09-17', 7);
                    INSERT INTO doacoes_3879 VALUES(10, 3057.65, '3979-09-18', 16);
                    INSERT INTO doacoes_3879 VALUES(11, 3648.78, '3979-09-19', 12);
                    INSERT INTO doacoes_3879 VALUES(12, 1559.23, '3979-09-20', 23);
                    INSERT INTO doacoes_3879 VALUES(13, 1578.64, '3979-09-21', 10);
                    INSERT INTO doacoes_3879 VALUES(14, 3729.88, '3979-09-22', 16);
                    INSERT INTO doacoes_3879 VALUES(15, 66.15, '3979-09-23', 1);
                    INSERT INTO doacoes_3879 VALUES(16, 1085.28, '3979-09-24', 31);
                    INSERT INTO doacoes_3879 VALUES(17, 1043.23, '3979-09-25', 17);
                    INSERT INTO doacoes_3879 VALUES(18, 2582.25, '3979-09-26', 10);
                    INSERT INTO doacoes_3879 VALUES(19, 519.28, '3979-09-27', 2);
                    INSERT INTO doacoes_3879 VALUES(20, 3483.72, '3979-09-28', 6);
                    INSERT INTO doacoes_3879 VALUES(21, 1883.86, '3979-09-29', 33);
                    INSERT INTO doacoes_3879 VALUES(22, 2838.75, '3979-09-30', 14);
                    INSERT INTO doacoes_3879 VALUES(23, 1890.64, '3979-10-01', 31);
                    INSERT INTO doacoes_3879 VALUES(24, 3160.02, '3979-10-02', 10);
                    INSERT INTO doacoes_3879 VALUES(25, 1776.62, '3979-10-03', 39);
                    INSERT INTO doacoes_3879 VALUES(26, 1842.15, '3979-10-04', 37);
                    INSERT INTO doacoes_3879 VALUES(27, 1646.32, '3979-10-05', 18);
                    INSERT INTO doacoes_3879 VALUES(28, 202.35, '3979-10-06', 3);
                    INSERT INTO doacoes_3879 VALUES(29, 3358.51, '3979-10-07', 38);
                    INSERT INTO doacoes_3879 VALUES(30, 3980.12, '3979-10-08', 36);
                    INSERT INTO doacoes_3879 VALUES(31, 2714.69, '3979-10-09', 32);
                    INSERT INTO doacoes_3879 VALUES(32, 2755.02, '3979-10-10', 31);
                    INSERT INTO doacoes_3879 VALUES(33, 3094.38, '3979-10-11', 12);
                    INSERT INTO doacoes_3879 VALUES(34, 894.22, '3979-10-12', 6);
                    INSERT INTO doacoes_3879 VALUES(35, 2857.56, '3979-10-13', 11);
                    INSERT INTO doacoes_3879 VALUES(36, 0.68, '3979-10-14', 4);
                    INSERT INTO doacoes_3879 VALUES(37, 796.54, '3979-10-15', 31);
                    INSERT INTO doacoes_3879 VALUES(38, 2886.48, '3979-10-16', 15);
                    INSERT INTO doacoes_3879 VALUES(39, 937.09, '3979-10-17', 32);
                    INSERT INTO doacoes_3879 VALUES(40, 1144.75, '3979-10-18', 12);
                    INSERT INTO doacoes_3879 VALUES(41, 644.19, '3979-10-19', 5);
                    INSERT INTO doacoes_3879 VALUES(42, 1551.51, '3979-10-20', 17);
                    INSERT INTO doacoes_3879 VALUES(43, 3176.01, '3979-10-21', 14);
                    INSERT INTO doacoes_3879 VALUES(44, 720.7, '3979-10-22', 22);
                    INSERT INTO doacoes_3879 VALUES(45, 1757.11, '3979-10-23', 9);
                    INSERT INTO doacoes_3879 VALUES(46, 2400.32, '3979-10-24', 12);
                    INSERT INTO doacoes_3879 VALUES(47, 1428.49, '3979-10-25', 18);
                    INSERT INTO doacoes_3879 VALUES(48, 86.31, '3979-10-26', 24);
                    INSERT INTO doacoes_3879 VALUES(49, 1209.95, '3979-10-27', 25);
                    INSERT INTO doacoes_3879 VALUES(50, 3605.4, '3979-10-28', 29);
                    INSERT INTO doacoes_3879 VALUES(51, 623.23, '3979-10-29', 3);
                    INSERT INTO doacoes_3879 VALUES(52, 1156.05, '3979-10-30', 35);
                    INSERT INTO doacoes_3879 VALUES(53, 2830.42, '3979-10-31', 14);
                    INSERT INTO doacoes_3879 VALUES(54, 984.91, '3979-11-01', 22);
                    INSERT INTO doacoes_3879 VALUES(55, 1310.24, '3980-01-11', 8);
                    INSERT INTO doacoes_3879 VALUES(56, 3216.27, '3980-01-12', 7);
                    INSERT INTO doacoes_3879 VALUES(57, 1206.84, '3980-01-13', 35);
                    INSERT INTO doacoes_3879 VALUES(58, 1957.0, '3980-01-14', 21);
                    INSERT INTO doacoes_3879 VALUES(59, 3636.95, '3980-01-15', 31);
                    INSERT INTO doacoes_3879 VALUES(60, 1094.96, '3980-01-16', 9);
                    INSERT INTO doacoes_3879 VALUES(61, 37.61, '3980-01-17', 5);
                    INSERT INTO doacoes_3879 VALUES(62, 433.56, '3980-01-18', 3);
                    INSERT INTO doacoes_3879 VALUES(63, 3099.13, '3980-01-19', 13);
                    INSERT INTO doacoes_3879 VALUES(64, 3009.24, '3980-01-20', 30);
                    INSERT INTO doacoes_3879 VALUES(65, 3286.82, '3980-01-21', 6);
                    INSERT INTO doacoes_3879 VALUES(66, 486.25, '3980-01-22', 36);
                    INSERT INTO doacoes_3879 VALUES(67, 56.36, '3980-01-23', 35);
                    INSERT INTO doacoes_3879 VALUES(68, 3088.99, '3980-01-24', 6);
                    INSERT INTO doacoes_3879 VALUES(69, 2567.81, '3980-01-25', 13);
                    INSERT INTO doacoes_3879 VALUES(70, 3105.45, '3980-01-26', 29);
                    INSERT INTO doacoes_3879 VALUES(71, 271.49, '3980-01-27', 14);
                    INSERT INTO doacoes_3879 VALUES(72, 876.31, '3980-01-28', 3);
                    INSERT INTO doacoes_3879 VALUES(73, 2757.96, '3980-01-29', 9);
                    INSERT INTO doacoes_3879 VALUES(74, 3486.6, '3980-01-30', 28);
                    INSERT INTO doacoes_3879 VALUES(75, 2628.14, '3980-01-31', 34);
                    INSERT INTO doacoes_3879 VALUES(76, 2025.75, '3980-02-01', 29);
                    INSERT INTO doacoes_3879 VALUES(77, 55.47, '3980-02-02', 5);
                    INSERT INTO doacoes_3879 VALUES(78, 2016.24, '3980-02-03', 17);
                    INSERT INTO doacoes_3879 VALUES(79, 699.45, '3980-02-04', 4);
                    INSERT INTO doacoes_3879 VALUES(80, 981.57, '3980-02-05', 39);
                    INSERT INTO doacoes_3879 VALUES(81, 520.61, '3980-02-06', 1);
                    INSERT INTO doacoes_3879 VALUES(82, 2493.55, '3980-02-07', 20);
                    INSERT INTO doacoes_3879 VALUES(83, 2986.37, '3980-02-08', 40);
                    INSERT INTO doacoes_3879 VALUES(84, 1583.68, '3980-02-09', 19);
                    INSERT INTO doacoes_3879 VALUES(85, 2601.12, '3980-02-10', 15);
                    INSERT INTO doacoes_3879 VALUES(86, 111.53, '3980-02-11', 7);
                    INSERT INTO doacoes_3879 VALUES(87, 2412.74, '3980-02-12', 10);
                    INSERT INTO doacoes_3879 VALUES(88, 3354.75, '3980-02-13', 32);
                    INSERT INTO doacoes_3879 VALUES(89, 223.47, '3980-02-14', 22);
                    INSERT INTO doacoes_3879 VALUES(90, 1335.04, '3980-02-15', 39);
                    INSERT INTO doacoes_3879 VALUES(91, 3059.44, '3980-02-16', 32);
                    INSERT INTO doacoes_3879 VALUES(92, 1647.08, '3980-02-17', 14);
                    INSERT INTO doacoes_3879 VALUES(93, 1738.58, '3980-02-18', 31);
                    INSERT INTO doacoes_3879 VALUES(94, 51.32, '3980-02-19', 29);
                    INSERT INTO doacoes_3879 VALUES(95, 1139.02, '3980-02-20', 13);
                    INSERT INTO doacoes_3879 VALUES(96, 2878.06, '3980-02-21', 35);
                    INSERT INTO doacoes_3879 VALUES(97, 342.83, '3980-02-22', 2);
                    INSERT INTO doacoes_3879 VALUES(98, 3231.98, '3980-02-23', 11);
                    INSERT INTO doacoes_3879 VALUES(99, 1857.08, '3980-02-24', 27);
                    INSERT INTO doacoes_3879 VALUES(100, 1759.4, '3980-02-25', 14);
                    COMMIT;";

        banco.consulta(con, bancoPrimario);


    }

    public void tip()
    {
        textoErro.SetText(messagemDeErro);
        botaoTip.gameObject.SetActive(false);

    }

    private bool ExceptionContainsErrorCode(Exception e, int ErrorCode)
    {
        Win32Exception winEx = e as Win32Exception;
        if (winEx != null && ErrorCode == winEx.ErrorCode)
            return true;

        if (e.InnerException != null)
            return ExceptionContainsErrorCode(e.InnerException, ErrorCode);

        return false;
    }


}
