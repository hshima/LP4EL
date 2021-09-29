using System;
//Aula2_HenriqueShimada

namespace Exercicio4
{
    class Inicio
    {
        static void Main(string[] args)
        {
            bool exit = true;
            PessoaFisica[] pf = new PessoaFisica[10];
            PessoaJuridica[] pj = new PessoaJuridica[10];
            int j = 0, f = 0;
            while (exit)
            {
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("1) Inserir cliente");
                Console.WriteLine("2) Remover cliente");
                Console.WriteLine("3) Consultar clientes");
                Console.WriteLine("0) Sair");
                switch (Console.ReadLine())
                {
                    case "0": exit = false; break;
                    case "1":
                        {
                            InserirCliente(pj, j, pf, f);
                            break;
                        }
                    case "2":
                        {
                            RemoverCliente(pj, pf);
                            break;
                        }
                    case "3":
                        {
                            ImprimeClientes(pj, pf);
                            break;
                        }
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }

        }

        private static Cliente option0ne(string option)
        {
            Cliente cliente = null;
            bool found = true;
            while(found)
            {
                switch (option)
                {
                    case "1":
                        PessoaJuridica pj = new PessoaJuridica();
                        Console.Write("Informe o código do cliente: ");
                        pj.SetCodigo(int.Parse(Console.ReadLine()));
                        Console.Write("Informe o numero do CNPJ do cliente: ");
                        pj.SetCnpjCliente(Console.ReadLine());
                        Console.Write("Informe a razão social do cliente: ");
                        pj.SetRazaoSocial(Console.ReadLine());
                        Console.Write("Informe o numero do telefone: ");
                        pj.SetTelefone(Console.ReadLine());
                        Console.Write("Informe o endereço do cliente: ");
                        pj.SetEndereco(Console.ReadLine());
                        Console.WriteLine(pj.ToString());
                        found = false;
                        return pj;
                    case "2":
                        PessoaFisica pf = new PessoaFisica();
                        Console.Write("Informe o código do cliente: ");
                        pf.SetCodigo(int.Parse(Console.ReadLine()));
                        Console.Write("Informe o numero do CPF do cliente: ");
                        pf.SetCpf(int.Parse(Console.ReadLine()));
                        Console.Write("Informe o nome do cliente: ");
                        pf.SetNome(Console.ReadLine());
                        Console.Write("Informe o numero do telefone: ");
                        pf.SetTelefone(Console.ReadLine());
                        Console.Write("Informe o endereço do cliente: ");
                        pf.SetEndereco(Console.ReadLine());
                        Console.WriteLine(pf.ToString());
                        found = false;
                        return pf;
                    default:
                        Console.WriteLine("Não foi selecionada uma opção válida");
                        break;
                }
            }
            return cliente;
        }
        private static void RemoverCliente(PessoaJuridica[] pj, PessoaFisica[] pf)
        {
            bool optionFound = true;
            while (optionFound)
            {
                Console.WriteLine("Informe o tipo de cliente que será removido:");
                Console.WriteLine("1) Pessoa Juridica");
                Console.WriteLine("2) Pessoa Física");
                Console.WriteLine("0) Voltar");
                string op = Console.ReadLine();
                switch (op)
                {
                    case "0":
                        optionFound = false;
                        break;
                    case "1":
                        {
                            int index = -1;
                            Console.Write("Informe o codigo do cliente pj que será apagado: ");
                            int codigoDelecao = int.Parse(Console.ReadLine());
                            try
                            {
                                for (int i = 0; i < pj.Length; i++)
                                {
                                    if (pj[i] != null && pj[i].GetCodigo() == codigoDelecao)
                                    {
                                        index = i;
                                        Console.WriteLine("index: " + index + ", element: " + pj[i]);
                                        pj[index] = null;
                                        return;
                                    }
                                }
                            }
                            catch (NullReferenceException e)
                            {
                                Console.WriteLine("index" + index);
                                throw e;
                            }
                            break;
                        }
                    case "2":
                        {
                            int index = -1;
                            Console.Write("Informe o codigo do cliente PF que será apagado: ");
                            int pos = int.Parse(Console.ReadLine());
                           
                            try
                            {
                                for (int i = 0; i < pf.Length; i++)
                                {
                                    index = i;
                                    Console.WriteLine("index: " + index + ", element: " + pf[i]);
                                    pf[index] = null;
                                    return;
                                }
                            }
                            catch (NullReferenceException e)
                            {
                                throw e;
                            }
                            if (pos == -1)
                                throw new Exception("Não há nenhum cliente nessa posição para ser removido.");
                            pf[index] = null;
                            return;
                        }
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
        private static void InserirCliente(PessoaJuridica[] pj, int j, PessoaFisica[] pf,  int f)
        {
            bool optionFound = true;
            while (optionFound)
            {
                Console.WriteLine("Informe o tipo de cliente que deseja cadastrar:");
                Console.WriteLine("1) Pessoa Juridica");
                Console.WriteLine("2) Pessoa Física");
                Console.WriteLine("0) Voltar");
                string op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        if (j < 10 && pj[j] == null)
                        {
                            pj[j] = (PessoaJuridica)option0ne(op);
                            j++;
                            optionFound = false;
                        }
                        else
                            Console.WriteLine("A lista de Pessoas Jurídicas está cheia");
                        break;
                    case "2":
                        if (f < 10 && pf[f] == null)
                        {
                            pf[f] = (PessoaFisica)option0ne(op);
                            f++;
                            optionFound = false;
                        }
                        else
                            Console.WriteLine("A lista de Pessoas Físicas está cheia");
                        break;
                    case "0":
                        optionFound = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
        private static void ImprimeClientes(PessoaJuridica[] pj, PessoaFisica[] pf)
        {
            Console.WriteLine("Pessoas Jurídicas: \n");
            foreach (Cliente c in pj)
            {
                if (c == null) return;
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("Pessoas Física: \n");

            foreach (Cliente c in pf)
            {
                if (c == null) return;
                Console.WriteLine(c.ToString());
            }
        }
    }

    class PessoaFisica : Cliente
    {
        private string nome;
        private int cpf;
        public string GetNome() {
            return nome;
        }
        public void SetNome(string nome)
        {
            this.nome = nome;
        }
        public int GetCpf()
        {
            return cpf; 
        } 
        public void SetCpf(int cpf)
        {
            this.cpf = cpf; 
        }
        public int GetCodigo()
        {
            return base.GetCodigo();
        }
        public void SetCodigo(int codigo)
        {
            base.SetCodigo(codigo);
        }
        public string GetEndereco()
        {
            return base.GetEndereco();
        }
        public void SetEndereco(string endereco)
        {
            base.SetEndereco(endereco);
        }
        public string GetTelefone()
        {
            return base.GetTelefone();
        }
        public void SetTelefone(string telefone)
        {
            base.SetTelefone(telefone);
        }
        public override string ToString()
        {
            return "PessoaFisica: { Codigo: " + GetCodigo() + ", Nome: " + GetNome() + ", Cpf: " + GetCpf() + ", Endereço: " + GetEndereco() + ", Telefone: " + GetTelefone() + "};";
        }
    }

    class PessoaJuridica : Cliente
    {
        private string razaoSocial, cnpjCliente;

        public string GetRazaoSocial()
        {
            return razaoSocial;
        }
        public void SetRazaoSocial(string razaoSocial)
        {
            this.razaoSocial = razaoSocial;
        }
        public string GetCnpjCliente()
        {
            return cnpjCliente;
        }
        public void SetCnpjCliente(string cnpjCliente)
        {
            this.cnpjCliente = cnpjCliente;
        }
        public int GetCodigo()
        {
            return base.GetCodigo();
        }
        public void SetCodigo(int codigo)
        {
            base.SetCodigo(codigo);
        }
        public string GetEndereco()
        {
            return base.GetEndereco();
        }
        public void SetEndereco(string endereco)
        {
            base.SetEndereco(endereco);
        }
        public string GetTelefone()
        {
            return base.GetTelefone();
        }
        public void SetTelefone(string telefone)
        {
            base.SetTelefone(telefone);
        }
        public override string ToString()
        {
            return "PessoaJuridica: { Codigo: " + GetCodigo() + ", RazaoSocial: " + GetRazaoSocial() + ", CnpjCliente: " + GetCnpjCliente() + ", Endereço: " + GetEndereco() + ", Telefone: " + GetTelefone() + "};";
        }
    }

    class Cliente
    {
        private int codigo;
        private string endereco;
        private string telefone;

        protected int GetCodigo() 
        { 
            return codigo;
        }
        protected void SetCodigo(int codigo)
        {
            this.codigo = codigo;
        }
        protected string GetEndereco()
        {
            return endereco;
        }
        protected void SetEndereco(string endereco) 
        { 
            this.endereco = endereco;
        }
        protected string GetTelefone()
        {
            return telefone;
        }
        protected void SetTelefone(string telefone)
        { 
            this.telefone = telefone;    
        }
        public override string ToString() { return null; }
    }

}