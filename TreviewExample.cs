using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class TreviewExample : Form
    {
        List<string> SelectedNodes = new List<string>();
        public TreviewExample()
        {
            InitializeComponent();
        }

        private void TreviewExample_Load(object sender, EventArgs e)
        {
            List<string> Nodes = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                Nodes.Add("Node" + i.ToString());
                treeView1.Nodes.Add(Nodes[i]);
            }

            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getSlected(treeView1.Nodes);
        }

        private void getSlected(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    SelectedNodes.Add(node.Text);
                }
            }

            comboBox1.DataSource = SelectedNodes;
        }
    }
}
