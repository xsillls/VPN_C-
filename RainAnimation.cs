using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

public class FullRain
{
    class Raindrop
    {
        public float X;
        public float Y;
        public float Length;
        public float Speed;
    }

    private List<Raindrop> drops = new List<Raindrop>();
    private Timer timer = new Timer();
    private Random rnd = new Random();
    private Control targetControl;
    private Color dropColor;
    private float lineWidth;
    private Stopwatch stopwatch = new Stopwatch();
    private float lastTime;
    private int dropCount;

    private float minSpeed, maxSpeed, minLength, maxLength;

    public FullRain(Control control, int dropCount = 200,
                    Color? dropColor = null,
                    float minSpeed = 150f, float maxSpeed = 400f,
                    float minLength = 5f, float maxLength = 20f,
                    float lineWidth = 2f)
    {
        targetControl = control;
        this.dropColor = dropColor ?? Color.LightBlue;
        this.dropCount = dropCount;
        this.minSpeed = minSpeed;
        this.maxSpeed = maxSpeed;
        this.minLength = minLength;
        this.maxLength = maxLength;
        this.lineWidth = lineWidth;

        targetControl.DoubleBuffered(true);
        targetControl.Paint += TargetControl_Paint;
        targetControl.Resize += TargetControl_Resize;

        InitDrops();

        timer.Interval = 1;
        timer.Tick += Timer_Tick;
        timer.Start();

        stopwatch.Start();
        lastTime = 0f;
    }

    private void InitDrops()
    {
        drops.Clear();
        for (int i = 0; i < dropCount; i++)
        {
            drops.Add(CreateDrop());
        }
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        float currentTime = (float)stopwatch.Elapsed.TotalSeconds;
        float deltaTime = currentTime - lastTime;
        lastTime = currentTime;

        foreach (var drop in drops)
        {
            drop.Y += drop.Speed * deltaTime;
            if (drop.Y > targetControl.Height)
                drop.Y = 0;
        }

        // Добавляем новые капли, если панель расширилась
        while (drops.Count < dropCount)
            drops.Add(CreateDrop());

        targetControl.Invalidate();
    }

    private Raindrop CreateDrop()
    {
        return new Raindrop
        {
            X = rnd.Next(0, Math.Max(targetControl.Width, 1)),
            Y = rnd.Next(0, Math.Max(targetControl.Height, 1)),
            Length = (float)(rnd.NextDouble() * (maxLength - minLength) + minLength),
            Speed = (float)(rnd.NextDouble() * (maxSpeed - minSpeed) + minSpeed)
        };
    }


    private void TargetControl_Paint(object sender, PaintEventArgs e)
    {
        using (Pen pen = new Pen(dropColor, lineWidth))
        {
            foreach (var drop in drops)
            {
                e.Graphics.DrawLine(pen, drop.X, drop.Y, drop.X, drop.Y + drop.Length);
            }
        }
    }

    private void TargetControl_Resize(object sender, EventArgs e)
    {
        // при изменении размера проверяем, хватает ли капель
        while (drops.Count < dropCount)
            drops.Add(CreateDrop());
    }
}

public static class ControlExtensions
{
    public static void DoubleBuffered(this Control control, bool enable)
    {
        var prop = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        prop.SetValue(control, enable, null);
    }
}
