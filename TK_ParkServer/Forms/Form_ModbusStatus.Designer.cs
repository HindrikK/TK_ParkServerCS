namespace TK_ParkServer.Forms
{
    partial class Form_ModbusStatus
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
            this.components = new System.ComponentModel.Container();
            this.listView_Connections = new System.Windows.Forms.ListView();
            this.columnHeader_ConnectedAt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Transport = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_LastValidRequest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_Status = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.timer_Refresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listView_Connections
            // 
            this.listView_Connections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ConnectedAt,
            this.columnHeader_Transport,
            this.columnHeader_Address,
            this.columnHeader_Port,
            this.columnHeader_LastValidRequest});
            this.listView_Connections.FullRowSelect = true;
            this.listView_Connections.GridLines = true;
            this.listView_Connections.Location = new System.Drawing.Point(12, 12);
            this.listView_Connections.Name = "listView_Connections";
            this.listView_Connections.Size = new System.Drawing.Size(564, 236);
            this.listView_Connections.TabIndex = 0;
            this.listView_Connections.UseCompatibleStateImageBehavior = false;
            this.listView_Connections.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_ConnectedAt
            // 
            this.columnHeader_ConnectedAt.Text = "Connected";
            this.columnHeader_ConnectedAt.Width = 145;
            // 
            // columnHeader_Transport
            // 
            this.columnHeader_Transport.Text = "Transport";
            this.columnHeader_Transport.Width = 75;
            // 
            // columnHeader_Address
            // 
            this.columnHeader_Address.Text = "Address";
            this.columnHeader_Address.Width = 120;
            // 
            // columnHeader_Port
            // 
            this.columnHeader_Port.Text = "Port";
            this.columnHeader_Port.Width = 70;
            // 
            // columnHeader_LastValidRequest
            // 
            this.columnHeader_LastValidRequest.Text = "Last valid request";
            this.columnHeader_LastValidRequest.Width = 145;
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(12, 259);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(37, 13);
            this.label_Status.TabIndex = 1;
            this.label_Status.Text = "Status";
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(501, 254);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 2;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // timer_Refresh
            // 
            this.timer_Refresh.Enabled = true;
            this.timer_Refresh.Interval = 1000;
            this.timer_Refresh.Tick += new System.EventHandler(this.timer_Refresh_Tick);
            // 
            // Form_ModbusStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 289);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.listView_Connections);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ModbusStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Market Interface Status";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListView listView_Connections;
        private System.Windows.Forms.ColumnHeader columnHeader_ConnectedAt;
        private System.Windows.Forms.ColumnHeader columnHeader_Transport;
        private System.Windows.Forms.ColumnHeader columnHeader_Address;
        private System.Windows.Forms.ColumnHeader columnHeader_Port;
        private System.Windows.Forms.ColumnHeader columnHeader_LastValidRequest;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Timer timer_Refresh;
    }
}
