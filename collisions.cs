using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using System.Security;
using System;
using System.Media;
using NAudio;
using NAudio.Wave;
class Collisions
{
    public Player player;
    public Attack attacki;
    public Image playerSprite;
    public Rectangle attackSprite;
    
    public Collisions()
    {
        playerSprite = new Image
        {
            Width = 500,
            Height = 500,
            Source = new BitmapImage(new Uri("assets/btlarena.png",UriKind.Relative))
        };
        attackSprite = new Rectangle
        {
            Width = 500,
            Height = 500,
            Fill = Brushes.Green
        };
        player = new Player(playerSprite,0,0,0,0,0,0,0,0);
        attacki = new Attack(attackSprite,0,0,0,0,0);
    }
    public void has_player_collisions_meteor()
    {
        
    }
}