import 'package:flutter/material.dart';
import 'package:flightlog/widgets/common_button.dart';

class StartScreen extends StatefulWidget {
  const StartScreen({Key? key, required this.title}) : super(key: key);

  // This widget is the home page of your application. It is stateful, meaning
  // that it has a State object (defined below) that contains fields that affect
  // how it looks.

  // This class is the configuration for the state. It holds the values (in this
  // case the title) provided by the parent (in this case the App widget) and
  // used by the build method of the State. Fields in a Widget subclass are
  // always marked "final".

  final String title;

  @override
  State<StartScreen> createState() => _StartScreenState();
}

class _StartScreenState extends State<StartScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: SafeArea(
        child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceAround,
            children: <Widget>[
              Text('Welcome to ${widget.title}',
                  style: Theme.of(context).textTheme.bodyText1,
                  textAlign: TextAlign.center),
              // Could also use the SVG here...
              Image.asset('assets/flightlog_logo.png'),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
                  CommonButton(
                    onPressed: () {
                      // Goto the main page
                    },
                    text: 'Login',
                  )
                ],
              )
            ]),
      ),
    );
  }
}
