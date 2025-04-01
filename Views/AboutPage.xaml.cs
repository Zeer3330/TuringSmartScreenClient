using System.Windows.Controls;
using TuringSmartScreenClient.Helper;

namespace TuringSmartScreenClient.Views
{
    public partial class AboutPage : UserControl
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Copyright { get; set; }

        public AboutPage()
        {
            InitializeComponent();
            Title = AssemblyInfoHelper.GetAssemblyTitle();
            Version = AssemblyInfoHelper.GetAssemblyVersion();
            Description = AssemblyInfoHelper.GetAssemblyDescription();
            Company = AssemblyInfoHelper.GetAssemblyCompany();
            Copyright = AssemblyInfoHelper.GetAssemblyCopyright();
            DataContext = this;
        }
    }
}