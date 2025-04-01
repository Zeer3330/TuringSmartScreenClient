using System.Reflection;

namespace TuringSmartScreenClient.Helper
{
    public static class AssemblyInfoHelper
    {
        public static string GetAssemblyTitle()
        {
            var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (!string.IsNullOrEmpty(titleAttribute.Title))
                {
                    return titleAttribute.Title;
                }
            }
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        }

        public static string GetAssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;
        }

        public static string GetAssemblyDescription()
        {
            var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }

        public static string GetAssemblyCompany()
        {
            var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCompanyAttribute)attributes[0]).Company;
        }

        public static string GetAssemblyCopyright()
        {
            var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }
    }
}