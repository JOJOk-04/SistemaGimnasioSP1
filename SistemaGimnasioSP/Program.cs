using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGimnasioSP
{
    internal static class Program
    {
        // Esta es la llave maestra para que Windows no achique tu programa
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            // LE DECIMOS A WINDOWS: "NO ME TOQUES EL TAMAÑO, YO SE LO QUE HAGO"
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin()); // Asegúrate que este sea tu form de inicio
            /// <summary>
            /// Punto de entrada principal para la aplicación.
            /// </summary>
        }
    }
}
