using Entities;
using PressureMVP.Views.ListViews.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PressureMVP.Views.ListViews.Views
{
    public partial class ListView : Form
    {
        private ListController _controller;

        public ListView()
        {
            InitializeComponent();

            if (DesignMode)
                return;

            _controller = new ListController(this);
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
