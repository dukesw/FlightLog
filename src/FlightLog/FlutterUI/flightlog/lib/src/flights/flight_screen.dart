import 'package:flightlog/src/navigation/app_state_controller.dart';
import 'package:flightlog/src/users/user.dart';
import 'package:provider/provider.dart';
import 'package:flutter/material.dart';

import '../utils/constants.dart';
import '../navigation/flightlog_pages.dart';
import '../users/auth_service.dart';

class FlightScreen extends StatefulWidget {
  const FlightScreen(
      {Key? key, required this.appStateController, int? currentTab})
      : super(key: key);
  final AppStateController appStateController;

  static MaterialPage page(
      AppStateController appStateController, int currentTab) {
    return MaterialPage(
      name: FlightLogPages.homePagePath,
      key: ValueKey(FlightLogPages.homePagePath),
      child: FlightScreen(
          appStateController: appStateController, currentTab: currentTab),
    );
  }

  @override
  State<FlightScreen> createState() => _FlightScreenState(appStateController);
}

class _FlightScreenState extends State<FlightScreen> {
  // Setup the AuthService - so can get login details
  final AppStateController appStateController;
  _FlightScreenState(this.appStateController);

  late Future<String?> _idToken;
  late User _user;

  @override
  void initState() {
    super.initState();
    _idToken = appStateController.authService.getValidIdToken();
    //_user = appStateController.authService.getUserDetails(_idToken);
  }

  void _logout() {
    appStateController.logout();
  }

  void _openProfile() {
    appStateController.openProfile();
  }

  @override
  Widget build(BuildContext context) {
    // final idToken = await appStateController.authService.getValidIdToken();
    // final user = Provider.of<AuthService>(context, listen: false).getUserDetails(idToken);
    return Scaffold(
      appBar: AppBar(
        title: const Text(APP_TITLE),
        centerTitle: true,
        automaticallyImplyLeading: false,
        actions: [
          IconButton(
              onPressed: _openProfile,
              tooltip: 'Open Profile',
              icon: const Icon(Icons.account_circle_rounded)),
        ],
      ),
      body: Padding(
        padding: const EdgeInsets.all(8),
        child: SafeArea(
          child: Column(
              mainAxisAlignment: MainAxisAlignment.start,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: const <Widget>[
                Text('Latest flights will be here...'),
                Text('An add button somethere too...')
              ]),
        ),
      ),
    );
  }
}
