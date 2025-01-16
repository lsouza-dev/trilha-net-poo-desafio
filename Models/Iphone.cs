namespace DesafioPOO.Models
{
    // TODO: Herdar da classe "Smartphone"
    public class Iphone : Smartphone
    {
        public Iphone()
        {
        }
        
        public Iphone(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria)
        {
        }

        // TODO: Sobrescrever o método "InstalarAplicativo"
        public override void InstalarAplicativo(string nomeApp)
        {
            System.Console.WriteLine($"Abrindo a App Store...");
            System.Console.WriteLine("Digite o nome do aplicativo que deseja instalar:");
            string nomeDoApp = Console.ReadLine();
            System.Console.WriteLine($"Instalando {nomeDoApp}...");
            System.Console.WriteLine("Aplicativo instalado com sucesso!");
        }
    }
}