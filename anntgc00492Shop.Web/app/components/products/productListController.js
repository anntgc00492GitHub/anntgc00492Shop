(function (app) {
    app.controller('productListController', productListController);
    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', "$filter"];
    function productListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.products = [];
        $scope.page = 0;
        $scope.keyword = '';
        $scope.pagesCount = 0;

        $scope.getProducts = getProducts;
        function getProducts(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get(
                'api/product/getall',
                config,
                function (result) {
                    if (result.data.TotalCount === 0) {
                        notificationService.displayWarning("không thấy bản ghi nào");
                    }
                    $scope.products = result.data.Items;
                    $scope.page = result.data.Page;
                    $scope.pagesCount = result.data.TotalPages;//pagesCount có s nhé, không thi không nhận đc ở chỗ thành phân trang
                    $scope.totalCount = result.data.TotalCount;
                },
                function () {
                    console.log('Load products list failed');
                }
            );
        }
        $scope.getProducts();//Khai báo chay luôn để load dữ liệu

        $scope.search = search;
        function search() {
            getProducts();
        }

        $scope.deleteProduct = deleteProduct;
        function deleteProduct(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/product/delete',
                    config,
                    function () {
                        notificationService.displaySuccess('Xóa thành công');
                        search();
                    },
                    function () {
                        notificationService.displayError('Xóa không thành công');
                    }
                );
            });
        }

        $scope.deleteMultiple = deleteMultiple;
        function deleteMultiple() {
            var listId = [];
            $.each(
                $scope.selected,
                function (i, item) {
                    listId.push(item.Id);
                }
            );
            var config = {
                params: {
                    checkedProducts: JSON.stringify(listId)
                }
            };
            apiService.del(
                'api/product/deletemulti',
                config,
                function (result) {
                    notificationService.displaySuccess("Xóa thành công" + result.data + "sản phẩm");
                    search();
                },
                function (error) {
                    notificationService.displayError("xóa không thành công");
                }
            );
        }

        $scope.isAll = false;
        $scope.selectAll = selectAll;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch(
            'products',
            function (n, o) {
                var checked = $filter("filter")(n, { checked: true });
                if (checked.length) {
                    $scope.selected = checked;
                    $('#btnDelete').removeAttr('disabled');
                } else {
                    $('#btnDelete').attr('disabled', 'disabled');
                }
            },
            true
        );
    }
})(angular.module('anntgc00492Shop.products'));