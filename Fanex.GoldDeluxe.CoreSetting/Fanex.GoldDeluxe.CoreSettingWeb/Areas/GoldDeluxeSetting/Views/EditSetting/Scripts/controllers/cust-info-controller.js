fanex.goldDeluxeSetting.controller('custInfoController', function ($scope) {
    var setting = settingViewModel.Setting;

    $scope.customerInfo = {
        enableGoldDeluxe: !setting.DisableGoldDeluxe,
        enableDownlines: !setting.DisableDownlines,
        fax: setting.Fax,
        firstName: setting.FirstName,
        hasDownline: setting.HasDownline,
        lastName: setting.LastName,
        mobilePhone: setting.MobilePhone,
        phone: setting.Phone,
        username: setting.Username,
        level: settingViewModel.Level
    };

    $scope.isShowEnableStatus = function () {
        return settingViewModel.System !== fanex.goldDeluxeSetting.system.Agency || settingViewModel.Level === fanex.goldDeluxeSetting.customerLevel.Member;
    }

    $scope.isShowEnableDownline = function () {
        return settingViewModel.Level !== fanex.goldDeluxeSetting.customerLevel.Member && $scope.customerInfo.hasDownline;
    }
});