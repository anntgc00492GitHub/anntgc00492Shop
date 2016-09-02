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

//////////////////////


myApp.service("KiemTraDuLieuService", KiemTraDuLieuService);
function KiemTraDuLieuService($window) {
    function KiemTraChanLe(nhapVao)
    {
        if (nhapVao % 2 == 0) {
            $window.alert("la so chan");
            return "la so schan";
        } else {
            $window.alert("la so le");
            return " la so le";
        }
    }
    return {
        KiemTraChanLe:KiemTraChanLe
    }
}


myApp.controller("TrinhKiemTra", TrinhKiemTra);
TrinhKiemTra.$inject = ["$scope", "KiemTraDuLieuService"];
function TrinhKiemTra($scope, KiemTraDuLieuService) {
    $scope.giatrinhapvao = 2;
    $scope.clicButtonEvent = function () {
        $scope.ketquakiemtra = KiemTraDuLieuService.KiemTraChanLe($scope.giatrinhapvao);
    }
}

myApp.directive("anntgcShopDirective", anntgcShopDirective);
function anntgcShopDirective() {
    return {
        restrict: "A",
        templateUrl: "/Scripts/spa/anntgc00492ShopDirective.html"
    }
}


