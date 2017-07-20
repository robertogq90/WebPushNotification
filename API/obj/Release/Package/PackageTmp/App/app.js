var app = angular.module('App', ['ngRoute']);


app.config(['$compileProvider', function ($compileProvider) {
	$compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|ftp|mailto|tel|file|blob):/);
}]);

app.config(['$locationProvider', function ($locationProvider) {
	$locationProvider.hashPrefix('');
}]);

app.config(['$routeProvider', function ($routeProvider) {


	$routeProvider

        .when('/404', {
        	templateUrl: '../../app/Views/Security/not_found.html'
        })

        .otherwise({
        	redirectTo: '/404'
        })

        .when('/home', {
        	templateUrl: '../../App/Views/Home/index.html',
        	controller: 'HomeController as ctrl'
        })

        .when('/', {
        	templateUrl: '../../App/Views/Home/index.html',
        	controller: 'HomeController as ctrl'
        });
}]);

app.controller('MainController', ['$scope', function ($scope) {

	var ctrl = this;

	var OneSignal = window.OneSignal || [];
	OneSignal.push(["init", {
		appId: "7f1fcfae-1a53-409f-af06-9175d8e8716e",
		subdomainName: "https://wpntest01.os.tc",
		autoRegister: false, /* Set to true to automatically prompt visitors */
		httpPermissionRequest: {
			enable: true
		},
		notifyButton: {
			enable: true /* Set to false to hide */
		}
	}]);

	OneSignal.push(function () {
	    /* These examples are all valid */
	    var isPushSupported = OneSignal.isPushNotificationsSupported();
	    if (isPushSupported) {
	        // Push notifications are supported
	    } else {
	        alert("No soporta notificaciones");
	    }
	});

	OneSignal.push(function () {

		OneSignal.on('notificationDisplay', function (event) {
			alert(JSON.stringify(event));
			// This callback fires every time the event occurs
		});

	});

	


}]);