using Microsoft.EntityFrameworkCore;
using StockBusinessLogic.BindingModels;
using StockBusinessLogic.BusinessLogic;
using StockBusinessLogic.ViewModels;
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
    //public partial class FormClients : Form
    //{
    //    [Dependency]
    //    public new IUnityContainer Container { get; set; }

    //    private readonly ClientBusinessLogic clientLogic;
    //    public int IdForUpd { set { idForUpd = value; } }
    //    private int? idForUpd;

    //    public FormClients(ClientBusinessLogic clLogic)
    //    {
    //        InitializeComponent();
    //        this.clientLogic = clLogic;
    //        LoadData();
    //    }

    //    private void LoadData()
    //    {
    //        try
    //        {
    //            var list = clientLogic.Read(null);
    //            if (list != null)
    //            {
    //                dataGridViewClients.DataSource = list;
    //                dataGridViewClients.Columns[0].Visible = false;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(ex.Message, "Ошибка загрузки данных по клиентам", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }

    //    private void ButtonAdd_Click(object sender, EventArgs e)
    //    {
    //        ClearForms();
    //        //groupBoxCreateUpdate.Visible = true;
    //        LoadDataForCrOrUpd();
    //    }

    //    private void ButtonUpd_Click(object sender, EventArgs e)
    //    {
    //        if (dataGridViewClients.SelectedRows.Count == 1)
    //        {
    //            IdForUpd = Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells[0].Value);
    //            //groupBoxCreateUpdate.Visible = true;
    //            LoadDataForCrOrUpd();
    //        }
    //    }

    //    private void ButtonDel_Click(object sender, EventArgs e)
    //    {
    //        if (dataGridViewClients.SelectedRows.Count == 1)
    //        {
    //            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    //            {
    //                int id = Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells[0].Value);
    //                try
    //                {
    //                    clientLogic.Delete(new ClientBindingModel { Id = id });
    //                }
    //                catch (Exception ex)
    //                {
    //                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //                }
    //                LoadData();
    //            }
    //        }
    //        ClearForms();
    //    }

    //    private void ButtonRefr_Click(object sender, EventArgs e)
    //    {
    //        ClearForms();
    //        LoadData();
    //    }

    //    private void ButtonSave_Click(object sender, EventArgs e)
    //    {
    //        if (string.IsNullOrEmpty(textBoxClientName.Text) ||
    //            string.IsNullOrEmpty(textBoxClientPhone.Text))
    //        {
    //            MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            return;
    //        }

    //        try
    //        {
    //            clientLogic.CreateOrUpdate(new ClientBindingModel
    //            {
    //                Id = idForUpd,
    //                FIO = textBoxClientName.Text,
    //                Telephone =Convert.ToInt32(textBoxClientPhone.Text)
    //            });
    //            MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //        ClearForms();
    //        LoadData();
    //    }

    //    private void ButtonCancel_Click(object sender, EventArgs e)
    //    {
    //        ClearForms();
    //        LoadData();
    //    }

    //    private void LoadDataForCrOrUpd()
    //    {
    //        if (idForUpd.HasValue)
    //        {
    //            try
    //            {
    //                var view = clientLogic.Read(new ClientBindingModel { Id = idForUpd })?[0];
    //                if (view != null)
    //                {
    //                    textBoxClientName.Text = view.FIO;
    //                    textBoxClientPhone.Text =Convert.ToString(view.Telephone);
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            }
    //        }
    //    }

    //    private void ClearForms()
    //    {
    //        textBoxClientName.Text = null;
    //        textBoxClientPhone.Text = null;
    //        idForUpd = null;
    //        //groupBoxCreateUpdate.Visible = false;
    //    }

    //}


    public partial class FormClients : Form
    {

        public int Id { set { id = value; } }
        private int? id;

        private readonly ClientBusinessLogic logic;

        public FormClients(ClientBusinessLogic logicА)
        {
            logic = logicА;
            InitializeComponent();
        }

        ClientViewModel view;

        private void FormClient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    view = logic.Read(new ClientBindingModel { Id = id })?[0];

                    if (view != null)
                    {
                        textBoxClientName.Text = view.FIO;
                        textBoxClientPhone.Text = Convert.ToString(view.Telephone);

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxClientName.Text))
            {
                MessageBox.Show("Заполните имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxClientPhone.Text))
            {
                MessageBox.Show("Заполните фамилию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                if (view != null)
                {
                    logic.CreateOrUpdate(new ClientBindingModel
                    {
                        Id = view.Id,
                        FIO = textBoxClientName.Text,
                        Telephone = Convert.ToInt32(textBoxClientPhone.Text),
                    });
                }
                else
                {
                    logic.CreateOrUpdate(new ClientBindingModel
                    {
                        FIO = textBoxClientName.Text,
                        Telephone = Convert.ToInt32(textBoxClientPhone.Text),
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (DbUpdateException exe)
            {
                MessageBox.Show(exe?.InnerException?.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
