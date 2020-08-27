export const environment = {
  production: true,
  apiUrl: "https://flightlogapi.azurewebsites.net/",
  identityServerAuthority: "https://flightlogis.azurewebsites.net/",
  identityServerRedirectUri: "https://flightlogui.azurewebsites.net/auth-callback", 
  identityServerPostLogoutRedirectUri: "https://flightlogui.azurewebsites.net/",
  silentRedirectUri: "https://flightlogui.azurewebsites.net/silent-refresh.html"
};
