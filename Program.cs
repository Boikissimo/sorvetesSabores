using System;

namespace Sabores
{
    class Program
    {
        static massaRepositorio massas = new massaRepositorio();
        static picoleRepositorio picoles = new picoleRepositorio();

        /*para eliminar confusões (leia-se: impedir a confução de ter que trabalhar com IDs separados ou unir tudo em uma classe, o que despertiça recursos no caso do picolé, que
        necessita de menor atributos), estou usando uma variavel para determinar se estamos trabalhando com picolés ou massas*/
        static void Main(string[] args)
        {
            string opcaoUsuario = selecionarOpcao("massas");
            string categoria = "massas";
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        listarSabores(categoria);
                        break;
                    case "2":
                        inserirProduto(categoria);
                        break;
                    case "3":
                        visualizar(categoria);
                        break;
                    case "4":
                        alterarQuantidade(categoria, true);
                        break;
                    case "5":
                        alterarQuantidade(categoria, false);
                        break;
                    case "6":
                        retirar(categoria);
                        break;
                    case "L":
                        Console.Clear();
                        break;
                    case "C":
                        if (categoria == "massas")
                        {
                            categoria = "picoles";
                        }
                        else 
                        {
                            categoria = "massas";
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = selecionarOpcao(categoria);
            }
            Console.WriteLine("Obrigado por utilizar o sistema Frescos. Precione enter para sair");
            Console.ReadLine();
        }
        private static string selecionarOpcao(string categoriaAtual)
        {

            Console.WriteLine();
            Console.WriteLine("Olá, atualmente você está trabalhando com: " + categoriaAtual);
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar " + categoriaAtual);
            Console.WriteLine("2 - Inserir novo produto");
            Console.WriteLine("3 - Visualizar produto");
            Console.WriteLine("4 - Aumentar a quantidade do produto");
            Console.WriteLine("5 - Reduzir a quantidade do produto");
            Console.WriteLine("6 - Retirar o produto de circulação");
            Console.WriteLine("L - Limpar tela");
            Console.WriteLine("C - Mudar categoria");
            Console.WriteLine("X - Sair" + Environment.NewLine);
            
            string opcao = Console.ReadLine().ToUpper();
            return opcao;
        }
        private static void listarSabores(string categoria)
        {
            if (categoria == "massas")
            {
                var lista = massas.lista();
                if (lista.Count == 0)
                {
                    Console.WriteLine("A lista está vazia");
                    return;
                }
                foreach (var valor in lista)
                {
                    var ativo = valor.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", valor.retornaId(), valor.retornaSabor(), (ativo ? "" : "*Não é mais produzido*"));
                }
            }
            else
            {
                var lista = picoles.lista();
                if (lista.Count == 0)
                {
                    Console.WriteLine("A lista está vazia");
                    return;
                }
                foreach (var valor in lista)
                {
                    var ativo = valor.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", valor.retornaId(), valor.retornaSabor(), (ativo ? "" : "*Não é mais produzido*"));
                }
            }
        }
        private static void inserirProduto(string categoria)
        {   
            Console.Write("Digite o sabor: ");
            string sabor = Console.ReadLine();

            Console.Write("Digite a quantidade atual de produtos em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            if (categoria == "massas")
            {
                foreach (int i in Enum.GetValues(typeof(massaEmbalagem)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(massaEmbalagem), i));
                }
                Console.Write("Digite a embalagem, usando os números fornecidos acima: ");
                int entradaMassa = int.Parse(Console.ReadLine());

                Console.Write("Digite o tamanho da embalagem, em ml: ");
                ushort ml = ushort.Parse(Console.ReadLine());

                massa novaMassa = new massa(massas.proxID(),
                                            sabor,
                                            quantidade,
                                            (massaEmbalagem)entradaMassa,
                                            ml);
                massas.adiciona(novaMassa);
            }
            else
            {
                foreach (int i in Enum.GetValues(typeof(basePicolé)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(basePicolé), i));
                }
                Console.Write("Digite a base, usando os números fornecidos acima: ");
                int basePicole = int.Parse(Console.ReadLine());

                picole novoPicole = new picole(picoles.proxID(),
                                                sabor,
                                                quantidade,
                                                (basePicolé)basePicole);
                
                picoles.adiciona(novoPicole);
            }
        }
        static void visualizar(string categoria)
        {
            Console.Write("Digite o ID do produto: ");
            int indice = int.Parse(Console.ReadLine());
            if (categoria == "massas")
            {
                var resultados = massas.retornaPorID(indice);
                Console.WriteLine(resultados);
            }
            else
            {
                var resultados = picoles.retornaPorID(indice);
                Console.WriteLine(resultados);
            }
        }
        static void alterarQuantidade(string categoria, bool opcao)
        {
            Console.Write("Digite o ID do produto: ");
            int indice = int.Parse(Console.ReadLine());
            uint variacao = 0;
            if (opcao)
            {
                Console.Write("Digite a quantidade que você quer adicionar: ");
                variacao = uint.Parse(Console.ReadLine());
            }
            else
            {
                Console.Write("Digite a quantidade que você quer remover, em número positivo: ");
                variacao = uint.Parse(Console.ReadLine());
            }
            if (categoria == "massas")
            {
                if (opcao)
                {
                    Console.WriteLine(massas.producao(indice, variacao));
                }
                else
                {
                    Console.WriteLine(massas.venda(indice, variacao));
                }
            }
            else
            {
                if (opcao)
                {
                    Console.WriteLine(picoles.producao(indice, variacao));
                }
                else
                {
                    Console.WriteLine(picoles.venda(indice, variacao));
                }
            }
        }
        static void retirar(string categoria)
        {
            Console.Write("Digite o ID do produto que você deseja retirar de circulação: ");
            int indice = int.Parse(Console.ReadLine());

            if (categoria == "massas")
            {
                Console.WriteLine(massas.excluir(indice));
            }
            else
            {
                Console.WriteLine(picoles.excluir(indice));
            }
        }
    }
}
