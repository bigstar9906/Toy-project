using System;


class Game{
    int[,] Map = new int[4,4];
    bool isend= false;
    Random r = new Random();
public Game()
{
    this.Map = new int[4,4] {{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0}};
}

public void PrintMap()
{
    Console.WriteLine("*****************\n");
    for(int i = 0;i<4;i++)
    {
        for(int j = 0;j<4;j++)
        {
            Console.Write("  "+this.Map[i,j]);
        }
        Console.WriteLine("\n");
    }
    Console.WriteLine("*****************\n");
}

public int SelectVal()
{
    int a = r.Next(1,10);
    if(a>4) return 2;
    else return 4;
}
public void AddBlock()
{
    int BlockVal = SelectVal();
    int PositionNum=0;
    int temp;
    int [] Position = new int [16];
    for(int i = 0;i<4;i++)
    {
        for(int j = 0;j<4;j++)
        {
            if(this.Map[i,j]==0)
            {
                Position[PositionNum] = i*4+j;
                PositionNum++;
            }
        }
    }
    if(PositionNum==0)
    {
        isend = true;
        return;
    }
    temp = Position[r.Next(0,PositionNum-1)];
    this.Map[temp/4,temp%4] = BlockVal;

}

public bool End()
{
    return this.isend;
}

}
class Program
{

    static void Main()
    {
        
        Game g = new Game();
        while(!g.End())
        {
            g.PrintMap();
            g.AddBlock();
        }
        Console.WriteLine("\n\nThis is end.");


        //종료 방지를 위해 작성
        Console.Write("종료하려면 누르세요.");
        Console.ReadKey();
    }
}