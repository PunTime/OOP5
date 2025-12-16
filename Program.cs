using System.Numerics;

namespace OOP5
{
    static class Program
    {
        /*Вказує, що головний потік програми використовує однопоточну модель COM (Single-Threaded Apartment)*/
        [STAThread]
        static void Main()
        {
            /*Активує сучасні візуальні стилі для елементів керування Windows Forms*/
            Application.EnableVisualStyles();
            /*Встановлює режим рендерингу тексту для елементів керування Windows Forms*/
            Application.SetCompatibleTextRenderingDefault(false);
            /*Запускає головну форму додатку Form1 і починає цикл обробки повідомлень Windows*/
            Application.Run(new Form1());
        }
    }
}
