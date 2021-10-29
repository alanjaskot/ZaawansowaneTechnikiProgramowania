using Entities;
using PressureMVP.Views.AddEditViews.Views;
using PressureMVP.Views.ListViews.Models;
using PressureMVP.Views.ListViews.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListView = PressureMVP.Views.ListViews.Views.ListView;

namespace PressureMVP.Views.ListViews.Controllers
{
    public class ListController
    {
        private ListView _view;
        private ListModel _model;

        public ListController(ListView view)
        {
            _view = view;

            Task.Run(async () =>
            {
                await InitViewModel();
                await InitView();
            }).Wait();
        }

        public async Task InitViewModel()
        {
            _model = new ListModel();
            await Task.CompletedTask;
        }

        public async Task InitView()
        {
            InitDataGrid();

            _view.buttonBack.Click += (object sender, EventArgs e) =>
            {
                _view.DialogResult = DialogResult.OK;
            };

            _view.buttonDisplay.Click += (object sender, EventArgs e) =>
            {
                if (_view.dateTimePickerDateStart.Value != DateTime.MinValue
                && _view.dateTimePickerDateEnd.Value != DateTime.MinValue)
                    DisplayDataByBothDates(_view.dateTimePickerDateStart.Value, _view.dateTimePickerDateEnd.Value);
 
                if (_view.dateTimePickerDateStart.Value != DateTime.MinValue
                && _view.dateTimePickerDateEnd.Value == DateTime.MinValue)
                   DisplayDataByStartDates(_view.dateTimePickerDateStart.Value);

                if (_view.dateTimePickerDateStart.Value == DateTime.MinValue
                && _view.dateTimePickerDateEnd.Value != DateTime.MinValue)
                    DisplayDataByEndDates(_view.dateTimePickerDateStart.Value);
            };

            _view.buttonDisplayAll.Click += (object sender, EventArgs e) =>
            {
                DisplayAll();
            };

            _view.buttonEdit.Click += (object sender, EventArgs e) =>
            {
                var view = new AddEditView();
                var pressure = PressureForEdit();
                if (pressure != null)
                {
                    view.SetObjectToEdit = pressure;
                    if (view.ShowDialog() == DialogResult.OK)
                    {
                        var pressure2 = view.SetObjectToEdit;
                        if(pressure2 != null)
                        {
                            var result = Task.Run(async () => await _model.UpdatePressure(pressure2)).Result;
                            if (result)
                            {
                                MessageBox.Show("Edycja pomiarów zakończona sukcesen");
                                DisplayAll();
                            }     
                            else
                                MessageBox.Show("Edycja pomiarów zakończona niepowodzeniem, spróbuj jeszcze raz");
                        }
                        else
                        {
                            MessageBox.Show("Edycja pomiarów zakończona niepowodzeniem, spróbuj jeszcze raz");
                        }
                        
                    }
                }
                else
                    MessageBox.Show("Proszę zaznaczyć jeden pomiar do modyfikacji");
            };

            _view.buttonDelete.Click += (object sender, EventArgs e) =>
            {
                var deletes = PressureForDelete();
                
                if(deletes != null)
                {
                    string question = "Czy chcesz usunąć zapisane pomiary w bezpieczny sposób?";
                    string title = "Usuwanie pomiarów ciśnienia";
                    var result = MessageBox.Show(question, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        var deleteList = SoftDelete(deletes);
                        MessageBox.Show($"Podana ilość pomiarów: {deleteList.Count+1} została usunięta");
                    }
                    else
                    {
                        var deleteList = HardDelete(deletes);
                        MessageBox.Show($"Podana ilość pomiarów: {deleteList.Count+1} została usunięta");
                    }
                        
                }
            };

            await Task.CompletedTask;
        }

