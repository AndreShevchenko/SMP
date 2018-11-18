using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Приложение_для_похудения
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
            label1.Text = "Сброшено калорий за этот сеанс: 0";
        }

        double a = 0;        
       
        private void button1_Click_1(object sender, EventArgs e)
        {
            a += 1.42;            
            label1.Text = "Сброшено калорий за этот сеанс: " + a;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Для указательного пальца объемом 10,8 кубических сантиметра и весом 11,78 грамм" +
                " требуется 1,42 калорий, чтобы переместить 1 грамм массы тела в течение 1 секунды.", 
                "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
