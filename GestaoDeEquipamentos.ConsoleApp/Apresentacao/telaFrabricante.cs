using System.Globalization;
using System.Runtime.InteropServices;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

class TelaFabricante
{
    public RepositorioFabricante repositorioFabricante;

    public string ObterEscolhaMenuPrincipal()
    {
        //Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadatrar Fabricantens");
        Console.WriteLine("2 - Editar Fabricantes");
        Console.WriteLine("3 - Excluir Fabricantes");
        Console.WriteLine("4 - Visualizar Fabricantens");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? ObterEscolha = Console.ReadLine()?.ToUpper(); ;

        return ObterEscolha;
    }
    public void CadastrarFabricantes()
    {
        ChamarCabecario("Cadastrar");

        bool realizado = repositorioFabricante.cadastrar(ObterDadosCadastrais());

        if (realizado)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("cadastro realizado com sucesso");
            Console.WriteLine("---------------------------------");
            Console.ReadLine();
        }
        else
        {
            System.Console.WriteLine("Array Lotado");
            Console.ReadLine();
        }
    }

    public void EditarFabricantes()
    {
        ChamarCabecario("Editar");

        Fabricante fabricanteSelecionado = EscolherFabricante();

        Fabricante novoFabricante = ObterDadosCadastrais();

        novoFabricante.Id = fabricanteSelecionado.Id;
    }

    public void ExcluirFabricantes()
    {
        repositorioFabricante.Excluir(EscolherFabricante());
    }

    public void VisiualizarFabricantes()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine(
         "{0, -7} | {1, -15} | {2, -25} | {3, -15} |",
          "Id", "Nome", "Email", "Telefone"
      );

        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -25} | {3, -15} ",
                f.Id, f.Nome, f.Email, f.Telefone
            );
        }

        Console.WriteLine("---------------------------------");
        Console.ReadLine();
    }

    public Fabricante EscolherFabricante()
    {
        Console.WriteLine(
          "{0, -7} | {1, -15} | {2, -25} | {3, -15} |",
          "Id", "Nome", "E-mail", "Telefone"
      );

        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -25} | {3, -15} |",
                f.Id, f.Nome, f.Email, f.Telefone
            );
        }

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do equipamento que deseja selecionar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Fabricante? fabricanteSelecionado = repositorioFabricante.SelecionarPorId(idSelecionado);

        if (fabricanteSelecionado == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontrar o fabricante informado.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return fabricanteSelecionado;
        }
        return fabricanteSelecionado;
    }

    public Fabricante ObterDadosCadastrais()
    {
        Fabricante novoFabricante = new Fabricante();
        do
        {
            Console.Write("Digite o Nome do fabricante: ");
            novoFabricante.Nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.Nome) &&
                novoFabricante.Nome.Length >= 3)
            {
                break;
            }

        } while (true);
        do
        {
            Console.Write("Digite o e-mail do fabricante: ");
            novoFabricante.Email = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.Email) &&
                novoFabricante.Email.Length >= 8)
            {
                break;
            }

        } while (true);
        do
        {
            Console.Write("Digite o Telefone do fabricante: ");
            novoFabricante.Telefone = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.Telefone) &&
                novoFabricante.Telefone.Length >= 10)
            {
                break;
            }
        } while (true);

        return novoFabricante;
    }
    public void ChamarCabecario(String Opcao)
    {
        //Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"{Opcao} de Fabricantes");
        Console.WriteLine("---------------------------------");
    }

}