namespace ScriptRunner.WinForms;

partial class ProfileEditorForm
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

    private void InitializeComponent()
    {
        lblName = new Label();
        txtName = new TextBox();
        lblProvider = new Label();
        cmbProvider = new ComboBox();
        lblConn = new Label();
        txtConn = new TextBox();
        btnTest = new Button();
        btnSave = new Button();
        lstProfiles = new ListBox();
        btnDelete = new Button();
        ConnectionSourceTxt = new TextBox();
        label1 = new Label();
        SuspendLayout();
        // 
        // lblName
        // 
        lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblName.Location = new Point(12, 96);
        lblName.Name = "lblName";
        lblName.Size = new Size(130, 17);
        lblName.TabIndex = 9;
        lblName.Text = "Connection Name:";
        // 
        // txtName
        // 
        txtName.Location = new Point(143, 93);
        txtName.Name = "txtName";
        txtName.Size = new Size(331, 23);
        txtName.TabIndex = 8;
        // 
        // lblProvider
        // 
        lblProvider.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblProvider.Location = new Point(11, 64);
        lblProvider.Name = "lblProvider";
        lblProvider.Size = new Size(130, 22);
        lblProvider.TabIndex = 7;
        lblProvider.Text = "Provider:";
        // 
        // cmbProvider
        // 
        cmbProvider.Location = new Point(143, 64);
        cmbProvider.Name = "cmbProvider";
        cmbProvider.Size = new Size(331, 23);
        cmbProvider.TabIndex = 6;
        // 
        // lblConn
        // 
        lblConn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblConn.Location = new Point(15, 258);
        lblConn.Name = "lblConn";
        lblConn.Size = new Size(127, 23);
        lblConn.TabIndex = 5;
        lblConn.Text = "Connection String:";
        // 
        // txtConn
        // 
        txtConn.Location = new Point(15, 284);
        txtConn.Multiline = true;
        txtConn.Name = "txtConn";
        txtConn.ScrollBars = ScrollBars.Vertical;
        txtConn.Size = new Size(760, 168);
        txtConn.TabIndex = 4;
        // 
        // btnTest
        // 
        btnTest.Location = new Point(15, 129);
        btnTest.Name = "btnTest";
        btnTest.Size = new Size(127, 30);
        btnTest.TabIndex = 3;
        btnTest.Text = "Test Connection";
        btnTest.UseVisualStyleBackColor = true;
        btnTest.Click += BtnTest_Click;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(320, 129);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(116, 30);
        btnSave.TabIndex = 2;
        btnSave.Text = "Save Connection";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += BtnSave_Click;
        // 
        // lstProfiles
        // 
        lstProfiles.ItemHeight = 15;
        lstProfiles.Location = new Point(480, 12);
        lstProfiles.Name = "lstProfiles";
        lstProfiles.Size = new Size(295, 259);
        lstProfiles.TabIndex = 1;
        lstProfiles.SelectedIndexChanged += LstProfiles_SelectedIndexChanged;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(176, 129);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(100, 30);
        btnDelete.TabIndex = 0;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += BtnDelete_Click;
        // 
        // ConnectionSourceTxt
        // 
        ConnectionSourceTxt.Location = new Point(143, 5);
        ConnectionSourceTxt.Name = "ConnectionSourceTxt";
        ConnectionSourceTxt.Size = new Size(331, 23);
        ConnectionSourceTxt.TabIndex = 10;
        // 
        // label1
        // 
        label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        label1.Location = new Point(8, 8);
        label1.Name = "label1";
        label1.Size = new Size(130, 17);
        label1.TabIndex = 11;
        label1.Text = "Connect Source:";
        // 
        // ProfileEditorForm
        // 
        ClientSize = new Size(789, 472);
        Controls.Add(ConnectionSourceTxt);
        Controls.Add(label1);
        Controls.Add(btnDelete);
        Controls.Add(lstProfiles);
        Controls.Add(btnSave);
        Controls.Add(btnTest);
        Controls.Add(txtConn);
        Controls.Add(lblConn);
        Controls.Add(cmbProvider);
        Controls.Add(lblProvider);
        Controls.Add(txtName);
        Controls.Add(lblName);
        Name = "ProfileEditorForm";
        Text = "Profile Editor";
        FormClosed += ProfileEditorForm_FormClosed;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblProvider;
    private System.Windows.Forms.ComboBox cmbProvider;
    private System.Windows.Forms.Label lblConn;
    private System.Windows.Forms.TextBox txtConn;
    private System.Windows.Forms.Button btnTest;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.ListBox lstProfiles;
    private System.Windows.Forms.Button btnDelete;
    private TextBox ConnectionSourceTxt;
    private Label label1;
}
