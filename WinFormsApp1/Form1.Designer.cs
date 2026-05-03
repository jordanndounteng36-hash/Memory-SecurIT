namespace WinFormsApp1
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
            btnJouer = new Button();
            lblEssais = new Label();
            lblTemps = new Label();
            btnQuitter = new Button();
            SuspendLayout();
            // 
            // btnJouer
            // 
            btnJouer.Location = new Point(0, 0);
            btnJouer.Name = "btnJouer";
            btnJouer.Size = new Size(94, 29);
            btnJouer.TabIndex = 0;
            btnJouer.Text = "Jouer";
            btnJouer.UseVisualStyleBackColor = true;
            btnJouer.Click += button1_Click;
            // 
            // lblEssais
            // 
            lblEssais.AutoSize = true;
            lblEssais.Location = new Point(24, 51);
            lblEssais.Name = "lblEssais";
            lblEssais.Size = new Size(70, 20);
            lblEssais.TabIndex = 1;
            lblEssais.Text = " Essais : 0";
            // 
            // lblTemps
            // 
            lblTemps.AutoSize = true;
            lblTemps.Location = new Point(351, 65);
            lblTemps.Name = "lblTemps";
            lblTemps.Size = new Size(81, 20);
            lblTemps.TabIndex = 2;
            lblTemps.Text = "Temps : 0 s";
            // 
            // btnQuitter
            // 
            btnQuitter.Location = new Point(361, 12);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new Size(94, 29);
            btnQuitter.TabIndex = 3;
            btnQuitter.Text = "Quitter";
            btnQuitter.UseVisualStyleBackColor = true;
            btnQuitter.Click += btnQuitter_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnQuitter);
            Controls.Add(lblTemps);
            Controls.Add(lblEssais);
            Controls.Add(btnJouer);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnJouer;
        private Label lblEssais;
        private Label lblTemps;
        private Button btnQuitter;
    }
}
