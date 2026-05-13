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

public static class Program
{
    [System.STAThread]
    public static void Main()
    {
        var aboba = new Application();
        aboba.Run(new Game());
    }
}

public class Game:Window
{
    private static readonly WaveOutEvent waveOut = new();
    bool AttackFlag = false;
    double AttackTime = 0;
    double meteorsvalue = 20;
    double buttonselected = 1;
    List<Attack> meteors = new List<Attack>{};
    Image playersprite;
    double shirinaOkna;
    double vusotaOkna;
    Player player;
    Image AttckBtnSprite;
    BtlButton AttackBtn;
    Image ActBtnSprite;
    BtlButton ActBtn;
    Image SpareBtnSprite;
    BtlButton SpareBtn;
    Image BlockBtnSprite;
    BtlButton BlockBtn;
    List<bool> buttons = new List<bool>{};
    Image PlayerBTL;
    Image EnemySprite;
    Enemy Enemy1;
    Image ArenaSprite;
    Image StephBar;
    TextBox PlayerHp;
    Timer Exiting;
    AttackSettings attackSettings;
    Arena arena;
    // Sounds
    Sound RMusic = new Sound();
    Sound RSound = new Sound();

    // RANDOM
    Random random = new Random();
    public Game()
    {
        // Озон . Настройка окна
        var gcanvas = new Canvas{};
        Content = gcanvas;
        MessageBox.Show("Version 1.7");
        Title = "The rain test";
        // Width = 1000;
        // Height = 1000;
        this.WindowState = WindowState.Maximized;
        this.WindowStyle = WindowStyle.None;
        this.Topmost = true;
        this.ResizeMode = ResizeMode.NoResize;
        Icon = new BitmapImage(new Uri("assets/app.ico",UriKind.Relative));
        Background = Brushes.Black;
        // Короче это привазка функции к клавиатуре и создаём Loaded
        this.KeyDown += HandlingKeysDown;
        this.KeyUp += HandlingKeysUp;
        this.Focusable = true;
        this.Focus();
        Loaded += async (_,__) => // :0
        // MAIN CODE HERE
        {
            RMusic.PlayLoop("assets/sounds/Run.mp3");
            RSound.PlaySound("assets/sounds/metal.mp3");
            shirinaOkna = this.ActualWidth-15; // вычесление реальных размеров окна
            vusotaOkna = this.ActualHeight-38; // круто
            // Arena!!!
            ArenaSprite = new Image
            {
                Width = 500,
                Height = 500,
                Source = new BitmapImage(new Uri("assets/btlarena.png",UriKind.Relative))
            };
            Arena arena = new Arena(ArenaSprite,shirinaOkna/2-250,vusotaOkna/2-250,500,500,shirinaOkna/2-235,vusotaOkna/2-235,520,520); //-235 -220
            gcanvas.Children.Add(arena.sprite);
            Canvas.SetLeft(arena.sprite,arena.spriteX);
            Canvas.SetTop(arena.sprite,arena.spriteY);

            playersprite = new Image
            {
                Width = 50,
                Height = 50,
                Source = new BitmapImage(new Uri("assets/player.png",UriKind.Relative))
            };
            player = new Player(playersprite,100,shirinaOkna/2-200,vusotaOkna/2,10,100,100,15,4);  // shirinaOkna/2-200,vusotaOkna/2
            PlayerBTL = new Image
            {
                Width = 200,
                Height = 227,
                Source = new BitmapImage(new Uri("assets/playerbtlidle.png",UriKind.Relative))
            };

            Enemy1 = new Enemy(EnemySprite,0,250);
            // GUI buttons / bar
            AttckBtnSprite = new Image
            {
                Width = 100,
                Height = 100,
                Source = new BitmapImage(new Uri("assets/AttackButton.png",UriKind.Relative))
            };
            ActBtnSprite = new Image
            {
                Width = 100,
                Height = 100,
                Source = new BitmapImage(new Uri("assets/AttackButton.png",UriKind.Relative))
            };
            SpareBtnSprite = new Image
            {
                Width = 100,
                Height = 100,
                Source = new BitmapImage(new Uri("assets/AttackButton.png",UriKind.Relative))
            };
            BlockBtnSprite = new Image
            {
                Width = 100,
                Height = 100,
                Source = new BitmapImage(new Uri("assets/AttackButton.png",UriKind.Relative))
            };
            AttackBtn = new BtlButton(AttckBtnSprite,shirinaOkna/2-150,vusotaOkna-100,100,100,false,true);
            ActBtn = new BtlButton(ActBtnSprite,shirinaOkna/2-50,vusotaOkna-100,100,100,false,false);
            SpareBtn = new BtlButton(SpareBtnSprite,shirinaOkna/2+50,vusotaOkna-100,100,100,false,false);
            BlockBtn = new BtlButton(BlockBtnSprite,shirinaOkna/2+150,vusotaOkna-100,100,100,false,false);

            StephBar = new Image
            {
                Width = 250,
                Height = 50,
                Source = new BitmapImage(new Uri("assets/Stephsbar.png",UriKind.Relative))
            };
            gcanvas.Children.Add(StephBar);
            Canvas.SetLeft(StephBar,shirinaOkna/2-100);
            Canvas.SetTop(StephBar,vusotaOkna-150);
            PlayerHp = new TextBox
            {
                Width = 100,
                Height = 20,
                Text = ""+player.hp
            };
            PlayerHp.Foreground = Brushes.White;
            PlayerHp.Background = Brushes.Black;
            PlayerHp.FontFamily = new FontFamily("Georgia");
            PlayerHp.IsHitTestVisible = false;
            TextOptions.SetTextFormattingMode(PlayerHp, TextFormattingMode.Display);
            TextOptions.SetTextRenderingMode(PlayerHp, TextRenderingMode.Aliased);
            gcanvas.Children.Add(PlayerHp);
            Canvas.SetLeft(PlayerHp,shirinaOkna/2+400);
            Canvas.SetTop(PlayerHp,vusotaOkna-150);
            // Attack :)
            // Setings :)
            AttackSettings attackSettings = new AttackSettings
            (
                20    // Time
            );
            // Timers
            Timer Exiting = new Timer(5);


            gcanvas.Children.Add(player.Sprite);
            gcanvas.Children.Add(PlayerBTL);
            Canvas.SetLeft(player.Sprite, player.X);
            Canvas.SetTop(player.Sprite, player.Y);
            Canvas.SetLeft(PlayerBTL, 50);
            Canvas.SetTop(PlayerBTL,vusotaOkna/2);

            gcanvas.Children.Add(AttackBtn.Sprite);
            Canvas.SetLeft(AttackBtn.Sprite, AttackBtn.X);
            Canvas.SetTop(AttackBtn.Sprite,AttackBtn.Y);
            gcanvas.Children.Add(ActBtn.Sprite);
            Canvas.SetLeft(ActBtn.Sprite, ActBtn.X);
            Canvas.SetTop(ActBtn.Sprite,ActBtn.Y);
            gcanvas.Children.Add(SpareBtn.Sprite);
            Canvas.SetLeft(SpareBtn.Sprite,SpareBtn.X);
            Canvas.SetTop(SpareBtn.Sprite,SpareBtn.Y);
            gcanvas.Children.Add(BlockBtn.Sprite);
            Canvas.SetLeft(BlockBtn.Sprite, BlockBtn.X);
            Canvas.SetTop(BlockBtn.Sprite,BlockBtn.Y);

            CreateMeteors(meteorsvalue);
            foreach (Attack meteor in meteors)
            {
                gcanvas.Children.Add(meteor.Sprite);
                Canvas.SetLeft(meteor.Sprite,meteor.X);
                Canvas.SetTop(meteor.Sprite,meteor.Y);
            }
            buttons.Add(AttackBtn.IsActive);
            buttons.Add(ActBtn.IsActive);
            buttons.Add(SpareBtn.IsActive);
            buttons.Add(BlockBtn.IsActive);
            while (1 == 1)
            {
                shirinaOkna = this.ActualWidth-15; // вычесление реальных размеров окна
                vusotaOkna = this.ActualHeight-38; // круто
                player.Controls(arena.physX,arena.physY,arena.physWidth,arena.physHeight); 
                Canvas.SetLeft(player.Sprite,player.X);
                Canvas.SetTop(player.Sprite,player.Y);
                Canvas.SetLeft(PlayerBTL, 50);
                Canvas.SetTop(PlayerBTL,vusotaOkna/2);

                PlayerHp.Text = ""+player.hp;


                if (AttackFlag == true)
                {
                    player.Speed = player.SpeedFromStart;
                    foreach (Attack meteor in meteors)
                    {
                        meteor.Undertale();
                        Canvas.SetTop(meteor.Sprite,meteor.Y);
                        if (meteor.Y > vusotaOkna)
                        {

                            meteor.X = random.Next(0,Convert.ToInt32(shirinaOkna));
                            meteor.Y = random.Next(-6000,-500);

                            Canvas.SetLeft(meteor.Sprite,meteor.X);
                            Canvas.SetTop(meteor.Sprite,meteor.Y);
                        }
                    }
                    // :D
                    attackSettings.attackTime = attackSettings.attackTime + 1;
                    if (attackSettings.attackTime >= attackSettings.attacklength)
                    {
                        AttackFlag = false;
                        attackSettings.attackTime = 0;
                        MoveMeteorsOutOfBounds(meteors);
                    }
                }
                
                // Timers
                Exiting.AddTime(Exiting.Time,Exiting.TimeMax,Exiting.IsTimerActive,Exiting.DoAction);







                // tick
                await Task.Delay(10);
            }
            
            
        };
        
    }
    void HandlingButtons()
    {
        // число увиличивается и проверяет если нажата вправо-left (если число следуеше 2 3 4 1)
        if (buttonselected == 0)
        {
            AttackBtn.Sprite.Source = new BitmapImage(new Uri("assets/AttackButtonSelected.png",UriKind.Relative));
        }
        if (buttonselected != 0)
        {
            AttackBtn.Sprite.Source = new BitmapImage(new Uri("assets/AttackButton.png",UriKind.Relative));
        }
        if (buttonselected == 1)
        {
            ActBtn.Sprite.Source = new BitmapImage(new Uri("assets/AttackButtonSelected.png",UriKind.Relative));
        }
        if (buttonselected != 1)
        {
            ActBtn.Sprite.Source = new BitmapImage(new Uri("assets/AttackButton.png",UriKind.Relative));
        }
        if (buttonselected == 2)
        {
            SpareBtn.Sprite.Source = new BitmapImage(new Uri("assets/AttackButtonSelected.png",UriKind.Relative));
        }
        if (buttonselected != 2)
        {
            SpareBtn.Sprite.Source = new BitmapImage(new Uri("assets/AttackButton.png",UriKind.Relative));
        }
        if (buttonselected == 3)
        {
            BlockBtn.Sprite.Source = new BitmapImage(new Uri("assets/AttackButtonSelected.png",UriKind.Relative));
        }
        if (buttonselected != 3)
        {
            BlockBtn.Sprite.Source = new BitmapImage(new Uri("assets/AttackButton.png",UriKind.Relative));
        }
    }
    void HandlingKeysUp(object Sender,KeyEventArgs event2)
    {
        if (AttackFlag == true)
        {
            if (event2.Key == Key.Right)
            {
                player.MoveRightFlag = false;
            }
            if (event2.Key == Key.Up)
            {
                player.MoveUpFlag = false;
            }
            if (event2.Key == Key.Left)
            {
                player.MoveLeftFlag = false;
            }
            if (event2.Key == Key.Down)
            {
                player.MoveDownFlag = false;
            }
            if (event2.Key == Key.LeftShift)
            {
                player.ShiftFlag = false;
            }
            if (event2.Key == Key.C)
            {
                
            }
        }
        // else if (AttackFlag == false)
        // {
        //     if (event2.Key == Key.Right)
        //     {
                    
        //     }
        //     if (event2.Key == Key.Up)
        //     {
                
        //     }
        //     if (event2.Key == Key.Left)
        //     {
                
        //     }
        //     if (event2.Key == Key.Down)
        //     {
                
        //     }
        //     if (event2.Key == Key.LeftShift)
        //     {
                
        //     }
        //     if (event2.Key == Key.C)
        //     {
                
        //     }
        // }
        if (event2.Key == Key.Escape)
        {
            
        }
        event2.Handled = true;
    }
    void HandlingKeysDown(object Sender,KeyEventArgs event2)
    {
        if (AttackFlag == true)
        {
            if (event2.Key == Key.Right)
            {
                player.MoveRightFlag = true;
            }
            if (event2.Key == Key.Up)
            {
                player.MoveUpFlag = true;
            }
            if (event2.Key == Key.Down)
            {
                player.MoveDownFlag = true;
            }
            if (event2.Key == Key.Left)
            {
                player.MoveLeftFlag = true;
            }
            if (event2.Key == Key.LeftShift)
            {
                player.ShiftFlag = true;
            }
        }
        else if (AttackFlag == false)
        {
            player.MoveLeftFlag = false;
            player.MoveRightFlag = false;
            player.MoveUpFlag = false;
            player.MoveDownFlag = false;
            if (event2.Key == Key.Right)
                {
                    if (buttonselected > 3)
                    {
                        buttonselected = 0;
                        HandlingButtons();
                    }
                    else
                    {
                        buttonselected = buttonselected+1;
                        HandlingButtons();
                    }
                }
                if (event2.Key == Key.Left)
                {
                    if (buttonselected < 0)
                    {
                        buttonselected = 3;
                        HandlingButtons();
                    }
                    else
                    {
                        buttonselected = buttonselected-1;
                        HandlingButtons();
                    }
                }
                if (event2.Key == Key.Enter && AttackFlag == false)
                {
                    if (buttonselected == 0)
                    {
                        Enemy1.hp = Enemy1.hp - 20;
                        PlayerBTL.Source = new BitmapImage(
                        new Uri("assets/playerbtlhitattack.png", UriKind.Relative));
                        AttackFlag = true;
                        PlayerBTL.Source = new BitmapImage(new Uri("assets/playerbtlidle.png", UriKind.Relative));
                    }
                    if (buttonselected == 1)
                    {
                        AttackFlag = true;
                    }
                    if (buttonselected == 2)
                    {
                        AttackFlag = true;
                    }
                    if (buttonselected == 3)
                    {
                        AttackFlag = true;
                    }
                }
        }
        if (event2.Key == Key.Escape)
        {
            Exiting.Activate(Exiting.IsTimerActive);
            if (Exiting.DoAction == true)
            {
                this.Close();
            }
        }
        event2.Handled = true;
    }
    
    void CreateMeteors(double value)
    {
        for (int i = 0;i < value; i++)
        {
            Rectangle meteorsprite = new Rectangle{Width = random.Next(70,100),Height = random.Next(70,100),Fill = Brushes.Red};
            Attack meteor = new Attack(meteorsprite,random.Next(0,Convert.ToInt32(shirinaOkna)),9999,meteorsprite.Width,meteorsprite.Height,random.Next(15,25));
            meteors.Add(meteor);
        }
    }
    void MoveMeteorsOutOfBounds(List<Attack> meteors)
    {
        foreach (Attack meteor in meteors)
        {
            meteor.Y = meteor.Y +9999;
            Canvas.SetTop(meteor.Sprite,meteor.Y);
        }
    }
}