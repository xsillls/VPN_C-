using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class AnimatedButton : Button
{
    // Публичные свойства для настройки
    public Color HoverColor { get; set; } = Color.LightSkyBlue;
    public Color ClickColor { get; set; } = Color.DodgerBlue;

    private Color currentColor;
    private Color startAnimationColor;
    private Color endAnimationColor;

    private Timer animationTimer;
    private int animationStep = 10;
    private int currentStep = 0;
    private bool isHovered = false;
    private bool isClicked = false;

    public AnimatedButton()
    {
        animationTimer = new Timer();
        animationTimer.Interval = 20;
        animationTimer.Tick += AnimationTimer_Tick;

        this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
        currentColor = SystemColors.Control;
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        isHovered = true;
        startAnimationColor = currentColor;
        endAnimationColor = isClicked ? ClickColor : HoverColor;
        currentStep = 0;
        animationTimer.Start();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        isHovered = false;
        startAnimationColor = currentColor;
        endAnimationColor = SystemColors.Control;
        currentStep = 0;
        animationTimer.Start();
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        base.OnMouseDown(mevent);
        if (mevent.Button == MouseButtons.Left)
        {
            isClicked = true;
            startAnimationColor = currentColor;
            endAnimationColor = ClickColor;
            currentStep = 0;
            animationTimer.Start();
        }
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
        base.OnMouseUp(mevent);
        if (mevent.Button == MouseButtons.Left)
        {
            isClicked = false;
            startAnimationColor = currentColor;
            endAnimationColor = isHovered ? HoverColor : SystemColors.Control;
            currentStep = 0;
            animationTimer.Start();
        }
    }

    private void AnimationTimer_Tick(object sender, EventArgs e)
    {
        if (currentStep < animationStep)
        {
            currentStep++;
            currentColor = Color.FromArgb(
                (int)(startAnimationColor.R + (endAnimationColor.R - startAnimationColor.R) * (float)currentStep / animationStep),
                (int)(startAnimationColor.G + (endAnimationColor.G - startAnimationColor.G) * (float)currentStep / animationStep),
                (int)(startAnimationColor.B + (endAnimationColor.B - startAnimationColor.B) * (float)currentStep / animationStep));
            this.Invalidate();
        }
        else
        {
            animationTimer.Stop();
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        Graphics g = pevent.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Заливаем фон
        using (SolidBrush brush = new SolidBrush(currentColor))
        {
            g.FillRectangle(brush, this.ClientRectangle);
        }

        // Контрастный цвет для текста
        Color textColor = (currentColor.GetBrightness() < 0.5f) ? Color.White : Color.Black;

        // Текст
        TextRenderer.DrawText(
            g,
            this.Text ?? string.Empty,
            this.Font,
            this.ClientRectangle,
            textColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
        );

        // Рамка
        using (Pen pen = new Pen(this.FlatAppearance.BorderColor, 1))
        {
            g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
        }
    }

}
