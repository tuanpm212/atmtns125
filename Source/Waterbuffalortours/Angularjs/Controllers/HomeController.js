
app.controller('HomeController', ['$scope', '$http', function ($scope, $http) {
    $scope.data = {
        slides: [],
        introduction: {
        },
        tours: []
    };


    //Function get data
    $scope.getData = function () {
        $http.get('/home/InitialData').success(function (data) {
            if (data.isOk) {
                $scope.data.slides = JSON.parse(data.slides);
                $scope.data.introduction = JSON.parse(data.introduction);
                $scope.data.tours = JSON.parse(data.tours);
            }
            else {
                $scope.modal.modalAlert.msgAlert = 'Load data không thành công';
                $scope.modal.modalAlert.isShowModal = true;
            }
        });
    };

    $scope.getData();
}]);