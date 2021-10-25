import 'package:flightlog/src/navigation/app_state_controller.dart';
import 'package:flightlog/src/users/user.dart';
import 'package:provider/provider.dart';
import 'package:flutter/material.dart';

import '../utils/constants.dart';
import '../navigation/flightlog_pages.dart';
import '../users/auth_service.dart';

class ProfileScreen extends StatefulWidget {
  const ProfileScreen(
      {Key? key, required this.appStateController, int? currentTab})
      : super(key: key);
  final AppStateController appStateController;

  static MaterialPage page(AppStateController appStateController) {
    return MaterialPage(
      name: FlightLogPages.profilePagePath,
      key: ValueKey(FlightLogPages.profilePagePath),
      child: ProfileScreen(appStateController: appStateController),
    );
  }

  @override
  State<ProfileScreen> createState() => _ProfileScreenState(appStateController);
}

class _ProfileScreenState extends State<ProfileScreen> {
  // Setup the AuthService - so can get login details
  final AppStateController appStateController;
  _ProfileScreenState(this.appStateController);

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
        title: const Text('Profile'),
        centerTitle: true,
        //automaticallyImplyLeading: false,
      ),
      body: SafeArea(
        child: Column(
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              FutureBuilder<String?>(
                  future: _idToken,
                  builder:
                      (BuildContext context, AsyncSnapshot<String?> snapshot) {
                    if (snapshot.hasData) {
                      var user = appStateController.authService
                          .getUserDetails(snapshot.data);
                      return Text(
                          'Name: ${user.name}, Account: ${user.accountId}');

                      // Text('This is the main screen',
                      //   style: Theme.of(context).textTheme.bodyText1,
                      //   textAlign: TextAlign.start),

                    } else {
                      return const Text('Loading user...');
                    }
                  }),
              // Text('This is the main screen',
              //     style: Theme.of(context).textTheme.bodyText1,
              //     textAlign: TextAlign.start),
              //   Text(${Provider.of<AuthService>().})
              ElevatedButton(onPressed: _logout, child: const Text('Logout'))
            ]),
      ),
    );
  }
}
