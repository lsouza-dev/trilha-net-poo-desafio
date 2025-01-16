using System.Net;
using System.Text.RegularExpressions;

namespace DesafioPOO.Models
{
    public abstract class Smartphone
    {
        public string Numero { get; set; }
        // TODO: Implementar as propriedades faltantes de acordo com o diagrama
        public string Modelo { get; set; }
        public string IMEI { get; set; }

        public int Memoria { get; set; }

        public Smartphone()
        {
            
        }

        public Smartphone(string numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            Modelo = modelo;
            IMEI = imei;
            Memoria = memoria;
            // TODO: Passar os parâmetros do construtor para as propriedades
        }

        public void Ligar()
        {
            Console.WriteLine($"\nLigando para {this.Numero}...");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1500);
                Console.WriteLine("...");
            }
            Console.WriteLine("\nChamada não atendida!");
        }

        public void ReceberLigacao()
        {
            Console.WriteLine($"\nRecebendo ligação de {this.Numero}...");
            Console.WriteLine("Pressione qualquer tecla para atender...");

            int timeout = 5000; // 5 segundos
            Task task = Task.Run(() => Console.ReadKey(true));
            if (task.Wait(timeout))
            {
                Console.WriteLine($"\nVocê atendeu a chamada de {this.Numero}.");
            }
            else
            {
                Console.WriteLine($"\nChamada perdida de {this.Numero}.");
            }
        }

        public abstract void InstalarAplicativo(string nomeApp);

        public static bool VerificarNumero(string numero)
        {
            string numeroRegex = @"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$";

            if (Regex.IsMatch(numero, numeroRegex)) return true;
            else
            {
                throw new Exception("\nO Número inserido é inválido. Não foi possível cadastrar o celular.");
            }
        }

        public static bool VerificarNumeroIMEI(string imei){
            string imeiRegex = @"^\d{15}$|^\d{2}[- ]?\d{6}[- ]?\d{6}[- ]?\d{1}$";

            if(Regex.IsMatch(imei,imeiRegex)) return true;
            else throw new Exception("\nO IMEI inserido é inválido. Não foi possível cadastrar o celular.\nA numeração IMEI contém 15 dígitos.");
        }

        // Override método toString para filhos
        public override string ToString()
        {
            return $"\nMarca: {this.GetType().Name}\nNúmero: {Numero}\nModelo: {Modelo}\nIMEI: {IMEI}\nMemória: {Memoria}\n";
        }
    }   
}