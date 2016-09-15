(function (app) {
    app.controller('productAddController', productAddController);
    productAddController.$inject = ['$scope', 'commonService', 'apiService', 'notificationService','$state'];//Sai dau $ nen khong itm ra

    function productAddController($scope, commonService, apiService, notificationService, $state) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.getSeoTitle = getSeoTitle;

        function getSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        $scope.ckeditorOptions = {
            language: 'vi',
            height: "200px"
        }


        $scope.chooseImage = chooseImage;
        function chooseImage () {
            var finder = new CKFinder();
            finder.selectActionFunction=function(fileUrl) {
                $scope.product.Image=fileUrl;
            }
            finder.popup();
        }

        $scope.addProduct = addProduct;
        function addProduct() {
            apiService.post(//Chỗ này nhơ là post, không chạy thử đc mà phải qua service. post sản phẩm phải post category id
                'api/product/create',
                $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + "đã được thêm mới");
                    $state.go("products");
                },
                function (error) {
                    notificationService.displayError("thêm mới không thành công");
                }
            );
        }

        function loadProductCategory()
        {
            apiService.get(
                    'api/productCategory/getallparents',
                    null,
                    function(result) {
                        $scope.productCategories = result.data;
                    },
                    function() {
                        console.log("can not get list category");
                    }
                );
        }
        loadProductCategory();

    }
})(angular.module('anntgc00492Shop.products'));
