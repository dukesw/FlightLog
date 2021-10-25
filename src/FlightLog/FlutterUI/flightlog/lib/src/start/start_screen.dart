import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../widgets/common_button.dart';
import '../navigation/flightlog_pages.dart';
import '../navigation/app_state_controller.dart';

class StartScreen extends StatefulWidget {
  const StartScreen({Key? key}) : super(key: key);

  static MaterialPage page() {
    return MaterialPage(
      name: FlightLogPages.startPagePath,
      key: ValueKey(FlightLogPages.startPagePath),
      child: const StartScreen(),
    );
  }

  //final String title;

  @override
  State<StartScreen> createState() => _StartScreenState();
}

class _StartScreenState extends State<StartScreen> {
  // May need to be refactored later
  bool isBusy = false;
  bool isLoggedIn = false;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    Provider.of<AppStateController>(context, listen: false).initialiseApp();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      // appBar: AppBar(
      //   title: Text(widget.title),
      // ),
      body: Center(
        child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceAround,
            children: <Widget>[
              Text('Welcome to Flight Log.', //). ..${widget.title}',
                  style: Theme.of(context).textTheme.bodyText1,
                  textAlign: TextAlign.center),
              // Could also use the SVG here...
              Image.asset('assets/flightlog_logo.png'),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
                  ElevatedButton(
                      onPressed: () {
                        Provider.of<AppStateController>(context, listen: false)
                            .login();
                      },
                      child: const Text('Login'))
                  // CommonButton(
                  //   onPressed: () {

                  //   },
                  //   text: 'Login',
                ],
              )
            ]),
      ),
    );
  }
}
