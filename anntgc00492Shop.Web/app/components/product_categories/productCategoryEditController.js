(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);
    productCategoryEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'commonService'];

    function productCategoryEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {

        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }

        function loadProductCategoryDetail() {
            apiService.get(
                'api/productCategory/getbyid/' + $stateParams.id,
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
                'api/productCategory/getallparents',
                null,
                function (result) {
                    $scope.parentCategories = result.data;
                },
                function (error) {
                    console.log('can not get list parent');
                }
            );
        }
        loadParentCategory();


        function getSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }
        $scope.getSeoTitle = getSeoTitle;

        function updateProductCategory() {
            apiService.put(
                'api/productcategory/update',
                $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('product_categories');
                },
                function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                }
            );
        }
        $scope.updateProductCategory = updateProductCategory;
    }
})(angular.module('anntgc00492Shop.product_categories'));