# VSIXControls

[Ver la versión en español de este archivo](README.md)

_User Controls for Windows Forms in Visual Studio_

![preview](Switch200x200.png)

----

## Description 👀

In this project a series of `user controls` are created as an extension of the Microsoft `Visual Studio` IDE. The installation of the controls is done easily and can be used in any `Windows Forms` desktop project.

The project is open source and is distributed as free software, so anyone can use the controls in their projects and / or modify them. 

In current version, two controls have been implemented:
> - **Switch**: A control with the appearance of a switch with two states (On and off)
> - **LED**: An indicator simulating a led pilot also with two states (On and off) 

## Controls :round_pushpin:

### Switch ![Switch](Switch16x16.bmp)

![image](https://user-images.githubusercontent.com/63002560/110090098-30f79e00-7d97-11eb-9f9d-dafe5d18aafe.png)

Simulates a microswitch. In current version it has the appearance of a slide-type microswitch with a square lever. It inherits its properties, methods and events from the *`UserControl`* class and also implements the following: 

> ####Properties :triangular_ruler:

- **IsON** : *'bool'* type property. Sets or returns the status of the control, *`true`* if the switch is ON or *`false`* if the switch is OFF. It appears on the *Behavior* tab in the Visual Studio *Properties window*. 
- **Colored**: *`bool`* type property. Determines if the control displays the colors 'BackgroundON' and 'BackgroundOFF' or just a gray background. ![image](https://user-images.githubusercontent.com/63002560/110089894-f2fa7a00-7d96-11eb-8004-a9242473083b.png)
It appears on the *Appearance* tab in the Visual Studio *Properties window*.
- **BackgrounON**: *`Color`* type property. Sets the background color when the state is 'ON' (IsON = true) and the *`Colored`* property is 'true'. It appears on the *Appearance* tab in the Visual Studio *Properties window*.
- **BackgroundOFF**: *`Color`* type propety. Sets the background color when the state is 'OFF' (IsON = false) and the *`Colored`* property is 'true'. It appears on the *Appearance* tab in the Visual Studio *Properties window*.
- **ShowLabels**: *`bool`* type property. Determines if the control displays the characters '1' and '0' indicating the status of the control. ![image](https://user-images.githubusercontent.com/63002560/110089474-76679b80-7d96-11eb-9bb7-19872048e628.png) Appears in the *Appearance* tab in the *Properties window* of Visual Studio .
- **LabelColor**: *`Color`* property. Sets the color of the visible labels '1' and '0' if ShowLabels is 'true'. It appears on the *Appearance* tab in the Visual Studio *Properties window*.

> #### Events :zap:

- **IsONChanged**: Occurs when the Switch changes its ON / OFF state. The event is invoked when the *`IsON`* property changes its value 

## Led ![LED](Led16x16.bmp)

![image](https://user-images.githubusercontent.com/63002560/110090455-9b104300-7d97-11eb-8e06-95eaef4a12a2.png)

It simulates an LED diode of the kind used as pilots. The color can be changed when it is on and when it is off and it can be round or rectangular. It inherits its properties, methods and events from the *`UserControl`* class and also implements the following:

> #### Properties: triangular_ruler: 

- **IsON**: *`bool`* type property. LED status on (IsON = true) or off (IsON = False). It appears on the *Behavior* tab in the Visual Studio *Properties window*.
- **Appearance**: *`Appearances`* type propety that can take the values *`Round`* or *`Square`*. Sets the 'shape' of the control: round or square. It appears on the *Appearance* tab in the Visual Studio *Properties window*.
- **LedColorON**: *`Color`* type property. Sets the color of the Led when the status is 'On' (IsON = true). It appears on the *Appearance* tab in the Visual Studio *Properties window*.
- **LedColorOFF**: *`Color`* type property. Sets the color of the Led when the status is 'Off' (IsON = false). It appears on the *Appearance* tab in the Visual Studio *Properties window*. 

### Instalation :electric_plug:

This extension is published on ***Visual Studio Marketplace***.
There are several ways to install this extension:

#### - With Extension Manager

> 1. Enter Visual Studio IDE
> 2. Open the *`Extensions manager`* dialog using the *`Extensions> Manage extensions`* menu.
> 3. In the dialog *`Extension manager`* search for the extension, for example by putting in the search box *VSIXControls*
> 4. Press the *`Install`* button.
> 5. Restart Visual Studio IDE.

#### - No Extension Manager

You can also install the .vsix file by **double clicking** or selecting and pressing ENTER. After that, you just have to follow the instructions.
After the extension is installed, you can use the Manage Extensions dialog to enable, disable, or uninstall it.

The process would be:

> 1. Download the file ***`VSIXControls.vsix`*** of the latest release from my [GitHub repository](https://github.com/cxrc/VSIXControls/releases/latest) or from the [Visual Studio Marketplace website ](https://marketplace.visualstudio.com/items?itemName=RafaelCarballoVazquez.VSIXControls)
> 2. Go to the file on your PC and make **double click** on it (or select it and press ENTER)
> 3. Follow the instructions on the screen. 

### Desinstalation :x:

If you want to stop using the extension, you can disable or uninstall it.
When disabling an extension, it remains installed but is downloaded.

> 1. In Visual Studio open *`Extensions> Manage Extensions`*
> 2. Under *`Installed`* search the **VSIXControls** extension.
> 3. Click *`Uninstall`* or *`Disable`*.
> 4. Restart Visual Studio.

## Buid with 🛠️

* [Microsoft Visual Studio Community 2019](https://visualstudio.microsoft.com/es/vs/community/)
* Source writed in ***C#***

## Wiki 📖

You can find much more about how to use this project in our [Wiki](https://github.com/cxrc/VSIXControls/wiki)

## Autor ✒️

* **Rafael Carballo Vázquez** - [cxrc](https://github.com/cxrc)

## Licencia 📄

This project is free software. It is allowed to use it, copy it, modify it, etc. - see the [LICENSE.md](LICENSE) file for details 

---
