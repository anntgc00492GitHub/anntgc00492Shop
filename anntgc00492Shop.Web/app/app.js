(function () {
    angular.module('anntgc00492Shop', ['anntgc00492Shop.products','anntgc00492Shop.product_categories','anntgc00492Shop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
                url: "/admin",
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
        });
        $urlRouterProvider.otherwise("/admin");
    }



})();