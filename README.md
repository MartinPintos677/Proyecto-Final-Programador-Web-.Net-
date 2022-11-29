# Proyecto-Final-Programador-Web-.Net-
Proyecto Final para el primer año de la carrera de Analista de Sistemas. Fue desarrollado una aplicación Web para un sitio de pronósticos del tiempo, 
el proyecto tiene la arquitectura en tres capas, programado en Visual Studio 2019, C#, Asp .Net y la base de datos en Sql Server.

Descripción de la Realidad:

Los pronósticos del tiempo se hacen para ciudades de países. De cada País se conoce un código 
de 3 letras (único en el sistema e identificador), y su nombre. Las ciudades pertenecen a un país 
especifico, y por lo tanto se identifican a partir de él. De cada ciudad se sabe además un código de 3 
letras único por país) y su nombre.
Los pronósticos se identifican por un código interno autogenerado por el sistema, y además se 
sabe: para que ciudad es y que usuario lo genero. Como datos del pronóstico se debe ingresar: fecha y 
hora del pronóstico, temperatura (máxima y mínima), velocidad del viento, tipo del cielo (despejado, 
parcialmente nuboso o nuboso), probabilidad de lluvias y tormentas (se asume 0 como la no 
probabilidad de que ocurran). No podrá ingresarse más de un pronóstico para una misma fecha y hora. 
Los usuarios del sistema serán los responsables de mantener la información del sistema. De 
ellos, se deberá saber nombre de usuario de logueo (único en el sistema e identificador del usuario),
contraseña y nombre completo del mismo. 

Funcionalidades Mínimas del Sitio Web:

Formulario Web: Default (formulario por defecto del sitio). 
Actor Participante: público.
Resumen: En este formulario deberá desplegarse por defecto un listado de todos los pronósticos del 
día (fecha de hoy). Además, deberá contar con un acceso al formulario de Logueo.

Formulario Web: Logueo.
Actor Participante: público.
Resumen: Mediante esta página se permitirá el logueo de un empleado al sitio (ingreso de usuario de 
logueo y contraseña). No se permite el uso de controles de tipo Login. Si el empleado se autentica 
correctamente, el sistema lo re direccionará a una página de bienvenida. 

Formulario Web: ABM de Países.
Actor Participante: Usuario empleado.
Resumen: Este formulario permitirá realizar cualquiera de las 3 acciones, a partir del ingreso del código 
de país. Si este ya existe, se podrá eliminar o modificar (previo despliegue de todos sus datos). En 
caso de que no exista, se solicitaran todos los datos para generar un nuevo país en el repositorio de 
datos. Tomar en cuenta que si se intenta eliminar un país, y tiene pronósticos asociados, no se podrá 
eliminar; de lo contrario se podrá eliminar conjuntamente con sus dependencias (las ciudades).

Formulario Web: ABM de Ciudades. 
Actor Participante: Usuario empleado.
Resumen: Este formulario permitirá realizar cualquiera de las 3 acciones, a partir del ingreso del 
identificador de una ciudad (código de país al que pertenece y su propio código de ciudad). Si dicho 
identificador ya existe se podrá eliminar o modificar (previo despliegue de todos sus datos). En caso 
de que no exista, se solicitaran todos los datos para ingresar una nueva ciudad en el repositorio de 
datos. Tomar en cuenta que si se elimina una ciudad, deberán eliminarse también sus dependencias
(pronósticos).

Formulario Web: ABM de Usuarios.
Actor Participante: Usuario empleado.
Resumen: Este formulario permitirá realizar cualquiera de las 3 acciones, a partir del ingreso del 
usuario de logueo. Si el valor ya existe se podrá eliminar o modificar dicho usuario (previo despliegue 
de todos sus datos). En caso de que el usuario no exista, se solicitaran todos los datos para generar un 
nuevo usuario en el repositorio de datos. Tomar en cuenta que si hay registros de pronósticos 
asociados a dicho usuario, no se habilita la acción de eliminar. 

Formulario Web: Registrar un Pronostico.
Actor Participante: Usuario Empleado.
Resumen: Este formulario permitirá generar un nuevo pronóstico del tiempo. Para ello se deberá 
poder seleccionar desde una grilla, la ciudad a la cual pertenece el pronóstico. Dicha lista deberá tener 
todos los datos de la ciudad. El usuario ingresara todos los datos del pronóstico y podrá confirmar la 
acción. El usuario actualmente logueado será relacionado al pronóstico. 

Formulario Web: Listado de Pronósticos por Ciudad. 
Actor Participante: Usuario empleado.
Resumen: Este formulario permitirá consultar todos los datos de los pronósticos. El usuario primero 
deberá seleccionar un país desde un control DropDownList. En una grilla se desplegaran todas las 
ciudades ingresadas en el sistema de dicho pais. Seleccionada una ciudad, se desplegaran todos los 
pronósticos de dicha ciudad (con todos sus datos), ordenados por fecha y hora. En caso de que aún no 
tenga pronósticos asignados, se deberá desplegar un mensaje indicándolo. 

Formulario Web: Listado Pronósticos para el día.
Actor Participante: Usuario Empleado.
Resumen: Este formulario mostrara en una grilla, la lista de pronósticos, cuya fecha sea una ingresada 
por el usuario. Si para dicha fecha no existen pronósticos, deberá notificársele al usuario mediante un 
mensaje
Nota: todas las páginas no públicas del sistema deberán desplegarse con una Master Page, en la cual 
se encontrará el menú principal correspondiente, un control que despliegue el nombre del usuario 
logueado y un acceso a desloguearse. Tomar en cuenta que la verificación de permisos deberá 
realizarse dentro de la MP correspondiente.
