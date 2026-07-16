namespace Estadisticas.Presentation
{
    partial class FormEstadisticas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimeFinEstadisticas = new System.Windows.Forms.DateTimePicker();
            this.dateTimeInicioEstadisticas = new System.Windows.Forms.DateTimePicker();
            this.textBoxFiltroPaciente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.dataGridViewEstadisticas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chartPatologia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimeFinGrafica = new System.Windows.Forms.DateTimePicker();
            this.dateTimeInicioGrafica = new System.Windows.Forms.DateTimePicker();
            this.buttonGrafica = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEstadisticas)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPatologia)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.label1);
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
            this.tabPage1.Text = "Estadísticas de Diagnóstico";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dateTimeFinEstadisticas);
            this.panel2.Controls.Add(this.dateTimeInicioEstadisticas);
            this.panel2.Controls.Add(this.textBoxFiltroPaciente);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.buttonBuscar);
            this.panel2.Controls.Add(this.dataGridViewEstadisticas);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(7, 7);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(963, 528);
            this.panel2.TabIndex = 5;
            // 
            // dateTimeFinEstadisticas
            // 
            this.dateTimeFinEstadisticas.Location = new System.Drawing.Point(510, 16);
            this.dateTimeFinEstadisticas.Name = "dateTimeFinEstadisticas";
            this.dateTimeFinEstadisticas.Size = new System.Drawing.Size(200, 22);
            this.dateTimeFinEstadisticas.TabIndex = 80;
            // 
            // dateTimeInicioEstadisticas
            // 
            this.dateTimeInicioEstadisticas.Location = new System.Drawing.Point(120, 16);
            this.dateTimeInicioEstadisticas.Name = "dateTimeInicioEstadisticas";
            this.dateTimeInicioEstadisticas.Size = new System.Drawing.Size(200, 22);
            this.dateTimeInicioEstadisticas.TabIndex = 79;
            // 
            // textBoxFiltroPaciente
            // 
            this.textBoxFiltroPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFiltroPaciente.Location = new System.Drawing.Point(120, 46);
            this.textBoxFiltroPaciente.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFiltroPaciente.Name = "textBoxFiltroPaciente";
            this.textBoxFiltroPaciente.Size = new System.Drawing.Size(590, 29);
            this.textBoxFiltroPaciente.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 24);
            this.label4.TabIndex = 77;
            this.label4.Text = "Paciente:";
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscar.Location = new System.Drawing.Point(834, 4);
            this.buttonBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(125, 46);
            this.buttonBuscar.TabIndex = 19;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // dataGridViewEstadisticas
            // 
            this.dataGridViewEstadisticas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEstadisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEstadisticas.Location = new System.Drawing.Point(9, 83);
            this.dataGridViewEstadisticas.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewEstadisticas.Name = "dataGridViewEstadisticas";
            this.dataGridViewEstadisticas.ReadOnly = true;
            this.dataGridViewEstadisticas.RowHeadersWidth = 51;
            this.dataGridViewEstadisticas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEstadisticas.Size = new System.Drawing.Size(950, 441);
            this.dataGridViewEstadisticas.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(435, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Desde:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(977, 542);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gráficas de Patología";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.chartPatologia);
            this.panel3.Controls.Add(this.dateTimeFinGrafica);
            this.panel3.Controls.Add(this.dateTimeInicioGrafica);
            this.panel3.Controls.Add(this.buttonGrafica);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(7, 7);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(963, 528);
            this.panel3.TabIndex = 6;
            // 
            // chartPatologia
            // 
            this.chartPatologia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartPatologia.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPatologia.Legends.Add(legend1);
            this.chartPatologia.Location = new System.Drawing.Point(8, 83);
            this.chartPatologia.Name = "chartPatologia";
            this.chartPatologia.Size = new System.Drawing.Size(951, 441);
            this.chartPatologia.TabIndex = 81;
            this.chartPatologia.Text = "chart1";
            // 
            // dateTimeFinGrafica
            // 
            this.dateTimeFinGrafica.Location = new System.Drawing.Point(510, 16);
            this.dateTimeFinGrafica.Name = "dateTimeFinGrafica";
            this.dateTimeFinGrafica.Size = new System.Drawing.Size(200, 22);
            this.dateTimeFinGrafica.TabIndex = 80;
            // 
            // dateTimeInicioGrafica
            // 
            this.dateTimeInicioGrafica.Location = new System.Drawing.Point(120, 16);
            this.dateTimeInicioGrafica.Name = "dateTimeInicioGrafica";
            this.dateTimeInicioGrafica.Size = new System.Drawing.Size(200, 22);
            this.dateTimeInicioGrafica.TabIndex = 79;
            // 
            // buttonGrafica
            // 
            this.buttonGrafica.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGrafica.Location = new System.Drawing.Point(834, 4);
            this.buttonGrafica.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGrafica.Name = "buttonGrafica";
            this.buttonGrafica.Size = new System.Drawing.Size(125, 46);
            this.buttonGrafica.TabIndex = 19;
            this.buttonGrafica.Text = "Buscar";
            this.buttonGrafica.UseVisualStyleBackColor = true;
            this.buttonGrafica.Click += new System.EventHandler(this.buttonGrafica_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(435, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "Hasta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Desde:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 29);
            this.label1.TabIndex = 75;
            this.label1.Text = "Estadísticas";
            // 
            // FormEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 631);
            this.Controls.Add(this.panel1);
            this.Name = "FormEstadisticas";
            this.Text = "FormEstadisticas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEstadisticas)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPatologia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.DataGridView dataGridViewEstadisticas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimeFinEstadisticas;
        private System.Windows.Forms.DateTimePicker dateTimeInicioEstadisticas;
        private System.Windows.Forms.TextBox textBoxFiltroPaciente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPatologia;
        private System.Windows.Forms.DateTimePicker dateTimeFinGrafica;
        private System.Windows.Forms.DateTimePicker dateTimeInicioGrafica;
        private System.Windows.Forms.Button buttonGrafica;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}