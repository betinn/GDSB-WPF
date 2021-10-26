
namespace GDSB.UI
{
    partial class FormCreateProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateProfile));
            this.textBoxPhoto = new System.Windows.Forms.TextBox();
            this.buttonUploadPic = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonCreateProfSave = new System.Windows.Forms.Button();
            this.buttonCreateProfCancel = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxConfirmarSenha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBoxReload = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPhoto
            // 
            this.textBoxPhoto.Location = new System.Drawing.Point(281, 202);
            this.textBoxPhoto.Name = "textBoxPhoto";
            this.textBoxPhoto.ReadOnly = true;
            this.textBoxPhoto.Size = new System.Drawing.Size(155, 20);
            this.textBoxPhoto.TabIndex = 1;
            this.textBoxPhoto.TabStop = false;
            // 
            // buttonUploadPic
            // 
            this.buttonUploadPic.Location = new System.Drawing.Point(180, 202);
            this.buttonUploadPic.Name = "buttonUploadPic";
            this.buttonUploadPic.Size = new System.Drawing.Size(95, 20);
            this.buttonUploadPic.TabIndex = 6;
            this.buttonUploadPic.Text = "Procurar Imagem";
            this.buttonUploadPic.UseVisualStyleBackColor = true;
            this.buttonUploadPic.Click += new System.EventHandler(this.buttonUploadPic_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome do perfil";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 28);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(263, 20);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
            // 
            // buttonCreateProfSave
            // 
            this.buttonCreateProfSave.Location = new System.Drawing.Point(12, 199);
            this.buttonCreateProfSave.Name = "buttonCreateProfSave";
            this.buttonCreateProfSave.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateProfSave.TabIndex = 4;
            this.buttonCreateProfSave.Text = "Salvar";
            this.buttonCreateProfSave.UseVisualStyleBackColor = true;
            this.buttonCreateProfSave.Click += new System.EventHandler(this.buttonCreateProfSave_Click);
            // 
            // buttonCreateProfCancel
            // 
            this.buttonCreateProfCancel.Location = new System.Drawing.Point(93, 199);
            this.buttonCreateProfCancel.Name = "buttonCreateProfCancel";
            this.buttonCreateProfCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateProfCancel.TabIndex = 5;
            this.buttonCreateProfCancel.Text = "Cancelar";
            this.buttonCreateProfCancel.UseVisualStyleBackColor = true;
            this.buttonCreateProfCancel.Click += new System.EventHandler(this.buttonCreateProfCancel_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(12, 76);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(263, 20);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Senha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 173);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(263, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(12, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Data nascimento";
            // 
            // textBoxConfirmarSenha
            // 
            this.textBoxConfirmarSenha.Location = new System.Drawing.Point(12, 124);
            this.textBoxConfirmarSenha.Name = "textBoxConfirmarSenha";
            this.textBoxConfirmarSenha.Size = new System.Drawing.Size(263, 20);
            this.textBoxConfirmarSenha.TabIndex = 2;
            this.textBoxConfirmarSenha.UseSystemPasswordChar = true;
            this.textBoxConfirmarSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Cyan;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Confirme sua senha";
            // 
            // pictureBoxReload
            // 
            this.pictureBoxReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxReload.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxReload.Image")));
            this.pictureBoxReload.Location = new System.Drawing.Point(409, 12);
            this.pictureBoxReload.Name = "pictureBoxReload";
            this.pictureBoxReload.Size = new System.Drawing.Size(27, 26);
            this.pictureBoxReload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxReload.TabIndex = 13;
            this.pictureBoxReload.TabStop = false;
            this.pictureBoxReload.Click += new System.EventHandler(this.pictureBoxReload_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(281, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 184);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormCreateProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(448, 229);
            this.Controls.Add(this.pictureBoxReload);
            this.Controls.Add(this.textBoxConfirmarSenha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCreateProfCancel);
            this.Controls.Add(this.buttonCreateProfSave);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUploadPic);
            this.Controls.Add(this.textBoxPhoto);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCreateProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCreateProfile";
            this.TopMost = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormCreateProfile_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxPhoto;
        private System.Windows.Forms.Button buttonUploadPic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonCreateProfSave;
        private System.Windows.Forms.Button buttonCreateProfCancel;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxConfirmarSenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBoxReload;
    }
}