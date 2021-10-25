import 'package:flightlog/src/navigation/flightlog_pages.dart';
import 'package:flutter/material.dart';

import 'app_state_controller.dart';
import '../start/start_screen.dart';
import '../flights/flight_screen.dart';
import '../users/profile_screen.dart';

// 1
class AppRouter extends RouterDelegate
    with ChangeNotifier, PopNavigatorRouterDelegateMixin {
  @override
  final GlobalKey<NavigatorState> navigatorKey;

  final AppStateController appStateManager;

  AppRouter({
    required this.appStateManager,
    // TODO all providers to listen to later...
  }) : navigatorKey = GlobalKey<NavigatorState>() {
    appStateManager.addListener(notifyListeners);
  }

  @override
  void dispose() {
    appStateManager.removeListener(notifyListeners);
    super.dispose();
  }

  // 6
  @override
  Widget build(BuildContext context) {
    // 7
    return Navigator(
      key: navigatorKey,
      onPopPage: _handlePopPage,
      pages: [
        if (appStateManager.isInitialised) StartScreen.page(),
        if (appStateManager.isLoggedIn)
          FlightScreen.page(appStateManager, FlightLogTab.flights),
        if (appStateManager.viewingProfile) ProfileScreen.page(appStateManager),
        // TODO: Add SplashScreen
        // TODO: Add LoginScreen
        // TODO: Add OnboardingScreen
        // TODO: Add Home
        // TODO: Create new item
        // TODO: Select GroceryItemScreen
        // TODO: Add Profile Screen
        // TODO: Add WebView Screen
      ],
    );
  }

  bool _handlePopPage(Route<dynamic> route, result) {
    if (!route.didPop(result)) {
      return false;
    }

    if (route.settings.name == FlightLogPages.profilePagePath) {
      appStateManager.closeProfile();
    }
    // 5
    // TODO: Handle Onboarding and splash
    // TODO: Handle state when user closes grocery item screen
    // TODO: Handle state when user closes profile screen
    // TODO: Handle state when user closes WebView screen
    // 6
    return true;
  }

  // 10
  @override
  Future<void> setNewRoutePath(configuration) async => null;
}
