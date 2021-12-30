namespace FuzzyLogic.src
{
    partial class MainWindow
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
            this.varNameTextbox = new System.Windows.Forms.TextBox();
            this.termVarTextbox = new System.Windows.Forms.TextBox();
            this.termNameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.functionTypeBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.varInputCheckbox = new System.Windows.Forms.CheckBox();
            this.addVarButton = new FuzzyLogic.src.CommandButton();
            this.addTermButton = new FuzzyLogic.src.CommandButton();
            this.undoButton = new FuzzyLogic.src.CommandButton();
            this.varsListbox = new System.Windows.Forms.ListBox();
            this.refreshButton = new FuzzyLogic.src.CommandButton();
            this.termsListbox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // varNameTextbox
            // 
            this.varNameTextbox.Location = new System.Drawing.Point(150, 8);
            this.varNameTextbox.Name = "varNameTextbox";
            this.varNameTextbox.Size = new System.Drawing.Size(237, 27);
            this.varNameTextbox.TabIndex = 0;
            // 
            // termVarTextbox
            // 
            this.termVarTextbox.Location = new System.Drawing.Point(586, 12);
            this.termVarTextbox.Name = "termVarTextbox";
            this.termVarTextbox.Size = new System.Drawing.Size(237, 27);
            this.termVarTextbox.TabIndex = 1;
            // 
            // termNameTextbox
            // 
            this.termNameTextbox.Location = new System.Drawing.Point(586, 54);
            this.termNameTextbox.Name = "termNameTextbox";
            this.termNameTextbox.Size = new System.Drawing.Size(237, 27);
            this.termNameTextbox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Имя переменной";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Имя переменной";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(448, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Имя терма";
            // 
            // functionTypeBox
            // 
            this.functionTypeBox.DropDownWidth = 437;
            this.functionTypeBox.FormattingEnabled = true;
            this.functionTypeBox.Location = new System.Drawing.Point(586, 97);
            this.functionTypeBox.Name = "functionTypeBox";
            this.functionTypeBox.Size = new System.Drawing.Size(237, 28);
            this.functionTypeBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Функция терма";
            // 
            // varInputCheckbox
            // 
            this.varInputCheckbox.AutoSize = true;
            this.varInputCheckbox.Location = new System.Drawing.Point(12, 46);
            this.varInputCheckbox.Name = "varInputCheckbox";
            this.varInputCheckbox.Size = new System.Drawing.Size(181, 24);
            this.varInputCheckbox.TabIndex = 10;
            this.varInputCheckbox.Text = "Переменная входная";
            this.varInputCheckbox.UseVisualStyleBackColor = true;
            // 
            // addVarButton
            // 
            this.addVarButton.Location = new System.Drawing.Point(120, 85);
            this.addVarButton.Name = "addVarButton";
            this.addVarButton.Size = new System.Drawing.Size(178, 29);
            this.addVarButton.TabIndex = 11;
            this.addVarButton.Text = "Добавить переменную";
            this.addVarButton.UseVisualStyleBackColor = true;
            // 
            // addTermButton
            // 
            this.addTermButton.Location = new System.Drawing.Point(534, 141);
            this.addTermButton.Name = "addTermButton";
            this.addTermButton.Size = new System.Drawing.Size(229, 29);
            this.addTermButton.TabIndex = 12;
            this.addTermButton.Text = "Добавить терм переменной";
            this.addTermButton.UseVisualStyleBackColor = true;
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(842, 258);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(190, 29);
            this.undoButton.TabIndex = 13;
            this.undoButton.Text = "Отменить операцию";
            this.undoButton.UseVisualStyleBackColor = true;
            // 
            // varsListbox
            // 
            this.varsListbox.FormattingEnabled = true;
            this.varsListbox.ItemHeight = 20;
            this.varsListbox.Location = new System.Drawing.Point(12, 213);
            this.varsListbox.Name = "varsListbox";
            this.varsListbox.Size = new System.Drawing.Size(375, 184);
            this.varsListbox.TabIndex = 14;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(842, 213);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(190, 29);
            this.refreshButton.TabIndex = 16;
            this.refreshButton.Text = "Обновить";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // termsListbox
            // 
            this.termsListbox.FormattingEnabled = true;
            this.termsListbox.ItemHeight = 20;
            this.termsListbox.Location = new System.Drawing.Point(448, 213);
            this.termsListbox.Name = "termsListbox";
            this.termsListbox.Size = new System.Drawing.Size(375, 184);
            this.termsListbox.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Переменные";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(448, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Термы выбранной переменной";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 415);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.termsListbox);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.varsListbox);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.addTermButton);
            this.Controls.Add(this.addVarButton);
            this.Controls.Add(this.varInputCheckbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.functionTypeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.termNameTextbox);
            this.Controls.Add(this.termVarTextbox);
            this.Controls.Add(this.varNameTextbox);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox varNameTextbox;
        private System.Windows.Forms.TextBox termVarTextbox;
        private System.Windows.Forms.TextBox termNameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox functionTypeBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox varInputCheckbox;
        private CommandButton addVarButton;
        private CommandButton addTermButton;
        private CommandButton undoButton;
        private System.Windows.Forms.ListBox varsListbox;
        private CommandButton refreshButton;
        private System.Windows.Forms.ListBox termsListbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}