using System.Collections;
using System.IO;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using ProjetoSenai.Model;
using System.Linq;

ExemploSenaiContext context = new ExemploSenaiContext();
List<Usuario> list = context.Usuarios.ToList();

string nome = "Edjalma",
        senha = "elefantinho";

var usuariosParaMandarEmail = list
    .Where(u => u.Nome == nome && u.Senha == senha);

foreach (var usuarios in usuariosParaMandarEmail)
{
    Console.WriteLine(usuarios.Nome);
}



public static class ClasseDeExtensao
{
    public static IEnumerable<R> Map<T, R>(
        this IEnumerable<T> collection,
        Func<T, R> func)
    {
        foreach (var element in collection)
        {
            yield return func(element);
        }
    }

    public static IEnumerable<T> Filter<T>(
        this IEnumerable<T> collection,
        Func<T, bool> filter)
    {
        foreach (var element in collection)
        {
            if (filter(element))
            {
                yield return element;
            }
        }
    }
}

// Lista<int> lista = new Lista<int>();
// lista.Add(1);
// lista.Add(2);
// lista.Add(3);
// lista.Add(4);

// foreach (var valor in lista)
// {
//     Console.WriteLine("bananinha");
//     Console.WriteLine(valor);
// }

public class Lista<T> : IEnumerable<T>
{
    int i = 0;
    T[] array = new T[10];

    public int Count
    {
        get
        {
            return i;
        }
    }

    public T this[int index]
    {
        get
        {
            return array[index];
        }
        set
        {
            array[index] = value;
        }
    }

    public void Add(T value)
    {
        if (i == array.Length)
        {
            T[] newArray = new T[2 * array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            this.array = newArray; 
        }
        array[i] = value;
        i++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int n = 0; n < Count; n++)
        {
            yield return array[n];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}