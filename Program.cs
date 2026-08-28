using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Windows.Input;
using System.Security;
using System;
using System.Media;
using NAudio;
using NAudio.Wave;
using TiledSharp;


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

    bool Freemode = true;
    bool BattleMode = false;

    BattleMode battleMode = new BattleMode();

    // InputSystem inputSystem = new InputSystem();

    Image Room1;

    // sounds
    Sound RMusic = new Sound();
    Sound RSound = new Sound();
    public Game()
    {
        var gcanvas = new Canvas{};
        Content = gcanvas;
        Title = "The rain test";
        this.WindowState = WindowState.Maximized;
        this.WindowStyle = WindowStyle.None;
        this.Topmost = true;
        this.ResizeMode = ResizeMode.NoResize;
        Icon = new BitmapImage(new Uri("assets/app.ico",UriKind.Relative));
        Background = Brushes.Black;
        this.KeyDown += InputSystem.HandlingKeysDown;
        this.KeyUp += InputSystem.HandlingKeysUp;
        this.Focusable = true;
        this.Focus();
        Loaded += async (_,__) => // :0
        // MAIN CODE HERE
        {
            await battleMode.StartBattle(
                gcanvas: gcanvas ,
                RMusic: RMusic,
                RSound: RSound,
                windowWidth: this.ActualWidth-15,
                windowHeight: this.ActualHeight-38
            );
        };
        
    }
    
    // async Task<bool> FreeMode(Canvas gcanvas)
    // {
    //     Freemode = true;
    //     BattleMode = false;
    //     int integerl = 0;
    //     player = new Player(
    //         new Image
    //         {
    //             Width = 350,
    //             Height = 350,
    //             Source = new BitmapImage(new Uri("assets/FreeMode/IdleDown.png",UriKind.Relative))
    //         }, // sprite
    //         275, //hp
    //         5, // defence
    //         windowWidth/2, //spawnX
    //         windowHeight/2, //spawnY
    //         5, // speedfromstart
    //         50, //width
    //         50, // height
    //         15, // sprintspeed
    //         4 // ishowspeed said it is "BUTTON COUNT *HAW HAW"
    //     );
    //     gcanvas.Children.Add(Room1);
    //     gcanvas.Children.Add(player.Sprite);

    //     Canvas.SetLeft(Room1,0);
    //     Canvas.SetTop(Room1,0);
    //     while (true)
    //     {
    //         windowWidth = this.ActualWidth-15;
    //         windowHeight = this.ActualHeight-38;
    //         foreach (Key kbb in InputSystem.keyboardbuttons)
    //         {
    //             Console.WriteLine(kbb);
    //         }
    //         player.Controls(0,0,windowWidth,windowHeight); 
            
    //         Canvas.SetLeft(player.Sprite,player.X);
    //         Canvas.SetTop(player.Sprite,player.Y);

    //         integerl = integerl + 1;
    //         if (integerl == 100)
    //         {
    //             Console.WriteLine("End");
    //             return true;
    //         }
    //         await Task.Delay(10);
    //         Console.WriteLine("-----------------");
    //     }
    // }
    
}