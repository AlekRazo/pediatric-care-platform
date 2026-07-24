namespace Estadisticas.Presentation
{
    partial class FormEstadisticasPaciente
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chartPesoPaciente = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chartTallaPaciente = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelPaciente = new System.Windows.Forms.Label();
            this.labelLimiteTalla = new System.Windows.Forms.Label();
            this.labelLimitePeso = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPesoPaciente)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTallaPaciente)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.labelPaciente);
            this.panel1.Location = new System.Drawing.Point(14, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 606);
            this.panel1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(985, 571);
            this.tabControl1.TabIndex = 76;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(977, 542);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Peso Vs Edad";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.labelLimitePeso);
            this.panel2.Controls.Add(this.chartPesoPaciente);
            this.panel2.Location = new System.Drawing.Point(7, 7);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(963, 528);
            this.panel2.TabIndex = 5;
            // 
            // chartPesoPaciente
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPesoPaciente.ChartAreas.Add(chartArea1);
            this.chartPesoPaciente.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartPesoPaciente.Legends.Add(legend1);
            this.chartPesoPaciente.Location = new System.Drawing.Point(0, 0);
            this.chartPesoPaciente.Name = "chartPesoPaciente";
            this.chartPesoPaciente.Size = new System.Drawing.Size(963, 528);
            this.chartPesoPaciente.TabIndex = 82;
            this.chartPesoPaciente.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(977, 542);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Talla Vs Edad";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.labelLimiteTalla);
            this.panel3.Controls.Add(this.chartTallaPaciente);
            this.panel3.Location = new System.Drawing.Point(7, 7);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(963, 528);
            this.panel3.TabIndex = 6;
            // 
            // chartTallaPaciente
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTallaPaciente.ChartAreas.Add(chartArea2);
            this.chartTallaPaciente.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartTallaPaciente.Legends.Add(legend2);
            this.chartTallaPaciente.Location = new System.Drawing.Point(0, 0);
            this.chartTallaPaciente.Name = "chartTallaPaciente";
            this.chartTallaPaciente.Size = new System.Drawing.Size(963, 528);
            this.chartTallaPaciente.TabIndex = 81;
            this.chartTallaPaciente.Text = "chart1";
            // 
            // labelPaciente
            // 
            this.labelPaciente.AutoSize = true;
            this.labelPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaciente.Location = new System.Drawing.Point(4, 0);
            this.labelPaciente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPaciente.Name = "labelPaciente";
            this.labelPaciente.Size = new System.Drawing.Size(153, 29);
            this.labelPaciente.TabIndex = 75;
            this.labelPaciente.Text = "Estadísticas";
            // 
            // labelLimiteTalla
            // 
            this.labelLimiteTalla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLimiteTalla.AutoSize = true;
            this.labelLimiteTalla.Location = new System.Drawing.Point(916, 512);
            this.labelLimiteTalla.Name = "labelLimiteTalla";
            this.labelLimiteTalla.Size = new System.Drawing.Size(0, 16);
            this.labelLimiteTalla.TabIndex = 7;
            // 
            // labelLimitePeso
            // 
            this.labelLimitePeso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLimitePeso.AutoSize = true;
            this.labelLimitePeso.Location = new System.Drawing.Point(916, 512);
            this.labelLimitePeso.Name = "labelLimitePeso";
            this.labelLimitePeso.Size = new System.Drawing.Size(44, 16);
            this.labelLimitePeso.TabIndex = 83;
            this.labelLimitePeso.Text = "label1";
            // 
            // FormEstadisticasPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 631);
            this.Controls.Add(this.panel1);
            this.Name = "FormEstadisticasPaciente";
            this.Text = "FormEstadisticas";
            this.Load += new System.EventHandler(this.FormEstadisticasPaciente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPesoPaciente)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTallaPaciente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelPaciente;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTallaPaciente;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPesoPaciente;
        private System.Windows.Forms.Label labelLimiteTalla;
        private System.Windows.Forms.Label labelLimitePeso;
    }
}