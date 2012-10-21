namespace SoapClient
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
            this.lblParameters = new System.Windows.Forms.Label();
            this.gridParameters = new System.Windows.Forms.DataGridView();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblValidation = new System.Windows.Forms.Label();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.lblResponse = new System.Windows.Forms.Label();
            this.lblServiceDesc = new System.Windows.Forms.Label();
            this.lblMethodDesc = new System.Windows.Forms.Label();
            this.treeResponse = new System.Windows.Forms.TreeView();
            this.lblTree = new System.Windows.Forms.Label();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.btnExpand = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // lblParameters
            // 
            this.lblParameters.AutoSize = true;
            this.lblParameters.Location = new System.Drawing.Point(12, 106);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(85, 17);
            this.lblParameters.TabIndex = 11;
            this.lblParameters.Text = "Parameters:";
            // 
            // gridParameters
            // 
            this.gridParameters.AllowUserToAddRows = false;
            this.gridParameters.AllowUserToDeleteRows = false;
            this.gridParameters.AllowUserToResizeColumns = false;
            this.gridParameters.AllowUserToResizeRows = false;
            this.gridParameters.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridParameters.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridParameters.Location = new System.Drawing.Point(14, 126);
            this.gridParameters.Name = "gridParameters";
            this.gridParameters.RowHeadersVisible = false;
            this.gridParameters.RowTemplate.Height = 24;
            this.gridParameters.Size = new System.Drawing.Size(566, 157);
            this.gridParameters.TabIndex = 10;
            // 
            // cmbMethod
            // 
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Location = new System.Drawing.Point(300, 29);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(280, 24);
            this.cmbMethod.TabIndex = 9;
            this.cmbMethod.SelectedIndexChanged += new System.EventHandler(this.cmbMethod_SelectedIndexChanged);
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(297, 9);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(59, 17);
            this.lblMethod.TabIndex = 8;
            this.lblMethod.Text = "Method:";
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(12, 9);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(59, 17);
            this.lblService.TabIndex = 7;
            this.lblService.Text = "Service:";
            // 
            // cmbService
            // 
            this.cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Location = new System.Drawing.Point(14, 29);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(280, 24);
            this.cmbService.TabIndex = 6;
            this.cmbService.SelectedIndexChanged += new System.EventHandler(this.cmbService_SelectedIndexChanged);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(474, 289);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(106, 31);
            this.btnSend.TabIndex = 12;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblValidation
            // 
            this.lblValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidation.ForeColor = System.Drawing.Color.Red;
            this.lblValidation.Location = new System.Drawing.Point(12, 289);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(453, 31);
            this.lblValidation.TabIndex = 13;
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(14, 340);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponse.Size = new System.Drawing.Size(566, 172);
            this.txtResponse.TabIndex = 14;
            this.txtResponse.WordWrap = false;
            // 
            // lblResponse
            // 
            this.lblResponse.AutoSize = true;
            this.lblResponse.Location = new System.Drawing.Point(12, 320);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(118, 17);
            this.lblResponse.TabIndex = 15;
            this.lblResponse.Text = "SOAP Response:";
            // 
            // lblServiceDesc
            // 
            this.lblServiceDesc.Location = new System.Drawing.Point(14, 60);
            this.lblServiceDesc.Name = "lblServiceDesc";
            this.lblServiceDesc.Size = new System.Drawing.Size(563, 23);
            this.lblServiceDesc.TabIndex = 16;
            // 
            // lblMethodDesc
            // 
            this.lblMethodDesc.Location = new System.Drawing.Point(14, 83);
            this.lblMethodDesc.Name = "lblMethodDesc";
            this.lblMethodDesc.Size = new System.Drawing.Size(563, 23);
            this.lblMethodDesc.TabIndex = 17;
            // 
            // treeResponse
            // 
            this.treeResponse.Location = new System.Drawing.Point(598, 29);
            this.treeResponse.Name = "treeResponse";
            this.treeResponse.Size = new System.Drawing.Size(334, 483);
            this.treeResponse.TabIndex = 18;
            this.treeResponse.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeResponse_AfterExpand);
            // 
            // lblTree
            // 
            this.lblTree.AutoSize = true;
            this.lblTree.Location = new System.Drawing.Point(598, 9);
            this.lblTree.Name = "lblTree";
            this.lblTree.Size = new System.Drawing.Size(72, 17);
            this.lblTree.TabIndex = 19;
            this.lblTree.Text = "Response";
            // 
            // btnCollapse
            // 
            this.btnCollapse.Location = new System.Drawing.Point(862, 6);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(70, 23);
            this.btnCollapse.TabIndex = 20;
            this.btnCollapse.Text = "Collapse";
            this.btnCollapse.UseVisualStyleBackColor = true;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.Location = new System.Drawing.Point(786, 6);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(70, 23);
            this.btnExpand.TabIndex = 21;
            this.btnExpand.Text = "Expand";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 529);
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.btnCollapse);
            this.Controls.Add(this.lblTree);
            this.Controls.Add(this.treeResponse);
            this.Controls.Add(this.lblMethodDesc);
            this.Controls.Add(this.lblServiceDesc);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblParameters);
            this.Controls.Add(this.gridParameters);
            this.Controls.Add(this.cmbMethod);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.cmbService);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.Text = "SoapClient";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridParameters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.DataGridView gridParameters;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblValidation;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.Label lblServiceDesc;
        private System.Windows.Forms.Label lblMethodDesc;
        private System.Windows.Forms.TreeView treeResponse;
        private System.Windows.Forms.Label lblTree;
        private System.Windows.Forms.Button btnCollapse;
        private System.Windows.Forms.Button btnExpand;
    }
}

