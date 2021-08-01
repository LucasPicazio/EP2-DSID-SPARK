namespace EP2
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMedia = new System.Windows.Forms.Button();
            this.btnVariancia = new System.Windows.Forms.Button();
            this.btnDesvio = new System.Windows.Forms.Button();
            this.btnQuadrados = new System.Windows.Forms.Button();
            this.cbYears = new System.Windows.Forms.CheckedListBox();
            this.cbStations = new System.Windows.Forms.CheckedListBox();
            this.cbData1 = new System.Windows.Forms.ComboBox();
            this.cbData2 = new System.Windows.Forms.ComboBox();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.chart1 = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Anos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Estações";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(437, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dado analisado 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(655, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dado analisado 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(836, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Agrupamento";
            // 
            // btnMedia
            // 
            this.btnMedia.Location = new System.Drawing.Point(15, 124);
            this.btnMedia.Name = "btnMedia";
            this.btnMedia.Size = new System.Drawing.Size(75, 23);
            this.btnMedia.TabIndex = 11;
            this.btnMedia.Text = "Média";
            this.btnMedia.UseVisualStyleBackColor = true;
            this.btnMedia.Click += new System.EventHandler(this.btnMedia_Click);
            // 
            // btnVariancia
            // 
            this.btnVariancia.Location = new System.Drawing.Point(165, 124);
            this.btnVariancia.Name = "btnVariancia";
            this.btnVariancia.Size = new System.Drawing.Size(75, 23);
            this.btnVariancia.TabIndex = 12;
            this.btnVariancia.Text = "Variancia";
            this.btnVariancia.UseVisualStyleBackColor = true;
            this.btnVariancia.Click += new System.EventHandler(this.btnVariancia_Click);
            // 
            // btnDesvio
            // 
            this.btnDesvio.Location = new System.Drawing.Point(315, 124);
            this.btnDesvio.Name = "btnDesvio";
            this.btnDesvio.Size = new System.Drawing.Size(121, 23);
            this.btnDesvio.TabIndex = 13;
            this.btnDesvio.Text = "Desvio Padrão";
            this.btnDesvio.UseVisualStyleBackColor = true;
            this.btnDesvio.Click += new System.EventHandler(this.btnDesvio_Click);
            // 
            // btnQuadrados
            // 
            this.btnQuadrados.Location = new System.Drawing.Point(476, 124);
            this.btnQuadrados.Name = "btnQuadrados";
            this.btnQuadrados.Size = new System.Drawing.Size(157, 23);
            this.btnQuadrados.TabIndex = 14;
            this.btnQuadrados.Text = "Quadrados Minimos";
            this.btnQuadrados.UseVisualStyleBackColor = true;
            this.btnQuadrados.Click += new System.EventHandler(this.btnQuadrados_Click);
            // 
            // cbYears
            // 
            this.cbYears.FormattingEnabled = true;
            this.cbYears.Location = new System.Drawing.Point(15, 29);
            this.cbYears.Name = "cbYears";
            this.cbYears.Size = new System.Drawing.Size(120, 89);
            this.cbYears.TabIndex = 16;
            this.cbYears.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cbYears_ItemCheck);
            // 
            // cbStations
            // 
            this.cbStations.FormattingEnabled = true;
            this.cbStations.Location = new System.Drawing.Point(165, 29);
            this.cbStations.Name = "cbStations";
            this.cbStations.Size = new System.Drawing.Size(248, 89);
            this.cbStations.TabIndex = 17;
            // 
            // cbData1
            // 
            this.cbData1.FormattingEnabled = true;
            this.cbData1.Location = new System.Drawing.Point(435, 39);
            this.cbData1.Name = "cbData1";
            this.cbData1.Size = new System.Drawing.Size(188, 24);
            this.cbData1.TabIndex = 18;
            // 
            // cbData2
            // 
            this.cbData2.FormattingEnabled = true;
            this.cbData2.Location = new System.Drawing.Point(653, 39);
            this.cbData2.Name = "cbData2";
            this.cbData2.Size = new System.Drawing.Size(162, 24);
            this.cbData2.TabIndex = 19;
            // 
            // cbGroup
            // 
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(839, 39);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(157, 24);
            this.cbGroup.TabIndex = 20;
            // 
            // chart1
            // 
            this.chart1.Location = new System.Drawing.Point(15, 183);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1047, 371);
            this.chart1.TabIndex = 21;
            this.chart1.Text = "cartesianChart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 566);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.cbGroup);
            this.Controls.Add(this.cbData2);
            this.Controls.Add(this.cbData1);
            this.Controls.Add(this.cbStations);
            this.Controls.Add(this.cbYears);
            this.Controls.Add(this.btnQuadrados);
            this.Controls.Add(this.btnDesvio);
            this.Controls.Add(this.btnVariancia);
            this.Controls.Add(this.btnMedia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Ep2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMedia;
        private System.Windows.Forms.Button btnVariancia;
        private System.Windows.Forms.Button btnDesvio;
        private System.Windows.Forms.Button btnQuadrados;
        private System.Windows.Forms.CheckedListBox cbYears;
        private System.Windows.Forms.CheckedListBox cbStations;
        private System.Windows.Forms.ComboBox cbData1;
        private System.Windows.Forms.ComboBox cbData2;
        private System.Windows.Forms.ComboBox cbGroup;
        private LiveCharts.WinForms.CartesianChart chart1;
    }
}

