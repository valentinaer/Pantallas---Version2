using grupoB_TP;

namespace Version_2___Pantallas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            //Repositorio: https://github.com/valentinaer/Pantallas---Version2
            ApplicationConfiguration.Initialize();
            //Application.Run(new EstadoDeCuenta());
            Application.Run(new SolicitudDeServicio());

        }
    }
}