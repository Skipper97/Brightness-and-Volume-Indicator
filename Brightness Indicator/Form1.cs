using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marox.ExtensionMethods;

namespace Brightness_Indicator
{
    public partial class Form1 : Form
    {
        System.Drawing.SolidBrush brush_background = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        System.Drawing.SolidBrush brush_bar_background = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);
        System.Drawing.SolidBrush brush_bar = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        System.Drawing.SolidBrush brush_indicator = new System.Drawing.SolidBrush(System.Drawing.Color.White);

        System.Drawing.Graphics formGraphics;

        Rectangle rectangle_background, rectangle_bar_background, rectangle_indicator, rectangle_bar;

        Timer timer = new Timer();

        const int _max = 20;
        const int _min = 114;

        int INDICATOR_Y_POS = _max;


        private int _BRIGHTNESS_ = 100;
        public int BRIGHTNESS
        {
            get { return _BRIGHTNESS_; }
            set
            {
                _BRIGHTNESS_ = value;

                if (global._FIRST_BRIGHTNESS == false)
                {
                    this.timer.Stop();
                    this.Show();

                    this.label.Text = value.ToString();
                    this.pictureBox1.Image = Brightness_Indicator.Resource1.sunny18;

                    double p = value / 100d;
                    int range = _min - _max;
                    int _new = _min - (int)(p * range);
                    this.INDICATOR_Y_POS = _new;

                    this.Refresh();
                    this.timer.Start();
                }
                else
                {
                    global._FIRST_BRIGHTNESS = false;
                }
            }
        }

        private int _VOLUME_ = 100;
        public int VOLUME
        {
            get { return _VOLUME_; }
            set
            {
                _VOLUME_ = value;
                if (value == -1)
                {
                    return;
                }

                if (global._FIRST_VOLUME == false)
                {
                    this.timer.Stop();
                    this.Show();

                    this.label.Text = value.ToString();
                    this.pictureBox1.Image = Brightness_Indicator.Resource1.sound53;

                    double p = value / 100d;
                    int range = _min - _max;
                    int _new = _min - (int)(p * range);
                    this.INDICATOR_Y_POS = _new;

                    this.Refresh();
                    this.timer.Start();
                }
                else
                {
                    global._FIRST_VOLUME = false;
                }
            }
        }

        private bool _MUTE_ = false;
        public bool MUTE
        {
            get { return _MUTE_; }
            set
            {
                _MUTE_ = value;
                if (value == false)
                {
                    this.VOLUME = -1;
                    return;
                }

                this.timer.Stop();
                this.Show();

                this.label.Text = string.Empty;

                this.pictureBox1.Image = Brightness_Indicator.Resource1.mute_1_gimp;

                this.INDICATOR_Y_POS = _min;

                this.Refresh();
                this.timer.Start();

            }
        }


        public Form1()
        {
            InitializeComponent();


            this.label.Width = this.Width;
            this.label.Location = new Point(0, this.Size.Height - 60);
            this.label.ForeColor = Color.White;
            this.label.BackColor = brush_background.Color;
            this.label.Text = this.BRIGHTNESS.ToString();
            //this.label.Text = Volume.GetMute().ToString();

            this.pictureBox1.BackColor = this.brush_background.Color;
            this.pictureBox1.Location = new Point((this.Size.Width / 2) - 13, this.Size.Height - 33);

            this.formGraphics = this.CreateGraphics();

            this.timer.Interval = 2000;
            this.timer.Tick += timer_Tick;
            this.timer.Start();



            //System.Threading.Thread t2 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart((object o) =>
            //{
            //    System.Threading.Thread.Sleep(1000);
            //    while (true)
            //    {
            //        if (global._HIDE == true)
            //        {
            //            System.Threading.Thread.Sleep(2000);
            //            if (global._HIDE == true)
            //                this.SafeInvoke(d => d.Hide());
            //        }
            //    }


            //}));

            //t2.IsBackground = true;
            //t2.Start();
            ////t2.Join();

            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart((object o) =>
                {
                    System.Threading.Thread.Sleep(1000);

                    while (true)
                    {
                        System.Threading.Thread.Sleep(100);

                        int b = Brightness.GetBrightness();
                        int v = Volume.GetVolume();
                        bool m = Volume.GetMute();

                        this.SafeInvoke(d =>
                            {
                                if (d.BRIGHTNESS != b)
                                {
                                    d.BRIGHTNESS = b;
                                }

                                if (d.VOLUME != v)
                                {
                                    d.VOLUME = v;
                                }

                                if (d.MUTE != m)
                                {
                                    d.MUTE = m;
                                }
                            });
                    }


                }));

            // t.IsBackground = true;
            t.Start();

        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.SafeInvoke(d => d.Hide());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.rectangle_background = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            formGraphics.FillRectangle(brush_background, rectangle_background);

            this.rectangle_bar_background = new Rectangle((this.Size.Width / 2) - 7, 20, 14, this.Size.Height - 100);
            formGraphics.FillRectangle(brush_bar_background, rectangle_bar_background);

            this.rectangle_indicator = new Rectangle(this.rectangle_bar_background.X, INDICATOR_Y_POS, 14, 14);
            formGraphics.FillRectangle(brush_indicator, rectangle_indicator);

            this.rectangle_bar = new Rectangle(this.rectangle_bar_background.X, INDICATOR_Y_POS + 14, 14, (this.Size.Height - 100) - (INDICATOR_Y_POS) + 14);
            formGraphics.FillRectangle(brush_bar, rectangle_bar);





        }


    }
}
