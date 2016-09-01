var myApp = angular.module('myModule', []);


//myApp.controller("myController", myController);
//myApp.$inject = ["$scope"];
//myApp.controller("schoolController", schoolController);



//declare
myApp.controller("SchoolController", function($scope) {
    $scope.thongDiep = "thong bao tu truong";
});

myApp.controller("TeacherController", function ($scope) {
    $scope.thongDiep = "Thong diep den giao vien";
});

myApp.controller("StudentController", function ($scope) {
    //$scope.thongDiep = "thong diep student Controller";
});
