# Solid

## ¿Qué es SOLID?

Son una serie de principios y recomendaciones que se aplican a la programacion orientada a objetos los cuales sirven como guía al momento de diseñar un sistema.
Su nombre hace referencia a la primera letra de cada uno de los principios.

## Objetivos de SOLID

Con la correcta aplicacion de los principios SOLID, estos nos ayudarán a que el código que escribimos sea más mantenible, extensible y legible sobre todo a largo plazo.

## Principios SOLID
Solid se compone de cinco principios, los cuales son:

### Single responsibility principle (Principio de responsablidad única)

Cada clase debe tener una única responsabilidad, es decir, cada clase debe encargarse de solo una parte del sistema y tener un solo propósito. Si tenemos una clase que se ocupa de muchas cosas, deberíamos crear nuevas clases para dividir sus responsabilidades 

Entre las principales ventajas de este principio están: ayudar a reducir la complejidad de cada una de las clases, logrando que tareas como el testing o localizar y corregir errores se hagan mucho más sencillas. También logra reducir el acoplamiento, lo que permite que al modificar una clase, el cambio no afecte al funcionamiento del resto de la aplicación.

#### Ejemplo de este principio

```java
public class TextManipulator {
    private String text;

    public TextManipulator(String text) {
        this.text = text;
    }

    public String getText() {
        return text;
    }

    public void appendText(String newText) {
        text = text.concat(newText);
    }
    
    public String findWordAndReplace(String word, String replacementWord) {
        if (text.contains(word)) {
            text = text.replace(word, replacementWord);
        }
        return text;
    }
    
    public String findWordAndDelete(String word) {
        if (text.contains(word)) {
            text = text.replace(word, "");
        }
        return text;
    }

    public void printText() {
        System.out.println(textManipulator.getText());
    }
}
```

El código en si no tiene ningún problema y funciona perfectamente, pero está incumpliendo con el primer principio al tener dos responsabilidades: manipular e imprimir el texto. En este caso, deberíamos crear una nueva clase que se encargue solamente de imprimir el texto.

```java
public class TextPrinter {
    TextManipulator textManipulator;

    public TextPrinter(TextManipulator textManipulator) {
        this.textManipulator = textManipulator;
    }

    public void printText() {
        System.out.println(textManipulator.getText());
    }

    public void printOutEachWordOfText() {
        System.out.println(Arrays.toString(textManipulator.getText().split(" ")));
    }

    public void printRangeOfCharacters(int startingIndex, int endIndex) {
        System.out.println(textManipulator.getText().substring(startingIndex, endIndex));
    }
}
```

### Open / Closed principle (Principio Abierto / Cerrado)

Una entidad debe quedar abierta para su extensión pero cerrada para su modificación.
El código escrito que ya funciona no debería modificarse, por lo tanto, para añadir alguna nueva funcionalidad al código, se debería escribir código nuevo

Este principio se aplica para evitar modificar el código ya existente con la posibilidad de causar errores

#### Ejemplo de este principio
```c#
public class Bebida
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public decimal Precio { get; set; }
}

public class Impuesto
{
    public decimal calcularTotal(IEnumerable<Bebida> listaBebidas)
    {
        decimal total = 0;
        foreach (var bebida in listaBebidas)
        {
            if (bebida.Tipo == "Agua")
                total += bebida.Precio;
            else if (bebida.Tipo == "Azucarada")
                total += bebida.Precio * 0.3m;
            else if (bebida.Tipo == "Alcoholica")
                total += bebida.Precio * 0.5m;
        }
        return total;
    }
}
```

Tenemos una clase Bebida en la cual dependiendo de su tipo se calculará en la clase *Impuesto* su precio agregando el impuesto correspondiente.

Si tuviéramos más adelante que agregar un nuevo tipo de bebida, tendríamos que modificar el código que ya escribimos rompiendo este segundo principio.

