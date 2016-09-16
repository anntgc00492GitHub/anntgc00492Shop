(function (app) {
    app.controller('productEditController', productEditController);
    productEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'commonService'];
 
    //Có khoảng cách sau dấu nháy như thến này ' $stateParams' là toi ngay

    function productEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {

        $scope.product = {

        };

        $scope.checkOptions = {
            language: 'vi',
            height: '200px'
        }

        function loadProductDetail() {
            apiService.get('api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        loadProductDetail();

        function loadProductCategories() {
            apiService.get(
                'api/productcategory/getallparents',
                null,
                function (result) {
                    $scope.productCategories = result.data;
                },
                function () {
                    console.log('can not get list parents');
                }
            );
        }
        loadProductCategories();

        $scope.getSeoTitle = function () {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        $scope.chooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.Image = fileUrl;
            }
            finder.popup();
        }

        $scope.updateProduct = updateProduct;
        function updateProduct() {
            apiService.put('api/product/update', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }
    }
})(angular.module('anntgc00492Shop.products'));
