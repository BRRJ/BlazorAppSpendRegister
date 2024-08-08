using BlazorAppSpendRegister.Models;
using Blazored.LocalStorage;
using System.Text.Json;

namespace BlazorAppSpendRegister.Services;

public class SpendService : ISpendService
{
    private const string SPENDS_LOCAL_STORAGE_KEY = "spendKey";

    private readonly ILocalStorageService _storageService;

    public SpendService(ILocalStorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task<List<Spend>> GetSpends()
    {
        var spendsJson = await _storageService.GetItemAsync<string>(SPENDS_LOCAL_STORAGE_KEY);

        if (string.IsNullOrEmpty(spendsJson)) return new();

        return (JsonSerializer.Deserialize<List<Spend>>(spendsJson) ?? new());
    }

    public async Task SaveSpends(List<Spend> spends)
    {
        var spendsJson = JsonSerializer.Serialize(spends);
        await _storageService.SetItemAsync(SPENDS_LOCAL_STORAGE_KEY, spendsJson);
    }
}

