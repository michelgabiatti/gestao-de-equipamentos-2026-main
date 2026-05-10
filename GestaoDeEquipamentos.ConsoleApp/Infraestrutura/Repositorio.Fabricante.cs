using System.Reflection.Metadata;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

class RepositorioFabricante
{
    public Fabricante?[] fabricantes = new Fabricante[100];

    public bool cadastrar(Fabricante novoFrabricante)
    {
        bool realizado = false;
        novoFrabricante.Id = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7);

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
            {
                realizado = true;
                fabricantes[i] = novoFrabricante;
                break;
            }
        }
        return realizado;
    }

    public Fabricante?[] SelecionarTodos()
    {
        return fabricantes;
    }

    public Fabricante? SelecionarPorId(String IdSelecionado)
    {
        Fabricante? fabricanteSelecioando = null;

        for (int i = 0; i < fabricantes.Length; i++)
        {
            if (fabricantes == null)
            {
                continue;
            }
            else if (IdSelecionado == fabricantes[i].Id)
            {
                fabricanteSelecioando = fabricantes[i];
                return fabricanteSelecioando;
            }
        }
        return fabricanteSelecioando;
    }

    public void Excluir(Fabricante ObjetoHaSerExcluido)
    {
        ObjetoHaSerExcluido = null;
    }
}