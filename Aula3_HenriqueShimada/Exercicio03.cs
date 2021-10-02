using System;
using System.Reflection;
using System.Text;

namespace Aula4_HenriqueShimada
{
    class Exercicio03
    {
        public static void Main(string[] args)
        {
            string cor;
            while (true)
            {
                Console.Write(
                    "Informe uma opção para ser calculada:\n" +
                    "0) Sair\n" +
                    "1) Retângulo\n" +
                    "2) Círculo\n" +
                    "Opção: "
                );
                int opt = 0;
                try
                {
                    opt = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    opt = 9;
                }

                switch (opt)
                {
                    case 0:
                        return;
                    case 1:
                        Console.Write("Informe a base: ");
                        var b = double.Parse(Console.ReadLine());
                        Console.Write("Informe a altura: ");
                        var h = double.Parse(Console.ReadLine());
                        Console.Write("Informe a cor: ");
                        cor = Console.ReadLine();
                        Console.WriteLine(new Retangulo(b, h, cor).ToString());
                        break;
                    case 2:
                        Console.Write("Informe o raio: ");
                        var r = double.Parse(Console.ReadLine());
                        Console.Write("Informe a cor: ");
                        cor = Console.ReadLine();
                        Console.WriteLine(new Circulo(r, cor).ToString());
                        break;
                    default:
                        Console.WriteLine("Opção inválida, escolha uma das opções numérica. Pressione qualquer tecla para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }

        }
        private interface IForma
        {
            public abstract void ConfigurarCor(string cor);
            public abstract double CalculaArea();
        }

        class Retangulo : General, IForma
        {
            private double b, h;

            public Retangulo(double b, double h, string cor)
            {
                this.B = b;
                this.H = h;
                ConfigurarCor(cor);
                ((IForma)this).CalculaArea();
            }

            public double B { get => b; set => b = value; }
            public double H { get => h; set => h = value; }


            double IForma.CalculaArea()
            {
                return B * H;
            }

            public void ConfigurarCor(string cor)
            {
                base.Cor = cor;
            }
            public override string ToString()
            {
                return base.ToString();
            }
        }

        class Circulo : General, IForma
        {
            private double r;
            public Circulo(double r, string cor)
            {
                this.R = r;
                ConfigurarCor(cor);
                CalculaArea();
            }

            public double R { get => r; set => r = value; }

            public double CalculaArea()
            {
                return Math.Pow(R * Math.PI, 2.0);
            }

            public void ConfigurarCor(string cor)
            {
                base.Cor = cor;
            }
            public override string ToString()
            {
                return base.ToString();
            }
        }

        public abstract class General {


            private PropertyInfo[] _PropertyInfos = null;

            private string cor;
            private double area;

            public double Area { get => area; set => area = value; }
            public string Cor { get => cor; set => cor = value; }

            public override string ToString()
            {
                if (_PropertyInfos == null)
                    _PropertyInfos = this.GetType().GetProperties();

                var sb = new StringBuilder();
                sb.Append(this.GetType().Name + " [");
                foreach (var info in _PropertyInfos)
                {
                    var value = info.GetValue(this, null) ?? "(null)";
                    if (_PropertyInfos[_PropertyInfos.Length - 1] != info)
                        sb.Append(info.Name + ": " + value.ToString() + ", ");
                    else
                        sb.Append(info.Name + ": " + value.ToString() + "]");
                }

                return sb.ToString();
            }
        }
    }
}
