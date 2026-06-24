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
    double wave = 2;
    bool BattleFlag = false;
    bool Attack1Flag = false;
    bool AttackFlag2 = false;
    double AttackTime = 0;
    double meteorsvalue = 10;
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
    Attack2 CC;
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
            shirinaOkna = this.ActualWidth-15; // вычесление реальных размеров окна
            vusotaOkna = this.ActualHeight-38; // круто
            // Arena!!!
            ArenaSprite = new Image
            {
                Width = 500,
                Height = 500,
                Source = new BitmapImage(new Uri("assets/btlarena.png",UriKind.Relative))
            };
            arena = new Arena(
                ArenaSprite,
                Math.Round(shirinaOkna/2-250),
                Math.Round(vusotaOkna/2-250),
                500,
                500,
                Math.Round(shirinaOkna/2-235),
                Math.Round(vusotaOkna/2-235),
                465,
                465
            );
            Console.WriteLine(arena.spriteX+" "+arena.spriteX2);
            gcanvas.Children.Add(arena.sprite);
            Canvas.SetLeft(arena.sprite,arena.spriteX);
            Canvas.SetTop(arena.sprite,arena.spriteY);

            playersprite = new Image
            {
                Width = 50,
                Height = 50,
                Source = new BitmapImage(new Uri("assets/player.png",UriKind.Relative))
            };
            player = new Player(
                playersprite, // sprite
                100, //hp
                shirinaOkna/2-200, //spawnX
                vusotaOkna/2, //spawnY
                5, // speedfromstart
                50, //width
                50, // height
                15, // sprintspeed
                4 // ishowspeed said it is "BUTTON COUNT *HAW HAW"
            );
            PlayerBTL = new Image
            {
                Width = 300,
                Height = 327,
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

            Rectangle CoolCubeSprite = new Rectangle
            {
                Width = 100,
                Height = 100,
                Fill = Brushes.White
            };
            CC = new Attack2(CoolCubeSprite,0,9999,100,100);
            gcanvas.Children.Add(CC.Sprite);
            Canvas.SetTop(CC.Sprite,CC.Y);
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
                if (BattleFlag == true && wave == 1)
                {
                    player.Speed = player.SpeedFromStart;
                    if (wave == 1)
                    {
                        foreach (Attack meteor in meteors)
                        {
                            if (CollisionsS.has_objects_collision(meteor,player) == true && attackSettings.attackTime%10 == 0)
                            {
                                player.hp = player.hp - 1;
                            }
                            meteor.Undertale();
                            Canvas.SetTop(meteor.Sprite,meteor.Y);
                            if (meteor.Y > vusotaOkna)
                            {
                                meteor.X = random.Next(Convert.ToInt32(arena.spriteX),Convert.ToInt32(arena.spriteX2));
                                meteor.Y = random.Next(-6000,-500);
                                meteor.X2 = meteor.X + meteor.Width;
                                meteor.Y2 = meteor.Y + meteor.Height;

                                Canvas.SetLeft(meteor.Sprite,meteor.X);
                                Canvas.SetTop(meteor.Sprite,meteor.Y);
                            } // Я дядя редит |:
                        }
                        // :D
                        attackSettings.attackTime = attackSettings.attackTime + 1;
                        if (attackSettings.attackTime >= attackSettings.attacklength)
                        {
                            BattleFlag = false;
                            Attack1Flag = false;
                            attackSettings.attackTime = 0;
                            MoveMeteorsOutOfBounds(meteors);
                        }
                    }
                    
                    }
                    if (BattleFlag == true && wave == 2)
                    {   // Я дядя редит |:
                        if (attackSettings.attackTime == 0)
                        {
                            CC.Apear(arena.physX,arena.physY,arena.physX2,arena.physY2);
                            Canvas.SetLeft(CC.Sprite,CC.X);
                            Canvas.SetTop(CC.Sprite,CC.Y);
                        }
                        if (CC.IsApear == true)
                        {
                            if (CC.Agresive == false)
                            {
                                if (attackSettings.attackTime%130 == 0)
                                {
                                    CC.Agresive = true;
                                    CC.Sprite.Fill = Brushes.Red;
                                }
                            }
                            if (CC.Agresive == true)
                            {
                                if (CollisionsS.has_objects_collision(CC,player) == true && attackSettings.attackTime%10 == 0)
                                {
                                    player.hp = player.hp - 2;
                                }
                                if (attackSettings.attackTime%250 == 0)
                                    {
                                        CC.Sprite.Fill = Brushes.White;
                                        CC.Disapear();
                                        Canvas.SetLeft(CC.Sprite,CC.X);
                                        Canvas.SetTop(CC.Sprite,CC.Y);
                                    }
                            }
                        }
                        if (CC.IsApear == false)
                        {
                            if (attackSettings.attackTime%270 == 0)
                                {
                                    CC.Apear(arena.physX,arena.physY,arena.physX2,arena.physY2);
                                    Canvas.SetLeft(CC.Sprite,CC.X);
                                    Canvas.SetTop(CC.Sprite,CC.Y);
                                }
                        }
                        attackSettings.attackTime = attackSettings.attackTime + 1;
                        if (attackSettings.attackTime >= attackSettings.attacklength)
                        {
                            BattleFlag = false;
                            AttackFlag2 = false;
                            attackSettings.attackTime = 0;
                            CC.Disapear();
                            CC.Sprite.Fill = Brushes.White;
                            Canvas.SetLeft(CC.Sprite,CC.X);
                            Canvas.SetTop(CC.Sprite,CC.Y);
                        }
                }
                
                // Timers
                







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
        if (BattleFlag == true)
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
        if (BattleFlag == true)
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
        else if (BattleFlag == false)
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
                if (event2.Key == Key.Enter && BattleFlag == false)
                {
                    if (buttonselected == 0)
                    {
                        Enemy1.hp = Enemy1.hp - 20;
                        PlayerBTL.Source = new BitmapImage(
                        new Uri("assets/playerbtlhitattack.png", UriKind.Relative));
                        BattleFlag = true;
                        PlayerBTL.Source = new BitmapImage(new Uri("assets/playerbtlidle.png", UriKind.Relative));
                    }
                    if (buttonselected == 1)
                    {
                        BattleFlag = true;
                    }
                    if (buttonselected == 2)
                    {
                        BattleFlag = true;
                    }
                    if (buttonselected == 3)
                    {
                        BattleFlag = true;
                    }
                }
        }
        if (event2.Key == Key.Escape)
        {
            
        }
        event2.Handled = true;
    }
    
    void CreateMeteors(double value)
    {
        for (int i = 0;i < value; i++)
        {
            double MeteorWidth = random.Next(70,100);
            double MeteorHeight = random.Next(70,100);
            Rectangle meteorsprite = new Rectangle{Width = MeteorWidth,Height = MeteorHeight,Fill = Brushes.Red};
            Attack meteor = new Attack(
                meteorsprite,
                random.Next(Convert.ToInt32(arena.spriteX),Convert.ToInt32(arena.spriteX2)), // X
                3000, // Y
                MeteorWidth,
                MeteorHeight,
                6
            );
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