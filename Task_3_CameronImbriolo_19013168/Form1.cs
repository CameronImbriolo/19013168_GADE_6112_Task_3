using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1_CameronImbriolo_19013168
{
    public partial class Form1 : Form
    {
        private GameEngine engine = new GameEngine();
        private static int interval = 20;

        public Form1()
        {
            InitializeComponent();
        }

        //Q.1.8 Manging the timer
        private void RoundTimer_Tick(object sender, EventArgs e)
        {
            engine.Run();
            Display();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            roundTimer.Enabled = true;
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            roundTimer.Enabled = false;
        }

        //Displays all relevant info on the form
        private void Display()
        {
            mapBox.Controls.Clear();
            lblRound.Text = "Current Round: " + engine.GameRound;

            for (int y = 0; y < engine.MyMap.mY; y++)
            {
                for (int x = 0; x < engine.MyMap.mX; x++)
                {
                    Label newLabel = new Label();
                    newLabel.Width = interval;
                    newLabel.Height = interval;
                    newLabel.Location = new Point(x * interval, y * interval);
                    newLabel.Text = engine.MyMap.getMap()[x, y];

                    mapBox.Controls.Add(newLabel);
                }
                gameInfoTxt.Text = engine.GameInfo();
                lblResource.Text = engine.ResourceInfo();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine.Initialise();
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            engine.Initialise();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            engine.Load();
            roundTimer.Enabled = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            engine.Save();
        }

        private void mapBox_Enter(object sender, EventArgs e)
        {

        }

        private void lblResource_Click(object sender, EventArgs e)
        {

        }
    }
}
