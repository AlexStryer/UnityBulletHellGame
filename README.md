Explicación Técnica
Los disparos de mi jefe se centran en una arquitectura modular con tres elementos claves: RadialShotSettings, ShotAttack, y BossAttackController. Cada ataque usa variaciones de la generación de direcciones y tiempos de disparo para lograr patrones distintos.

Patrón 1 – Disparo Radial Básico
En este patrón se genera un círculo de balas alrededor del jefe, o en el caso de mi juego, la pistola del jefe. 
Calculamos el ángulo con: angleBetweenBullets = 360f / NumberOfBullets
Por cada bala rotamos un vector base(transform.up) usando una extensión que usa Quaternion.
Cada bala se obtiene del BulletPool, se activa y se le asigna una velocidad en la dirección. 
El código principal de este disparo se puede ver aquí:

Se repite 10 veces gracias al coroutine:

Así conseguimos nuestro tiro redondo:


Patrón 2 – Estrella Rotante
El segundo patrón alterna entre dos fases para crear un efecto de estrella. 
El patrón sigue la misma estructura radial que el disparo básico, sin embargo, alterna un offset angular de media separación entre balas.
Un ciclo dispara normal, mientras que el otro dispara con 180 / N grados. 
Esto produce un patrón donde las líneas de balas cruzan, creando la forma de estrella.
La función responsable del disparo se puede ver aquí: 

El patrón generado se ve así: 


Patrón 3 – Espiral Continua
Para este disparo se genera un stream de balas que gira progresivamente. El funcionamiento es de la siguiente manera:
Se mantiene un ángulo acumulado llamado currentAngle.
En cada iteración del ciclo, se calcula una dirección desde ese ángulo:

Se hace un solo disparo en esa dirección.
Después, el ángulo aumenta por angleStep, generando la forma de espiral.
El cooldown lo hice corto para que se vea fluido el efecto. 
Es importante notar que este ataque no utiliza un círculo. 
El patrón se ve de la siguiente manera: 


Por qué cada patrón es diferente
Los tres patrones son mecánicamente distintos, no solo son cambios de velocidad y dirección.

Ataque 1: Círculo básico 
Se disparan todas las balas al mismo tiempo en una distribución uniforme.
No hay movimiento angular acumulado.
No hay alternancia de fases.

Ataque 2: Estrella rotante
Usa el mismo número de balas, pero alterna fases entre disparos/rafagas.
La alteración de las balas crea huecos y líneas entrecruzadas.  

Ataque 3: Espiral
No dispara en círculo, dispara un stream de balas. 
El ángulo nunca reinicia, siempre se acumula.
La geometría del patrón nace del tiempo

Los tres patrones incluso son modificables directamente del Boss:

Referencias/Inspiracion: 
- https://www.youtube.com/watch?v=0cycus0Ojnc
- https://www.youtube.com/watch?v=rVBzTKvoStk
- https://www.youtube.com/watch?v=0cycus0Ojnc
- https://www.youtube.com/watch?v=xrLlZ1mHCTA
- https://www.youtube.com/watch?v=_YgeNG6MtQQ
