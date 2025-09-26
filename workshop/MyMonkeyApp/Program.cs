
using MyMonkeyApp.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

async Task RunMenuAsync()
{
	while (true)
	{
		Console.Clear();
		Console.WriteLine("============================");
		Console.WriteLine("   🐒 Monkey Console App 🐒");
		Console.WriteLine("============================");
		Console.WriteLine();
		Console.WriteLine(AsciiArtHelper.GetRandomArt());
		Console.WriteLine();
		Console.WriteLine("1. 모든 원숭이 나열");
		Console.WriteLine("2. 이름으로 원숭이 세부 정보");
		Console.WriteLine("3. 무작위 원숭이");
		Console.WriteLine("4. 종료");
		Console.Write("메뉴 선택: ");
		var input = Console.ReadLine();
		Console.WriteLine();
		switch (input)
		{
			case "1":
				await ListAllMonkeysAsync();
				break;
			case "2":
				await ShowMonkeyByNameAsync();
				break;
			case "3":
				await ShowRandomMonkeyAsync();
				break;
			case "4":
				Console.WriteLine("앱을 종료합니다.");
				return;
			default:
				Console.WriteLine("잘못된 입력입니다.");
				break;
		}
		Console.WriteLine("\n아무 키나 누르면 계속...");
		Console.ReadKey();
	}
}

async Task ListAllMonkeysAsync()
{
	var monkeys = await MonkeyHelper.GetMonkeysAsync();
	Console.WriteLine("\n[모든 원숭이 목록]");
	foreach (var m in monkeys)
	{
		Console.WriteLine($"- {m.Name} ({m.Location}) | 개체수: {m.Population}");
	}
}

async Task ShowMonkeyByNameAsync()
{
	Console.Write("원숭이 이름을 입력하세요: ");
	var name = Console.ReadLine() ?? string.Empty;
	var monkey = await MonkeyHelper.GetMonkeyByNameAsync(name);
	if (monkey == null)
	{
		Console.WriteLine("해당 이름의 원숭이를 찾을 수 없습니다.");
		return;
	}
	PrintMonkeyDetails(monkey);
}

async Task ShowRandomMonkeyAsync()
{
	var monkey = await MonkeyHelper.GetRandomMonkeyAsync();
	if (monkey == null)
	{
		Console.WriteLine("원숭이 데이터가 없습니다.");
		return;
	}
	PrintMonkeyDetails(monkey);
	var counts = MonkeyHelper.GetRandomAccessCounts();
	Console.WriteLine($"[무작위 선택 횟수: {counts[monkey.Name]}]");
}

void PrintMonkeyDetails(Monkey m)
{
	Console.WriteLine($"\n이름: {m.Name}");
	Console.WriteLine($"서식지: {m.Location}");
	Console.WriteLine($"개체수: {m.Population}");
	Console.WriteLine($"설명: {m.Details}");
	Console.WriteLine($"위도: {m.Latitude}, 경도: {m.Longitude}");
	Console.WriteLine();
	Console.WriteLine(AsciiArtHelper.GetRandomArt());
}

await RunMenuAsync();
