// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Persona p = new Persona();
Estudiante e = new Estudiante();

Persona pe = new Estudiante();

Console.WriteLine(p.GetType() == typeof(Persona));
Console.WriteLine(e.GetType() == typeof(Estudiante));
Console.WriteLine(pe.GetType().IsAssignableFrom(typeof(Persona)));
Console.WriteLine(pe.GetType().IsAssignableTo(typeof(Persona)));
Console.WriteLine(pe.GetType() == typeof(Estudiante));

class Persona
{
}

class Estudiante : Persona
{
}