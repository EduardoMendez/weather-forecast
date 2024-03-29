## Ejercicio:

En una galaxia lejana, existen tres civilizaciones. Vulcanos, Ferengis y Betasoides. Cada civilización vive en paz en su respectivo planeta.
Dominan la predicción del clima mediante un complejo sistema informático. A continuación el diagrama del sistema solar.

Premisas:
- El planeta Ferengi se desplaza con una velocidad angular de 1 grados/día en sentido horario. Su distancia con respecto al sol es de 500Km.
- El planeta Betasoide se desplaza con una velocidad angular de 3 grados/día en sentido horario. Su distancia con respecto al sol es de 2000Km.
- El planeta Vulcano se desplaza con una velocidad angular de 5 grados/día en sentido anti­horario, su distancia con respecto al sol es de 1000Km.
- Todas las órbitas son circulares.

Cuando los tres planetas están alineados entre sí y a su vez alineados con respecto al sol, el sistema solar experimenta un período de sequía.
Cuando los tres planetas no están alineados, forman entre sí un triángulo. Es sabido que en el momento en el que el sol se encuentra dentro del triángulo, el sistema solar experimenta un período de lluvia, teniendo éste, un pico de intensidad cuando el perímetro del triángulo está en su máximo.
Las condiciones óptimas de presión y temperatura se dan cuando los tres planetas están alineados entre sí pero no están alineados con el sol.

Realizar un programa informático para poder predecir en los próximos 10 años:
1. ¿Cuántos períodos de sequía habrá?
2. ¿Cuántos períodos de lluvia habrá y qué día será el pico máximo de lluvia?
3. ¿Cuántos períodos de condiciones óptimas de presión y temperatura habrá?

Bonus:
Para poder utilizar el sistema como un servicio a las otras civilizaciones, los Vulcanos requieren tener una base de datos con las condiciones meteorológicas de todos los días y brindar una API REST de consulta sobre las condiciones de un día en particular.
- Generar un modelo de datos con las condiciones de todos los días hasta 10 años en adelante utilizando un job para calcularlas.
- Generar una API REST la cual devuelve en formato JSON la condición climática del día consultado.
- Hostear el modelo de datos y la API REST en un cloud computing libre (como APP Engine o Cloudfoudry) y enviar la URL para consulta:
Ej: GET → http://....../clima?dia=566 → Respuesta: {“dia”:566, “clima”:”lluvia”}


## Suposiciones
- El programa empieza en el día 0. La posición inicial de todos los planetas es aquella que forma un ángulo de 0 grados con respecto al eje X.
- La posición del sol es el punto (0,0).
- La duración de un año es de 360 días (que es tiempo que tarda el planeta más lento -Ferengi- en hacer una rotación completa).
- Un "período" es un conjunto de días seguidos con el mismo clima. Un período podría estar formado por 1 solo día.

## Implementación
Este ejercicio se encuentra implementado en C# utilizando .NET Core 3.0 y utiliza EF para el modelo de datos con una base SQL Server.
Para generar la DB de manera local se debe contar con una instancia de SQL Server instalada y se deben correr las migrations, ejecutando en la Package Manager Console el comando 
```Update-Database```
*(verificar que esté seleccionado como proyecto default de la solución, el proyecto "WeatherForecastAPI").*

## Web API
El deploy de esta aplicación fue realizado en Azure (aplicación + DB).

### Uso
Obtener los períodos de cada clima para las próximos 10 años:
https://challenge-weather-forecast-api.azurewebsites.net/weatherforecast/weatherperiods?years=10

Obtener la cantidad total de días por cada clima para las próximos 10 años:
https://challenge-weather-forecast-api.azurewebsites.net/weatherforecast/weatherdays?years=10

Obtener el clima para un cierto día:
https://challenge-weather-forecast-api.azurewebsites.net/weatherforecast/weather?day=29
