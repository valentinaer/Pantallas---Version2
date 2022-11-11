using grupoB_TP;

namespace Version_2___Pantallas
{
    internal static class ArchivoRecargos
    {
        static List<Recargos> listaRecargos = new List<Recargos>();
        internal static void CargarRecargos()
        {
            using var archivoRecargos = new StreamReader("ArchivoRecargos.txt");

            while (!archivoRecargos.EndOfStream)
            {
                var proximoLinea = archivoRecargos.ReadLine();
                string[] datosTarifa = proximoLinea!.Split("|");

                var recargo = new Recargos();

                recargo.RecargoUrgente = decimal.Parse(datosTarifa[0]);
                recargo.TopeUrgente = decimal.Parse(datosTarifa[1]);
                recargo.RecargoRetiroEnPuerta = decimal.Parse(datosTarifa[2]);
                recargo.RecargoEntregaEnPuerta = decimal.Parse(datosTarifa[3]);

                listaRecargos.Add(recargo);
            };
        }
    }
}