        private void InitDataGrid()
        {
            var detailDGV = _view.dataGridViewPressureList;

            detailDGV.AllowUserToAddRows = false;
            detailDGV.AutoGenerateColumns = false;
            detailDGV.RowHeadersVisible = false;
            detailDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            detailDGV.Columns.Clear();
            detailDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            detailDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            var dgvTextColumn = default(DataGridViewColumn);

            dgvTextColumn = new DataGridViewTextBoxColumn();
            dgvTextColumn.HeaderText = "ID";
            dgvTextColumn.Name = "ID";
            dgvTextColumn.DataPropertyName = "Id";
            dgvTextColumn.Width = 50;
            dgvTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTextColumn.Visible = false;
            detailDGV.Columns.Add(dgvTextColumn);

            dgvTextColumn = new DataGridViewTextBoxColumn();
            dgvTextColumn.HeaderText = "Lp.";
            dgvTextColumn.Name = "Lp.";
            dgvTextColumn.DataPropertyName = "lp";
            dgvTextColumn.Width = 50;
            dgvTextColumn.Visible = true;
            detailDGV.Columns.Add(dgvTextColumn);

            dgvTextColumn = new DataGridViewTextBoxColumn();
            dgvTextColumn.HeaderText = "Cis. Skurczowe";
            dgvTextColumn.Name = "gorne";
            dgvTextColumn.DataPropertyName = "gorne";
            dgvTextColumn.Width = 150;
            dgvTextColumn.Visible = true;
            detailDGV.Columns.Add(dgvTextColumn);

            dgvTextColumn = new DataGridViewTextBoxColumn();
            dgvTextColumn.HeaderText = "Cis. Rozskurczowe";
            dgvTextColumn.Name = "dolne";
            dgvTextColumn.DataPropertyName = "dolne";
            dgvTextColumn.Width = 150;
            dgvTextColumn.Visible = true;
            detailDGV.Columns.Add(dgvTextColumn);

            dgvTextColumn = new DataGridViewTextBoxColumn();
            dgvTextColumn.HeaderText = "Puls";
            dgvTextColumn.Name = "puls";
            dgvTextColumn.DataPropertyName = "puls";
            dgvTextColumn.Width = 100;
            dgvTextColumn.Visible = true;
            detailDGV.Columns.Add(dgvTextColumn);

            dgvTextColumn = new DataGridViewTextBoxColumn();
            dgvTextColumn.HeaderText = "Data";
            dgvTextColumn.Name = "data";
            dgvTextColumn.DataPropertyName = "date";
            dgvTextColumn.Width = 100;
            dgvTextColumn.Visible = true;
            detailDGV.Columns.Add(dgvTextColumn);

            dgvTextColumn = new DataGridViewTextBoxColumn();
            dgvTextColumn.HeaderText = "Czas";
            dgvTextColumn.Name = "czas";
            dgvTextColumn.DataPropertyName = "time";
            dgvTextColumn.Width = 100;
            dgvTextColumn.Visible = true;
            detailDGV.Columns.Add(dgvTextColumn);

            dgvTextColumn = new DataGridViewCheckBoxColumn();
            dgvTextColumn.HeaderText = "";
            dgvTextColumn.Name = "checked";
            dgvTextColumn.DataPropertyName = "check";
            dgvTextColumn.Width = 50;
            detailDGV.Columns.Add(dgvTextColumn);
        }

        public void DisplayDataByBothDates(DateTime startDate, DateTime endDate)
        {
            _view.dataGridViewPressureList.Rows.Clear();

            var pressures = default(List<Pressure>);
            try
            {
                pressures = Task.Run(async() => await _model.GetPressuresByDates(startDate, endDate)).Result;
                if(pressures != null)
                {
                    int i = 1;
                    foreach(var pressure in pressures)
                    {
                        _view.dataGridViewPressureList.Rows.Add(pressure.Id, i,
                            pressure.SystolicPressure, pressure.DiastolicPressure,
                            pressure.Pulse, pressure.MeasurementDateTime.ToString("dd.MM.yyyy"),
                            pressure.MeasurementDateTime.ToString("HH.mm"));
                        i++;
                    }
                }
            }
            catch
            {
                throw new Exception("ListController.DisplayDataByBothDates");
            }
        }

