namespace ScriptRunner.WinForms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        btnLoad = new Button();
        btnRun = new Button();
        btnProfiles = new Button();
        txtScript = new TextBox();
        txtLog = new TextBox();
        ProfileListBox = new ComboBox();
        label1 = new Label();
        label4 = new Label();
        DatabaseCombo = new ComboBox();
        SuspendLayout();
        // 
        // btnLoad
        // 
        btnLoad.FlatStyle = FlatStyle.Flat;
        btnLoad.Location = new Point(21, 116);
        btnLoad.Margin = new Padding(3, 2, 3, 2);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(106, 22);
        btnLoad.TabIndex = 0;
        btnLoad.Text = "Load Script";
        btnLoad.UseVisualStyleBackColor = true;
        btnLoad.Click += BtnLoad_Click;
        // 
        // btnRun
        // 
        btnRun.FlatStyle = FlatStyle.Flat;
        btnRun.Location = new Point(216, 116);
        btnRun.Margin = new Padding(3, 2, 3, 2);
        btnRun.Name = "btnRun";
        btnRun.Size = new Size(105, 22);
        btnRun.TabIndex = 1;
        btnRun.Text = "Run Script";
        btnRun.UseVisualStyleBackColor = true;
        btnRun.Click += BtnRun_Click;
        // 
        // btnProfiles
        // 
        btnProfiles.FlatStyle = FlatStyle.Flat;
        btnProfiles.Location = new Point(419, 116);
        btnProfiles.Margin = new Padding(3, 2, 3, 2);
        btnProfiles.Name = "btnProfiles";
        btnProfiles.Size = new Size(105, 22);
        btnProfiles.TabIndex = 2;
        btnProfiles.Text = "Add Connection";
        btnProfiles.UseVisualStyleBackColor = true;
        btnProfiles.Click += BtnProfiles_Click;
        // 
        // txtScript
        // 
        txtScript.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtScript.BorderStyle = BorderStyle.FixedSingle;
        txtScript.Location = new Point(12, 152);
        txtScript.Margin = new Padding(3, 2, 3, 2);
        txtScript.Multiline = true;
        txtScript.Name = "txtScript";
        txtScript.ReadOnly = true;
        txtScript.ScrollBars = ScrollBars.Vertical;
        txtScript.Size = new Size(1020, 353);
        txtScript.TabIndex = 3;
        txtScript.TabStop = false;
        // 
        // txtLog
        // 
        txtLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtLog.Location = new Point(10, 528);
        txtLog.Margin = new Padding(3, 2, 3, 2);
        txtLog.Multiline = true;
        txtLog.Name = "txtLog";
        txtLog.ReadOnly = true;
        txtLog.ScrollBars = ScrollBars.Vertical;
        txtLog.Size = new Size(1020, 186);
        txtLog.TabIndex = 4;
        // 
        // ProfileListBox
        // 
        ProfileListBox.FlatStyle = FlatStyle.Popup;
        ProfileListBox.FormattingEnabled = true;
        ProfileListBox.Location = new Point(140, 21);
        ProfileListBox.Name = "ProfileListBox";
        ProfileListBox.Size = new Size(329, 23);
        ProfileListBox.TabIndex = 5;
        ProfileListBox.SelectedIndexChanged += ProfileListBox_SelectedIndexChanged;
        // 
        // label1
        // 
        label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        label1.Location = new Point(21, 24);
        label1.Name = "label1";
        label1.Size = new Size(113, 17);
        label1.TabIndex = 12;
        label1.Text = "Connect Source:";
        // 
        // label4
        // 
        label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        label4.Location = new Point(563, 24);
        label4.Name = "label4";
        label4.Size = new Size(113, 17);
        label4.TabIndex = 18;
        label4.Text = "Databases:";
        // 
        // DatabaseCombo
        // 
        DatabaseCombo.FlatStyle = FlatStyle.Popup;
        DatabaseCombo.FormattingEnabled = true;
        DatabaseCombo.Location = new Point(682, 21);
        DatabaseCombo.Name = "DatabaseCombo";
        DatabaseCombo.Size = new Size(329, 23);
        DatabaseCombo.TabIndex = 17;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1041, 727);
        Controls.Add(label4);
        Controls.Add(DatabaseCombo);
        Controls.Add(label1);
        Controls.Add(ProfileListBox);
        Controls.Add(txtLog);
        Controls.Add(txtScript);
        Controls.Add(btnProfiles);
        Controls.Add(btnRun);
        Controls.Add(btnLoad);
        Margin = new Padding(3, 2, 3, 2);
        Name = "MainForm";
        Text = "ScriptRunner";
        Load += MainForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.Button btnRun;
    private System.Windows.Forms.Button btnProfiles;
    private System.Windows.Forms.TextBox txtScript;
    private System.Windows.Forms.TextBox txtLog;
    private ComboBox ProfileListBox;
    private Label label1;
    private Label label4;
    private ComboBox DatabaseCombo;
}
