using System;
using System.Collections;
using System.Collections.Generic;

public class ListaOrdenada<T> : IEnumerable<T> where T : IComparable<T>
{
    private List<T> elementos = new List<T>();

    public bool Contiene(T elemento)
    {
        return elementos.Contains(elemento);
    }

    public void Agregar(T elemento)
    {
        if (!Contiene(elemento))
        {
            int index = elementos.BinarySearch(elemento);
            if (index < 0) index = ~index;
            elementos.Insert(index, elemento);
        }
    }

    public void Eliminar(T elemento)
    {
        elementos.Remove(elemento);
    }

    public int Cantidad
    {
        get { return elementos.Count; }
    }

    public T this[int indice]
    {
        get { return elementos[indice]; }
    }

    public ListaOrdenada<T> Filtrar(Predicate<T> condicion)
    {
        var nuevaLista = new ListaOrdenada<T>();
        foreach (T elemento in elementos)
        {
            if (condicion(elemento))
            {
                nuevaLista.Agregar(elemento);
            }
        }
        return nuevaLista;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return elementos.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Contacto : IComparable<Contacto>
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }

    public Contacto(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
    }

    public int CompareTo(Contacto otro)
    {
        return this.Nombre.CompareTo(otro.Nombre);
    }

    public override bool Equals(object obj)
    {
        if (obj is Contacto otro)
        {
            return this.Nombre == otro.Nombre && this.Telefono == otro.Telefono;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Nombre, Telefono);
    }

    public override string ToString()
    {
        return $"{Nombre} - {Telefono}";
    }
}