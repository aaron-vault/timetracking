namespace timetrack
{
    partial class Used
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "1. Укажите рабочий период времени",
            "2. Если Вы уходили на обед, поставьте галочку \"Обед\"",
            "3. Нажмите кнопку \"Добавить\"",
            "4. Если появилась ошибка, необходимо добавить рабочий период времени",
            "5. Укажите комментарии к работе",
            "6. Укажите вид работы",
            "7. Для сохранения данных в Excel, в меню нажмите \"Файл\" -> \"Сохранить в Excel\"",
            "8. Для создания отчета, в меню нажмите \"Отчеты\" -> \"Создать\"",
            "9. Для быстрой печати, в меню нажмите \"Отчеты\" -> \"Печать\"",
            "10. Если печать отчета не удалась, смотри пункт 8"});
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(509, 446);
            this.listBox1.TabIndex = 0;
            // 
            // Used
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 470);
            this.Controls.Add(this.listBox1);
            this.Name = "Used";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Описание использования";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
    }
}