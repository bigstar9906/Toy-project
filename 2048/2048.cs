using System;


class Game{
    int[,] Map = new int[4,4];
    int[,]preMap = new int [4,4];
    int[,]tempMap = new int [4,4];
    bool isend= false;
    Random r = new Random();
public Game()
{
    this.Map = new int[4,4] {{0,0,0,0},{0,0,4,0},{0,0,0,0},{0,0,0,0}};
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

//데이터 실험용 삭제해야함 나중에
public void PrintpreMap()
{
    Console.WriteLine("*****************\n");
    for(int i = 0;i<4;i++)
    {
        for(int j = 0;j<4;j++)
        {
            Console.Write("  "+this.preMap[i,j]);
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





public void PressL()
{
    int cmp = -1;
    int pos = 0;
    for(int i = 0;i<4;i++)
    {
        cmp = -1;
        pos = 0;
        for(int j = 0;j<4;j++)
        {
            preMap[i,j] = Map[i,j];
            if(cmp==this.Map[i,j])
            {
                this.Map[i,j-1] = cmp*2;
                this.Map[i,j] = 0;
            }
            cmp = this.Map[i,j];
        }
        for(int j=0;j<4;j++)
        {
            if(this.Map[i,j]!=0)
            {
                this.Map[i,pos] = this.Map[i,j];
                if(j!=0)this.Map[i,j] = 0;
                pos++;

            }
        }
    }

    if(!preMap.Equals(this.Map))
    {
        AddBlock();
        PrintMap();
    }
}




}
class Program
{

    static void Main()
    {
        
        Game g = new Game();
        g.AddBlock();
        g.PrintMap();
        g.PressL();
        g.PressL();
        g.PressL();

        Console.WriteLine("\n\nThis is end.");


        //종료 방지를 위해 작성
        Console.Write("종료하려면 누르세요.");
        Console.ReadKey();
    }
}