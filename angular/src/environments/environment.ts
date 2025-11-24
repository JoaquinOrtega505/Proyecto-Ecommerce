export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200',
    name: 'Ecommerce'
  },
  oAuthConfig: {
    issuer: 'http://localhost:44300',
    redirectUri: 'http://localhost:4200',
    clientId: 'Ecommerce_App',
    responseType: 'code',
    scope: 'offline_access Ecommerce',
    requireHttps: false
  },
  apis: {
    default: {
      url: 'http://localhost:44300',
      rootNamespace: 'Ecommerce'
    }
  }
};
