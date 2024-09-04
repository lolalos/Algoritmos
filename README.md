# Proyecto CFecha

## Descripción

Este proyecto implementa una clase `CFecha` en C# que permite manejar fechas de forma nativa, sin depender de bibliotecas externas. La clase incluye métodos para validar fechas, calcular el día de la semana, determinar si un año es bisiesto, y más. Además, el programa principal permite al usuario ingresar una fecha y obtener información relacionada con ella.

## Funcionalidades

- **Validación de Fechas**: Verifica si una fecha es válida, considerando el mes y si el año es bisiesto.
- **Cálculo del Día de la Semana**: Usa el algoritmo de Zeller para determinar el día de la semana para cualquier fecha.
- **Determinación de Años Bisiestos**: Identifica si un año es bisiesto según las reglas del calendario gregoriano.
- **Cálculo de Días en un Mes**: Determina el número de días en un mes específico.
- **Cálculo de Días Transcurridos**: Calcula los días transcurridos en el año y los días totales desde el 01/01/1900.
- **Manipulación de Fechas**: Obtiene la fecha del día siguiente y la del día anterior.

## Formato de Entrada

El programa admite fechas ingresadas en los siguientes formatos:

- `dd-mm-aaaa`
- `dd/mm/aaaa`

El usuario debe ingresar una fecha en uno de estos formatos. Si la fecha o el formato son incorrectos, el programa solicitará que se intente nuevamente.

## Uso

### Ejecución

1. **Clonar el repositorio**:

    ```bash
    git clone https://github.com/lolalos/Algoritmos/tree/main/AppFecha
    ```

2. **Abrir el proyecto en Visual Studio**:

    - Abre `Visual Studio`.
    - Navega hasta `File > Open > Project/Solution`.
    - Selecciona el archivo `.sln` del proyecto.

3. **Ejecutar el programa**:

    - Presiona `F5` para compilar y ejecutar el proyecto.

### Ingreso de Datos

- Cuando se ejecuta el programa, se te pedirá que ingreses una fecha en formato `dd-mm-aaaa` o `dd/mm/aaaa`.
- El programa procesará la fecha ingresada y mostrará la siguiente información:
  - Fecha actual con el día de la semana.
  - Si el año es bisiesto.
  - El número de días en el mes.
  - Días transcurridos en el año.
  - Días totales desde el 01/01/1900.
  - Fecha del día siguiente.
  - Fecha del día anterior.

### Ejemplo de Ejecución

```plaintext
Ingrese la fecha en formato dd-mm-aaaa o dd/mm/aaaa: 01-09-2024
Fecha actual: domingo 1 de septiembre de 2024
Es bisiesto: True
Días en el mes: 30
Días transcurridos en el año: 245
Días totales desde 01/01/1900: 45535
Fecha del día siguiente: lunes 2 de septiembre de 2024
Fecha del día anterior: sábado 31 de agosto de 2024

Presione cualquier tecla para salir...
