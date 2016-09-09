(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function productCategoryListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProductCategories = getProductCategories;
        $scope.keyword = '';

        $scope.search = search;
        function search() {
            getProductCategories();
        }

        $scope.getProductCategories();
        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get('api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning("Không tìm thấy bản nào");
                }
                //else {
                //    notificationService.displaySuccess("Đãt tìm thấy " + result.data.TotalCount + " bản ghi ");
                //}
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load productcategory failed.');
            });
        }

        $scope.deleteProductCategory = deleteProductCategory;
        function deleteProductCategory(id) {
            $ngBootbox.confirm("Bạn có muốn xóa không ?").then(
                function () {
                    var config = {
                        params: {
                            Id: id
                        }
                        //Chữ params Viết cẩn thận, dùng text compare.com phat hien ra
                    };
                    apiService.del(
                        'api/productcategory/delete',
                        config,
                        function () {
                            notificationService.displaySuccess("Xóa thành công !");
                            search();
                        },
                        function () {
                            notificationService.displayError('Xóa không thành công');
                        }
                    );
                }
            );
        }       
        //Nhớ bên html phải dùng ng-click nó mới ăn hàm

    }
})(angular.module('anntgc00492Shop.product_categories'));