using Microsoft.Extensions.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComply.Blazor.Chat.Interfaces
{
    public interface IDebugHistoryStore
    {
        
        Task SaveHistory(List<ChatMessage> history, string name);
        
        Task<List<string>> GetAllHistoryNames();
 
        Task ClearHistory();
        Task<List<ChatMessage>> GetNamedHistory(string name);

        Task<List<ChatMessage>> GetCurrentHistory();

        Task SetCurrentHistory(List<ChatMessage>? history);

    }
}
