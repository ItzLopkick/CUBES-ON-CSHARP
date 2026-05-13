using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public class Player
{
    public Image Sprite;
    public double Speed;
    public double X;
    public double Y;
    public double Width;
    public double Height;
    public double SpeedBuff;
    public double hp;
    public bool MoveUpFlag = false;
    public bool MoveRightFlag = false;
    public bool MoveDownFlag = false;
    public bool MoveLeftFlag = false;
    public bool ShiftFlag = false;
    public double SpeedFromStart;
    public double ButtonCount;
    public Player(Image Sprite,double hp,double X,double Y,double SpeedFromStart,double Width, double Height, double SpeedBuff, double ButtonCount)
    {
        this.Sprite = Sprite;
        this.hp = hp;
        this.SpeedFromStart = SpeedFromStart;
        this.Speed = SpeedFromStart;
        this.X = X;
        this.Y = Y;
        this.Width = Width;
        this.Height = Height;
        this.SpeedBuff = SpeedBuff;
        this.MoveUpFlag = false;
        this.MoveLeftFlag = false;
        this.MoveRightFlag = false;
        this.ShiftFlag = false;
        this.ButtonCount = ButtonCount;
    }
    public void Controls(double ArenaX, double ArenaY, double ArenaWidth, double ArenaHeight)
    {
        double ArenaX2 = ArenaX+ArenaWidth;
        double ArenaY2 = ArenaY+ArenaHeight;
        if (ShiftFlag == true)
        {
            Speed = SpeedBuff;
        }
        else
        {
            Speed = SpeedFromStart;
        }
        if ((MoveRightFlag == true || MoveLeftFlag == true) && (MoveDownFlag == true || MoveUpFlag == true))
        {
            Speed = Speed*0.7;
        }
        else
        {
            Speed = SpeedFromStart;
        }
        if (MoveLeftFlag == true)
        {
            // Console.WriteLine("!left");
            if ((X - Speed) < ArenaX)
            {
                X = ArenaX;
                // Console.WriteLine("!left_nope");
            }
            else
            {
                X = X-Speed;
            }
        }
        if (MoveRightFlag == true)
        {
            // Console.WriteLine("!right");
            if ((X + Speed + Width) >  ArenaX2)
            {
                X = ArenaX2-Width;
                // Console.WriteLine("!right_nope");
            }
            else
            {
                X = X+Speed;          
            }
        }
        if (MoveUpFlag == true)
        {
            // Console.WriteLine("!up");
            if ((Y - Speed) < ArenaY)
            {
                Y = ArenaY;
                // Console.WriteLine("!up_nope");
            }
            else
            {
                Y = Y-Speed;
            }
        }
        if (MoveDownFlag == true)
        {
            // Console.WriteLine("!down");
            if ((Y + Speed + Height) > ArenaY2)
            {
                Y = ArenaY2-Height;
                // Console.WriteLine("!down_nope");
            }
            else
            {
                Y = Y+Speed;
            }
        }
    }
    // if (ShiftFlag == true)
        // {
        //     Speed = SpeedBuff;
        // }
        // else
        // {
        //     Speed = SpeedFromStart;
        // }
        // if ((MoveRightFlag == true || MoveLeftFlag == true) && (MoveDownFlag == true || MoveUpFlag == true))
        // {
        //     Speed = Speed*0.7;
        // }
        // else
        // {
        //     Speed = SpeedFromStart;
        // }
        // if (MoveLeftFlag == true)
        // {
        //     // Console.WriteLine("!left");
        //     if ((X - Speed) < 0)
        //     {
        //         X = 0;
        //         // Console.WriteLine("!left_nope");
        //     }
        //     else
        //     {
        //         X = X-Speed;
        //     }
        // }
        // if (MoveRightFlag == true)
        // {
        //     // Console.WriteLine("!right");
        //     if ((X + Speed + Width) >  LevelWidth)
        //     {
        //         X = LevelWidth-Width;
        //         // Console.WriteLine("!right_nope");
        //     }
        //     else
        //     {
        //         X = X+Speed;          
        //     }
        // }
        // if (MoveUpFlag == true)
        // {
        //     // Console.WriteLine("!up");
        //     if ((Y - Speed) < 0)
        //     {
        //         Y = 0;
        //         // Console.WriteLine("!up_nope");
        //     }
        //     else
        //     {
        //         Y = Y-Speed;
        //     }
        // }
        // if (MoveDownFlag == true)
        // {
        //     // Console.WriteLine("!down");
        //     if ((Y + Speed + Height) > LevelHeight)
        //     {
        //         Y = LevelHeight-Height;
        //         // Console.WriteLine("!down_nope");
        //     }
        //     else
        //     {
        //         Y = Y+Speed;
        //     }
        // }
}