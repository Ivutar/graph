using System.Windows.Forms;

namespace graph;

class Swimmer
{
    public int x;
    public int y;
    public int wd;
    public int hg;

    public virtual void Move(int width, int height) { }
    public virtual void Draw(Graphics g) { }
}

class Fish : Swimmer
{
    public int dx;
    public int dy;
    public Image leftfish;
    public Image rightfish;

    public override void Move(int width, int height)
    {
        var nx = x + dx;
        var ny = y + dy;
        if (nx < 0 || nx > width - wd) dx = -dx;
        if (ny < 0 || ny > height - hg) dy = -dy;

        x += dx;
        y += dy;
    }

    public override void Draw(Graphics g)
    {
        g.DrawImage(dx < 0 ? leftfish : rightfish, x, y);
    }
}

class Food : Swimmer
{
    public int Satuation;
    public Image food;

    public override void Move(int width, int height)
    {
        const int food_speed = 10;

        var ny = y + food_speed;
        if (ny < height - hg) y = ny;
    }

    public override void Draw(Graphics g)
    {
        g.DrawImage(food, x, y);
    }
}

class Buble : Swimmer
{
    public Image buble;

    public override void Move(int width, int height)
    {
        const int buble_speed = -5;

        var ny = y + buble_speed;
        if (ny > 0)
            y = ny;
        else
        {
            y = height - hg;
            x = Random.Shared.Next(0, width - wd);
        }
    }

    public override void Draw(Graphics g)
    {
        g.DrawImage(buble, x, y);
    }
}