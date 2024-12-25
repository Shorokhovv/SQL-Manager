namespace SQL_Manager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Tables_ListBox = new System.Windows.Forms.ListBox();
            this.Create_AtSQL = new System.Windows.Forms.Button();
            this.Override_AtSQL = new System.Windows.Forms.Button();
            this.Find_AtSQL = new System.Windows.Forms.Button();
            this.Delete_AtSQL = new System.Windows.Forms.Button();
            this.BackUp_AtSQL = new System.Windows.Forms.Button();
            this.Create_tt = new System.Windows.Forms.ToolTip(this.components);
            this.Override_tt = new System.Windows.Forms.ToolTip(this.components);
            this.Find_tt = new System.Windows.Forms.ToolTip(this.components);
            this.Delete_tt = new System.Windows.Forms.ToolTip(this.components);
            this.BackUp_tt = new System.Windows.Forms.ToolTip(this.components);
            this.Reset_ListBox = new System.Windows.Forms.Button();
            this.Load_XLS = new System.Windows.Forms.Button();
            this.DataGridView_SQL = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_SQL)).BeginInit();
            this.SuspendLayout();
            // 
            // Tables_ListBox
            // 
            this.Tables_ListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Tables_ListBox.ForeColor = System.Drawing.Color.White;
            this.Tables_ListBox.FormattingEnabled = true;
            this.Tables_ListBox.ItemHeight = 16;
            this.Tables_ListBox.Location = new System.Drawing.Point(864, 9);
            this.Tables_ListBox.Margin = new System.Windows.Forms.Padding(0);
            this.Tables_ListBox.Name = "Tables_ListBox";
            this.Tables_ListBox.Size = new System.Drawing.Size(194, 420);
            this.Tables_ListBox.TabIndex = 1;
            this.Tables_ListBox.SelectedIndexChanged += new System.EventHandler(this.Tables_ListBox_SelectedIndexChanged);
            // 
            // Create_AtSQL
            // 
            this.Create_AtSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Create_AtSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create_AtSQL.Location = new System.Drawing.Point(9, 434);
            this.Create_AtSQL.Name = "Create_AtSQL";
            this.Create_AtSQL.Size = new System.Drawing.Size(97, 28);
            this.Create_AtSQL.TabIndex = 2;
            this.Create_AtSQL.Text = "Create";
            this.Create_tt.SetToolTip(this.Create_AtSQL, "Добавить новый элемент");
            this.Create_AtSQL.UseVisualStyleBackColor = false;
            this.Create_AtSQL.Click += new System.EventHandler(this.Create_AtSQL_Click);
            // 
            // Override_AtSQL
            // 
            this.Override_AtSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Override_AtSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Override_AtSQL.Location = new System.Drawing.Point(9, 468);
            this.Override_AtSQL.Name = "Override_AtSQL";
            this.Override_AtSQL.Size = new System.Drawing.Size(97, 28);
            this.Override_AtSQL.TabIndex = 3;
            this.Override_AtSQL.Text = "Override";
            this.Override_tt.SetToolTip(this.Override_AtSQL, "Перезаписать элемент");
            this.Override_AtSQL.UseVisualStyleBackColor = false;
            this.Override_AtSQL.Click += new System.EventHandler(this.Override_AtSQL_Click);
            // 
            // Find_AtSQL
            // 
            this.Find_AtSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Find_AtSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Find_AtSQL.Location = new System.Drawing.Point(9, 502);
            this.Find_AtSQL.Name = "Find_AtSQL";
            this.Find_AtSQL.Size = new System.Drawing.Size(97, 28);
            this.Find_AtSQL.TabIndex = 4;
            this.Find_AtSQL.Text = "Find";
            this.Find_tt.SetToolTip(this.Find_AtSQL, "Найти все совпадения");
            this.Find_AtSQL.UseVisualStyleBackColor = false;
            this.Find_AtSQL.Click += new System.EventHandler(this.Find_AtSQL_Click);
            // 
            // Delete_AtSQL
            // 
            this.Delete_AtSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Delete_AtSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete_AtSQL.Location = new System.Drawing.Point(9, 536);
            this.Delete_AtSQL.Name = "Delete_AtSQL";
            this.Delete_AtSQL.Size = new System.Drawing.Size(97, 28);
            this.Delete_AtSQL.TabIndex = 5;
            this.Delete_AtSQL.Text = "Delete";
            this.Delete_tt.SetToolTip(this.Delete_AtSQL, "Удалить элемент");
            this.Delete_AtSQL.UseVisualStyleBackColor = false;
            this.Delete_AtSQL.Click += new System.EventHandler(this.Delete_AtSQL_Click);
            // 
            // BackUp_AtSQL
            // 
            this.BackUp_AtSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BackUp_AtSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackUp_AtSQL.Location = new System.Drawing.Point(961, 536);
            this.BackUp_AtSQL.Name = "BackUp_AtSQL";
            this.BackUp_AtSQL.Size = new System.Drawing.Size(97, 28);
            this.BackUp_AtSQL.TabIndex = 6;
            this.BackUp_AtSQL.Text = "BackUp";
            this.BackUp_tt.SetToolTip(this.BackUp_AtSQL, "Сохранить базу данных");
            this.BackUp_AtSQL.UseVisualStyleBackColor = false;
            this.BackUp_AtSQL.Click += new System.EventHandler(this.BackUp_AtSQL_Click);
            // 
            // Reset_ListBox
            // 
            this.Reset_ListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Reset_ListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Reset_ListBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Reset_ListBox.FlatAppearance.BorderSize = 0;
            this.Reset_ListBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reset_ListBox.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Reset_ListBox.Location = new System.Drawing.Point(1018, 430);
            this.Reset_ListBox.Margin = new System.Windows.Forms.Padding(0);
            this.Reset_ListBox.Name = "Reset_ListBox";
            this.Reset_ListBox.Size = new System.Drawing.Size(37, 39);
            this.Reset_ListBox.TabIndex = 7;
            this.Reset_ListBox.Text = "🔄";
            this.Reset_ListBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BackUp_tt.SetToolTip(this.Reset_ListBox, "Сделать .bak копию базы данных");
            this.Reset_ListBox.UseVisualStyleBackColor = false;
            this.Reset_ListBox.Click += new System.EventHandler(this.Reset_ListBox_Click);
            // 
            // Load_XLS
            // 
            this.Load_XLS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Load_XLS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Load_XLS.Location = new System.Drawing.Point(830, 536);
            this.Load_XLS.Name = "Load_XLS";
            this.Load_XLS.Size = new System.Drawing.Size(97, 28);
            this.Load_XLS.TabIndex = 10;
            this.Load_XLS.Text = "Load file";
            this.BackUp_tt.SetToolTip(this.Load_XLS, "Сохранить базу данных");
            this.Load_XLS.UseVisualStyleBackColor = false;
            this.Load_XLS.Visible = false;
            this.Load_XLS.Click += new System.EventHandler(this.Load_XLS_Click);
            // 
            // DataGridView_SQL
            // 
            this.DataGridView_SQL.AllowUserToAddRows = false;
            this.DataGridView_SQL.AllowUserToDeleteRows = false;
            this.DataGridView_SQL.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.DataGridView_SQL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridView_SQL.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_SQL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.DataGridView_SQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_SQL.DefaultCellStyle = dataGridViewCellStyle14;
            this.DataGridView_SQL.EnableHeadersVisualStyles = false;
            this.DataGridView_SQL.GridColor = System.Drawing.Color.White;
            this.DataGridView_SQL.Location = new System.Drawing.Point(9, 9);
            this.DataGridView_SQL.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridView_SQL.MultiSelect = false;
            this.DataGridView_SQL.Name = "DataGridView_SQL";
            this.DataGridView_SQL.ReadOnly = true;
            this.DataGridView_SQL.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_SQL.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DataGridView_SQL.RowHeadersWidth = 51;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.Transparent;
            this.DataGridView_SQL.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.DataGridView_SQL.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.DataGridView_SQL.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridView_SQL.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.DataGridView_SQL.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridView_SQL.RowTemplate.Height = 24;
            this.DataGridView_SQL.Size = new System.Drawing.Size(853, 420);
            this.DataGridView_SQL.TabIndex = 8;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1067, 572);
            this.Controls.Add(this.Load_XLS);
            this.Controls.Add(this.DataGridView_SQL);
            this.Controls.Add(this.Reset_ListBox);
            this.Controls.Add(this.BackUp_AtSQL);
            this.Controls.Add(this.Delete_AtSQL);
            this.Controls.Add(this.Find_AtSQL);
            this.Controls.Add(this.Override_AtSQL);
            this.Controls.Add(this.Create_AtSQL);
            this.Controls.Add(this.Tables_ListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "SQL Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_SQL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox Tables_ListBox;
        private System.Windows.Forms.Button Create_AtSQL;
        private System.Windows.Forms.Button Override_AtSQL;
        private System.Windows.Forms.Button Find_AtSQL;
        private System.Windows.Forms.Button Delete_AtSQL;
        private System.Windows.Forms.Button BackUp_AtSQL;
        private System.Windows.Forms.ToolTip Create_tt;
        private System.Windows.Forms.ToolTip Override_tt;
        private System.Windows.Forms.ToolTip Find_tt;
        private System.Windows.Forms.ToolTip Delete_tt;
        private System.Windows.Forms.ToolTip BackUp_tt;
        private System.Windows.Forms.Button Reset_ListBox;
        private System.Windows.Forms.DataGridView DataGridView_SQL;
        private System.Windows.Forms.Button Load_XLS;
    }
}

