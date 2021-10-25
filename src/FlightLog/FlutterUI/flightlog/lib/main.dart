import 'package:flutter/material.dart';
import 'package:flutter_appauth/flutter_appauth.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:provider/provider.dart';

import 'src/navigation/app_state_controller.dart';
import 'src/users/auth_service.dart';
import 'src/flightlog_app.dart';
import 'src/utils/secure_storage_service.dart';

void main() {
  const FlutterSecureStorage secureStorage = FlutterSecureStorage();
  final SecureStorageService secureStorageService =
      SecureStorageService(secureStorage);

  runApp(MultiProvider(providers: [
    //ChangeNotifierProvider(create: (context) => _flightProvider),
    Provider<FlutterAppAuth>(create: (_) => FlutterAppAuth()),
    ProxyProvider<FlutterAppAuth, AuthService>(
        update: (_, FlutterAppAuth appAuth, __) =>
            AuthService(appAuth, secureStorageService)),
    ChangeNotifierProvider<AppStateController>(
      create: (BuildContext context) => AppStateController(
        Provider.of<AuthService>(context, listen: false),
      ),
    )

    // Provider<AppStateManager>(
    //     create: (_) => AppStateManager(_authService)),
  ], child: const FlightLogApp()));
}