En este caso, podemos encontrar la solución en las interfaces. Transformamos la clase *Bebida* en una interfaz y quitamos la propiedad *Tipo*, ya que ahora los tipos de bebidas vendrán dados por nuevas clases que implementen la interfaz *IBebida*.
Para hacer el cálculo de precio agregamos la propiedad *Impuesto* y el método *CalcularPrecio()*. De esta forma, cuando las clases implementen la interfaz, podrán calcular su precio dependiendo de la interfaz y de su propia lógica

```c#
public interface IBebida
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public decimal Impuesto { get; set; }
    public decimal CalcularPrecio();
}

public class Agua : IBebida
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public decimal Impuesto { get; set; }

    // Calcular precio con impuesto
    public decimal CalcularPrecio()
    {
        return Precio * Impuesto;
    }
}

public class Azucarada : IBebida
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Promocion { get; set;}

    // Calcular precio con impuesto y promoción
    public decimal CalcularPrecio()
    {
        return (Precio * Impuesto) - Promocion;
    }
}

public class Alcoholica : IBebida
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public decimal Impuesto { get; set; }
     
    public decimal CalcularPrecio()
    {
        return Precio * Impuesto;
    }
}

//Nuevo tipo de bebida sin alterar el código escrito
public class Energetica : IBebida
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public decimal Impuesto { get; set; }
     
    public decimal CalcularPrecio()
    {
        return Precio * Impuesto;
    }
}

public class Impuesto
{
    public decimal CalcularTotal(IEnumerable<IBebida> listaBebidas)
    {
        decimal total = 0;
        foreach (var bebida in listaBebidas)
        {
            total += bebida.CalcularPrecio();
        }
        return total;
    }
}

```

Con el código estructurado de esta manera, podemos agregar más tipos de bebida sin necesidad de cambiar el código ya escrito, solamente creando nuevas clases para cada tipo de bebida, cumpliendo así con el segundo principio.


### Liskov substitution principle (Principio de sustitución de Liskov)
Toda clase que es hija de una clase padre, debe poder ser utilizada como si fuera el mismo padre.
Esto quiere decir que cualquier subclase de una clase padre, puede ser reemplazada y usada como su clase padre sin alterar su funcionamiento ni provocar errores en el sistema.

#### Ejemplo de este principio

