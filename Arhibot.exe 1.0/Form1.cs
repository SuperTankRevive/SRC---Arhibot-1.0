using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Arhibot.exe_1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor; // Делаем фон формы прозрачным
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Здесь будет предупреждение о запуске. Если нажмем No, прога завершит свою работу, иначе он покажет второе предупреждение
            if (MessageBox.Show("Before running this malware,\ni must warn that this trojan harmful for your computer\nAlso, he is dangerous. If you use safe environment to test, press Yes.\nIf you don't want to destroy your computer, press No to exit.\n\nDo you want to execute malware, resulting in an destroyed system?", "Arhibot", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                Last_Warning();
            }
        }
        public void Last_Warning()
        {
            //Последнее предупреждение. Все также, только если нажмем на Yes, то троян перейдет к его активации, и дальше пошла жара
            if (MessageBox.Show("THIS IS THE LAST WARNING!\nI'M NOT RESPONSIBLE FOR ANY DAMAGE MADE USING THIS MALWARE!\nSTILL EXECUTE IT?", "Arhibot", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                activate();
            }

        }
        public void activate()
        {
            this.Hide();
            var NewForm = new Payload(); // Активация вируса
            NewForm.ShowDialog(); // переходим на другую форму и закрываем эту
            this.Close();

        }
    }
}
