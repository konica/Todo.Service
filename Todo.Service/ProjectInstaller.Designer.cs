namespace Todo.Service
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TodoServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.TodoServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // TodoServiceProcessInstaller
            // 
            this.TodoServiceProcessInstaller.Password = null;
            this.TodoServiceProcessInstaller.Username = null;
            // 
            // TodoServiceInstaller
            // 
            this.TodoServiceInstaller.ServiceName = "Todo.Service";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.TodoServiceProcessInstaller,
            this.TodoServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller TodoServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller TodoServiceInstaller;
    }
}