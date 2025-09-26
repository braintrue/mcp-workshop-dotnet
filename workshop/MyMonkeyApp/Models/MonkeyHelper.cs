using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyMonkeyApp.Models;

/// <summary>
/// Monkey 데이터 관리를 위한 정적 헬퍼 클래스입니다.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey>? monkeys;
    private static readonly Dictionary<string, int> randomAccessCounts = new();

    /// <summary>
    /// MCP 서버에서 모든 원숭이 데이터를 비동기로 가져옵니다.
    /// </summary>
    public static async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (monkeys != null)
            return monkeys;

        using var http = new HttpClient();
        // MCP 서버의 엔드포인트 URL을 실제로 입력해야 합니다.
        var url = "https://monkeymcp.braintrue.com/api/monkeys";
        monkeys = await http.GetFromJsonAsync<List<Monkey>>(url) ?? new List<Monkey>();
        return monkeys;
    }

    /// <summary>
    /// 이름으로 특정 원숭이를 찾습니다.
    /// </summary>
    public static async Task<Monkey?> GetMonkeyByNameAsync(string name)
    {
        var list = await GetMonkeysAsync();
        return list.FirstOrDefault(m => string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// 무작위 원숭이를 반환하고, 해당 원숭이의 액세스 횟수를 1 증가시킵니다.
    /// </summary>
    public static async Task<Monkey?> GetRandomMonkeyAsync()
    {
        var list = await GetMonkeysAsync();
        if (list.Count == 0) return null;
        var random = new Random();
        var monkey = list[random.Next(list.Count)];
        if (!randomAccessCounts.ContainsKey(monkey.Name))
            randomAccessCounts[monkey.Name] = 0;
        randomAccessCounts[monkey.Name]++;
        return monkey;
    }

    /// <summary>
    /// 무작위로 선택된 각 원숭이의 액세스 횟수를 반환합니다.
    /// </summary>
    public static IReadOnlyDictionary<string, int> GetRandomAccessCounts() => randomAccessCounts;
}
