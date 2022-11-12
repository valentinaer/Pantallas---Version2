using grupoB_TP;

namespace Version_2___Pantallas
{
    internal static class ArchivoRecargos
    {
        public static decimal BuscarRecargos(int indice)
        {
            using var archivoRecargos = new StreamReader("ArchivoRecargos.txt");

            while (!archivoRecargos.EndOfStream)
            {
                var proximoLinea = archivoRecargos.ReadLine();
                string[] datosTarifa = proximoLinea!.Split("|");

                return Decimal.Parse(datosTarifa[indice]);
            };
            return 0;
        }
    }
}