using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
static class CollisionsS
{
    public static bool has_objects_collision(Attack obj1,Player obj2)
    {
        if (obj1.X < obj2.X2 && obj1.Y2 > obj2.Y && obj1.X2 > obj2.X && obj2.Y2 > obj1.Y){return true;}
        else {return false;}
    }
}
// if (obj1.X < obj2.X2 && obj1.Y2 > obj2.Y && obj1.X2 > obj2.X && obj2.Y2 > obj1.Y){obj2.hp = obj2.hp - 1;}