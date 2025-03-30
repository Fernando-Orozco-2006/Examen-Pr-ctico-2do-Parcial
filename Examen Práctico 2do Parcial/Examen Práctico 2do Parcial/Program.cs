using System;
using System.Collections.Generic;

class NodoFamiliar
{
    public string Nombre { get; set; }
    public List<NodoFamiliar> Padres { get; set; }
    public NodoFamiliar(string nombre)
    {
        Nombre = nombre;
        Padres = new List<NodoFamiliar>();
    }
}
class ArbolGenealogico
{
    private Dictionary<string, NodoFamiliar> miembros;
    public ArbolGenealogico()
    {
        miembros = new Dictionary<string, NodoFamiliar>();
    }
    public void AgregarMiembro(string nombreHijo, string nombrePadre, string nombreMadre)
    {
        if (!miembros.ContainsKey(nombreHijo))
        {
            miembros[nombreHijo] = new NodoFamiliar(nombreHijo);
        }

        if (!miembros.ContainsKey(nombrePadre))
        {
            miembros[nombrePadre] = new NodoFamiliar(nombrePadre);
        }
        if (!miembros.ContainsKey(nombreMadre))
        {
            miembros[nombreMadre] = new NodoFamiliar(nombreMadre);
        }

        miembros[nombreHijo].Padres.Add(miembros[nombrePadre]);
        miembros[nombreHijo].Padres.Add(miembros[nombreMadre]);
    }
    public void RecorrerPreorden(NodoFamiliar nodo, int nivel = 0)
    {
        if (nodo == null)
            return;

        Console.WriteLine(new string('-', nivel * 2) + nodo.Nombre);

        foreach (var padre in nodo.Padres)
        {
            RecorrerPreorden(padre, nivel + 1);
        }
    }
    public void MostrarPadres(string nombre)
    {
        if (miembros.ContainsKey(nombre))
        {
            var padres = miembros[nombre].Padres;
            if (padres.Count > 0)
            {
                Console.WriteLine($"Los padres de {nombre} son:");
                foreach (var padre in padres)
                {
                    Console.WriteLine(padre.Nombre);
                }
            }
            else
            {
                Console.WriteLine($"{nombre} no tiene padres registrados en el sistema.");
            }
        }
        else
        {
            Console.WriteLine("Miembro no encontrado.");
        }
    }
    public NodoFamiliar ObtenerMiembroRaiz()
    {
        foreach (var miembro in miembros.Values)
        {
            if (!EsPadreDeAlguien(miembro))
            {
                return miembro;
            }
        }
        return null;
    }
    private bool EsPadreDeAlguien(NodoFamiliar nodo)
    {
        foreach (var miembro in miembros.Values)
        {
            if (miembro.Padres.Contains(nodo))
            {
                return true;
            }
        }
        return false;
    }
}
class Program
{
    static void Main()
    {
        ArbolGenealogico arbol = new ArbolGenealogico();
        arbol.AgregarMiembro("Moises", "Carlos", "Watts");
        arbol.AgregarMiembro("Carlos", "Fernando", "Anton");
        arbol.AgregarMiembro("Watts", "Alan", "Gigi");
        Console.WriteLine("Recorrido preorden del árbol genealógico:");
        NodoFamiliar raiz = arbol.ObtenerMiembroRaiz();
        if (raiz != null)
        {
            arbol.RecorrerPreorden(raiz);
        }
        Console.WriteLine("\nBuscando padres de Moises:");
        arbol.MostrarPadres("Moises");
    }
}