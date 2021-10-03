export const environment = {
  production: true,
  apiUrl: "https://flightlogapi.azurewebsites.net/",
  identityServerAuthority: "https://flightlogis.azurewebsites.net/",
  identityServerRedirectUri: "https://flightlogui.azurewebsites.net/auth-callback", 
  identityServerPostLogoutRedirectUri: "https://flightlogui.azurewebsites.net/",
  silentRedirectUri: "https://flightlogui.azurewebsites.net/silent-refresh.html",
  auth0Domain: "dev-flightlog.au.auth0.com", 
  auth0ClientId: "K4yvPKBlTCzvhmVSsjPiZCEIGBGbDr8n", 
  auth0RedirectUri: window.location.origin, 
  auth0Scope: 'openid profile email'
};
