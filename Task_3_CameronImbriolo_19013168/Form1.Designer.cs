namespace Task_1_CameronImbriolo_19013168
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.mapBox = new System.Windows.Forms.GroupBox();
            this.lblRound = new System.Windows.Forms.Label();
            this.lblFight = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.gameInfoTxt = new System.Windows.Forms.RichTextBox();
            this.roundTimer = new System.Windows.Forms.Timer(this.components);
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblResource = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mapBox
            // 
            this.mapBox.Location = new System.Drawing.Point(0, 45);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(574, 449);
            this.mapBox.TabIndex = 0;
            this.mapBox.TabStop = false;
            this.mapBox.Text = "Map";
            this.mapBox.Enter += new System.EventHandler(this.mapBox_Enter);
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.Location = new System.Drawing.Point(693, 153);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(172, 23);
            this.lblRound.TabIndex = 1;
            this.lblRound.Text = "Current Round: 0";
            // 
            // lblFight
            // 
            this.lblFight.AutoSize = true;
            this.lblFight.Font = new System.Drawing.Font("Britannic Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFight.Location = new System.Drawing.Point(674, 82);
            this.lblFight.Name = "lblFight";
            this.lblFight.Size = new System.Drawing.Size(220, 71);
            this.lblFight.TabIndex = 2;
            this.lblFight.Text = "FIGHT!";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(583, 189);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(205, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(583, 218);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(205, 23);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // gameInfoTxt
            // 
            this.gameInfoTxt.Location = new System.Drawing.Point(583, 280);
            this.gameInfoTxt.Name = "gameInfoTxt";
            this.gameInfoTxt.Size = new System.Drawing.Size(416, 214);
            this.gameInfoTxt.TabIndex = 5;
            this.gameInfoTxt.Text = "";
            // 
            // roundTimer
            // 
            this.roundTimer.Interval = 1000;
            this.roundTimer.Tick += new System.EventHandler(this.RoundTimer_Tick);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(583, 247);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(205, 23);
            this.btnRestart.TabIndex = 6;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(794, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(205, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(794, 247);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(205, 23);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.Location = new System.Drawing.Point(12, 9);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(58, 13);
            this.lblResource.TabIndex = 9;
            this.lblResource.Text = "Resources";
            this.lblResource.Click += new System.EventHandler(this.lblResource_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 500);
            this.Controls.Add(this.lblResource);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.gameInfoTxt);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblFight);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.mapBox);
            this.Name = "Form1";
            this.Text = "BATTLE!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox mapBox;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Label lblFight;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.RichTextBox gameInfoTxt;
        private System.Windows.Forms.Timer roundTimer;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblResource;
    }
}

