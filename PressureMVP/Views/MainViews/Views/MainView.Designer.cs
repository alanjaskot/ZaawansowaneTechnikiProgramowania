
namespace PressureMVP.Views.MainViews.Views
{
    partial class MainView
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
            this.labelPressure = new System.Windows.Forms.Label();
            this.buttonList = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPressure
            // 
            this.labelPressure.AutoSize = true;
            this.labelPressure.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPressure.Location = new System.Drawing.Point(68, 83);
            this.labelPressure.Name = "labelPressure";
            this.labelPressure.Size = new System.Drawing.Size(244, 45);
            this.labelPressure.TabIndex = 0;
            this.labelPressure.Text = "PressureApp";
            // 
            // buttonList
            // 
            this.buttonList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonList.Location = new System.Drawing.Point(68, 320);
            this.buttonList.MaximumSize = new System.Drawing.Size(250, 80);
            this.buttonList.MinimumSize = new System.Drawing.Size(250, 80);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(250, 80);
            this.buttonList.TabIndex = 2;
            this.buttonList.Text = "Wszystkie pomiary";
            this.buttonList.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.Location = new System.Drawing.Point(68, 447);
            this.buttonAdd.MaximumSize = new System.Drawing.Size(250, 80);
            this.buttonAdd.MinimumSize = new System.Drawing.Size(250, 80);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(250, 80);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Dodaj pomiar";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonExit.Location = new System.Drawing.Point(68, 569);
            this.buttonExit.MaximumSize = new System.Drawing.Size(250, 80);
            this.buttonExit.MinimumSize = new System.Drawing.Size(250, 80);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(250, 80);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Wyjście";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 712);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonList);
            this.Controls.Add(this.labelPressure);
            this.MaximumSize = new System.Drawing.Size(400, 768);
            this.MinimumSize = new System.Drawing.Size(400, 768);
            this.Name = "MainView";
            this.Text = "PressureApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPressure;
        protected internal System.Windows.Forms.Button buttonList;
        protected internal System.Windows.Forms.Button buttonAdd;
        protected internal System.Windows.Forms.Button buttonExit;
    }
}