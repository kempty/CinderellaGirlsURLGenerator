using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CinderellaGirlsURLGenerator
{
    public partial class Form1 : Form
    {
        String genURL = "", mobageID = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //自分のマイページのURLはこんな感じ。15985882がID
            //ttp://sp.pf.mbga.jp/12008305/?guid=ON&url=http%3A%2F%2F125.6.169.35%2Fidolmaster%2Fprofile%2Fshow%2F15985882%3Frnd%3D185892710
            //                                                                                                    ~~~~~~~~

            //意味ないかもだけど、2回目以降はURLクリアしとく
            if (genURL != "")
            {
                genURL = "";
            }

            if (textBox1.Text != "")
            {
                //改行・コロン・全半角スペース・記号類・ID(という文字列)を削除してID整形
                textBox1.Text = textBox1.Text.Replace("\r", "");    //改行コードCR
                textBox1.Text = textBox1.Text.Replace("\n", "");    //改行コードLF
                textBox1.Text = textBox1.Text.Replace(":" , "");
                textBox1.Text = textBox1.Text.Replace("：", "");
                textBox1.Text = textBox1.Text.Replace("【", "");
                textBox1.Text = textBox1.Text.Replace("】", "");
                textBox1.Text = textBox1.Text.Replace(" " , "");
                textBox1.Text = textBox1.Text.Replace("　", "");
                textBox1.Text = textBox1.Text.Replace("ID", "");

                mobageID = textBox1.Text;

                genURL = "http://sp.pf.mbga.jp/12008305/?guid=ON&url=http%3A%2F%2F125.6.169.35%2Fidolmaster%2Fprofile%2Fshow%2F" + mobageID + "%3Frnd%3D185892710";

                Clipboard.SetText(genURL);

                linkLabel1.Text = genURL;

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(genURL);
        }
    }
}
