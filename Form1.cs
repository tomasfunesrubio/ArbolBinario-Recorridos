using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbol_01
{
    public partial class Form1 : Form
    {
        Nodo nA, nB, nC, nD, nE, nF;

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach(Nodo n in PreOrden())
            {
                listBox1.Items.Add(n.Id);
            }
        }
        public List<Nodo> PreOrden()
        {
            List<Nodo> pListaNodos = new List<Nodo>();
            PreOrdenRecursiva2(nA,pListaNodos);
            return pListaNodos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Clear();
                InOrdenRecursiva(nA, textBox2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void InOrdenRecursiva(Nodo pNodo, TextBox pCajaTexto)
        {
            if (pNodo != null)
            {
                InOrdenRecursiva(pNodo.Izquierdo, pCajaTexto);
                pCajaTexto.Text += $"{pNodo.Id} ";
                InOrdenRecursiva(pNodo.Derecho, pCajaTexto);
            }
        }
        private void PosOrdenRecursiva(Nodo pNodo, TextBox pCajaTexto)
        {
            if (pNodo != null)
            {
                PosOrdenRecursiva(pNodo.Izquierdo, pCajaTexto);
                PosOrdenRecursiva(pNodo.Derecho, pCajaTexto);
                pCajaTexto.Text += $"{pNodo.Id} ";
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Clear();
                PosOrdenRecursiva(nA, textBox3);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            AmplitudRecursiva(new List<Nodo> {nA},textBox4);
        }
        private void AmplitudRecursiva(List<Nodo> pListaNodos, TextBox pCajaTexto)
        {
           if(pListaNodos.Exists(x => x.Id!="@"))
            {
                List<Nodo> auxListaNodos = new List<Nodo>();
                foreach(Nodo n in pListaNodos)
                {
                    pCajaTexto.Text += $"{n.Id}";               
                    auxListaNodos.Add(n.Izquierdo != null ? n.Izquierdo : new Nodo("@"));
                    auxListaNodos.Add(n.Derecho != null ? n.Derecho : new Nodo("@"));
                }
                AmplitudRecursiva(auxListaNodos, pCajaTexto);
               
            }
        }
        private void PreOrdenRecursiva2(Nodo pNodo, List<Nodo> pListaNodos)
        {
            if (pNodo != null)
            {
                pListaNodos.Add(new Nodo(pNodo.Id));
                PreOrdenRecursiva2(pNodo.Izquierdo, pListaNodos);
                PreOrdenRecursiva2(pNodo.Derecho, pListaNodos);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                textBox1.Clear();
                PreOrdenRecursiva(nA,textBox1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void PreOrdenRecursiva(Nodo pNodo, TextBox pCajaTexto)
        {
            if(pNodo!=null)
            {
                pCajaTexto.Text += $"{pNodo.Id} ";
                PreOrdenRecursiva(pNodo.Izquierdo, pCajaTexto);
                PreOrdenRecursiva(pNodo.Derecho, pCajaTexto);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nF = new Nodo("F");
            nE = new Nodo("E");
            nD = new Nodo("D");
            nC = new Nodo("C",nE,nF);
            nB = new Nodo("B",null, nD);
            nA = new Nodo("A", nB, nC);

            treeView1.ExpandAll();

        }
    }
    public class Nodo
    {
        public Nodo(string pId="",Nodo pIzq=null,Nodo pDer=null) { Id = pId;Izquierdo = pIzq;Derecho = pDer; }
        public string Id { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }
    }
}