        public void DisplayDataByStartDates(DateTime startDate)
        {
            _view.dataGridViewPressureList.Rows.Clear();
            DateTime endDate = DateTime.Now;

            var pressures = default(List<Pressure>);
            try
            {
                pressures = Task.Run(async() => await _model.GetPressuresByDates(startDate, endDate)).Result;
                if (pressures != null)
                {
                    int i = 1;
                    foreach (var pressure in pressures)
                    {
                        _view.dataGridViewPressureList.Rows.Add(pressure.Id, i,
                            pressure.SystolicPressure, pressure.DiastolicPressure,
                            pressure.Pulse, pressure.MeasurementDateTime.ToString("dd.MM.yyyy"),
                            pressure.MeasurementDateTime.ToString("HH.mm"));
                        i++;
                    }
                }
            }
            catch
            {
                throw new Exception("ListController.DisplayDataByBothDates");
            }
        }

        public void DisplayDataByEndDates(DateTime endDate)
        {
            _view.dataGridViewPressureList.Rows.Clear();
            DateTime startDate = DateTime.Now.AddYears(-200);

            var pressures = default(List<Pressure>);
            try
            {
                pressures = Task.Run(async() => await _model.GetPressuresByDates(startDate, endDate)).Result;
                if (pressures != null)
                {
                    int i = 1;
                    foreach (var pressure in pressures)
                    {
                        _view.dataGridViewPressureList.Rows.Add(pressure.Id, i,
                            pressure.SystolicPressure, pressure.DiastolicPressure,
                            pressure.Pulse, pressure.MeasurementDateTime.ToString("dd.MM.yyyy"),
                            pressure.MeasurementDateTime.ToString("HH.mm"));
                        i++;
                    }
                }
            }
            catch
            {
                throw new Exception("ListController.DisplayDataByBothDates");
            }
        }

        public void DisplayAll()
        {
            _view.dataGridViewPressureList.Rows.Clear();

            var pressures = default(List<Pressure>);
            try
            {
                pressures = Task.Run(async() => await _model.GetAllPressures()).Result;
                if (pressures != null)
                {
                    int i = 1;
                    foreach (var pressure in pressures)
                    {
                        _view.dataGridViewPressureList.Rows.Add(pressure.Id, i,
                            pressure.SystolicPressure, pressure.DiastolicPressure,
                            pressure.Pulse, pressure.MeasurementDateTime.ToString("dd.MM.yyyy"),
                            pressure.MeasurementDateTime.ToString("HH.mm"));
                        i++;
                    }
                }
            }
            catch
            {
                throw new Exception("ListController.DisplayDataByBothDates");
            }
        }

        public Pressure PressureForEdit()
        {
            var result = default(Pressure);
            int numberOfChecked = 0;


            foreach (DataGridViewRow item in _view.dataGridViewPressureList.SelectedRows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)item.Cells[7];
                if (chk.Selected)
                {
                    numberOfChecked++;
                    Guid id = Guid.Parse(_view.dataGridViewPressureList.Rows[item.Index].Cells[0].Value.ToString());
                    result = _model.GetPressureById(id);
                    if (numberOfChecked >= 2)
                        return null;
                }
                else
                {
                return null;
                }
            }

            return result;
        }

        public List<Pressure> PressureForDelete()
        {
            var result = new List<Pressure>();
            var pressure = default(Pressure);
            int numberOfRows = _view.dataGridViewPressureList.RowCount;


            foreach (DataGridViewRow item in _view.dataGridViewPressureList.SelectedRows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)item.Cells[7];
                if (chk.Selected)
                {
                    Guid id = Guid.Parse(_view.dataGridViewPressureList.Rows[item.Index].Cells[0].Value.ToString());
                    pressure = _model.GetPressureById(id);
                    result.Add(pressure);
                }
                else
                {
                    return null;
                }
            }

            return result;
        }

        public List<Guid> SoftDelete(List<Pressure> pressures)
        {
            var result = default(List<Guid>);
            try
            {
                result = _model.SoftDeletes(pressures).Result;
            }
            catch
            {
                throw new Exception("ListController.SoftDelete");
            }
            return result;
        }

        public List<Guid> HardDelete(List<Pressure> pressures)
        {
            var result = default(List<Guid>);
            try
            {
                result = _model.HardDeletesPressures(pressures).Result;
            }
            catch
            {
                throw new Exception("ListController.SoftDelete");
            }
            return result;
        }

        public Pressure SetPressure
        {
            get
            {
                return _model.Pressure;
            }
            set
            {
                _model.Pressure = value;
            }
        }
    }
}
