using Entities;
using PressureMVP.Views.AddEditViews.Views;
using PressureMVP.Views.MainViews.Views;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PressureMVP.Views.MainViews.Models;
using ApplicationLibrary.Services;

namespace PressureMVP.Views.MainViews.Controllers
{
    public class MainController
    {
        private readonly MainView _view;
        private MainModel _model;

        public MainController(MainView view)
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
            _model = new MainModel();
            await Task.CompletedTask;
        }

        public async Task InitView()
        {
            _view.buttonList.Click += (object sender, EventArgs e) =>
            {
                var view = new PressureMVP.Views.ListViews.Views.ListView();
                view.ShowDialog();
                if(view.DialogResult == DialogResult.OK)
                {
                    view.Close();
                }
            };

            _view.buttonAdd.Click += (object sender, EventArgs e) =>
            {
                var view = new AddEditView();
                view.SetObjectToEdit = new Pressure();
                view.ShowDialog();
                if(view.DialogResult == DialogResult.OK)
                {
                    var pressure = view.SetObjectToEdit;
                    Task.Run(async () => await _model.AddPressure(pressure)).Wait(); 
                }
            };

            _view.buttonExit.Click += (object sender, EventArgs e) =>
            {
                _view.Close();
            };
            await Task.CompletedTask;
        }


    }
}
