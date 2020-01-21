using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Gallows2_BL;

namespace Gallows2
{
    public partial class Form1 : Form
    {
        Word word;
        Button[] letterButtons;
        List<Button> buttonsToRemove;
        int nrOfMisses = 0;
        const int maxMiss = 12;
        bool wordCompleted = false;  // mike: deze als event maken

        Graphics grGallows;
        Bitmap canvas;
        SolidBrush brush;

        public Form1()
        {
            InitializeComponent();                        
            Init();
            Start();
        }

        private void Init()
        {            
            Words.GetWords();
            canvas = new Bitmap(picCanvas.Width, picCanvas.Height);            
            picCanvas.Image = canvas;
            grGallows = Graphics.FromImage(canvas);
            brush = new SolidBrush(Color.Green);

            GallowsDrawing.DefineGallowElementsPositions();
            DrawGallows(0);
        }

        private void Start()
        {
            nrOfMisses = 0;            
            RefreshScreen();
            grGallows.Clear(picCanvas.BackColor);
            buttonsToRemove = new List<Button>();
            string w = Words.ChooseWord().ToUpper();
            word = new Word(w);            
            CreateLetterPositions();            
        }

        private void RefreshScreen()
        {
            btnInput.Text = "";
            if (buttonsToRemove != null)
            {
                foreach (Button b in buttonsToRemove)
                {
                    splitContainerSec.Panel1.Controls.Remove(b);
                }
            }
        }

        private void CreateLetterPositions()
        {
            letterButtons = new Button[word.TheWord.Length];
            
            for(int i = 0; i < letterButtons.Length; i++)
            {
                letterButtons[i] = CreateButton(new Point(i * 40 + 60, 50), word.TheWord[i]);                
            }            
        }

        private Button CreateButton(Point location, char letter)
        {
            Button button = new Button();
            button.Enabled = false;
            button.Size = new Size(32, 32);
            button.Font = new Font(this.Font, FontStyle.Bold);
            button.Location = location;
            button.Tag = "ButtonCreated";
            button.BackColor = Color.Gray;                       

            splitContainerSec.Panel1.Controls.Add(button);
            buttonsToRemove.Add(button);

            return button;
        }

        private void LetterCorrect(char letter, int position)
        {            
            letterButtons[position].Text = letter.ToString();
            letterButtons[position].BackColor = Color.Green;            
        }

        private void LetterFalse(char letter)
        {            
            Button button = CreateButton(new Point(nrOfMisses * 40 - 20, 300), letter);
            button.Text = letter.ToString();
            button.BackColor = Color.Red;
            DrawGallows(nrOfMisses);
            if (nrOfMisses >= maxMiss)
                GameOver();
        }

        private void GameOver()
        {
            MessageBox.Show("Game over!");
        }

        private void DrawGallows(int nrOfMisses)
        {
            Point[] pts;
            // Make the GraphicsPath.
            GraphicsPath polygon_path = new GraphicsPath(FillMode.Winding);

            for (int i = 0; i < nrOfMisses; i++)
            {
                pts = GallowsDrawing.GetPoint(i).ToArray();
                polygon_path.Reset();
                polygon_path.AddPolygon(pts);
                grGallows.FillPolygon(brush, pts);
            }            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Length == 1)
            {
                int key = char.Parse(keyData.ToString());
                if (key >= 65 && key <= 90)  // a - z
                {
                    string inputLetter = keyData.ToString().ToUpper();
                    btnInput.Text = inputLetter;
                    CheckLetter(key);                    
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void WordCompleted()
        {
            MessageBox.Show("Gewonnen");            
        }

        private void CheckLetter(int key)
        {            
            char c = Convert.ToChar(key);
            List<int> positions = word.GetPosLettersInWord(c);

            if(positions.Count > 0)
            {
                wordCompleted = word.SetLettersToGuessed(positions);
                foreach (int pos in positions)
                {
                    LetterCorrect(c, pos);
                }
                if (wordCompleted)
                    WordCompleted();
            }
            else
            {
                nrOfMisses++;
                LetterFalse(c);
            }
        }        

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void hoeWerktHetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Je moet een letter intypen, trut!");
        }
    }
}
