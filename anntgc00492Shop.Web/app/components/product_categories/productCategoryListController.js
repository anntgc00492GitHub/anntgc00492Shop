(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope', 'apiService'];
    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];
        $scope.getProductCategories = getProductCategories;
        $scope.getProductCategories();
        function getProductCategories() {
            apiService.get('/api/productCategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () { 
                console.log('load product categories failed');
            });
        }
    }
})(angular.module('anntgc00492Shop.products'));