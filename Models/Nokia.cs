namespace DesafioPOO.Models
{
    // TODO: Herdar da classe "Smartphone"
    public class Nokia : Smartphone
    {
        public Nokia(){}
        public Nokia(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria)
        {
        }

        // TODO: Sobrescrever o método "InstalarAplicativo"
        public override void InstalarAplicativo(string nomeApp)
        {
            System.Console.WriteLine($"Abrindo a Google Play...");
            Thread.Sleep(3000);
            System.Console.WriteLine("Digite o nome do aplicativo que deseja instalar:");
            string nomeDoApp = Console.ReadLine();
            System.Console.WriteLine($"Instalando {nomeDoApp}...");
            Thread.Sleep(5000);
            System.Console.WriteLine("Aplicativo instalado com sucesso!");
        }
    }
}