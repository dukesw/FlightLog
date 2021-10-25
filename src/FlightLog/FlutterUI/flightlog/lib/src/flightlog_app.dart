import 'package:flightlog/src/utils/constants.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import 'navigation/app_state_controller.dart';
import 'navigation/app_router.dart';

class FlightLogApp extends StatefulWidget {
  const FlightLogApp({Key? key}) : super(key: key);

  @override
  State<StatefulWidget> createState() => _FlightLogAppState();
}

class _FlightLogAppState extends State<FlightLogApp> {
  // final _flightProvider = FlightProvider(); still TODO

  // final FlutterAppAuth appAuth = FlutterAppAuth();
  // const FlutterSecureStorage flutterSecureStorage = FlutterSecureStorage();
  // const SecureStorageService secureStorageService =
  //     SecureStorageService(flutterSecureStorage);

// // //   const AuthService
// // //       authService; // = AuthService(appAuth, secureStorageService);

  late AppRouter _appRouter;
  late AppStateController _appStateController;

// // //   //_FlightLogAppState();

// // //   // _appStateManager = AppStateManager(authService);

// // // final FlutterSecureStorage secureStorageService = FlutterSecureStorage();

  @override
  void initState() {
    super.initState();
    _appStateController =
        Provider.of<AppStateController>(context, listen: false);
    _appRouter = AppRouter(appStateManager: _appStateController);
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: APP_TITLE,
      home: Router(
          routerDelegate: _appRouter,
          backButtonDispatcher: RootBackButtonDispatcher()),
    );
  }
}
