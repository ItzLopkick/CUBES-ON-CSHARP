using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

class Enemy
{
    public Image Sprite;
    public double sparepoints;
    public double hp;
    public Enemy(Image Sprite,double sparepoints,double hp)
    {
        this.Sprite = Sprite;
        this.sparepoints = sparepoints;
        this.hp = hp;
    }
    public void IfSpareIsPossible(double sparepoints)
    {
        if (sparepoints == 100)
        {
            hp = 0;
        }
        else
        {
            // text
        }
    }
}