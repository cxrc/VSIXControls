# VSIXControls

>Controles de usuario para Windows Forms en Visual Studio
>
>Última versión 1.0.0

---

|  [Download](https://github.com/cxrc/VSIXControls/releases/latest)  |  [Wiki](https://github.com/cxrc/VSIXControls/wiki)  |

---

1. [Descripción](#id1)
2. [Controles](#id2)
   1. [Switch](#id21)

![preview](https://user-images.githubusercontent.com/63002560/110313720-20e5f580-8007-11eb-80e3-0b581b83c273.png)

## Descripción 👀<a name="id1"></a>

En este proyecto se crean una serie de controles de usuario como extensión del `IDE Visual Studio de Microsoft`. La instalación de los controles se realiza de forma sencilla y pueden ser utilizados en cualquier proyecto de escritorio de Windows Forms.

El proyecto es de código abierto y se distribuye como software libre, por lo que cualquiera puede usar los controles en sus proyectos y/o modificarlos.

En la versión actual se han implementado los siguientes controles:

- **Switch** : Un control con la apariencia de un interruptor con dos estados (Encendido y apagado)
- **LED** : Un indicador simulando un piloto led tambien con dos estados (Encendido y apagado)

## Controles 📍<a name="id2"></a>

### Switch ![image](https://user-images.githubusercontent.com/63002560/110314448-21cb5700-8008-11eb-94db-d23c7bc855d5.png)<a name="id21"></a>

![image](https://user-images.githubusercontent.com/63002560/110314464-298afb80-8008-11eb-86b2-925ddbbeb19a.png)


Simula un **microinterruptor**. En la actual versión tiene la apariencia de un microinterruptor de tipo deslizante con la palanca cuadrada. Hereda sus propiedades, métodos y eventos de la clase `UserControl` y además implementa los siguientes:

#### Propiedades 📐
- **IsON** : Propiedad de tipo `bool`. Establece o devuelve el estado del control, `true` si el interruptor está en posición **ON** o `false` si el interruptor está en posición **OFF**. Aparece en la pestaña *Comportamiento* en la ventana de *Propiedades* de Visual Studio.
- **Colored** : Propiedad de tipo `bool`. Determina si el control muestra los colores `BackgroundON` y `BackgroundOFF` o solamente un fondo gris. Aparece en la pestaña *Apariencia* en la ventana de *Propiedades* de Visual Studio.

![image](https://user-images.githubusercontent.com/63002560/110315053-fb59eb80-8008-11eb-97f8-94ea7bd3cfed.png)
- **BackgrounON** : Propiedad de tipo `Color`. Establece el color del fondo cuando el estado es **'ON'** `(IsON = true)` y la propiedad `Colored` es `true`. Aparece en la pestaña *Apariencia* en la ventana de *Propiedades* de Visual Studio.
- **BackgroundOFF** : Propiedad de tipo `Color`. Establece el color del fondo cuando el estado es **'OFF'** `(IsON = false)` y la propiedad `Colored` es `true`. Aparece en la pestaña *Apariencia* en la ventana de *Propiedades* de Visual Studio.
- **ShowLabels** : Propiedad de tipo `bool`. Determina si el control muestra los caracteres '1' y '0' indicando el estado del control.  Aparece en la pestaña Apariencia en la ventana de Propiedades de Visual Studio.
LabelColor : Propiedad de tipo Color. Establece el color de las etiqueta '1' y '0' visibles si ShowLabels es 'true'. ![image](https://user-images.githubusercontent.com/63002560/110315841-1f69fc80-800a-11eb-9d7a-d3050d9de9ff.png)
 Aparece en la pestaña *Apariencia* en la ventana de *Propiedades* de Visual Studio.
 
#### Eventos ⚡

- *IsONChanged* : Se produce cuando el Switch cambia de estado ON/OFF. El evento es invocado cuando la propiedad IsON cambia su valor

### Led ![image](https://user-images.githubusercontent.com/63002560/110315982-5809d600-800a-11eb-96a1-06c7784f74f5.png)

image![image](https://user-images.githubusercontent.com/63002560/110316003-5f30e400-800a-11eb-927b-2e6d57cc581c.png)


Simula un **diodo LED** de los que se utilizan como pilotos. Se puede cambiar el color cuando está encendido y cuando está apagado y puede ser redondo o rectangular. Hereda sus propiedades, métodos y eventos de la clase `UserControl` y ademas implementa los siguientes:

#### Propiedades 📐

- **IsON** : Propiedad de tipo `bool`. Estado del LED **encendido** `(IsON = true)` o **apagado** `(IsON = False)`. Aparece en la pestaña *Comportamiento* en la ventana de *Propiedades* de Visual Studio.
- **Appearance** : Propiedad de tipo `Appearances` que puede tomar los valores `Round` o `Square`. Establece la 'forma' del control: redondo o cuadrado. Aparece en la pestaña *Apariencia* en la ventana de *Propiedades* de Visual Studio.
- **LedColorON** : Propiedad de tipo `Color`. Establece el color del Led cuando el estado es *Encendido* `(IsON = true)`. Aparece en la pestaña *Apariencia* en la ventana de *Propiedades* de Visual Studio.
- **LedColorOFF** : Propiedad de tipo `Color`. Establece el color del Led cuando el estado es *Apagado* `(IsON = false)`. Aparece en la pestaña *Apariencia* en la ventana de *Propiedades* de Visual Studio.

## Instalación 🔌

Por el momento esta extensión aunque está empaquetada en un archivo .vsix no está disponible en ***Visual Studio Marketplace***.

El cuadro de diálogo `Extensiones > Administrar extensiones` no puede detectar este archivo, pero se puede instalar el archivo .vsix si se hace doble clic en él o si se selecciona y se presiona ENTRAR. Después de eso, solo tiene que seguir las instrucciones.

Una vez instalada la extensión, puede usar el cuadro de diálogo Administrar extensiones para habilitarla, deshabilitarla o desinstalarla.

El proceso sería:

1. Descargar el archivo `VSIXControls.vsix` del último release de mi repositorio de GitHub. [Descragar última versión](https://github.com/cxrc/VSIXControls/releases/latest)
2. Situarse en el archivo en nuestro PC y hacer **doble click** en él. (o seleccionarlo y pulsar ENTRAR)
3. Seguir las instrucciones que aparecen en pantalla.

## Desinstalación ❌

Si desea dejar de usar la extensión, puede deshabilitarla o desinstalarla.

Al deshabilitar una extensión esta sigue instalada pero está descargada.

1. En Visual Studio abra `Extensiones > Administrar extensiones`
2. En *Instaladas* busque la extensión **VSIXControls**.
3. Haga clic *Desinstalar* o *Deshabilitar*.
4. Reinicie Visual Studio.

## Construido con 🛠️

[Microsoft Visual Studio Community 2019](https://visualstudio.microsoft.com/es/vs/community/)

Fuente escrita en C#

## Wiki 📖
Puedes encontrar mucho más de cómo utilizar este proyecto en nuestra [Wiki](https://github.com/cxrc/VSIXControls/wiki)

## Autor ✒️

Rafael Carballo Vázquez - [cxrc](https://github.com/cxrc)

## Licencia 📄

Este proyecto es software libre. Está permitido usarlo, copiarlo, modificarlo, etc. - mira el archivo LICENSE.md para detalles

---
