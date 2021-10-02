using System;
using System.Collections.Generic;
using System.Text;

namespace Aula4_HenriqueShimada
{
    class Exercicio01
    {
        public static void Main(string[] args)
        {
            bool continueHere = true;
            Pesquisa pesquisa = new Pesquisa();
            while (continueHere)
            {
                Console.Write(
                    "Informe uma opção:\n" +
                    "0) Sair\n" +
                    "1) Informar texto\n" +
                    "2) Buscar string -> Retorna verdadeiro ou falso\n" +
                    "3) Buscar string no inicio -> Retorna verdadeiro ou falso\n" +
                    "4) Buscar string no fim -> Retorna verdadeiro ou falso\n" +
                    "Opção: "
                );
                int opt = int.Parse(Console.ReadLine());

                switch (opt)
                {
                    case 0:
                        continueHere = true;
                        break;
                    case 1:
                        Console.WriteLine("Informe o texto: ");
                        pesquisa.SetTexto(Console.ReadLine());
                        break;
                    case 2:
                        Console.Write("Informe a frase que verificará se existe na string: ");
                        Console.WriteLine(pesquisa.BuscarString(Console.ReadLine()) ? "Exite!" : "Não existe!");
                        break;
                    case 3:
                        Console.Write("Informe a frase que verificará se existe no início da string: ");
                        Console.WriteLine(new PesquisaInicio(pesquisa).BuscarString(Console.ReadLine()) ? "Exite!" : "Não existe!");
                        break;
                    case 4:
                        Console.Write("Informe a frase que verificará se existe no fim da string: ");
                        Console.WriteLine(new PesquisaFim(pesquisa).BuscarString(Console.ReadLine()) ? "Exite!" : "Não existe!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida, escolha uma das opções numérica. Pressione qualquer tecla para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }

        }
        class Pesquisa
        {
            private string texto;

            public string Texto { get => texto; set => texto = value; }

            public void SetTexto(string texto)
            {
                this.Texto = texto;
            }
            public virtual bool BuscarString(string cadeiaCaracteres)
            {
                return Texto.Contains(cadeiaCaracteres);
            }


        }

        class PesquisaInicio : Pesquisa
        {
            private Pesquisa pesquisa;

            public PesquisaInicio(Pesquisa pesquisa)
            {
                this.pesquisa = pesquisa;
            }
            public sealed override bool BuscarString(string cadeiaCaracteres)
            {
                return this.pesquisa.Texto.StartsWith(cadeiaCaracteres);
            }
        }

        class PesquisaFim: Pesquisa
        {
            private Pesquisa pesquisa;

            public PesquisaFim(Pesquisa pesquisa)
            {
                this.pesquisa = pesquisa;
            }
            public sealed override bool BuscarString(string cadeiaCaracteres)
            {
                return this.pesquisa.Texto.EndsWith(cadeiaCaracteres);
            }
        }
    }
}
