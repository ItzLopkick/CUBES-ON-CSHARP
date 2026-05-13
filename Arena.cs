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




class Arena
{
    public Image sprite;
    public double spriteX2;
    public double spriteY2; 
    public double spriteX;
    public double spriteY;
    public double spriteWidth;
    public double spriteHeight;
    public double physX;
    public double physY;
    public double physX2;
    public double physY2;
    public double physWidth;
    public double physHeight;
    public Arena(Image sprite,double spriteX,double spriteY,double spriteWidth,double spriteHeight,double PhysX,double PhysY,double physWidth,double physHeight)
    {
        this.sprite = sprite;
        this.spriteX = spriteX;
        this.spriteY = spriteY;
        this.spriteX2 = spriteX+spriteWidth;
        this.spriteY2 = spriteY+spriteHeight;
        this.spriteWidth = spriteWidth;
        this.spriteHeight = spriteHeight;
        this.physX = PhysX;
        this.physY = PhysY;
        this.physWidth = physWidth;
        this.physHeight = physHeight;
        this.physX2 = PhysX+physWidth;
        this.physY2 = PhysY+physHeight;
    }
}