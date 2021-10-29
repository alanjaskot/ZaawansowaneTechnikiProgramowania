
namespace PressureMVP.Views.ListViews.Views
{
    partial class ListView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewPressureList = new System.Windows.Forms.DataGridView();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.dateTimePickerDateStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDateEnd = new System.Windows.Forms.DateTimePicker();
            this.labelFromDate = new System.Windows.Forms.Label();
            this.labelToDate = new System.Windows.Forms.Label();
            this.buttonDisplay = new System.Windows.Forms.Button();
            this.buttonDisplayAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPressureList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPressureList
            // 
            this.dataGridViewPressureList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPressureList.Location = new System.Drawing.Point(41, 194);
            this.dataGridViewPressureList.MaximumSize = new System.Drawing.Size(704, 450);
            this.dataGridViewPressureList.MinimumSize = new System.Drawing.Size(704, 450);
            this.dataGridViewPressureList.Name = "dataGridViewPressureList";
            this.dataGridViewPressureList.RowHeadersWidth = 62;
            this.dataGridViewPressureList.RowTemplate.Height = 33;
            this.dataGridViewPressureList.Size = new System.Drawing.Size(704, 450);
            this.dataGridViewPressureList.TabIndex = 0;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(822, 244);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(112, 34);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Edytuj";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(822, 304);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(112, 34);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Usuń";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(822, 610);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(112, 34);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Wyjście";
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerDateStart
            // 
            this.dateTimePickerDateStart.Location = new System.Drawing.Point(41, 108);
            this.dateTimePickerDateStart.Name = "dateTimePickerDateStart";
            this.dateTimePickerDateStart.Size = new System.Drawing.Size(300, 31);
            this.dateTimePickerDateStart.TabIndex = 5;
            // 
            // dateTimePickerDateEnd
            // 
            this.dateTimePickerDateEnd.Location = new System.Drawing.Point(445, 108);
            this.dateTimePickerDateEnd.Name = "dateTimePickerDateEnd";
            this.dateTimePickerDateEnd.Size = new System.Drawing.Size(300, 31);
            this.dateTimePickerDateEnd.TabIndex = 6;
            // 
            // labelFromDate
            // 
            this.labelFromDate.AutoSize = true;
            this.labelFromDate.Location = new System.Drawing.Point(41, 48);
            this.labelFromDate.Name = "labelFromDate";
            this.labelFromDate.Size = new System.Drawing.Size(37, 25);
            this.labelFromDate.TabIndex = 7;
            this.labelFromDate.Text = "Od";
            // 
            // labelToDate
            // 
            this.labelToDate.AutoSize = true;
            this.labelToDate.Location = new System.Drawing.Point(445, 48);
            this.labelToDate.Name = "labelToDate";
            this.labelToDate.Size = new System.Drawing.Size(36, 25);
            this.labelToDate.TabIndex = 8;
            this.labelToDate.Text = "Do";
            // 
            // buttonDisplay
            // 
            this.buttonDisplay.Location = new System.Drawing.Point(822, 39);
            this.buttonDisplay.Name = "buttonDisplay";
            this.buttonDisplay.Size = new System.Drawing.Size(112, 34);
            this.buttonDisplay.TabIndex = 9;
            this.buttonDisplay.Text = "Pokaz";
            this.buttonDisplay.UseVisualStyleBackColor = true;
            // 
            // buttonDisplayAll
            // 
            this.buttonDisplayAll.Location = new System.Drawing.Point(822, 108);
            this.buttonDisplayAll.Name = "buttonDisplayAll";
            this.buttonDisplayAll.Size = new System.Drawing.Size(112, 76);
            this.buttonDisplayAll.TabIndex = 10;
            this.buttonDisplayAll.Text = "Pokaż wszystko";
            this.buttonDisplayAll.UseVisualStyleBackColor = true;
            // 
            // ListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 712);
            this.Controls.Add(this.buttonDisplayAll);
            this.Controls.Add(this.buttonDisplay);
            this.Controls.Add(this.labelToDate);
            this.Controls.Add(this.labelFromDate);
            this.Controls.Add(this.dateTimePickerDateEnd);
            this.Controls.Add(this.dateTimePickerDateStart);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.dataGridViewPressureList);
            this.MaximumSize = new System.Drawing.Size(1000, 768);
            this.MinimumSize = new System.Drawing.Size(1000, 768);
            this.Name = "ListView";
            this.Text = "Pressure App";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPressureList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected internal System.Windows.Forms.Button buttonEdit;
        protected internal System.Windows.Forms.Button buttonDelete;
        protected internal System.Windows.Forms.DataGridView dataGridViewPressureList;
        protected internal System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelFromDate;
        private System.Windows.Forms.Label labelToDate;
        protected internal System.Windows.Forms.Button buttonDisplay;
        protected internal System.Windows.Forms.DateTimePicker dateTimePickerDateStart;
        protected internal System.Windows.Forms.DateTimePicker dateTimePickerDateEnd;
        protected internal System.Windows.Forms.Button buttonDisplayAll;
    }
}