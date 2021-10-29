using ApplicationLibrary.Services;
using Entities;
using PressureMVP.Views.AddEditViews.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PressureMVP.Views.AddEditViews.Views
{
    public partial class AddEditView : Form
    {
        private AddEditController _controller;

        public AddEditView()
        {
            InitializeComponent();

            if (DesignMode)
                return;

            _controller = new AddEditController(this);
        }

        public Pressure SetObjectToEdit
        {
            get
            {
                return _controller.SetPressure;
            }
            set
            {
                _controller.SetPressure = value;
            }
        }

    }
}
