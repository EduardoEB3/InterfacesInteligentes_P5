# InterfacesInteligentes_P5

## Componentes de la escena principal
- Para la realización de esta práctica, he creado una escena que contiene los siguientes objetos:
  -  Un cubo el cual representa un controlador y se puede mover con las letras **aswd**.
  -  Un cilindro de color rosa que permite activar el reconocedor de palabras al colisionar con él.
  -  Un cilindro de color naranja que permite activar el dictado al colisionar con él.
  -  Un Ethan que representa a un jugador de fútbol.

## Imagen de la escena principal
![Imagen](https://github.com/EduardoEB3/InterfacesInteligentes_P5/blob/main/image/Escena.jpg)

## Ejemplo del funcionamiento
![GIF](https://github.com/EduardoEB3/InterfacesInteligentes_P5/blob/main/GIF/Ejecuci%C3%B3n.gif)

## Explicación del código
  - **Reconocedor:**
    - La implementación del reconocedor, podemos encontrarla en el fichero **Capturar.cs**, en el cual he implementado un método **MicrosDisponibles()** que me muestra los micrófonos disponibles, además, al colisionar con el objeto **Jugador** por primera vez, éste permite activar el reconocedor y al colisionar por segunda vez, éste permite detenerlo. Para poder llevar a cabo esto, el dictado debe estar desactivado. Una vez activado, muestra la información de las palabras reconocidas y en caso de coincidir con las palabras claves Atacar, Defender, Girar, Izquierda, Derecha o Gol, este produce un evento sobre Ethan.
  - **Dictado:**
    - La implementación del dictado, podemos encontrarla en el fichero **Dictado.cs**, en el cual he implementado que al colisionar con el objeto **Jugador** por primera vez, éste permite realizar al dictado y al colisionar por segunda vez, éste permite detenerlo. Para poder llevar a cabo esto, el reconocedor debe estar desactivado. Una vez activado, cada frase que es dictada, es mostrada en mensaje por pantalla.

## Estructura de directorios
El directorio está organizado de la siguiente manera:
  
      .
      ├── GIF
          ├── Ejecución.gif
      ├── image
          ├── Escena.jpg
      ├── scripts
          ├── Capturar.cs
          ├── Controlador.cs
          ├── Dictado.cs
          ├── Jugador.cs
          
**Realizado por:** *Eduardo Expósito Barrera*

**Correo institucional:** alu0101230382@ull.edu.es
