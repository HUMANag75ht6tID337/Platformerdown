using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<Obstacle> obstacles = new List<Obstacle>();
        Block block;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Red;
            Obstacle ob = new Obstacle(50, 50, 50, 50,2, Color.Red, this);
            obstacles.Add(ob);
            block = new Block(50, 10, 10, 10, Color.Black, this);


        }

        private void update(object sender, EventArgs e)
        {
            block.updadeLocation(obstacles);
        }


        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                block.jump();
            }
        }
    }
}
