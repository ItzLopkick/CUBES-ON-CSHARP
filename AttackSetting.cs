using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
class AttackSettings
{
    public double attacklength;
    public List<Attack> attacks;

    public AttackSettings(double attacklength,List<Attack> attacks)
    {
        this.attacklength = attacklength;
        this.attacks = attacks;
    }
}