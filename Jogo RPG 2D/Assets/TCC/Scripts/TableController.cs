using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WDT;

namespace Assets.TCC.Scripts
{
    /// <summary>
    /// Configura o componente da tabela de banco de dados para mostrar as informações da maneira correta
    /// </summary>
    public class TableController : MonoBehaviour
    {
        public WDataTable dataTable;
        public bool testDynamic;
        public bool testTextMeshPro;
        public Text text;

        private List<IList<object>> m_datas = null;
        private List<WColumnDef> m_columnDefs = null;
        private int m_tempSelectIndex = -1;

        // Use this for initialization
        void Start()
        {

           
        }

        /// <summary>
        /// Monta os dados da tabela de banco de dados que aparecerão na tela para o usuário
        /// </summary>
        /// <param name="nomeColunas">Lista com o nome das colunas em string</param>
        /// <param name="dados">Uma lista de listas de objetos que compõe a tabela do banco</param>
        public void MontarTabela(List<string> nomeColunas, List<IList<object>> dados)
        {
            //Definir as colunas da tabela
            m_columnDefs = new List<WColumnDef>() { };

            foreach (var nome in nomeColunas)
            {
                m_columnDefs.Add(new WColumnDef() { name = nome, width = "60" });

            }
  
            //Montar os dados com os respectivos valores
            m_datas = new List<IList<object>>(dados);

            //Inicializa a tabela
            if (testTextMeshPro)
            {
                dataTable.defaultHeadPrefabName = "TMPButtonElement";
                dataTable.defaultElementPrefabName = "TMPTextElement";
            }
            dataTable.msgHandle += HandleTableEvent;
            dataTable.InitDataTable(m_datas, m_columnDefs);
        }

        public void HandleTableEvent(WEventType messageType, params object[] args)
        {
            if (messageType == WEventType.INIT_ELEMENT)
            {
                int rowIndex = (int)args[0];
                int columnIndex = (int)args[1];
                WElement element = args[2] as WElement;
                if (element == null)
                    return;
                Text tText = element.GetComponent<Text>();
                if (tText == null)
                    return;
                tText.color = columnIndex % 2 == 0 ? Color.blue : Color.red;
            }
            else if (messageType == WEventType.SELECT_ROW)
            {
                int rowIndex = (int)args[0];
                if (text != null)
                    text.text = "Select Row" + rowIndex;
                m_tempSelectIndex = rowIndex;
            }

        }

        /// <summary>
        /// Limpa a tabela de dados
        /// </summary>
        public void reset()
        {
            dataTable.Clear();
        }

        private List<object> GetRandomData(int i = -1)
        {
            return new List<object>
        {
            i,
            "dsada" + i,
            20.1 + i,
            Random.Range(0.0f, 1.0f),
            new Vector3(1, i, 2)
        };
        }

        public void AddRow()
        {
            m_datas.Add(GetRandomData());
            dataTable.UpdateData(m_datas);
        }

        public void InsertRow(int index)
        {
            m_datas.Insert(index, GetRandomData());
            dataTable.UpdateData(m_datas);
        }

        public void RemoveRow(int index)
        {
            if (m_datas.Count == 0)
                return;

            m_datas.RemoveAt(index);
            dataTable.UpdateData(m_datas);
        }

        public void RemoveSelectRow()
        {
            if (m_datas.Count == 0)
                return;

            if (m_tempSelectIndex < 0 || m_tempSelectIndex >= m_datas.Count)
                return;

            int oldSize = m_datas.Count;
            float oldPostion = dataTable.GetPosition();
            m_datas.RemoveAt(m_tempSelectIndex);
            int newSize = m_datas.Count;
            dataTable.UpdateData(m_datas);
            dataTable.SetPosition(dataTable.GetPositionByNewSize(oldPostion, oldSize, newSize));
        }

        private void Update()
        {
            if (!testDynamic)
                return;
            dataTable.tableWidth = (int)(Mathf.Sin(Time.time * 2) * 100) + 600;
            dataTable.tableHeight = (int)(Mathf.Sin(Time.time * 2) * 50) + 200;
            dataTable.itemHeight = (int)(Mathf.Cos(Time.time * 2) * 10) + 40;
            dataTable.UpdateSize();
        }
    }
}
