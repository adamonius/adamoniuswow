namespace Professions
{
  partial class frmProfs
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
        this.radChar = new System.Windows.Forms.RadioButton();
        this.radGuild = new System.Windows.Forms.RadioButton();
        this.panel1 = new System.Windows.Forms.Panel();
        this.btnProcess = new System.Windows.Forms.Button();
        this.txtBoxServer = new System.Windows.Forms.TextBox();
        this.lblServer = new System.Windows.Forms.Label();
        this.txtBoxName = new System.Windows.Forms.TextBox();
        this.prgBarProcess = new System.Windows.Forms.ProgressBar();
        this.txtBoxResult = new System.Windows.Forms.TextBox();
        this.bgrndWork = new System.ComponentModel.BackgroundWorker();
        this.panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // radChar
        // 
        this.radChar.AutoSize = true;
        this.radChar.Location = new System.Drawing.Point(12, 12);
        this.radChar.Name = "radChar";
        this.radChar.Size = new System.Drawing.Size(71, 17);
        this.radChar.TabIndex = 0;
        this.radChar.Text = "Character";
        this.radChar.UseVisualStyleBackColor = true;
        // 
        // radGuild
        // 
        this.radGuild.AutoSize = true;
        this.radGuild.Checked = true;
        this.radGuild.Location = new System.Drawing.Point(89, 12);
        this.radGuild.Name = "radGuild";
        this.radGuild.Size = new System.Drawing.Size(49, 17);
        this.radGuild.TabIndex = 1;
        this.radGuild.TabStop = true;
        this.radGuild.Text = "Guild";
        this.radGuild.UseVisualStyleBackColor = true;
        // 
        // panel1
        // 
        this.panel1.Controls.Add(this.btnProcess);
        this.panel1.Controls.Add(this.txtBoxServer);
        this.panel1.Controls.Add(this.lblServer);
        this.panel1.Controls.Add(this.txtBoxName);
        this.panel1.Controls.Add(this.radChar);
        this.panel1.Controls.Add(this.radGuild);
        this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        this.panel1.Location = new System.Drawing.Point(0, 0);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(343, 71);
        this.panel1.TabIndex = 2;
        // 
        // btnProcess
        // 
        this.btnProcess.Location = new System.Drawing.Point(255, 13);
        this.btnProcess.Name = "btnProcess";
        this.btnProcess.Size = new System.Drawing.Size(79, 42);
        this.btnProcess.TabIndex = 5;
        this.btnProcess.Text = "Lookup";
        this.btnProcess.UseVisualStyleBackColor = true;
        this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
        // 
        // txtBoxServer
        // 
        this.txtBoxServer.Location = new System.Drawing.Point(148, 36);
        this.txtBoxServer.Name = "txtBoxServer";
        this.txtBoxServer.Size = new System.Drawing.Size(100, 20);
        this.txtBoxServer.TabIndex = 4;
        this.txtBoxServer.Text = "Greymane";
        // 
        // lblServer
        // 
        this.lblServer.AutoSize = true;
        this.lblServer.Location = new System.Drawing.Point(145, 13);
        this.lblServer.Name = "lblServer";
        this.lblServer.Size = new System.Drawing.Size(38, 13);
        this.lblServer.TabIndex = 3;
        this.lblServer.Text = "Server";
        // 
        // txtBoxName
        // 
        this.txtBoxName.Location = new System.Drawing.Point(13, 36);
        this.txtBoxName.Name = "txtBoxName";
        this.txtBoxName.Size = new System.Drawing.Size(125, 20);
        this.txtBoxName.TabIndex = 2;
        this.txtBoxName.Text = "Solution";
        // 
        // prgBarProcess
        // 
        this.prgBarProcess.Dock = System.Windows.Forms.DockStyle.Top;
        this.prgBarProcess.Location = new System.Drawing.Point(0, 71);
        this.prgBarProcess.Name = "prgBarProcess";
        this.prgBarProcess.Size = new System.Drawing.Size(343, 23);
        this.prgBarProcess.Step = 1;
        this.prgBarProcess.TabIndex = 3;
        // 
        // txtBoxResult
        // 
        this.txtBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
        this.txtBoxResult.Location = new System.Drawing.Point(0, 94);
        this.txtBoxResult.Multiline = true;
        this.txtBoxResult.Name = "txtBoxResult";
        this.txtBoxResult.ReadOnly = true;
        this.txtBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtBoxResult.Size = new System.Drawing.Size(343, 235);
        this.txtBoxResult.TabIndex = 4;
        // 
        // bgrndWork
        // 
        this.bgrndWork.WorkerReportsProgress = true;
        this.bgrndWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgrndWork_DoWork);
        this.bgrndWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgrndWork_RunWorkerCompleted);
        this.bgrndWork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgrndWork_ProgressChanged);
        // 
        // frmProfs
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(343, 329);
        this.Controls.Add(this.txtBoxResult);
        this.Controls.Add(this.prgBarProcess);
        this.Controls.Add(this.panel1);
        this.Name = "frmProfs";
        this.Text = "Professions";
        this.panel1.ResumeLayout(false);
        this.panel1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton radChar;
    private System.Windows.Forms.RadioButton radGuild;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox txtBoxName;
    private System.Windows.Forms.ProgressBar prgBarProcess;
    private System.Windows.Forms.TextBox txtBoxResult;
    private System.Windows.Forms.Button btnProcess;
    private System.Windows.Forms.TextBox txtBoxServer;
    private System.Windows.Forms.Label lblServer;
      private System.ComponentModel.BackgroundWorker bgrndWork;
  }
}

