app.directive('initTable', ['$compile', function ($compile) {
    return {
        restrict: 'A',

        link: function (scope, el, attrs) {
            var opts = scope.$eval(attrs.initTable);

            opts.onLoadSuccess = function () {
                $compile(el.contents())(scope);
            };

            el.bootstrapTable(opts);
        }

    };
}]);