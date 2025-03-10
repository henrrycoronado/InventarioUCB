const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:39364';

const PROXY_CONFIG = [
  {
    context: [
      "/gestionarsolicitudes",
      "/solicitudprestamo",
      "/Prestamo",
      "/categoria",
      "/componente",
      "/equipo",
      "/usuario",
      "/weatherforecast",
   ],
    proxyTimeout: 10000,
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
