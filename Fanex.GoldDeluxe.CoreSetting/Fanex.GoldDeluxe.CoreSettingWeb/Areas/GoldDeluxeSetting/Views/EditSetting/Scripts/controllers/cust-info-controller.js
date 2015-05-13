fanex.goldDeluxeSetting.controller('CustomerInfoController', function ($scope) {

    $scope.enableGoldDeluxe = !settingViewModel.DisableGoldDeluxe;
    $scope.enableDownline = !settingViewModel.DisableDownlines;
    $scope.hasDownline = settingViewModel.HasDownline;
    $scope.disableCheckBoxGoldDeluxe = settingViewModel.DisableUpline;

    $scope.updateSettingStatus = function (setting) {
        setting.DisableGoldDeluxe = !$scope.enableGoldDeluxe;
        setting.DisableDownlines = !$scope.enableDownline;
    };
});
