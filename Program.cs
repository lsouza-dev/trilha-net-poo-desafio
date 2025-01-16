using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using DesafioPOO.Models;

List<Smartphone> smartphones = new List<Smartphone>();

bool cadastrandoSmartphones = true;
while (cadastrandoSmartphones)
{

    System.Console.WriteLine("""

************* Smartphone DIO System *************

Escolha a operação desejada:

[1] - Cadastrar Nokia
[2] - Cadastrar Iphone
[3] - Listar Smartphones Cadastrados
[4] - Ligar
[5] - Receber Ligação

[6] - Sair

""");

    int.TryParse(Console.ReadLine(), out int modelo);
    Console.Clear();

    switch (modelo)
    {
        case 1:
            System.Console.WriteLine("********** Área de cadastro do Nokia **********");
            try
            {
                System.Console.WriteLine("\nDigite o número do seu Nokia:\n( Inclua o DDD )");
                string numeroNokia = Console.ReadLine();

                Smartphone.VerificarNumero(numeroNokia);

                System.Console.WriteLine("\nDigite o modelo do seu Nokia:");
                string modeloNokia = Console.ReadLine();

                System.Console.WriteLine("\nDigite o IMEI do seu Nokia:");
                string imeiNokia = Console.ReadLine();

                Smartphone.VerificarNumeroIMEI(imeiNokia);

                System.Console.WriteLine("\nDigite a quantidade de memória do Nokia:");
                int.TryParse(Console.ReadLine(), out int memoriaNokia);

                Nokia nokia = new Nokia(numeroNokia, modeloNokia, imeiNokia, memoriaNokia);
                Console.Clear();

                smartphones.Add(nokia);
                System.Console.WriteLine("Nokia cadastrado com sucesso!\n\n" + nokia.ToString());

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            break;
        case 2:
            System.Console.WriteLine("********** Área de cadastro do Iphone **********");
            try
            {
                System.Console.WriteLine("\nDigite o número do seu Iphone:\n( Inclua o DDD )");
                string numeroIphone = Console.ReadLine();

                Smartphone.VerificarNumero(numeroIphone);

                System.Console.WriteLine("\nDigite o modelo do seu Iphone:");
                string modeloIphone = Console.ReadLine();

                System.Console.WriteLine("\nDigite o IMEI do seu Iphone:");
                string imeiIphone = Console.ReadLine();

                Smartphone.VerificarNumeroIMEI(imeiIphone);

                System.Console.WriteLine("\nDigite a quantidade de memória do Iphone:");
                int.TryParse(Console.ReadLine(), out int memoriaIphone);

                Iphone iphone = new Iphone(numeroIphone, modeloIphone, imeiIphone, memoriaIphone);
                Console.Clear();

                smartphones.Add(iphone);
                System.Console.WriteLine("Iphone cadastrado com sucesso!\n\n" + iphone.ToString());



            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }


            break;

        case 3:
            Console.Clear();
            System.Console.WriteLine("""
            ********** Smartphones Cadastrados **********

            Deseja visualizar:

            [1] - Nokia
            [2] - Iphone
            [3] - Todos

            [4] - Voltar

            """);

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                switch (opcao)
                {
                    case 1:
                        foreach (var item in smartphones)
                        {
                            if (item is Nokia)
                            {
                                System.Console.WriteLine(item.ToString());
                            }
                        }
                        break;
                    case 2:
                        foreach (var item in smartphones)
                        {
                            if (item is Iphone)
                            {
                                System.Console.WriteLine(item.ToString());
                            }
                        }
                        break;
                    case 3:
                        foreach (var item in smartphones)
                        {
                            System.Console.WriteLine(item.ToString());
                        }
                        break;
                    case 4:
                        break;
                    default:
                        System.Console.WriteLine("Opção inválida!");
                        break;
                }
            }

            System.Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            break;
        case 4:
            System.Console.WriteLine("********** Ligar **********");
            System.Console.WriteLine("Selecione o número do celular que deseja ligar:\n");
            int index = 0;
            smartphones.ForEach(s =>
            {
                System.Console.WriteLine($"[{index}] - {s.Numero}");
                index++;
            });
            if (int.TryParse(Console.ReadLine(), out int indiceLigar) && indiceLigar >= 0 && indiceLigar < smartphones.Count)
            {
                var cell = smartphones[indiceLigar];
                cell.Ligar();
            }
            else
            {
                System.Console.WriteLine("Opção inválida!");
            }

            break;
        case 5:
            Random random = new Random();
            if (smartphones.Count > 0)
            {
                int randomIndex = random.Next(smartphones.Count);
                smartphones[randomIndex].ReceberLigacao();
            }
            else
            {
                System.Console.WriteLine("Nenhum smartphone cadastrado para receber ligação.");
            }
            break;
        case 6:
            cadastrandoSmartphones = false;
            System.Console.WriteLine("Obrigado por utilizar o Smartphone DIO System!");
            System.Console.WriteLine("Saindo da aplicação....");
            break;
        default:
            Console.Clear();
            System.Console.WriteLine("Opção inválida!\n");
            Thread.Sleep(1000);
            break;
    }


}