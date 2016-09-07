(function (app) {
    app.controller("productCategoryAddController", productCategoryAddController);
    productCategoryAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state'];

    function productCategoryAddController($scope, apiService, notificationService, $state) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
            Name: "Ten"
        }


        $scope.parentCategories = [];
        function loadParentCategory() {
            apiService.get('/api/productCategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log("can not get list parent");
            });
        }
        loadParentCategory();

        $scope.addProductCategory=addProductCategory;
        function addProductCategory() {
            apiService.post('/api/productCategory/create', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + "đã được thêm mới");
                    $state.go('product_categories');
                },
                 function (error) {
                     notificationService.displayError("thêm mới không thành công");
                 }
            );
        }

    }
})(angular.module('anntgc00492Shop.product_categories'));