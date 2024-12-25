internal class Program
{
	private static void Main(string[] args)
	{
		Console.WriteLine("ビンゴのガラガラ by CUI Ver.2");
		Option gameOption = new Option();
		gameOption.SetisBingoRetsu();

		Console.WriteLine("準備完了。Enterを押してゲーム画面に移ります");
		Console.ReadLine();
		Console.Clear();
		ShowHelp();
		/*
 * 数学に関すること
 * min:15,max:20のとき、期待する数字は、
 * 15,16,17,18,19,20である。
 * ここで、list.lengthは、
 * max-min+1で求められる。
 * よって、length=20-15+1=6
 * また、random.next()の引数には、
 * max-min+1
 * つまり、lengthを代入する。
 * random.next()から数字が被らないように出していくと、
 * 0,1,2,3,4,5
 * が出される。
 * これにminをたすと、
 * 15,16,17,18,19,20
 * 完成！
 */
		while (true)
		{
			Console.Write("コマンド>");
			string command = Console.ReadLine();
			switch (command)
			{
				case "":
					gameOption.NextNumber();
					break;

				case "search":
					gameOption.Search();
					break;

				case "list":
					gameOption.ShowList();
					break;

				case "line":
					gameOption.ChangeLine();
					break;

				case "help":
					ShowHelp();
					break;

				case "quit":
					Console.WriteLine("終了");
					Environment.Exit(0);
					break;

				default:
					Console.WriteLine("無効なコマンド");
					break;
			}
		}
	}

	static void ShowHelp()
	{
		Console.BackgroundColor = ConsoleColor.White;
		Console.ForegroundColor = ConsoleColor.Black;
		Console.WriteLine("Enter=次の数,list=数のリスト,search=数を検索,line=列表示切り替え,quit=終了");
		Console.WriteLine("helpでヘルプ表示");
		Console.ResetColor();
	}
}

class Option
{
	public int min = 0;
	public int max = 0;
	public int[] list;
	public bool isBingoRetsuEnable = false;
	int index = 0;
	internal Option()
	{
		SetMinMax();
		list = Enumerable.Repeat(min - 1, max - min + 1).ToArray();
	}

	internal void SetMinMax()
	{
		Console.WriteLine("ゲーム設定");
		Console.Write("数字の最小値を入力(規定で1)>");
		if (!int.TryParse(Console.ReadLine(), out this.min))
		{
			this.min = 1;
		}

		Console.Write(@$"最小値:{this.min}に設定

最大値(その数も含まれる)を入力(規定で75)>");
		if (!int.TryParse(Console.ReadLine(), out this.max))
		{
			this.max = 75;
		}
		if (min >= max)
		{
			Console.WriteLine("数値が認められません");
			Environment.Exit(1);
		}
		Console.WriteLine($@"最大値:{this.max}に設定
");
	}

	internal void SetisBingoRetsu()
	{
		Console.Write(@"数字を出す際にビンゴの列(例:Bの17,Gの58)を表示しますか
カードが規格に沿ったものであればYをおすすめします(Y/n)>");
		string read_henzi = Console.ReadLine();
		if (read_henzi == "y" || read_henzi == "Y" || read_henzi == "yes")
		{
			this.isBingoRetsuEnable = true;
			Console.WriteLine("列を表示します");
		}
		else
		{
			this.isBingoRetsuEnable = false;
			Console.WriteLine("列を表示しません");
		}
	}

	internal void NextNumber()
	{
		throw new NotImplementedException();
	}

	internal void Search()
	{
		throw new NotImplementedException();
	}

	internal void ShowList()
	{
		throw new NotImplementedException();
	}

	internal void ChangeLine()
	{
		throw new NotImplementedException();
	}
}