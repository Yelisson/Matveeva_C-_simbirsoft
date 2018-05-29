using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simbirsoft1
{
    public partial class FormGame : Form
    {
        private GameLogic game=new GameLogic();     
        public static int n = 3;
        readonly GameContext context = new GameContext();
        public FormGame()
        {
            InitializeComponent();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            int x = 0, y = 70;
            for (int i = 0; i < n - 1; i++)
            {
                Pen p = new Pen(Color.Black);
                e.Graphics.DrawLine(p, x, y, pictureBox.Width, y);
                y += 70;
            }
            x = 70;
            y = 0;
            for (int i = 0; i < n - 1; i++)
            {
                Pen p = new Pen(Color.Black);
                e.Graphics.DrawLine(p, x, y, x, pictureBox.Height);
                x += 70;
            }
            x = 0;
            y = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (game.arr[i, j] == 1)
                    {
                        Pen p = new Pen(Color.Blue);
                        e.Graphics.DrawEllipse(p, y + 5, x + 5, 70 - 10, 70 - 10);
                    }
                    else
                    {
                        if (game.arr[i, j] == 2)
                        {
                            Pen p = new Pen(Color.Red);
                            e.Graphics.DrawLine(p, y + 5, x + 5, y + 70 - 5, x + 70 - 5);
                            e.Graphics.DrawLine(p, y + 5, x + 70 - 5, y + 70 - 5, x + 5);
                        }
                    }
                    x += 70;
                }
                x = 0;
                y += 70;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxX.Text.Length==0 || textBoxY.Text.Length == 0 || textBoxValue.Text.Length == 0)
            {
                MessageBox.Show("Одно из полей не заполнено");
            }else
            {
                try
                {
                   int j = Convert.ToInt32(textBoxY.Text);
                   int i = Convert.ToInt32(textBoxX.Text);
                   int num= Convert.ToInt32(textBoxValue.Text);
                    if (i < n && i >= 0)
                    {
                        if (j < n && j >= 0)
                        {
                            if (num == 1 || num == 2)
                            {
                                if (game.arr[i, j] == 0)
                                {
                                    game.fixNextStep(i,j,num);
                                    pictureBox.Refresh();
                                    if (complete())
                                    {
                                        MessageBox.Show("Игра окончена. Победитель: " + game.isCompleted(), "Конец", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        context.GamesInfos.Add(new Models.GameInfo
                                        {
                                            GameDate = DateTime.Now,
                                            Winner = game.isCompleted()
                                        });
                                        context.SaveChanges();                                      
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ячейка занята");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Введено неверное значение");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите значения от 0 до " + n);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите значения от 0 до " + n);
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public bool complete()
        {
            if (game.isCompleted()!=null)
            {
                return true;
            }
            return false;
        }
    }
}
