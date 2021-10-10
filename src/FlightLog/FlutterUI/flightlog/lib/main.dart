import 'package:flutter/material.dart';
import 'package:flightlog/screens/start_screen.dart';


void main() {
  runApp(const FlightLogApp());
}

class FlightLogApp extends StatelessWidget {
  const FlightLogApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    const String appTitle = "Flight Log";

    return MaterialApp(
      title: appTitle,
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: const StartScreen(title: appTitle),
    );
  }
}
