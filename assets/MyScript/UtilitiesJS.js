/// <reference path="../angular/angular.js/angular.js" />

var apps = angular.module("MyApp", []);
apps.controller("SendEmailController", function ($scope, $http) {
    $scope.credential = {
        fullName: '',
        clientEmail: '',
        comment: '',
        sysAdminEmail: 'rayaduboat@yahoo.com'
    }
    //constructor
    $scope.$onInit = () => {

    }
    $scope.SendEmail = () => {
        $http.post("http://localhost:64567/api/email/sendemail", $scope.credential)//====Localhost for testing   
       //$http.post("http://rayaduboat-001-site7.itempurl.com/api/email/sendemail", $scope.credential)  //Production on live server--info@iprosystem.co.uk --louiseabrown1@gmail.com
            .then(function (response) {
                return response.json();
            }).then(response => {
                $scope.response = response;
            })
        //alert("Jack where are you");
    }
});
//function SendEmail() {
//    //alert("Jack where are you"); http://rayaduboat-001-site7.itempurl.com/
//}