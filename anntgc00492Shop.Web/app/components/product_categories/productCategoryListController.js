(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
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
            apiService.get('api/productcategory/getall',
                config,
                function (result) {
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
                },
                function () {
                    console.log('Load productcategory failed.');
                });
        }

        $scope.deleteProductCategory = deleteProductCategory;

        function deleteProductCategory(id) {
            $ngBootbox.confirm("Bạn có muốn xóa không ?")
                .then(
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


        //Phần dưới triển khai xóa nhiều

        $scope.deleteMultiple = deleteMultiple; //Khai báo hàm xóa nhiều
        function deleteMultiple() {
            var listId = [];
            $.each(
                    $scope.selected,//cho danh sách các cái đc tích lấy ở scope watch
                    function (i, item) {
                        listId.push(item.Id);//đẩy id trong từng item vào trong $scope.selected
                        // chú ý Id trong item.Id phải là Id giống trong db không phải ID.
                    }
                );

            //Tạo params nạp 
            var config = {
                params: {
                    checkedProductCategories: JSON.stringify(listId)
                }
            }
            //Triển khai gọi hàm xóa 4 tham số truyển vào
            apiService.del(
                'api/productcategory/deletemulti',
                config,
                function (result) {
                    notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                    search();
                },
                function (error) {
                    notificationService.displayError('Xóa không thành công');
                }
            );
        }


        //lập biến và hàm thay đổi trạng thái các item trong productCategories khi tích nút chọn all kích hoạt sự kiện selectAll()
        $scope.isAll = false;
        $scope.selectAll = selectAll;//Khai báo hàm xóa selectAll
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.productCategories,
                    function (item) {
                        item.checked = true;
                    });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.productCategories,
                    function (item) {
                        item.checked = false;
                    });
                $scope.isAll = false;
            }
        }


        //Hảm thay đổi trạng thái nút xóa multi có idbtnDelete
        $scope.$watch(
            "productCategories",
            function (n, o) {
                var checked = $filter("filter")(n, { checked: true });//Tìm tất cả trong biến danh sách productCategories item.check nào có giá trị true
                if (checked.length) {
                    $scope.selected = checked;//Nạp cái thu đc vào biến dang danh sách selected để dùng ở hàm kahcs
                    $('#btnDelete').removeAttr('disabled');
                } else {
                    $('#btnDelete').attr('disabled', 'disabled');
                }
            },
            true);
    }
})(angular.module('anntgc00492Shop.product_categories'));