![](https://images1.programmerclick.com/24/2c/2cc32ab3bf398f8e1153af0a74710e58.png "Ejemplo imagen 1.")

A base de este diagrama, si quisiéramos agregar una clase pistola de juguete ("*ToyGun*") que herede de la clase *AbstractGun* estaríamos rompiendo este principio, ya que una pistola de juguete no debería poder realizar la acción *KillEnemy()* 

![](https://images2.programmerclick.com/352/f2/f2618fc81c387a6c717221bbaf055338.png "Ejemplo imagen 2.")

Para respetar el principio, podemos crear una nueva clase dedicada a armas de juguete ("*AbstractToy*") para poder separar armas reales de las de juguete.

![](https://images1.programmerclick.com/51/ce/ced899a39d9f925594f685d842a2aa23.png "Ejemplo imagen 3.")


### Interface segregation principle (Principio de segregacion de interfaces)
Ninguna clase debería estar forzada a depender de métodos que no utiliza.
Para lograr esto, se deben crear pequeñas interfaces específicas en vez de una interfaz muy sobrecargada y general.
Dependiendo de los requerimientos que tenga nuestro sistema, se tiene que detectar lo mínimo que una clase necesita de su interfaz y en base a eso, crear una interfaz general para ella. Para implementar funcionalidades extras se deben crear nuevas interfaces especializadas para tales funciones.

#### Ejemplo de este principio

```java
interface Product {
    val name: String
    val stock: Int
    val numberOfDisks: Int
    val releaseDate: Int
}
class CD : Product {
    ...
}
```
En este ejemplo simulamos una tienda de CDs de música con una clase *CD* que implementa la interfaz *Product*.
Si quisiéramos agregar un nuevo producto como por ejemplo DVDs, necesitaríamos crear una clase que implemente una clasificación por edades para evitar vender películas no aptas para la edad del cliente.

Lo más rápido de hacer, sería modificar la interfaz con la propiedad que necesitamos.

```java
interface Product {
    ...
    val recommendedAge: Int
}
```
Sin embargo, aquí estaríamos rompiendo este principio, ya que CD estaría obligado a implementar *recommendedAge*, una propiedad que no necesita, lanzando una excepción o dejándola vacía, con los problemas que esto trae.

Para solucionar esto, usamos el principio de segregación de interfaces, dividiendo la interfaz creando una nueva para la clasificación de edades.
```java
interface AgeAware {
    val recommendedAge: Int
}
```
Ahora cada clase implementa las interfaces que realmente necesita.
```java
class CD : Product {
    ...
}
class DVD : Product, AgeAware {
    ...
}
```

### Dependency inversion principle (Principio de inversión de la dependencia)
Las clases de alto nivel no deberían depender de las clases de bajo nivel. Ambas deberían depender de abstracciones
Este principio nos dice que no debería haber dependencia entre módulos, sobre todo entre los de alto y bajo nivel. Esto quiere decir que el núcleo de nuestro sistema no debería depender de detalles de implementación como los puede ser un framework, la base de datos o la conexión al servidor.
Esto lo logramos con la dependencia de interfaces. Necesitamos que nuestras clases dependan de abstracciones de las interfaces,

#### Ejemplo de este principio

Tenemos una clase *AccesoADatos* que accede a los datos a través de una base de datos.

```java  
class DatabaseService{  
    //...
    void getDatos(){ //... }
}

class AccesoADatos {

    private DatabaseService databaseService;

    public AccesoADatos(DatabaseService databaseService){
        this.databaseService = databaseService;
    }

    Dato getDatos(){
        databaseService.getDatos();
        //...
    }
}
```
Si quisiéramos a futuro cambiar el servicio de base de datos a por ejemplo uno que se conecte a una API, deberíamos modificar una a una cada instancia de *AccesoADatos*, ya que esta clase depende directamente de *DatabaseService*, un módulo de bajo nivel.
De esta forma estamos incumpliendo el principio de inversión de dependencias, los módulos de alto nivel, deberían depender de abstracciones.

Para solucionarlo, podemos hacer que *AccesoADatos* depende de una abstracción más genérica.

```java
interface Conexion {  
    Dato getDatos();
    void setDatos();
}

class AccesoADatos {

    private Conexion conexion;

    public AccesoADatos(Conexion conexion){
        this.conexion = conexion;
    }

    Dato getDatos(){
        conexion.getDatos();
    }
}
```

De esta manera, no importa cuál sea el tipo de conexión que use *AccesoADatos*, no habrá que modificar ni la clase ni sus instancias para lograr el cambio.

Ahora, cada servicio que vayamos a pasarle a *AccesoADatos* deberá cumplir con la interfaz *Conexion* logrando que tanto los módulos de bajo y de alto nivel dependan de abstracciones.

```java
class DatabaseService implements Conexion {

    @Override
    public Dato getDatos() { //... }

    @Override
    public void setDatos() { //... }
}

class APIService implements Conexion{

    @Override
    public Dato getDatos() { //... }

    @Override
    public void setDatos() { //... }
}
```

## Referencias 

Ejemplo de [Single responsibility principle](https://www.baeldung.com/java-single-responsibility-principle)

Ejemplo de [Liskov substitution principle](https://programmerclick.com/article/55451263051/)

Ejemplo de [Interface segregation principle](https://devexperto.com/principio-de-segregacion-de-interfaces/)

Ejemplo de [Dependency inversion principle](https://enmilocalfunciona.io/principios-solid/)


