(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);
    productCategoryEditController.$inject = ['$scope', '$state', 'apiService', 'notificationService', '$stateParams'];

    function productCategoryEditController($cope, $state, $stateParams, apiService, notificationService) {

        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }

        function loadProductCategoryDetail() {
            apiService.get(
                '/api/productCategoryController/getbyid/' + $stateParams,
                null,
                function (result) {
                    $scope.productCategory = result.data;
                },
                function (error) {
                    notificationService.displayError(error.data);
                }
            );
        }
        loadProductCategoryDetail();

        function loadParentCategory() {
            apiService.get(
                'api/productCategoryController/getallparents',
                null,
                function(result) {
                    $scope.productCategory = result.data;
                },
                function() {
                    console.log('can not get list parent');
                }
            );
        }
        loadParentCategory();


        function getSeoTitle() {

        }
        $scope.getSeoTitle = getSeoTitle;

        function updateProductCategory() {

        }
        $scope.updateProductCategory = updateProductCategory;

    }

})(angular.module('anntgc00492Shop.product_categories'));