app.directive('rnStepper', function () {
    return {
        restrict: 'AE',
        scope: {},
        template: '<button ng-click="decrement()">-</button>' +
                  '<div>{{value}}</div>' +
                  '<button ng-click="increment()">+</button>',
        link: function (scope, iElement, iAttrs) {
            scope.value = 0;
            scope.increment = function () {
                scope.value++;
            };
            scope.decrement = function () {
                scope.value--;
            };
        }
    };
});
app.controller("TestController", ["$scope", "$location", function ($scope, $location) {
    $scope.goToIndex2 = function () {
        $location.path("/SY");
    }
    function query() {
        $("#list").bootstrapTable({
            method: 'post',
            url: './Admin/Home/list',
            dataType: "json",
            striped: true,	 //使表格带有条纹
            pagination: true,	//在表格底部显示分页工具栏
            pageSize: 4,
            pageNumber: 1,
            pageList: [10, 20, 50, 100, 200, 500],
            idField: "Id",  //标识哪个字段为id主键
            showToggle: false,   //名片格式
            cardView: false,//设置为True时显示名片（card）布局
            showColumns: true, //显示隐藏列  
            showRefresh: true,  //显示刷新按钮
            singleSelect: true,//复选框只能选择一条记录
            search: false,//是否显示右上角的搜索框
            clickToSelect: true,//点击行即可选中单选/复选框
            sidePagination: "server",//表格分页的位置
            queryParams: {pageSize : 0,pageNumber : 10}, //参数
            queryParamsType: "", //参数格式,发送标准的RESTFul类型的参数请求
            paginationLoop: true,
            toolbar: '#toolbar',
            columns:
            [
                { field: "Id", title: "编号" },
                { field: "Name", title: "名称" },
                {
                    field: 'operate', title: '操作', align: 'center', valign: 'middle',
                    formatter: function (value, row, index) {
                        var html = ["<span class=\"btn-a\">"];
                        html.push("<a class=\"good-check\">测试</a>");
                        html.push("</span>");
                        return html.join("");
                    }
                }
            ],
            onClickRow: function (row) {
            }
        });
        flag = false;
    }

    $(function () {
        query();
        $scope.rating = 42;
        $scope.minRating = 40;
        $scope.maxRating = 50;
    });

    
}]);



app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/SY', { templateUrl: '../../Angular/Admin/Index.html', controller: 'TestController' })
        .otherwise({ redirectTo: '/SY' });
}]);

