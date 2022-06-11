using System;
using System.Globalization;

namespace ModaMediaMediana
{
    internal class Program
    {
        public static void OrdemCrescente(double[] valores, int casos)
        {
            for (int i = 0; i < casos; i++) 
            {
                for (int j = 0; j < casos; j++)
                {
                    if (valores[i] < valores[j])
                    {
                        double aux = valores[i];
                        valores[i] = valores[j];
                        valores[j] = aux;
                    }
                }
            }
        }

        static double MediaDosNNumeros(double[] valores, int casos)
        {
            double soma = 0;

            for (int i = 0; i < casos; i++)
            {
                soma += valores[i];
            }
            return soma / casos;
        }
        static double MaiorNumeroModal(double[] valores, int casos)
        {
            int maiorRepetido = -1;
            double valorRepetido = 0;

            for (int i = 0; i < casos; i++) // aqui eu pequei o modal.
            {
                int quantasVezesRepete = 0;

                for (int j = i + 1; j < casos; j++)
                {
                    if (valores[i] == valores[j])
                    {
                        quantasVezesRepete++;
                    }
                }
                if (quantasVezesRepete > maiorRepetido)
                {
                    maiorRepetido = quantasVezesRepete;
                    valorRepetido = valores[i];
                }
            }
            return valorRepetido;
        }

        static int QuantasVezesRepeteModal(double[] valores, int casos)
        {
            int maiorRepetido = -1;
            double valorRepetido = 0;

            for (int i = 0; i < casos; i++) 
            {
                int quantasVezesRepete = 0;

                for (int j = i + 1; j < casos; j++)
                {
                    if (valores[i] == valores[j])
                    {
                        quantasVezesRepete++;
                    }
                }
                if (quantasVezesRepete > maiorRepetido)
                {
                    maiorRepetido = quantasVezesRepete;
                    valorRepetido = valores[i];
                }
            }
            return maiorRepetido;
        }
        static double MaiorNumeroBiModal(double[] valores, int casos, double valorRepetido)
        {
            int maiorRepetidoBimodal = -1;
            double valorRepetidoBimodal = 0;

            for (int i = 0; i < casos; i++) // Aqui se tiver Bi-modal.
            {
                int quantasVezesRepeteBimodal = 0;

                for (int j = i + 1; j < casos; j++)
                {
                    if (valores[i] == valores[j] && valores[i] != valorRepetido)
                    {
                        quantasVezesRepeteBimodal++;
                    }
                }
                if (quantasVezesRepeteBimodal > maiorRepetidoBimodal && valores[i] != valorRepetido)
                {
                    maiorRepetidoBimodal = quantasVezesRepeteBimodal;
                    valorRepetidoBimodal = valores[i];
                }
            }
            return valorRepetidoBimodal;
        }
        static int QuantasVezesRepeteBiModal(double[] valores, int casos, double valorRepetido)
        {
            int maiorRepetidoBimodal = -1;
            double valorRepetidoBimodal = 0;

            for (int i = 0; i < casos; i++) // Aqui se tiver Bi-modal.
            {
                int quantasVezesRepeteBimodal = 0;

                for (int j = i + 1; j < casos; j++)
                {
                    if (valores[i] == valores[j] && valores[i] != valorRepetido)
                    {
                        quantasVezesRepeteBimodal++;
                    }
                }
                if (quantasVezesRepeteBimodal > maiorRepetidoBimodal && valores[i] != valorRepetido)
                {
                    maiorRepetidoBimodal = quantasVezesRepeteBimodal;
                    valorRepetidoBimodal = valores[i];
                }
            }
            return maiorRepetidoBimodal;
        }
        static double Mediana(int casos, double[] valores)
        {

            if (casos % 2 == 0) 
            {
                casos /= 2;
                return  (valores[casos - 1] + valores[casos]) / 2.0;
            }
            else
            {
                casos /= 2;
                return  valores[casos];
            }
        }
        public static void ResultadoFinal(int maiorRepetido,int maiorRepetidoBimodal,int valoresDigitados, double moda,double Bimodal, double media, double mediana)
        {
            if (maiorRepetido > maiorRepetidoBimodal)
            {
                Console.WriteLine($"De {valoresDigitados} numeros um valor se repete sendo Modal: {moda.ToString(CultureInfo.InvariantCulture)}");
            }
            else if (maiorRepetido == maiorRepetidoBimodal && maiorRepetido != 0)
            {
                Console.WriteLine($"De {valoresDigitados} numeros dois valores se repete sendo Bi-Modal: {moda.ToString(CultureInfo.InvariantCulture)} e {Bimodal.ToString(CultureInfo.InvariantCulture)}");
            }
            else
            {
                Console.WriteLine($"Nenhum valor e constante nos {valoresDigitados} numeros digitados");
            }

            Console.WriteLine($"A média de {valoresDigitados} numeros é: {media.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"A mediana de {valoresDigitados} numeros é: {mediana.ToString(CultureInfo.InvariantCulture)}");
        }
        public static void Letreito()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("   M E D I A   M O D A   M E D I A N A   ");
            Console.WriteLine("=========================================");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            string escolha;

            do {
                Letreito();
                Console.Write("Quantos numeros você deseja saber a media,moda e mediana? ");
                int casos = int.Parse(Console.ReadLine());

                double[] valores = new double[casos];

                for (int i = 0; i < casos; i++)
                {
                    Console.Write($"Digite o numero {i + 1}: ");
                    valores[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }

                OrdemCrescente(valores, casos);

                double media = MediaDosNNumeros(valores, casos);
                double modal = MaiorNumeroModal(valores, casos);
                int repeticaoModal = QuantasVezesRepeteModal(valores, casos);
                double biModal = MaiorNumeroBiModal(valores, casos, modal);
                int repeticaoBiModal = QuantasVezesRepeteBiModal(valores, casos, modal);
                double mediana = Mediana(casos, valores);

                Console.Clear();
                Letreito();
                ResultadoFinal(repeticaoModal, repeticaoBiModal, casos, modal, biModal, media, mediana);

                Console.WriteLine();
                Console.Write("Deseja fazer outra consulta [S/N]: ");
                escolha = Console.ReadLine();

                while (escolha != "N" && escolha != "S" )
                {
                    Console.Write($"ERRO!! Comando {escolha} errado, digite sim (S) ou não (N): ");
                    escolha = Console.ReadLine();
                }
                Console.Clear();

            } while (escolha == "S");
            Console.ReadKey();
        }
    }
}