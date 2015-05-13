fanex.goldDeluxeSetting.controller('CustomerInfoController', function ($scope) {
    $scope.enableGoldDeluxe = !settingViewModel.DisableGoldDeluxe;
    $scope.enableDownline = !settingViewModel.DisableDownlines;
    $scope.hasDownline = settingViewModel.HasDownline;
    $scope.disableCheckBoxGoldDeluxe = settingViewModel.DisableUpline;

    $scope.getCustInfo = function () {
        settingViewModel.DisableGoldDeluxee = !$scope.enableGoldDeluxe;
        return settingViewModel;
    };
});
