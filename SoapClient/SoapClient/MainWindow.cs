/// MainWindow.cs
/// Thomas Kempton 2012
///

namespace SoapClient
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Net;
    using System.Windows.Forms;
    using System.Xml;
    using SoapClient.Config;
    using SoapClient.Service;
    using System.IO;

    /// <summary>
    /// The class for the main window.
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.ConfigManager =
                        new ClientConfigManager<ClientConfig>(@"client.xml");
        }

        /// <summary>
        /// Gets or sets the configuration manager.
        /// </summary>
        /// <value>
        /// The configuration manager.
        /// </value>
        private ClientConfigManager<ClientConfig> ConfigManager { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        private BindingList<ParameterViewModel> Parameters { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        private ServiceDescriptor Service { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        private ServiceMethod Method { get; set; }

        /// <summary>
        /// Loads the service names combo box.
        /// </summary>
        private void LoadServiceNames()
        {
            var services =
                this.ConfigManager.Configuration.Services
                        .Select(s => s.Name).OrderBy(s => s);

            cmbService.Items.Clear();
            cmbService.Items.AddRange(services.ToArray());
        }

        /// <summary>
        /// Loads the method names combo box.
        /// </summary>
        /// <param name="service">The service.</param>
        private void LoadMethodNames(string service)
        {
            this.Service =
                    this.ConfigManager.Configuration.Services
                            .Single(s => s.Name == service);
            var methods =
                    this.Service.Methods.Select(m => m.Name).OrderBy(s => s);

            cmbMethod.Items.Clear();
            cmbMethod.Items.AddRange(methods.ToArray());
            lblServiceDesc.Text = this.Service.Description;
        }

        /// <summary>
        /// Loads the parameters.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="method">The method.</param>
        private void LoadParameters(string method)
        {
            this.Method = this.Service.Methods
                            .Single(s => s.Name == method);
            lblMethodDesc.Text = this.Method.Description;

            var parameters = this.Method.Parameters;

            var list = new BindingList<ParameterViewModel>();
            this.Parameters.Clear();

            foreach (var p in parameters.OrderBy(p => p.Name))
            {
                var model = new ParameterViewModel();
                model.Parameter = p.Name;
                model.ParameterType = p.ParameterType;

                this.Parameters.Add(model);
            }
        }

        /// <summary>
        /// Initializes the parameters grid.
        /// </summary>
        private void InitializeParametersGrid()
        {
            gridParameters.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    ReadOnly = true,
                    Name = "Name",
                    DataPropertyName = "Parameter",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

            gridParameters.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    ReadOnly = true,
                    Name = "Type",
                    DataPropertyName = "ParameterType",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

            gridParameters.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    ReadOnly = false,
                    Name = "Value",
                    DataPropertyName = "Value",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

            this.Parameters = new BindingList<ParameterViewModel>();
            gridParameters.DataSource = this.Parameters;
        }

        /// <summary>
        /// Validates the parameter.
        /// </summary>
        /// <returns>The parameters.</returns>
        private Dictionary<string, string> ValidateParameters()
        {
            var dict = new Dictionary<string, string>();
            lblValidation.Text = string.Empty;

            foreach (var p in this.Parameters)
            {
                var str = ValidateSingleParameter(p);

                if (str != null)
                {
                    lblValidation.Text = str;
                    return null;
                }

                dict.Add(p.Parameter, p.Value);
            }

            return dict;
        }

        /// <summary>
        /// Validates a single parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The error message, or null.</returns>
        private static string ValidateSingleParameter(
                ParameterViewModel parameter)
        {
            switch(parameter.ParameterType.ToLower())
            {
                case "int":
                    try
                    {
                        int.Parse(parameter.Value);
                    }
                    catch
                    {
                        return string.Format(
                                "{0} must be an integer",
                                parameter.Parameter);
                    }
                    break;

                case "boolean":
                    try
                    {
                        var i = int.Parse(parameter.Value);

                        if (i != 0 && i != 1)
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        return string.Format(
                                "{0} must be either 0 or 1",
                                parameter.Parameter);
                    }
                    break;

                case "string":
                default:
                    //if (string.IsNullOrEmpty(parameter.Value))
                    //{
                    //    return string.Format(
                    //            "{0} must not be blank",
                    //            parameter.Parameter);
                    //}
                    break;
            }

            return null;
        }


        /// <summary>
        /// Handles the Load event of the MainWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                this.ConfigManager.Load();
                this.LoadServiceNames();
                this.InitializeParametersGrid();
            }
            catch
            {
                MessageBox.Show(
                    "There was an error reading your configuration file.\r\n"
                    + "Please verify its contents.",
                    "Configuration Error");
                this.Close();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbService control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        private void cmbService_SelectedIndexChanged(
                object sender,
                EventArgs e)
        {
            this.LoadMethodNames(cmbService.SelectedItem as string);
            this.btnSend.Enabled = false;
            txtResponse.Text = string.Empty;
            treeResponse.Nodes.Clear();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbMethod control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var method = cmbMethod.SelectedItem as string;
            this.btnSend.Enabled = true;
            txtResponse.Text = string.Empty;
            treeResponse.Nodes.Clear();

            if (!string.IsNullOrEmpty(method))
            {
                this.LoadParameters(method);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSend control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            txtResponse.Text = string.Empty;
            treeResponse.Nodes.Clear();
            var dict = this.ValidateParameters();

            if (dict != null)
            {
                this.InvokeAsync(() =>
                {
                    try
                    {
                        var request = new SoapRequest(
                                new Uri(this.Service.ServiceUrl),
                                this.Service.NamespaceUrl,
                                this.Method.Name);

                        var envelope = request.BuildEnvelope(dict);

                        var response = request.Send(envelope);
                        this.DisplayResponse(response);
                    }
                    catch (WebException ex)
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        using (var reader = new StreamReader(stream))
                        {
                            var fault = reader.ReadToEnd();
                            this.DisplayResponse(fault);
                        }
                    }
                    catch (XmlException ex)
                    {
                        this.InvokeOnUI(() =>
                            txtResponse.Text = string.Format(
                                "Exception Parsing Soap Response:\r\n{0}",
                                ex.Message));
                    }
                });
            }
        }

        /// <summary>
        /// Displays the response.
        /// </summary>
        /// <param name="response">The response.</param>
        private void DisplayResponse(string response)
        {
            this.InvokeOnUI(() => txtResponse.Text = response);

            var tree = TreeBuilder.BuildTreeView(response);
            this.InvokeOnUI(() =>
                    treeResponse.Nodes.Add(tree));
        }

        /// <summary>
        /// Handles the Click event of the btnExpand control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        private void btnExpand_Click(object sender, EventArgs e)
        {
            treeResponse.ExpandAll();
        }

        /// <summary>
        /// Handles the Click event of the btnCollapse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        private void btnCollapse_Click(object sender, EventArgs e)
        {
            treeResponse.CollapseAll();
        }

        /// <summary>
        /// Handles the AfterExpand event of the treeResponse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        ///   The <see cref="TreeViewEventArgs" />
        ///   instance containing the event data.
        /// </param>
        private void treeResponse_AfterExpand(
                object sender,
                TreeViewEventArgs e)
        {
            // this expands any sub-nodes that are text-only
            foreach (TreeNode node in e.Node.Nodes)
            {
                if (node.Nodes.Count == 1 &&
                        node.FirstNode.Nodes.Count == 0)
                {
                    node.Expand();
                }
            }
        }
    }
}
