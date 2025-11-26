# Boss Attack Patterns — Technical Explanation

Este documento explica la implementación técnica de los tres patrones de disparo del jefe en el proyecto. Los ataques funcionan mediante una arquitectura modular compuesta por tres elementos principales.  
RadialShotSettings define los parámetros del disparo.  
ShotAttack contiene la lógica matemática que genera las direcciones.  
BossAttackController controla la duración y secuencia de cada ataque.

---

# Patron 1 — Disparo Radial Basico

Este patron dispara balas distribuidas uniformemente alrededor del jefe. El calculo principal consiste en dividir el circulo completo entre el numero de balas usando la expresion angleBetweenBullets = 360f / NumberOfBullets.  
Con este valor se generan direcciones al rotar un vector base mediante una funcion auxiliar que usa una transformacion en el plano.  
Cada direccion produce una bala obtenida del BulletPool y se le asigna la velocidad establecida en la configuracion.  
El ataque se repite durante un tiempo controlado por un coroutine dentro del BossAttackController.  
El resultado final es un circulo de balas que sale simultaneamente en todas direcciones.

---

# Patron 2 — Estrella Rotante

Este patron utiliza la misma logica radial del disparo basico pero alternando dos fases de disparo.  
Una fase dispara de manera normal y la siguiente desplaza las direcciones media separacion angular.  
Este desplazamiento se logra aplicando un offset adicional equivalente a la mitad de angleBetweenBullets.  
La alternancia entre una fase y otra genera lineas de balas que se cruzan y forman una figura en forma de estrella que cambia con cada rafaga.  
El efecto final es un patron dinamico donde las lineas parecen rotar debido a los cambios de fase entre cada disparo.

---

# Patron 3 — Espiral Continua

Este patron no dispara un circulo completo sino un flujo continuo de balas que giran progresivamente.  
En lugar de repartir balas alrededor del circulo se usa un angulo acumulado llamado currentAngle que aumenta de manera constante con cada iteracion.  
La direccion de disparo se calcula convirtiendo ese angulo a radianes y generando un vector mediante funciones trigonometricas.  
Cada bala se dispara individualmente y el angulo sigue aumentando, produciendo una trayectoria en espiral.  
La forma final depende tanto del tiempo como del aumento progresivo del angulo, lo que da un movimiento continuo y fluido.

---

# Diferencias entre los patrones

Cada patron funciona de manera distinta aunque comparten la misma estructura modular.  
El disparo radial genera un circulo completo con todas las balas al mismo tiempo y sin acumulacion angular.  
El patron de estrella alterna entre dos fases para crear intersecciones y huecos que forman una figura geometrica.  
El patron de espiral dispara una sola bala a la vez y acumula angulo continuamente, formando una curva basada en el paso del tiempo.

---

# Ajuste y configuracion desde el inspector

Los tres patrones pueden modificarse directamente desde el inspector de Unity.  
Cada configuracion permite cambiar numero de balas, velocidad, offsets y tipos de variacion angular.  
Esto facilita ajustar cada ataque sin modificar codigo.

---

# Referencias

https://www.youtube.com/watch?v=0cycus0Ojnc  
https://www.youtube.com/watch?v=rVBzTKvoStk  
https://www.youtube.com/watch?v=0cycus0Ojnc  
https://www.youtube.com/watch?v=xrLlZ1mHCTA  
https://www.youtube.com/watch?v=_YgeNG6MtQQ

# Aviso

Este texto fue escrito por AI simplemente para documentar el trabajo de forma rapida y sensilla. Si quieren un documento más extenso de la creacion me pueden contactar. 
