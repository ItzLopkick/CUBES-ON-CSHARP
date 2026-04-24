using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public class Attack
{
    public Rectangle Sprite;
    public double X;
    public double Y;
    public double Speed;
    public double Width;
    public double Height;
    public Attack(Rectangle Sprite,double X, double Y,double Width,double Height,double Speed)
    {
        this.Sprite = Sprite;
        this.X = X;
        this.Y = Y;
        this.Width = Width;
        this.Height = Height;
        this.Speed = Speed;
    }
    public void Undertale()
    {
        this.Y = this.Y+this.Speed;
    }
}
// Домашнее задание: 

// 1) Создать файл Meteor.cs
// 2) В нём создать класс Meteor
// 3) По сути у метеора пока что будут только переменные x,y,width,height - создать их
// 4) Функция у метеора будет только одна - падать. По аналогии с игроком, в этой функции будет только логика падения (без отрисовки). То есть в этой функции будет просто увеличиваться y и всё - буквально одна срока кода