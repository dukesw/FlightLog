import 'dart:async';
// import 'dart:html';
import '../users/auth_service.dart';
import 'package:flutter/material.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/services.dart';

// The tabs in the app
class FlightLogTab {
  static const int flights = 0;
  static const int models = 1;
}

class AppStateController extends ChangeNotifier {
  bool _initialised = true;
  bool _signingIn = false;
  bool _loggedIn = false;
  bool _viewingProfile = false;
  int _selectedTab = FlightLogTab.flights;

  bool get isInitialised => _initialised;
  bool get isSigningIn => _signingIn;
  bool get isLoggedIn => _loggedIn;
  bool get viewingProfile => _viewingProfile;
  int get getSelectedTab => _selectedTab;

  final AuthService authService;
  AppStateController(this.authService);

  void initialiseApp() {
    // Example wraps this in a timer,...
    WidgetsBinding.instance!.addPostFrameCallback((timestamp) {
      _initialised = true;
      notifyListeners();
    });
  }

  void openProfile() {
    _viewingProfile = true;
    notifyListeners();
  }

  void closeProfile() {
    _viewingProfile = false;
    notifyListeners();
  }

  Future<void> login() async {
    try {
      //authService.logout(); // For testing
      _signingIn = true;
      notifyListeners();
      var accessToken = await authService.getValidAccessToken();
      if (accessToken == null) {
        notifyListeners();
        await authService.authorise();
        _loggedIn = true;
      } else {
        _loggedIn = true;
      }
      notifyListeners();
    } on PlatformException {
      // User failed to login or cancelled.
      _loggedIn = false;
      notifyListeners();
    } finally {
      _signingIn = false;
      notifyListeners();
    }
  }

  Future<void> logout() async {
    _loggedIn = false;
    _viewingProfile = false;
    _selectedTab = FlightLogTab.flights;
    await authService.logout();
    notifyListeners();
  }

  void goToTab(index) {
    _selectedTab = index;
    notifyListeners();
  }
}
