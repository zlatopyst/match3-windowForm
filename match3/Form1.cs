using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace match3
{

    public partial class Form1 : Form
    {
        public int[,] map = new int[8,8];
        Bitmap[] gameSprites = new Bitmap[3];
        public Button lastButton;
        private bool isSelected = false;
        public Form1()
        {
            InitializeComponent();
            //gameSprites = new Image("Sprites/" + 1 + ".png");
            for (int x = 0; x < 3; x++)
            {
                gameSprites[x] = new Bitmap($"C:\\Users\\Роман\\source\\repos\\match3\\match3\\Sprites\\{(x+1)}.png");
            }


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    
                }
            }

            Init();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Init()
        {
            CreateMap();
        }
        public void CreateMap()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Random random = new Random();
                    int figure = random.Next(0, 3);
                    Button tile = new Button();
                    tile.Size = new Size(50, 50);
                    tile.Location = new Point(j * 50, i * 50);
                    Image part = new Bitmap(50, 50);
                    Graphics g = Graphics.FromImage(part);
                    g.DrawImage(gameSprites[figure], new Rectangle(0, 0, 50, 50));
                    tile.BackgroundImage = part;
                    map[i, j] = figure;
                    tile.BackColor = Color.White; 
                    tile.Click += new EventHandler(OnClicked);
                    this.Controls.Add(tile);
                }
            }

        }
        public void OnClicked(object sender, EventArgs e)
        {
            if (lastButton != null)
                lastButton.BackColor = Color.White;
            Button pressedButton = sender as Button;
            if (isSelected == false)
            {
                pressedButton.BackColor = Color.Blue;
                isSelected = true;
            }
            else if (isSelected)
            {
                int temp = map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50];
                Image tempImage = pressedButton.BackgroundImage;
                map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] = map[lastButton.Location.Y / 50, lastButton.Location.X / 50];
                map[lastButton.Location.Y / 50, lastButton.Location.X / 50] = temp;
                pressedButton.BackgroundImage = lastButton.BackgroundImage;
                lastButton.BackgroundImage = tempImage;
                isSelected = false;
            }
            lastButton = pressedButton;
        }
    }
}

