(function(app) {
    app.filter('statusFilter',
        function() {
            return function(input) {
                if (input == true) {
                    return "kích hoạt";
                } else {
                    return 'khoa';
                }
            };
        });
})(angular.module('anntgc00492Shop.common'));