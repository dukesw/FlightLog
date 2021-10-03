// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false, 
  apiUrl: "https://localhost:5002/", 
  identityServerAuthority: "https://localhost:5001/",
  identityServerRedirectUri: "http://localhost:4200/auth-callback", 
  identityServerPostLogoutRedirectUri: "http://localhost:4200/",
  silentRedirectUri: "http://localhost:4200/silent-refresh.html",
  auth0Domain: "dev-flightlog.au.auth0.com", 
  auth0ClientId: "K4yvPKBlTCzvhmVSsjPiZCEIGBGbDr8n", 
  auth0RedirectUri: window.location.origin, 
  auth0Scope: 'openid profile email'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
