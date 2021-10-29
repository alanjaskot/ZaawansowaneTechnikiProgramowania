using Entities;
using PressureMVP.Views.AddEditViews.Models;
using PressureMVP.Views.AddEditViews.Views;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureMVP.Views.AddEditViews.Controllers
{
    public class AddEditController
    {
        private readonly AddEditView _view;
        private AddEditModel _model;

        public AddEditController(AddEditView view)
        {
            _view = view;

            Task.Run(async () =>
            {
                await InitViewModel();
                await InitView();
                await RefreshView();

            }).Wait();
        }

        public async Task InitViewModel()
        {
            _model = new AddEditModel();
            await Task.CompletedTask;
        }

        public async Task InitView()
        {
            _view.buttonOK.Click += (object sender, EventArgs e) =>
            {
                if (Valid())
                {
                    SetPressureModel();
                    _view.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Proszę ponownie sprawdzić dane");
            };

            _view.buttonCancel.Click += (object sender, EventArgs e) => 
            {
                _view.DialogResult = DialogResult.Cancel;
            };

            await Task.CompletedTask;
        }

        public async Task RefreshView()
        {
            if(_model.Pressure != null)
            {
                _view.textBoxSystolicPressure.Text = _model.Pressure.SystolicPressure;
                _view.textBoxDiastolicPressure.Text = _model.Pressure.DiastolicPressure;
                _view.textBoxPulse.Text = _model.Pressure.Pulse;
                _view.dateTimePickerMeasureDate.Value = _model.Pressure.MeasurementDateTime;
            }
            await Task.CompletedTask;
        }

        public void SetPressureModel()
        {
            var pressure = new Pressure();

            if(_model.Pressure.Id != Guid.Empty)
            {
                pressure = new Pressure
                {
                    Id = _model.Pressure.Id,
                    SystolicPressure = _view.textBoxSystolicPressure.Text,
                    DiastolicPressure = _view.textBoxDiastolicPressure.Text,
                    Pulse = _view.textBoxPulse.Text,
                    MeasurementDateTime = _view.dateTimePickerMeasureDate.Value
                };
            }
            else
            {
                pressure = new Pressure
                {
                    Id = Guid.NewGuid(),
                    SystolicPressure = _view.textBoxSystolicPressure.Text,
                    DiastolicPressure = _view.textBoxDiastolicPressure.Text,
                    Pulse = _view.textBoxPulse.Text,
                    MeasurementDateTime = _view.dateTimePickerMeasureDate.Value
                };
            }
            _model.Pressure = pressure;
        }

        public bool Valid()
        {
            var result = false;
            if ((_view.textBoxSystolicPressure.Text != "" || _view.textBoxSystolicPressure.Text != null)
                || (_view.textBoxDiastolicPressure.Text != "" || _view.textBoxDiastolicPressure.Text != null)
                || (_view.textBoxPulse.Text != "" || _view.textBoxPulse != null)
                || (_view.dateTimePickerMeasureDate.Value != DateTime.MinValue))
                result = true;
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
