import 'dart:async';
import 'dart:html';
import 'package:flutter/material.dart';

// The tabs in the app
class FlightLogTab {
  static const int flights = 0;
  static const int models = 1;
}

class AppStateManager extends ChangeNotifier {
  bool _initialised = true;
  bool _loggedIn = false;
  int _selectedTab = FlightLogTab.flights;

  bool get isInitialised => _initialised;
  bool get isLoggedIn => _loggedIn;
  int get getSelectedTab => _selectedTab;

  void initialiseApp() {
    // Example wraps this in a timer,...
    _initialised = true;
    notifyListeners();
  }

  void login() {
    // This will need to redirect to Auth0 etc... to add later
    _loggedIn = true;
    notifyListeners();
  }

  void goToTab(index) {
    _selectedTab = index;
    notifyListeners();
  }
}
