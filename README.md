<div align="center">

# VideoFetcher Web API
![VisionAuditiva Logo](https://visionauditiva.azurewebsites.net/Image/logo2)

</div>


API.VideoFetcher es una API web desarrollada con .NET 7 que te permite obtener información de videos y descargar flujos de video y audio de YouTube. Utiliza la biblioteca [YoutubeExplode](https://github.com/Tyrrrz/YoutubeExplode) para interactuar con la API de YouTube.

La documentación de la API se encuentra en [https://apivideofetcher.azurewebsites.net/swagger/index.html](https://apivideofetcher.azurewebsites.net/swagger/index.html) utilizando Swagger.

## Requisitos previos

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)

## Instalación

1. Clona el repositorio: `git clone https://github.com/xstefano/API.VideoFetcher.git`
2. Navega al directorio del proyecto: `cd API.VideoFetcher`
3. Compila el proyecto: `dotnet build`
4. Ejecuta el proyecto: `dotnet run`
5. La API estará accesible en `https://localhost:5001` de manera predeterminada.

## Endpoints

La API proporciona los siguientes endpoints:

### YoutubeController

- `GET /api/youtube/getvideo/videoUrl={videoUrl}`: Obtiene información del video basada en la URL del video de YouTube proporcionada.

- `GET /api/youtube/urlvideo/videoUrl={videoUrl}`: Obtiene la mejor URL para transmitir el video basada en la URL del video de YouTube proporcionada.

- `GET /api/youtube/getcontainer/videoUrl={videoUrl}`: Obtiene los flujos de video disponibles (contenedores) para la URL del video de YouTube proporcionada.

- `GET /api/youtube/getcontainerm4a/videoUrl={videoUrl}`: Obtiene los flujos de audio disponibles (contenedores M4A) para la URL del video de YouTube proporcionada.

- `GET /api/youtube/stream/videoUrl={videoUrl}/quality={quality}`: Descarga el flujo de video de la calidad especificada como un archivo MP4.

- `GET /api/youtube/streamm4a/videoUrl={videoUrl}/bytes={bytes}`: Descarga el flujo de audio del tamaño especificado en bytes como un archivo M4A.

## Contribución

Si deseas contribuir a este proyecto, sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una nueva rama para tu contribución: `git checkout -b nombre-de-tu-rama`.
3. Realiza los cambios y mejoras necesarias.
4. Realiza un commit de tus cambios: `git commit -m "Descripción de los cambios"`.
5. Envía tus cambios al repositorio remoto: `git push origin nombre-de-tu-rama`.
6. Crea una Pull Request en GitHub describiendo tus cambios.

## Licencia

Este proyecto está licenciado bajo la Licencia GNU v3.0. Consulta el archivo [LICENSE](LICENSE) para obtener más detalles.

## Contacto

Si tienes alguna pregunta o sugerencia, no dudes en contactarme a través de andres.aleg.19@gmail.com

---

© 2023 xstefano | [Enlace al repositorio](https://github.com/xstefano/API.VideoFetcher)
