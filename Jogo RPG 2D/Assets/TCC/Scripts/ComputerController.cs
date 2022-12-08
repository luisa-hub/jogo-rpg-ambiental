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
    public string bancoPrimario; //"missao1" "missao1Banckup"
    public TMP_InputField input;
    private Dictionary<string, string> backups = new Dictionary<string, string>();


    void Awake()
    {
        banco = GetComponent<DatabaseController>();
        table = GetComponent<TableController>();
        prepareBackups();


    }

    public void click()
    {

        try
        {

            List<string> colunas = banco.colunas(consulta.text, bancoPrimario);
            List<IList<object>> linhas = banco.dados(consulta.text, bancoPrimario);


            quest.verifyMissionDB(colunas, linhas, bancoPrimario);

            table.MontarTabela(colunas, linhas);

            botaoTip.gameObject.SetActive(false);
            mostra.text = "";

        }
        catch (SqliteException ex)
        {
            if (ex.ErrorCode == SQLiteErrorCode.Error)
            {
                mostra.text = "Parece que você digitou algo errado!";

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

    public void resetaBanco()
    {


        banco.consulta(backups["missao1Backup"], bancoPrimario);


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



    private void prepareBackups()
    {

        backups.Add
        ("missao1Backup", @"BEGIN TRANSACTION;
                        DROP TABLE IF EXISTS doacoes_3979;
            DROP TABLE IF EXISTS empresas_3979;
CREATE TABLE IF NOT EXISTS 'empresas_3979' (
	'Id'	INTEGER,
	'Nome'	TEXT,
	'CEO'	TEXT,
	PRIMARY KEY('Id')
);
CREATE TABLE IF NOT EXISTS 'doacoes_3979' (
	'Id'	INTEGER NOT NULL,
	'Valor'	REAL NOT NULL,
	'Data'	TEXT NOT NULL,
	'Id_Empresa'	INTEGER NOT NULL,
	PRIMARY KEY('Id')
);
INSERT INTO 'empresas_3979' ('Id','Nome','CEO') VALUES (1,'Ajude Cãezinhos','Bobbie Toosh'),
 (2,'Florestando React','Miss Sunflower'),
 (3,'ComPaz - Comunidade pela paz','Sra. Nunbee Aly'),
 (4,'Zero-Hungry','Aladir Foods'),
 (5,'Trees Pandas','Panmela Dalias'),
 (6,'Carnoo Moo','Zé Saturvinense'),
 (7,'Madeireira Saturno','Jupiter Mark'),
 (8,'Pescaria Giant','Eleanor Geirrod'),
 (9,'Poison Shampoo','MIss Styles'),
 (10,'Sodaa Bomb!','Pemberton'),
 (11,'Músculos Incríveis','Maron Bates'),
 (12,'Fragrância Cinza','Chain Flower'),
 (13,'Atlantis Fish','Beth Romda'),
 (14,'TrashShow - Moda','Blom Sein'),
 (15,'Curtis Wood','Sr. Wood'),
 (16,'Washing Nature','Moon Lee'),
 (17,'Green Dental','Sr. Teeth'),
 (18,'Super Esponja - Brilhando panelas','Boris Briliant'),
 (19,'Smell Loom - Sabão em barra','Cleanar Marilia'),
 (20,'Super Ceo Advogados','Magnan Nate'),
 (21,'Moodando Couros - Jaquetas','Leon Mark'),
 (22,'LimpoosChão','Mike Osorio'),
 (23,'Hidratante VerdeFeet','Alicia Beauty'),
 (24,'MakeDonuts','Mateus Loid'),
 (25,'Ocopocus Limpador','Tako Kai'),
 (26,'Cupcakes Felizes','Amandy Can'),
 (27,'Boombodoo - doces açucarados','Boris Booblodong'),
 (28,'Medikos King','Richard Filho'),
 (29,'RefriFree',NULL),
 (30,'Carpintaria Joaquina','Joaquina Alastair'),
 (31,'Jojo joias',NULL),
 (32,'Carin Bianchini',NULL),
 (33,'Super Maromba  - Suplementos',NULL),
 (34,'Plastic is Life! - Canudinhos',NULL),
 (35,'Glitter Drag','Paula Ruh'),
 (36,'Perfect Flowers - Perfume',NULL),
 (37,'MataMoscas1000','Moscowitz'),
 (38,'Guardanapos Papos',NULL),
 (39,'Velas Aromáticas Orgânicas',NULL),
 (40,'Gordura 0! - Limpa panelas',NULL),
 (41,'Roupa Prin',NULL),
 (42,'Multiuso Multiclean',NULL),
 (43,'DesodoraFudum',NULL),
 (44,'Barber Gel',NULL),
 (45,'Papel Higiênico Loomie',NULL),
 (46,'ProtectseSol','Apolo Bloom'),
 (47,'LiquiBoom',NULL),
 (48,'Purificador de Ar',NULL),
 (49,'Alamood Flores',NULL),
 (50,'Requien Eco','Morticia Leal');
INSERT INTO 'doacoes_3979' ('Id','Valor','Data','Id_Empresa') VALUES (1,24000.0,'3979-06-14',34),
 (2,28954.0,'3979-06-20',40),
 (3,0.89,'3979-07-20',4),
 (4,3900.0,'3979-07-28',6),
 (5,435.0,'3979-09-13',18),
 (6,3390.66,'3979-09-14',38),
 (7,3648.54,'3979-09-15',31),
 (8,1325.84,'3979-09-16',23),
 (9,1295.28,'3979-09-17',18),
 (10,3057.65,'3979-09-18',28),
 (11,3648.78,'3979-09-19',14),
 (12,1559.23,'3979-09-20',28),
 (13,1578.64,'3979-09-21',36),
 (14,3729.88,'3979-09-22',24),
 (15,66.15,'3979-09-23',1),
 (16,1085.28,'3979-09-24',19),
 (17,1043.23,'3979-09-25',8),
 (18,2582.25,'3979-09-26',40),
 (19,519.28,'3979-09-27',2),
 (20,3483.72,'3979-09-28',37),
 (21,1883.86,'3979-09-29',23),
 (22,2838.75,'3979-09-30',14),
 (23,1890.64,'3979-10-01',40),
 (24,3160.02,'3979-10-02',8),
 (25,1776.62,'3979-10-03',38),
 (26,1842.15,'3979-10-04',35),
 (27,1646.32,'3979-10-05',21),
 (28,202.35,'3979-10-06',3),
 (29,3358.51,'3979-10-07',24),
 (30,3980.12,'3979-10-08',13),
 (31,2714.69,'3979-10-09',11),
 (32,2755.02,'3979-10-10',13),
 (33,3094.38,'3979-10-11',20),
 (34,894.22,'3979-10-12',28),
 (35,2857.56,'3979-10-13',12),
 (36,0.68,'3979-10-14',5),
 (37,796.54,'3979-10-15',11),
 (38,2886.48,'3979-10-16',20),
 (39,937.09,'3979-10-17',19),
 (40,1144.75,'3979-10-18',33),
 (41,644.19,'3979-10-19',4),
 (42,1551.51,'3979-10-20',9),
 (43,3176.01,'3979-10-21',37),
 (44,720.7,'3979-10-22',19),
 (45,1757.11,'3979-10-23',36),
 (46,2400.32,'3979-10-24',22),
 (47,1428.49,'3979-10-25',14),
 (48,86.31,'3979-10-26',11),
 (49,1209.95,'3979-10-27',30),
 (50,3605.4,'3979-10-28',34),
 (51,623.23,'3979-10-29',3),
 (52,1156.05,'3979-10-30',37),
 (53,2830.42,'3979-10-31',37),
 (54,984.91,'3979-11-01',13),
 (55,1310.24,'3980-01-11',17),
 (56,3216.27,'3980-01-12',19),
 (57,1206.84,'3980-01-13',18),
 (58,1957.0,'3980-01-14',6),
 (59,3636.95,'3980-01-15',24),
 (60,1094.96,'3980-01-16',23),
 (61,37.61,'3980-01-17',5),
 (62,433.56,'3980-01-18',3),
 (63,3099.13,'3980-01-19',18),
 (64,3009.24,'3980-01-20',38),
 (65,3286.82,'3980-01-21',27),
 (66,486.25,'3980-01-22',18),
 (67,56.36,'3980-01-23',27),
 (68,3088.99,'3980-01-24',33),
 (69,2567.81,'3980-01-25',27),
 (70,3105.45,'3980-01-26',32),
 (71,271.49,'3980-01-27',22),
 (72,876.31,'3980-01-28',3),
 (73,2757.96,'3980-01-29',20),
 (74,3486.6,'3980-01-30',24),
 (75,2628.14,'3980-01-31',35),
 (76,2025.75,'3980-02-01',25),
 (77,55.47,'3980-02-02',5),
 (78,2016.24,'3980-02-03',26),
 (79,6909.45,'3980-02-04',4),
 (80,981.57,'3980-02-05',29),
 (81,520.61,'3980-02-06',1),
 (82,2493.55,'3980-02-07',34),
 (83,2986.37,'3980-02-08',27),
 (84,1583.68,'3980-02-09',15),
 (85,2601.12,'3980-02-10',40),
 (86,111.53,'3980-02-11',40),
 (87,24120.74,'3980-02-12',20),
 (88,3354.75,'3980-02-13',9),
 (89,223.47,'3980-02-14',32),
 (90,1335.04,'3980-02-15',14),
 (91,3059.44,'3980-02-16',13),
 (92,1647.08,'3980-02-17',40),
 (93,17308.58,'3980-02-18',33),
 (94,51.32,'3980-02-19',16),
 (95,1139.02,'3980-02-20',24),
 (96,2878.06,'3980-02-21',23),
 (97,342.83,'3980-02-22',2),
 (98,3231.98,'3980-02-23',36),
 (99,1857.08,'3980-02-24',36),
 (100,1759.4,'3980-02-25',25);
COMMIT;



");

    }

}
