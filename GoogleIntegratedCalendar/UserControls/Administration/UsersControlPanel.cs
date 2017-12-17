using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Enums;
using EZKO.Forms.AdministrationForms;
using EZKO.Controllers;
using ExceptionHandler;

namespace EZKO.UserControls.Administration
{
    public partial class UsersControlPanel : UserControl
    {
        private EzkoController ezkoController;

        public UsersControlPanel()
        {
            InitializeComponent();

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.GridColor = Color.White;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            ezkoController = GlobalSettings.EzkoController;
            InitializeDataGridView();
            FillDataGridView();
        }

        #region Public methods
        public void UpdateControl()
        {
            FillDataGridView();
        }
        #endregion

        #region Private methods
        private void InitializeDataGridView()
        {
            DataGridViewTextBoxColumn userIDColumn = new DataGridViewTextBoxColumn()
            {
                Name = "ID",
                HeaderText = "ID",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            userIDColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add(userIDColumn);

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn()
            {
                Name = "Image",
                HeaderText = "",
                ImageLayout = DataGridViewImageCellLayout.Stretch,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 50
            };
            dataGridView.Columns.Add(imageColumn);

            DataGridViewTextBoxColumn userNameColumn = new DataGridViewTextBoxColumn()
            {
                Name = "UserName",
                HeaderText = "Používateľské meno",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25,
            };
            dataGridView.Columns.Add(userNameColumn);

            DataGridViewTextBoxColumn userRoleColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Role",
                HeaderText = "Rola",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                //FillWeight = 25,
            };
            dataGridView.Columns.Add(userRoleColumn);

            DataGridViewTextBoxColumn fillEmptySpaceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Last",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 50,
            };
            dataGridView.Columns.Add(fillEmptySpaceColumn);

            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn()
            {
                Name = "Edit",
                HeaderText = "Akcie",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            editColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorBlue;
            editColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorBlue;
            dataGridView.Columns.Add(editColumn);

            DataGridViewButtonColumn removeColumn = new DataGridViewButtonColumn()
            {
                Name = "Remove",
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            removeColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorRed;
            removeColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorRed;
            dataGridView.Columns.Add(removeColumn);
        }

        private void FillDataGridView()
        {
            dataGridView.Rows.Clear();

            foreach (var item in ezkoController.GetUsers())
            {
                int rowIndex = dataGridView.Rows.Add(new object[]
                { item.ID, DirectoriesController.GetImage(item.AvatarImagePath, Properties.Resources.noUserImage), item.Login, GetRoleName(item.RoleID), "", "Upraviť", "Zmazať", " " });
                dataGridView.Rows[rowIndex].Tag = item;
            }
        }

        private string GetRoleName(int userRoleID)
        {
            string result = "";

            switch (userRoleID)
            {
                case (int)UserRoleEnum.Doctor:
                    result = "Doktor";
                    break;
                case (int)UserRoleEnum.Nurse:
                    result = "Sestra";
                    break;
                case (int)UserRoleEnum.Manager:
                    result = "Manažér";
                    break;
                case (int)UserRoleEnum.Administrator:
                    result = "Administrátor";
                    break;
                default:
                    result = "Neznáma rola";
                    break;
            }

            return result;
        }

        private void EditItem(DatabaseCommunicator.Model.User user)
        {
            EditUserForm form = new EditUserForm(user);
            if (form.ShowDialog() == DialogResult.OK)
                FillDataGridView();
        }

        private void RemoveItem(DatabaseCommunicator.Model.User user)
        {
            if(MessageBox.Show("Naozaj si želáte odstrániť používateľa " + user.Login, "?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!ezkoController.RemoveUser(user))
                    BasicMessagesHandler.ShowErrorMessage("Používateľa sa nepodarilo odstrániť");
                else
                    FillDataGridView();
            }
        }
        #endregion

        #region UI events
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DatabaseCommunicator.Model.User item = senderGrid.Rows[e.RowIndex].Tag as DatabaseCommunicator.Model.User;
                if (senderGrid.Columns[e.ColumnIndex].Name == "Edit")
                    EditItem(item);
                else if (senderGrid.Columns[e.ColumnIndex].Name == "Remove")
                    RemoveItem(item);
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                DatabaseCommunicator.Model.User user = senderGrid.Rows[e.RowIndex].Tag as DatabaseCommunicator.Model.User;
                EditItem(user);
            }
        }
        #endregion
    }
}
