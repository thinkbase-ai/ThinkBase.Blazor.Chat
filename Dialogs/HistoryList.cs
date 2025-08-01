using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBase.Blazor.Chat.Dialogs
{
    public class HistoryList
    {
        public List<string> choices { get; set; } = new List<string>();
        public string? selection { get; set; }

    }
}
