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
        public Tile[,] Map = new Tile[8, 8];
        Bitmap[] gameSprites = new Bitmap[3];
        public Button lastButton;
        private bool isSelected = false;
        //private int countDestroy;
        public Form1()
        {
            InitializeComponent();
            //gameSprites = new Image("Sprites/" + 1 + ".png");
            for (int x = 0; x < 3; x++)
            {
                gameSprites[x] = new Bitmap($"C:\\Users\\Роман\\source\\repos\\match3\\match3\\Sprites\\{(x + 1)}.png");
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
                    FigureType figureType = (FigureType)figure;
                    Tile tile = new Tile(new Size(50,50),new Point(i * 50, j * 50), gameSprites[figure], figureType);
                    tile.Button.Click += new EventHandler(OnClicked);
                    this.Controls.Add(tile.Button);
                    Map[i, j] = tile;
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

                Tile temp = Map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50];
                Image tempImage = pressedButton.BackgroundImage;
                int pBX = pressedButton.Location.X / 50;
                int pBY = pressedButton.Location.Y / 50;
                int lBX = lastButton.Location.X / 50;
                int lBY = lastButton.Location.Y / 50;
                if ((pBY + 1 == lBY || pBY - 1 == lBY) & (pBX == lBX) ||
                    (pBX + 1 == lBX || pBX - 1 == lBX) & (pBY == lBY))

                {
                    Map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] = Map[lastButton.Location.Y / 50, lastButton.Location.X / 50];
                    Map[lastButton.Location.Y / 50, lastButton.Location.X / 50] = temp;
                    pressedButton.BackgroundImage = lastButton.BackgroundImage;
                    lastButton.BackgroundImage = tempImage;
                    isSelected = false;
                }

            }
            lastButton = pressedButton;
            Destroy();
        }
        public void Destroy()
        {
            int countDestroy = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j + 1 < 8 && Map[j, i].Type == Map[j + 1, i].Type)
                        countDestroy++;
                    else
                    {
                        if (countDestroy >= 3)
                        {
                            for (int x = 0; x <= countDestroy; x++)
                            {
                                Map[j - x, i].Button.BackgroundImage = null;
                            }
                        }
                        countDestroy = 0;
                    }
                }
            }


            /*for (int i = 0; i < 8; i++)
            {
                countDestroy = 0;
                for (int j = 1; j < 8; j++)
                {
                    if (Map[i, j].Type == Map[i, j - 1].Type)
                        countDestroy++;

                    
                    else if (countDestroy >= 3)
                    {
                        for (int x = 1; x <= countDestroy; x++)
                        {
                            Map[i, j - x].Button.BackgroundImage = null;

                        }
                        countDestroy = 0;
                    }
                    else
                    {
                        countDestroy = 0;
                    }
                }
            }*/
        }
    }
}

    


