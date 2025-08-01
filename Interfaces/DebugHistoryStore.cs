using Blazored.LocalStorage;
using Microsoft.Extensions.AI;


namespace ThinkBase.Blazor.Chat.Interfaces
{
    /// <summary>
    /// Ideally this would use the browser memory.
    /// </summary>
    public class DebugHistoryStore : IDebugHistoryStore
    {
        ILocalStorageService _localStorage;
        string CurrentHistoryName = nameof(DebugHistoryStore) + ":" + "**CurrentHistory**";
        public DebugHistoryStore(ILocalStorageService LocalStorage)
        {
            _localStorage = LocalStorage;
        }
        public async Task ClearHistory()
        {
            await SetCurrentHistory(null);
        }

        public async Task<List<string>> GetAllHistoryNames()
        {
            var keys =  await _localStorage.KeysAsync();
            var res =  keys
                .Where(key => key != CurrentHistoryName && key.StartsWith(nameof(DebugHistoryStore))) // Exclude the current history name
                .ToList();
            // Remove the prefix from each key
            var reducedKeys = new List<string>();
            foreach (var key in res)
            {
                if (key.StartsWith(nameof(DebugHistoryStore) + ":"))
                {
                    reducedKeys.Add( key.Substring((nameof(DebugHistoryStore) + ":").Length));
                }
            }
            return reducedKeys;
        }

        public async Task<List<ChatMessage>> GetCurrentHistory()
        {
            return await GetNamedHistory(CurrentHistoryName);
        }

        public async Task<List<ChatMessage>> GetNamedHistory(string name)
        {
            return await _localStorage.GetItemAsync<List<ChatMessage>>(nameof(DebugHistoryStore) + ":" + name) ?? [];
        }

        public async Task SaveHistory(List<ChatMessage> history, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("History name cannot be null or empty.", nameof(name));
            }
            await _localStorage.SetItemAsync(nameof(DebugHistoryStore) + ":" + name, history);
        }

        public async Task SetCurrentHistory(List<ChatMessage>? history)
        {
            await SaveHistory(history ?? new List<ChatMessage>(), CurrentHistoryName);
        }
    }
}
