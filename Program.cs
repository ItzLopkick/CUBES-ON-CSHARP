using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security;
using System.Drawing;
using System.Runtime.InteropServices.Marshalling;

public static class Program
{
    [System.STAThread]
    public static void Main()
    {
        var aboba = new Application();
        aboba.Run(new Okoshka());
    }
}



public class Okoshka:Window
{

    public Okoshka()
    {
        Title = "Square";
        Width = 1000;
        Height = 1000;
        Icon = new BitmapImage(new Uri("pack://application:,,,/assets/app.ico"));
        var gcanvas = new Canvas{};
        var sqaure = new Rectangle{Width = 100,Height = 100,Fill = Brushes.Red};
        var sqaure2 = new Rectangle{Width = 100,Height = 100,Fill = Brushes.Green};
        var sqaure3 = new Rectangle{Width = 100,Height = 100,Fill = Brushes.Yellow};
        gcanvas.Children.Add(sqaure); // добавление фигуры
        gcanvas.Children.Add(sqaure2);
        gcanvas.Children.Add(sqaure3);
        Canvas.SetLeft(sqaure,100);
        Canvas.SetTop(sqaure,100);
        Canvas.SetLeft(sqaure2,250);
        Canvas.SetTop(sqaure2,100);
        Canvas.SetLeft(sqaure3,370);
        Canvas.SetTop(sqaure3,100);
        var img = new Image
        {
            Width = 200,
            Height = 200,
            Source = new BitmapImage(new Uri("pack://application:,,,/assets/app.ico"))
        };
        var btn = new Button
        {
            Content = "Full version",
            Width = 350,
            Height = 60
        };

        gcanvas.Children.Add(btn);
        Canvas.SetLeft(btn, 300);
        Canvas.SetTop(btn, 300);
        gcanvas.Children.Add(img);
        Canvas.SetLeft(img, 500);
        Canvas.SetTop(img, 500);

        Content = gcanvas;

        Loaded += async (_,__) =>
        {
            await Task.Delay(3000);
            Canvas.SetLeft(img,-56667);
            while (1 == 1)
            {
                double y = Canvas.GetTop(sqaure);
                y = y+10;
                Canvas.SetTop(sqaure,y);
                await Task.Delay(10);
                double wdths = this.Width;
                double hiths = this.Height;
                if (y > wdths)
                {
                    Canvas.SetTop(sqaure,-500);
                }
                double y2 = Canvas.GetTop(sqaure2);
                y2 = y2+10;
                Canvas.SetTop(sqaure2,y);
                await Task.Delay(10);
                double wdths2 = this.Width;
                double hiths2 = this.Height;
                if (y2 > wdths2)
                {
                    Canvas.SetTop(sqaure2,-500);
                }
                double y3 = Canvas.GetTop(sqaure3);
                y3 = y3+10;
                Canvas.SetTop(sqaure3,y);
                await Task.Delay(10);
                double wdths3 = this.Width;
                double hiths3 = this.Height;
                if (y3 > wdths3)
                {
                    Canvas.SetTop(sqaure3,-500);
                }
            }
            
        };
        btn.Click += (s, e) =>
        {
            double ytwo = 1000;
            MessageBox.Show("Downloading");
            Canvas.SetTop(btn,ytwo);
            var S1 = new Okoshkatwo();
            this.Close();
            S1.Show();
        };

    }
}
public class Okoshkatwo:Window
{
    public Okoshkatwo()
    {
        double shirinaOkna = this.Width;
        double vusotaOkna = this.Height;
        Random random = new Random();
        MessageBox.Show("Version 1.1");
        Title = "Squre";
        Width = 1000;
        Height = 1000;
        Icon = new BitmapImage(new Uri("pack://application:,,,/assets/app.ico"));
        var gcanvas = new Canvas{};
        var img = new Image
        {
            Width = 200,
            Height = 200,
            Source = new BitmapImage(new Uri("pack://application:,,,/assets/app.ico"))
        };
        gcanvas.Children.Add(img);
        Canvas.SetLeft(img, 500);
        Canvas.SetTop(img, 500);

        var squres = new List<Rectangle>
        {
            new Rectangle{Width = random.Next(100,250),Height = random.Next(100,250),Fill = Brushes.Red},
            new Rectangle{Width = random.Next(100,250),Height = random.Next(100,250),Fill = Brushes.Red},
            new Rectangle{Width = random.Next(100,250),Height = random.Next(100,250),Fill = Brushes.Red},
            new Rectangle{Width = random.Next(100,250),Height = random.Next(100,250),Fill = Brushes.Red},
            new Rectangle{Width = random.Next(100,250),Height = random.Next(100,250),Fill = Brushes.Red},
            new Rectangle{Width = random.Next(100,250),Height = random.Next(100,250),Fill = Brushes.Red}
        };
        var player = new Rectangle
        {
            Width = 100,
            Height = 100
        };

        foreach (Rectangle rect in squres)
        {
            gcanvas.Children.Add(rect);
            Canvas.SetLeft(rect,random.Next(0,Convert.ToInt32(Width)));
            Canvas.SetTop(rect,random.Next(-10000,0));
        }
        // var sqaure = new Rectangle{Width = 100,Height = 100,Fill = Brushes.Red};
        // gcanvas.Children.Add(sqaure); // добавление фигуры
        // Canvas.SetLeft(sqaure,100);
        // Canvas.SetTop(sqaure,100);

        Content = gcanvas;

        Loaded += async (_,__) =>
        {
            await Task.Delay(3000);
            Canvas.SetLeft(img,-56667);
            while (1 == 1)
            {
                // double squareX = Canvas.GetLeft(sqaure);
                // double squareY = Canvas.GetTop(sqaure);
                // squareY = squareY+10;
                // Canvas.SetTop(sqaure,squareY);
                // double shirinaOkna = this.Width;
                // double vusotaOkna = this.Height;
                // if (squareY > vusotaOkna)
                // {
                //     int vusotaOknaInt = Convert.ToInt32(vusotaOkna);
                //     int shirinaOknaInt = Convert.ToInt32(shirinaOkna);

                //     int xRandom = random.Next(0,shirinaOknaInt);
                //     int yRandom = random.Next(-6000,-500);
                //     Canvas.SetLeft(sqaure,xRandom);
                //     Canvas.SetTop(sqaure,yRandom);
                // }
                foreach (Rectangle rect in squres)
                {
                    double squareX = Canvas.GetLeft(rect);
                    double squareY = Canvas.GetTop(rect);
                    squareY = squareY+10;
                    Canvas.SetTop(rect,squareY);
                    double shirinaOkna = this.Width;
                    double vusotaOkna = this.Height;
                    if (squareY > vusotaOkna)
                    {
                        int vusotaOknaInt = Convert.ToInt32(vusotaOkna);
                        int shirinaOknaInt = Convert.ToInt32(shirinaOkna);

                        int xRandom = random.Next(0,shirinaOknaInt);
                        int yRandom = random.Next(-6000,-500);
                        Canvas.SetLeft(rect,xRandom);
                        Canvas.SetTop(rect,yRandom);
                    }
                }

                // tick
                await Task.Delay(10);
            }
            
        };
    }
}