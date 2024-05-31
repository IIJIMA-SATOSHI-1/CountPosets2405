internal class Program
{
    /// <summary>
    /// 異なる2元間の関係をi<jをa_i,j=1,i<>jをa_i,j=0,i>jをa_i,j=-1で表した
    /// 配列で、推移律を満たすを満たすものをカウントする
    /// </summary>
    private static void Main(string[] args)
    {
        var n = 4;
        if (args.Length > 0)
        {
            if (int.TryParse(args[0], out var x)) { 
                n = x;
            }
        }
        //第2引数があれば、Printを実行
        var option_print = args.Length > 1;

        //異なる2元間の関係をi<jをa_i,j=1,i<>jをa_i,j=0,i>jをa_i,j=-1
        short[][] a = new short[n - 1][];
        for (int i = 0; i < n - 1; i++)
        {
            a[i] = new short[n - i - 1];
            for (int j = 0; j < a[i].Length; j++)
            {
                //すべて-1で初期化
                a[i][j] = -1;
            }
        }
        var allNum = 0;
        var count = 0;

        if (option_print)
        {
            do
            {
                if (IsPoset(a))
                {
                    Print(a);
                    Console.WriteLine();
                    count++;
                }
                allNum++;
            } while (Next(a));
        }
        else
        {
            do
            {
                if (IsPoset(a))
                {
                    count++;
                }
                allNum++;
            } while (Next(a));
        }
        Console.WriteLine($"Number of posets of {n} elements :\t{count}");
        Console.WriteLine($"Number of three types of relation of {n} elements (3^({n}*{n - 1}/2)):\t{allNum}");
    }

    //表示
    private static void Print(short[][] a)
    {
        int n = a.Length+1;
        for (int i = 1; i <= n - 1; i++)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write("\t");
            }
            for (int j = i + 1; j <= n; j++)
            {
//                Console.Write($"\t{i},{j}:{GetValue(a, i, j)}");
                Console.Write($"\t{GetValue(a, i, j)}");
            }
            Console.WriteLine();
        }
    }

    //わかりやすい添え字で値を取得
    public static short GetValue(short[][] a, int x, int y)
    {
        return a[x - 1][y - x - 1];
    }

    //わかりやすい添え字で値を設定
    public static void SetValue(short[][] a, int x, int y, short value)
    {
        a[x - 1][y - x - 1] = value;
    }

    //n元の集合で2元の関係-1,0,1の3値のパターンの次
    public static bool Next(short[][] a) {

        var n = a.Length+1;
        var i = n-1;
        var j = n;
        while (i > 0)
        {
            j = n;
            while (j > i) {
                var v = GetValue(a,i,j);
                if (v < 1)
                {
                    SetValue(a, i, j, (short)(v + 1));
                    return true;
                }
                SetValue(a, i, j, -1);
                j--;
            }
            i--;
        }
        return false;
    }

    //推移律を満たすときtrue
    public static bool Transitive(short[][] a, int i, int j, int k) {
        var x = GetValue(a, i, j) - GetValue(a, i, k) + GetValue(a, j, k);
        return -1 <= x && x <= 1;
    }

    //3元の間の推移律をすべて満たすときtrue
    public static bool IsPoset(short[][] a) {
        int n = a.Length+1;
        int i = 1;
        while (i < n-1)
        {
            int j = i + 1;
            while (j < n) { 
                int k= j + 1;
                while(k < n+1)
                {
                    if (!Transitive(a, i, j, k))
                    {
                        return false;
                    }
                    k++;
                }
                j++;
            }
            i++;
        }
        return true;
    }
}