import 'package:flutter_secure_storage/flutter_secure_storage.dart';

import 'constants.dart';

class SecureStorageService {
  final FlutterSecureStorage flutterSecureStorage;
  SecureStorageService(this.flutterSecureStorage);

  Future<String?> getAccessToken() {
    return flutterSecureStorage.read(key: ACCESS_TOKEN_KEY);
  }

  Future<String?> getIdToken() {
    return flutterSecureStorage.read(key: ID_TOKEN_KEY);
  }

  Future<void> saveAccessToken(String accessToken) {
    return flutterSecureStorage.write(
        key: ACCESS_TOKEN_KEY, value: accessToken);
  }

  Future<void> saveIdToken(String idToken) {
    return flutterSecureStorage.write(key: ID_TOKEN_KEY, value: idToken);
  }

  Future<DateTime?> getAccessTokenExpirationDateTime() async {
    final String? iso8601ExpirationDate = await flutterSecureStorage.read(
        key: ACCESS_TOKEN_EXPIRATION_DATETIME_KEY);
    if (iso8601ExpirationDate == null) {
      return null;
    }
    return DateTime.parse(iso8601ExpirationDate);
  }

  Future<void> saveAccessTokenExpiresIn(
      DateTime? accessTokenExpirationDateTime) {
    return flutterSecureStorage.write(
        key: ACCESS_TOKEN_EXPIRATION_DATETIME_KEY,
        value: accessTokenExpirationDateTime!.toIso8601String());
  }

  Future<String?> getRefreshToken() {
    return flutterSecureStorage.read(key: REFRESH_TOKEN_KEY);
  }

  Future<void> saveRefreshToken(String? refreshToken) {
    return flutterSecureStorage.write(
        key: REFRESH_TOKEN_KEY, value: refreshToken);
  }

  Future<void> deleteAll() {
    return flutterSecureStorage.deleteAll();
  }
}
