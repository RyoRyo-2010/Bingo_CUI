// See https://aka.ms/new-console-template for more information
//TODO: BINGOのどの列か出す
//参照: https://ja.wikipedia.org/wiki/ビンゴ#用具
Console.WriteLine("ビンゴのガラガラ by CUI");
Console.Write("最小値を入力(規定で1): ");
int min = 0;
if (!int.TryParse(Console.ReadLine(), out min))
{
    min = 1;
}
if (min <= 0)
{
    Console.WriteLine("数値が認められません");
    Environment.Exit(-1);
}
Console.WriteLine($"最小値:{min}に設定");
Console.WriteLine();
Console.Write("最大値(その数も含まれる)を入力(規定で75): ");
int max = 0;
if (!int.TryParse(Console.ReadLine(), out max))
{
    max = 75;
}
if (min >= max)
{
    Console.WriteLine("数値が認められません");
    Environment.Exit(-1);
}
Console.WriteLine($"最大値:{max}に設定");
Console.WriteLine();
Console.WriteLine("準備完了。次に進むにはEnterキーを押す");
Console.ReadLine();
Console.Clear();
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine("Enter=次の数,list=数のリスト,search=数を検索,quit=終了");
Console.WriteLine("helpでヘルプ表示");
Console.ResetColor();
//TODO: シードを設定するか被らないようにする
Random random = new Random();
int[] list = Enumerable.Repeat(min - 1, max - min + 1).ToArray();
int index = 0;

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
            bool isloop = true;
            while (isloop)
            {
                //終わり？
                if (index >= list.Length)
                {
                    Console.WriteLine("これで全てです。");
                    break;
                }
                int next = random.Next(list.Length) + min;
                if (Array.IndexOf(list, next) == -1)
                {
                    isloop = false;
                    list[index++] = next;
                    Console.WriteLine(next + "番");
                }
            }
            break;

        case "list":
            if (index < 2)
            {
                Console.WriteLine("数の履歴が足りません");
                Console.WriteLine("次の数を出してください");
                break;
            }
            for (int i = 0; i < index - 1; i++)
            {
                Console.Write($"{list[i]}, ");
            }
            Console.WriteLine($"{list[index - 1]}");
            break;

        case "search":
            Console.Write("検索する番号を入力: ");
            string input_search = Console.ReadLine();
            int search_number;
            if (!int.TryParse(input_search, out search_number))
            {
                Console.WriteLine("数値が認められません");
            }
            else
            {
                if (Array.IndexOf(list, search_number) != -1)
                {
                    //見つかる
                    Console.WriteLine($"{search_number}が見つかりました");
                }
                else
                {
                    Console.WriteLine($"{search_number}は見つかりませんでした");
                }
            }
            break;

        case "quit":
            Console.WriteLine("終了");
            Environment.Exit(0);
            break;

        case "help":
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Enter=次の数,list=数のリスト,search=数を検索,quit=終了");
            Console.WriteLine("helpでヘルプ表示");
            Console.ResetColor();
            break;
        default:
            Console.WriteLine("無効なコマンド");
            break;
    }
}
