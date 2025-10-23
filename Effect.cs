using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace C_Menu_Test
{
    public class SymbolRain
    {
        private class SymbolDrop
        {
            public string Text;
            public PointF Position;
            public float Speed;
            public float SwingOffset;
            public float SwingSpeed;
            public float SwingAmplitude;
            public Font Font;
            public Color Color;
        }

        private Panel targetPanel;
        private Timer timer;
        private List<SymbolDrop> drops = new List<SymbolDrop>();
        private Random rnd = new Random();

        private int dropCount;
        private string[] symbols;
        private float minSpeed, maxSpeed;
        private float minAmplitude, maxAmplitude;
        private float minSwingSpeed, maxSwingSpeed;
        private float minFontSize, maxFontSize;
        private Font baseFont;
        private Color colorFrom, colorTo;

        public SymbolRain(Panel panel,
                          string[] symbols,
                          Color colorFrom,
                          Color colorTo,
                          int dropCount = 50,
                          float minSpeed = 0.5f,
                          float maxSpeed = 2f,
                          float minAmplitude = 5f,
                          float maxAmplitude = 20f,
                          float minSwingSpeed = 0.05f,
                          float maxSwingSpeed = 0.15f,
                          float minFontSize = 12f,
                          float maxFontSize = 18f,
                          Font font = null)
        {
            targetPanel = panel;
            this.symbols = symbols;
            this.dropCount = dropCount;
            this.minSpeed = minSpeed;
            this.maxSpeed = maxSpeed;
            this.minAmplitude = minAmplitude;
            this.maxAmplitude = maxAmplitude;
            this.minSwingSpeed = minSwingSpeed;
            this.maxSwingSpeed = maxSwingSpeed;
            this.minFontSize = minFontSize;
            this.maxFontSize = maxFontSize;
            this.baseFont = font ?? new Font("Consolas", 12, FontStyle.Bold);
            this.colorFrom = colorFrom;
            this.colorTo = colorTo;

            targetPanel.DoubleBuffered(true); // включаем DoubleBuffered
            InitDrops();

            timer = new Timer();
            timer.Interval = 16; // ~60 fps
            timer.Tick += Timer_Tick;
            timer.Start();

            targetPanel.Paint += TargetPanel_Paint;
        }
        private float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private void InitDrops()
        {
            drops.Clear();
            for (int i = 0; i < dropCount; i++)
            {
                float fontSize = minFontSize + (float)rnd.NextDouble() * (maxFontSize - minFontSize);
                Font font = new Font(baseFont.FontFamily, fontSize, baseFont.Style);

                drops.Add(new SymbolDrop
                {
                    Text = symbols[rnd.Next(symbols.Length)],
                    Position = new PointF(rnd.Next(targetPanel.Width), rnd.Next(targetPanel.Height)),
                    Speed = minSpeed + (float)rnd.NextDouble() * (maxSpeed - minSpeed),
                    SwingAmplitude = minAmplitude + (float)rnd.NextDouble() * (maxAmplitude - minAmplitude),
                    SwingSpeed = minSwingSpeed + (float)rnd.NextDouble() * (maxSwingSpeed - minSwingSpeed),
                    SwingOffset = 0,
                    Font = font,
                    Color = MixColors(colorFrom, colorTo, (float)rnd.NextDouble())
                });
            }
        }

        private Color MixColors(Color c1, Color c2, float t)
        {
            t = Clamp(t, 0f, 1f);
            int r = (int)(c1.R + (c2.R - c1.R) * t);
            int g = (int)(c1.G + (c2.G - c1.G) * t);
            int b = (int)(c1.B + (c2.B - c1.B) * t);
            int a = (int)(c1.A + (c2.A - c1.A) * t);
            return Color.FromArgb(a, r, g, b);
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var drop in drops)
            {
                drop.Position = new PointF(
                    drop.Position.X + (float)Math.Sin(drop.Position.Y * drop.SwingSpeed) * drop.SwingAmplitude * 0.1f,
                    drop.Position.Y + drop.Speed
                );

                if (drop.Position.Y > targetPanel.Height)
                {
                    drop.Position = new PointF(rnd.Next(targetPanel.Width), -20);
                    drop.Text = symbols[rnd.Next(symbols.Length)];
                    drop.Speed = minSpeed + (float)rnd.NextDouble() * (maxSpeed - minSpeed);
                    drop.SwingAmplitude = minAmplitude + (float)rnd.NextDouble() * (maxAmplitude - minAmplitude);
                    drop.SwingSpeed = minSwingSpeed + (float)rnd.NextDouble() * (maxSwingSpeed - minSwingSpeed);

                    // пересоздаем случайный размер и цвет
                    float fontSize = minFontSize + (float)rnd.NextDouble() * (maxFontSize - minFontSize);
                    drop.Font = new Font(baseFont.FontFamily, fontSize, baseFont.Style);
                    drop.Color = MixColors(colorFrom, colorTo, (float)rnd.NextDouble());
                }
            }
            targetPanel.Invalidate();
        }

        private void TargetPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(targetPanel.BackColor);
            foreach (var drop in drops)
            {
                using (Brush brush = new SolidBrush(drop.Color))
                {
                    e.Graphics.DrawString(drop.Text, drop.Font, brush, drop.Position);
                }
            }
        }
    }

    // Вспомогательный метод для включения DoubleBuffered на Panel
    public static class ControlExtensions
    {
        public static void DoubleBuffered(this Control control, bool enable)
        {
            System.Reflection.PropertyInfo prop = typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop.SetValue(control, enable, null);
        }
    }
}
