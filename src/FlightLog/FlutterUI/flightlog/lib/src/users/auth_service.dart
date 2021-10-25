import 'dart:convert';
import 'dart:developer' as developer;

import 'package:flutter_appauth/flutter_appauth.dart';

import '../utils/constants.dart';
import '../utils/secure_storage_service.dart';
import 'user.dart';

class AuthService {
  final FlutterAppAuth appAuth;
  final SecureStorageService secureStorageService;

  AuthService(this.appAuth, this.secureStorageService);

  Future<void> authorise() async {
    final AuthorizationTokenResponse? response =
        await appAuth.authorizeAndExchangeCode(AuthorizationTokenRequest(
            AUTH0_CLIENT_ID, AUTH0_REDIRECT_URI,
            issuer: AUTH0_ISSUER,
            promptValues: <String>['login'],
            scopes: AUTH0_SCOPES,
            additionalParameters: {'audience': AUTH0_AUDIENCE}));

    developer.log('AccessToken: ${response!.accessToken}',
        name: 'AuthService.authorise()');
    developer.log(
        'AccessTokenExpiration: ${response.accessTokenExpirationDateTime}',
        name: 'AuthService.authorise()');
    developer.log('IdToken: ${response.idToken}',
        name: 'AuthService.authorise()');
    developer.log('RefreshToken: ${response.refreshToken}',
        name: 'AuthService.authorise()');

    await secureStorageService.saveIdToken(response.idToken as String);

    await secureStorageService.saveAccessToken(response.accessToken as String);

    await secureStorageService
        .saveAccessTokenExpiresIn(response.accessTokenExpirationDateTime);

    await secureStorageService.saveRefreshToken(response.refreshToken);
  }

  Future<String?> getValidAccessToken() async {
    final accessToken = await secureStorageService.getAccessToken();

    developer.log('AccessToken: $accessToken',
        name: 'AuthService.getValidAccessToken()');

    if (accessToken == null) {
      return null;
    }

    final DateTime? expirationDate =
        await secureStorageService.getAccessTokenExpirationDateTime();

    developer.log('AccessTokenExpiration: $expirationDate',
        name: 'AuthService.getValidAccessToken()');

    if (DateTime.now()
        .isBefore(expirationDate!.subtract(const Duration(minutes: 1)))) {
      return accessToken;
    }

    return _refreshAccessToken();
  }

  Future<String?> getValidIdToken() async {
    final idToken = await secureStorageService.getIdToken();

    return idToken;
    // TODO refresh where needed based on exp??

    // developer.log('AccessToken: $idToken',
    //     name: 'AuthService.getValidAccessToken()');

    // if (idToken == null) {
    //   return null;
    // }

    // final DateTime? expirationDate =
    //     await secureStorageService.getAccessTokenExpirationDateTime();

    // developer.log('AccessTokenExpiration: $expirationDate',
    //     name: 'AuthService.getValidAccessToken()');

    // if (DateTime.now()
    //     .isBefore(expirationDate!.subtract(const Duration(minutes: 1)))) {
    //   return accessToken;
    // }

    // return _refreshAccessToken();
  }

  Map<String, dynamic> parseIdToken(String idToken) {
    final parts = idToken.split(r'.');
    assert(parts.length == 3);

    return jsonDecode(
        utf8.decode(base64Url.decode(base64Url.normalize(parts[1]))));
  }

  User getUserDetails(String? idToken) {
    var idTokenMap = parseIdToken(idToken!);
    return User(idTokenMap['name'], idTokenMap[ACCOUNT_ID_CLAIM],
        idTokenMap['picture']);
  }

  Future<String?> _refreshAccessToken() async {
    final String? refreshToken = await secureStorageService.getRefreshToken();
    if (refreshToken == null) {
      return null;
    }
    final TokenResponse? response = await appAuth.token(TokenRequest(
        AUTH0_CLIENT_ID, AUTH0_REDIRECT_URI,
        issuer: AUTH0_ISSUER,
        refreshToken: refreshToken,
        scopes: AUTH0_SCOPES));

    developer.log('AccessToken: ${response!.accessToken}',
        name: 'AuthService._refreshAccessToken()');
    developer.log(
        'AccessTokenExpiration: ${response.accessTokenExpirationDateTime}',
        name: 'AuthService._refreshAccessToken()');
    developer.log('IdToken: ${response.idToken}',
        name: 'AuthService._refreshAccessToken()');
    developer.log('RefreshToken: ${response.refreshToken}',
        name: 'AuthService._refreshAccessToken()');

    await secureStorageService.saveAccessToken(response.accessToken as String);

    await secureStorageService.saveAccessTokenExpiresIn(
        response.accessTokenExpirationDateTime as DateTime);

    await secureStorageService
        .saveRefreshToken(response.refreshToken as String);

    return response.accessToken;
  }

  Future<void> logout() {
    return secureStorageService.deleteAll();
  }
}
