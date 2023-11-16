namespace NumericTypeSuggesterWinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MinValueInput = new TextBox();
            label1 = new Label();
            label2 = new Label();
            MaxValueInput = new TextBox();
            IntegralOnlyCheckbox = new CheckBox();
            PreciseCheckbox = new CheckBox();
            SuggestedTypeLabel = new Label();
            SuggestedTypeOutput = new Label();
            SuspendLayout();
            // 
            // MinValueInput
            // 
            MinValueInput.Font = new Font("Microsoft Sans Serif", 16F);
            MinValueInput.Location = new Point(318, 196);
            MinValueInput.Name = "MinValueInput";
            MinValueInput.Size = new Size(851, 44);
            MinValueInput.TabIndex = 0;
            MinValueInput.TextChanged += TextBox_TextChanged;
            MinValueInput.KeyPress += TextBox_KeyPressed;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16F);
            label1.Location = new Point(119, 196);
            label1.Name = "label1";
            label1.Size = new Size(161, 37);
            label1.TabIndex = 1;
            label1.Text = "Min value:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 16F);
            label2.Location = new Point(119, 268);
            label2.Name = "label2";
            label2.Size = new Size(169, 37);
            label2.TabIndex = 2;
            label2.Text = "Max value:";
            // 
            // MaxValueInput
            // 
            MaxValueInput.Font = new Font("Microsoft Sans Serif", 16F);
            MaxValueInput.Location = new Point(318, 268);
            MaxValueInput.Name = "MaxValueInput";
            MaxValueInput.Size = new Size(851, 44);
            MaxValueInput.TabIndex = 3;
            MaxValueInput.TextChanged += TextBox_TextChanged;
            MaxValueInput.KeyPress += TextBox_KeyPressed;
            // 
            // IntegralOnlyCheckbox
            // 
            IntegralOnlyCheckbox.AutoSize = true;
            IntegralOnlyCheckbox.CheckAlign = ContentAlignment.MiddleRight;
            IntegralOnlyCheckbox.Checked = true;
            IntegralOnlyCheckbox.CheckState = CheckState.Checked;
            IntegralOnlyCheckbox.Font = new Font("Microsoft Sans Serif", 16F);
            IntegralOnlyCheckbox.Location = new Point(119, 349);
            IntegralOnlyCheckbox.Name = "IntegralOnlyCheckbox";
            IntegralOnlyCheckbox.Size = new Size(233, 41);
            IntegralOnlyCheckbox.TabIndex = 5;
            IntegralOnlyCheckbox.Text = "Integral only?";
            IntegralOnlyCheckbox.UseVisualStyleBackColor = true;
            IntegralOnlyCheckbox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // PreciseCheckbox
            // 
            PreciseCheckbox.AutoSize = true;
            PreciseCheckbox.CheckAlign = ContentAlignment.MiddleRight;
            PreciseCheckbox.Font = new Font("Microsoft Sans Serif", 16F);
            PreciseCheckbox.Location = new Point(119, 414);
            PreciseCheckbox.Name = "PreciseCheckbox";
            PreciseCheckbox.Size = new Size(284, 41);
            PreciseCheckbox.TabIndex = 6;
            PreciseCheckbox.Text = "Must be precise?";
            PreciseCheckbox.TextAlign = ContentAlignment.TopLeft;
            PreciseCheckbox.UseVisualStyleBackColor = true;
            PreciseCheckbox.Visible = false;
            PreciseCheckbox.CheckedChanged += PreciseCheckbox_CheckedChanged;
            // 
            // SuggestedTypeLabel
            // 
            SuggestedTypeLabel.AutoSize = true;
            SuggestedTypeLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            SuggestedTypeLabel.Location = new Point(318, 561);
            SuggestedTypeLabel.Name = "SuggestedTypeLabel";
            SuggestedTypeLabel.Size = new Size(270, 45);
            SuggestedTypeLabel.TabIndex = 7;
            SuggestedTypeLabel.Text = "Suggested type: ";
            // 
            // SuggestedTypeOutput
            // 
            SuggestedTypeOutput.AutoSize = true;
            SuggestedTypeOutput.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            SuggestedTypeOutput.Location = new Point(594, 561);
            SuggestedTypeOutput.Name = "SuggestedTypeOutput";
            SuggestedTypeOutput.Size = new Size(0, 45);
            SuggestedTypeOutput.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1499, 837);
            Controls.Add(SuggestedTypeOutput);
            Controls.Add(SuggestedTypeLabel);
            Controls.Add(PreciseCheckbox);
            Controls.Add(IntegralOnlyCheckbox);
            Controls.Add(MaxValueInput);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(MinValueInput);
            Name = "Form1";
            Text = "Numeric Types Suggester";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox MinValueInput;
        private Label label1;
        private Label label2;
        private TextBox MaxValueInput;
        private CheckBox IntegralOnlyCheckbox;
        private CheckBox PreciseCheckbox;
        private Label SuggestedTypeLabel;
        private Label SuggestedTypeOutput;
    }
}
