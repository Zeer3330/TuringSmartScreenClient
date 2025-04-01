using System;
using System.Windows.Controls;

namespace TuringSmartScreenClient.Models
{
    public class NavigationItem
    {
        public required string Title { get; set; }
        public required UserControl Content { get; set; }
    }
}    