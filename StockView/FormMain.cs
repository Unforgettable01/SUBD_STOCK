using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace StockView
{
    public partial class FormMain : Form
    {
        [Dependency]

        public new IUnityContainer Container { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void toolStripMenuItemProduct_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormProduct>();
            form.ShowDialog();
        }

        private void ToolStripMenuWorker_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormWorkers>();
            form.ShowDialog();
        }

        private void ToolStripMenuItemClients_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void ToolStripMenuItemNPP_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormNPP>();
            form.ShowDialog();
        }

        private void ToolStripMenuItemPN_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPN>();
            form.ShowDialog();
        }
    }
}
