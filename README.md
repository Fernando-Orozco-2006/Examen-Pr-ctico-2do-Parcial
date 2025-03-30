# Examen-Pr-ctico-2do-Parcial
Esta actividad es representada como el Examen Práctico del segundo parcial de nuestro curso.

En este examen del segundo paricial, se tendra que implementar un sistema especial para poder gestionar un árbol genealógico en C#.
Cada nodo dentro del arbol representa un hijo y sus padres son nodos hijos de esos nodos.

## Características
Representa una familia en forma de un árbol genealógico con la posibilidad de agregar nuevos miembros con sus respectivos padres,
ademas de poder recorrer todo el arbol de forma preordenada para visualisar total mente la jerarquía familiar y ayudar a buscar los
padres de un miembro que no estes familiarizado.

## Requisitos
Los sistemas .NET Core o .NET Framework instalado en el sistema, ya que el sistema fue creado para ser compatible con C# 
(Visual Studio, Visual Studio Code, etc.).

## Uso

1. Compilar y ejecutar el programa
   
   En la terminal o línea de comandos, ejecutar:
   ```sh
   dotnet run
   ```
   
2. Agregar miembros
   - Se pueden agregar miembros con `AgregarMiembro(nombreHijo, nombrePadre, nombreMadre)`.
   
3. Recorrer el árbol genealógico
   - Se muestra el árbol en preorden llamando a `RecorrerPreorden()`.

4. Buscar padres de un miembro
   - Llamando a `MostrarPadres(nombre)`, se obtiene la lista de los padres de un miembro específico.

## Ejemplo de Salida
```
Recorrido preorden del árbol genealógico:
Juan
--Carlos
----Pedro
----María
--Ana
----José
----Laura

Buscando padres de Juan:
Los padres de Juan son:
Carlos
Ana
```

