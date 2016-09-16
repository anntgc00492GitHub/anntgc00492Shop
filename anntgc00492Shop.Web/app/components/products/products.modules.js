(function() {
    angular.module("anntgc00492Shop.products", ['anntgc00492Shop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state(
                'products',
                {
                    parent: 'base',
                    url: "/products",
                    templateUrl: "/app/components/products/productListView.html",
                    controller: "productListController"
                })
            .state(
                'product_add',
                {
                    parent: 'base',
                    url: "/product_add",
                    templateUrl: "/app/components/products/productAddView.html",
                    controller: "productAddController"
                })
            .state(
                'product_edit',
                {
                    parent:'base',
                    url: "/product_edit/:id",
                    templateUrl: "/app/components/products/productEditView.html",
                    controller: "productEditController"
                }
            );
    }
})();