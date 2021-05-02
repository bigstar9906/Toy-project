using System;


class Game{
    int[,] Map = new int[4,4];
public Game()
{
    this.Map = new int[4,4] {{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0}};
}

public void PrintMap()
{
    for(int i = 0;i<4;i++)
    {
        for(int j = 0;j<4;j++)
        {
            Console.Write("  "+this.Map[i,j]);
        }
        Console.WriteLine("\n");
    }
}

}
class Program
{

    static void Main()
    {
        
        Game g = new Game();
        g.PrintMap();


        //종료 방지를 위해 작성
        Console.Write("종료하려면 누르세요.");
        Console.ReadKey();
    }
}