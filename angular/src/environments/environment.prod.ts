export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200',
    name: 'Ecommerce'
  },
  oAuthConfig: {
    issuer: 'http://backend:80',
    redirectUri: 'http://frontend:80',
    clientId: 'Ecommerce_App',
    responseType: 'code',
    scope: 'offline_access Ecommerce',
    requireHttps: false
  },
  apis: {
    default: {
      url: 'http://backend:80',
      rootNamespace: 'Ecommerce'
    }
  }
};
