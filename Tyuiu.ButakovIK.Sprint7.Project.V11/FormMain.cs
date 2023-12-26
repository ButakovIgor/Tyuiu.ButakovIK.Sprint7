using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.ButakovIK.Sprint7.Project.V11.Lib;

namespace Tyuiu.ButakovIK.Sprint7.Project.V11
{
    public partial class FormMain : Form
    {
        string opened_file_path_ = "";

        public FormMain()
        {
            InitializeComponent();
        }

        DataService ds = new DataService();

        private void ToolStripMenuItemExitElem_BIK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripMenuItemCreateFile_BIK_Click(object sender, EventArgs e)
        {
            DataService ds = new DataService();
            this.dataGridViewTable_BIK.DataSource = ds.CreateEmptyTable();
        }

        private void ToolStripMenuItemOpenElem_BIK_Click(object sender, EventArgs e)
        {
            //dataGridViewTable_BIK
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "%HOMEPATH%"; // Set the initial directory
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"; // Filter for CSV files
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    opened_file_path_ = openFileDialog.FileName;
                    ds.LoadCsvDataToDataGridView(openFileDialog.FileName, this.dataGridViewTable_BIK);
                }
                else
                {
                    return;
                }

            }
        }

        private void ToolStripMenuItemSaveElem_BIK_Click(object sender, EventArgs e)
        {
            if (opened_file_path_ == string.Empty)
            {
                ToolStripMenuItemSaveAsElem_BIK_Click(sender, e);
                return;
            }
            ds.SaveDataGridViewToCsv(opened_file_path_, this.dataGridViewTable_BIK);
        }

        private void ToolStripMenuItemSaveAsElem_BIK_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "%HOMEPATH%"; // Set the initial directory
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"; // Filter for CSV files
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.DefaultExt = "csv"; // Default file extension
                saveFileDialog.AddExtension = true; // Add extension if user does not provide one

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ds.SaveDataGridViewToCsv(saveFileDialog.FileName, this.dataGridViewTable_BIK);
                    opened_file_path_ = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
        }

        private void toolStripTextBoxFind_BIK_TextChanged(object sender, EventArgs e)
        {
            ToolStripTextBox textBox = sender as ToolStripTextBox;
            if (textBox != null)
            {
                string currentText = textBox.Text;
                ds.HighlightRowsWithSearchString(this.dataGridViewTable_BIK, currentText);
            }
        }

        private void buttonAddData_BIK_Click(object sender, EventArgs e)
        {
            DataTable data_source = this.dataGridViewTable_BIK.DataSource as DataTable;
            if (data_source == null)
                return;
            DataRow new_row = data_source.NewRow();
            new_row["Фамилия"] = textBoxSurname_BIK.Text;
            new_row["Имя"] = textBoxName_BIK.Text;
            new_row["Отчество"] = textBoxPatronymic_BIK.Text;
            new_row["Адрес"] = textBoxAdress_BIK.Text;
            new_row["Номер Телефона"] = textBoxPhoneNumber_BIK.Text;
            new_row["Оклад"] = textBoxZP_BIK.Text;
            new_row["Наименование подразделения"] = textBoxSubunit_BIK.Text;
            new_row["Дата рождения"] = dateTimePickerBirthday_BIK.Value.ToShortDateString();
            new_row["Должность"] = textBoxJobTitle_BIK.Text;
            new_row["Отработанные часы"] = 0;
            data_source.Rows.Add(new_row);
        }

        private void buttonDeleteRowData_BIK_Click(object sender, EventArgs e)
        {
            if (dataGridViewTable_BIK.SelectedRows.Count > 0 && !dataGridViewTable_BIK.Rows[dataGridViewTable_BIK.SelectedRows[0].Index].IsNewRow)
            {
                dataGridViewTable_BIK.Rows.RemoveAt(dataGridViewTable_BIK.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления");
            }
        }

        private void dataGridViewTable_BIK_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView != null)
            {
                // Get the row index in the correct format (e.g., "1", "2", etc.)
                string rowIndex = (e.RowIndex + 1).ToString();

                // Determine the display size based on the row index string
                SizeF textSize = e.Graphics.MeasureString(rowIndex, dataGridView.Font);

                // Determine where to draw the text on the row header
                int rowIndexX = Math.Max(0, e.RowBounds.Left + (dataGridView.RowHeadersWidth - (int)textSize.Width) / 2);
                int rowIndexY = e.RowBounds.Top + (dataGridView.RowTemplate.Height - (int)textSize.Height) / 2;

                // Draw the row index
                e.Graphics.DrawString(rowIndex, dataGridView.Font, SystemBrushes.ControlText, rowIndexX, rowIndexY);
            }
        }

        private void buttonAddHours_BIK_Click(object sender, EventArgs e)
        {
            int row_index = 0;
            int hours_number = 0;
            if (!int.TryParse(this.textBoxRows_BIK.Text, out row_index))
            {
                MessageBox.Show("Ошибка при добавлении количества часов\nНомер строки не является числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(this.textBoxHours_BIK.Text, out hours_number))
            {
                MessageBox.Show("Ошибка при добавлении количества часов\nКоличество часов не является числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable ds = this.dataGridViewTable_BIK.DataSource as DataTable;
            if (ds != null)
            {
                if (row_index < 1 || row_index > ds.Rows.Count)
                    return;
                if(ds.Rows[row_index - 1]["Отработанные часы"] != null)
                {
                    ds.Rows[row_index-1]["Отработанные часы"] = int.Parse(ds.Rows[row_index - 1]["Отработанные часы"].ToString()) + hours_number;
                }
                else
                {
                    ds.Rows[row_index - 1]["Отработанные часы"] = hours_number;
                }
            }
        }

        private void dataGridViewTable_BIK_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int rowCount = ((DataGridView)sender).RowCount-1;
            this.textBoxAmountEmployee_BIK.Text = rowCount.ToString();
        }

        private void dataGridViewTable_BIK_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int rowCount = ((DataGridView)sender).RowCount-1;
            this.textBoxAmountEmployee_BIK.Text = rowCount.ToString();
        }

        private void buttonChart_BIK_Click(object sender, EventArgs e)
        {
            chartData_BIK.Series.Clear();
            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Отработанные часы");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            foreach (DataGridViewRow row in this.dataGridViewTable_BIK.Rows)
            {
                if (!row.IsNewRow && row.Cells["Отработанные часы"] != null && row.Cells["Отработанные часы"].Value != null)
                {
                    string label = row.Cells["Фамилия"].Value.ToString();
                    double hours = Convert.ToDouble(row.Cells["Отработанные часы"].Value);
                    series.Points.AddXY(label, hours);
                }
            }
            this.chartData_BIK.Series.Add(series);
        }


        public void SortDataGridViewColumn(DataGridView dataGridView, string columnName, bool ascending)
        {
            if (dataGridView.Columns.Contains(columnName))
            {
                dataGridView.Sort(dataGridView.Columns[columnName], ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
            }
            else
            {
                MessageBox.Show($"Column '{columnName}' not found in the DataGridView.");
            }
        }

        public void FilterDataGridView(DataTable dataTable, string columnName, string filterValue)
        {
            if (dataTable.Columns.Contains(columnName))
                    dataTable.DefaultView.RowFilter = string.Format("Convert([{0}], System.String) LIKE '%{1}%'", columnName, filterValue);
        }

        private void textBoxFilter_BIK_TextChanged(object sender, EventArgs e)
        {
            string column_name = comboBoxFilter_BIK.Text;
            string filter_value = textBoxFilter_BIK.Text;
            DataTable dataTable = (DataTable)dataGridViewTable_BIK.DataSource;
            FilterDataGridView(dataTable, column_name, filter_value);
            
        }

        private void ToolStripMenuItemAboutElem_BIK_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void ToolStripMenuItemTipElem_BIK_Click(object sender, EventArgs e)
        {
            FormTip formTip = new FormTip();
            formTip.ShowDialog();
        }
    }
}