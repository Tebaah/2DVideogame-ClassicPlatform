using Godot;
using System;

/// <summary>
/// Clase auxiliar para inicializar y obtener referencias a componentes hijos de un nodo.
/// Permite centralizar la lógica de inicialización y reutilizarla en distintos scripts.
/// </summary>
public static class ComponentInitializer
{
    /// <summary>
    /// Obtiene y retorna un hijo de tipo T a partir de un nodo padre y una ruta relativa.
    /// Lanza una excepción si el componente no se encuentra.
    /// </summary>
    /// <typeparam name="T">Tipo del componente a buscar.</typeparam>
    /// <param name="parent">Nodo padre desde el cual buscar.</param>
    /// <param name="path">Ruta relativa al componente.</param>
    /// <returns>Referencia al componente encontrado.</returns>
    public static T GetComponent<T>(Node parent, NodePath path) where T : Node
    {
        var node = parent.GetNodeOrNull<T>(path);
        if (node == null)
            throw new InvalidOperationException($"No se encontró el componente de tipo {typeof(T).Name} en la ruta '{path}'.");
        return node;
    }

    /// <summary>
    /// Inicializa múltiples componentes y retorna un array con las referencias.
    /// </summary>
    /// <typeparam name="T">Tipo base de los componentes.</typeparam>
    /// <param name="parent">Nodo padre.</param>
    /// <param name="paths">Rutas relativas a los componentes.</param>
    /// <returns>Array de referencias a los componentes encontrados.</returns>
    public static T[] GetComponents<T>(Node parent, params NodePath[] paths) where T : Node
    {
        T[] components = new T[paths.Length];
        for (int i = 0; i < paths.Length; i++)
        {
            components[i] = GetComponent<T>(parent, paths[i]);
        }
        return components;
    }
}
