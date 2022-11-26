using System.Security.Cryptography.X509Certificates;

namespace graph;

public partial class Form1 : Form
{
    Image leftfish;
    Image rightfish;
    Image food;
    Image buble;
    Bitmap buffer;
    Graphics back;
    List<Swimmer> list;
    //List<Fish> swimmerList;
    //List<Food> foodList;

    public Form1()
    {
        InitializeComponent();
        buffer = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        back = Graphics.FromImage(buffer);
        leftfish = Image.FromFile("fish.png");
        rightfish = Image.FromFile("fish.png");
        rightfish.RotateFlip(RotateFlipType.RotateNoneFlipX);
        food = Image.FromFile("worm.png");
        buble = Image.FromFile("buble.png");
        list = new List<Swimmer>();
        for (int i = 0; i < 4; i++)
            AddFish();
        for (int i = 0; i < 1; i++)
            AddFood();
        for (int i = 0; i < 6; i++)
            AddBuble();
    }

    private void AddFish()
    {
        var f = new Fish();
        f.wd = leftfish.Width;
        f.hg = leftfish.Height;
        f.x = Random.Shared.Next(0, pictureBox1.Width - f.wd);
        f.y = Random.Shared.Next(0, pictureBox1.Height - f.hg);
        f.dx = Random.Shared.Next(-10, 11);
        f.dy = Random.Shared.Next(-10, 11);
        f.leftfish = leftfish;
        f.rightfish = rightfish;
        list.Add(f);
    }

    private void AddFood()
    {
        var f = new Food();
        f.wd = food.Width;
        f.hg = food.Height;
        f.x = Random.Shared.Next(0, pictureBox1.Width - f.wd);
        f.y = 0;
        f.food = food;
        list.Add(f);
    }
    private void AddBuble()
    {
        var f = new Buble();
        f.wd = buble.Width;
        f.hg = buble.Height;
        f.x = Random.Shared.Next(0, pictureBox1.Width - f.wd);
        f.y = pictureBox1.Height - f.hg;
        f.buble = buble;
        list.Add(f);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        back.FillRectangle(Brushes.NavajoWhite, 0, 0, pictureBox1.Width, pictureBox1.Height);     
        foreach(Swimmer s in list)
        {
            s.Move(pictureBox1.Width, pictureBox1.Height);
            s.Draw(back);
        }

        using var g = pictureBox1.CreateGraphics();
        g.DrawImage(buffer, 0, 0);
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
            AddFish();
        if (e.KeyCode == Keys.Enter)
            AddFood();
        if (e.KeyCode == Keys.Back)
            AddBuble();
    }
}
