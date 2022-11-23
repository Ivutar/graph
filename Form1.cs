using System.Security.Cryptography.X509Certificates;

namespace graph;

public partial class Form1 : Form
{
    Image fish;
    Bitmap buffer;
    Graphics back;
    List<Swimmer> swimmerList;

    public Form1()
    {
        InitializeComponent();
        buffer = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        back = Graphics.FromImage(buffer);
        fish = Image.FromFile("fish.png");
        swimmerList = new List<Swimmer>();
        for (int i = 0; i < 1000; i++)
            AddFish();
    }

    private void AddFish()
    {
        var f = new Swimmer();
        f.wd = fish.Width;
        f.hg = fish.Height;
        f.x = Random.Shared.Next(0, pictureBox1.Width - f.wd);
        f.y = Random.Shared.Next(0, pictureBox1.Height - f.hg);
        f.dx = Random.Shared.Next(-10, 11);
        f.dy = Random.Shared.Next(-10, 11);
        swimmerList.Add(f);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        back.FillRectangle(Brushes.NavajoWhite, 0, 0, pictureBox1.Width, pictureBox1.Height);     
        foreach(var s in swimmerList)
        {
            var nx = s.x + s.dx;
            var ny = s.y + s.dy;
            if (nx < 0 || nx > pictureBox1.Width - s.wd) s.dx = -s.dx;
            if (ny < 0 || ny > pictureBox1.Height - s.hg) s.dy = -s.dy;

            s.x += s.dx;
            s.y += s.dy;
            back.DrawImage(fish, s.x, s.y);
        }

        using var g = pictureBox1.CreateGraphics();
        g.DrawImage(buffer, 0, 0);
    }
}
