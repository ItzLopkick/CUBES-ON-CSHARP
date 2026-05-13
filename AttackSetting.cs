using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
class AttackSettings
{
    public double attacklength;
    public double attackTime;

    public AttackSettings(double attacklength)
    {
        this.attacklength = attacklength*100;
        this.attackTime = 0;
    }
}