# Tarea 3 - Gestión de Empleados

Nombre: Juan Murillo  
Carnet: C35485  

## Instrucciones de ejecución

1. Abrir el proyecto en Visual Studio.
2. Verificar que la cadena de conexión esté configurada en `appsettings.json`.
3. Ejecutar las migraciones con `Update-Database` si la base de datos no existe.
4. Ejecutar el proyecto.
5. Acceder a la ruta `/Empleados`.

## Funcionalidad

El sistema permite registrar, editar y dar de baja empleados.  
La baja no elimina el registro físicamente, solamente cambia el estado del empleado.

## Búsqueda y paginación

La pantalla principal permite buscar empleados por nombre, apellidos o departamento.  
Los resultados se muestran paginados en grupos de 5 registros por página.

Ejemplo de URL con búsqueda:

`/Empleados?busqueda=TI&pagina=1`

## Autor
Juan Murillo
