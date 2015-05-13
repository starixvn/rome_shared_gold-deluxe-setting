if (fanex.goldDeluxeSetting) {
    fanex.goldDeluxeSetting.controller('CustomerSettingController',
    [
        '$scope',
        '$http',
        '$window',
        '$timeout',
        'CustomerSettingService',
        function ($scope, $http, $window, $timeout, customerSettingService) {
            'use strict';
            var updateAllSettingUrl = $('#UpdateLiveCasinoSettingUrl').val();
            $scope.mainResult = {
                CommandResultsList: []
            };

            $scope.isUpdateAllSetting = false;
            $scope.isReadOnly = settingViewModel.FormType === fanex.goldDeluxeSetting.formType.ReadOnly;
            $scope.isEditMultiple = settingViewModel.Customers && settingViewModel.Customers.length > 0;
            $scope.isEditDirect = (settingViewModel.UpLineLevel - settingViewModel.Level === 1);

            $scope.validateAndUpdateSetting = function (updateType) {
                $scope.isUpdateAllSetting = true;
                var ptAndComScope = angular.element('[data-ng-controller="PtAndComSettingController"]').scope();

                if (ptAndComScope.isEditPresetOnMember()) {
                    return;
                }

                $scope.updateAllSetting(updateType);
            };

            $scope.updateAllSetting = function (updateType) {
                updateType = updateType || fanex.goldDeluxeSetting.updateType.AllSetting;
                var custInfoScope = angular.element('[data-ng-controller="CustomerInfoController"]').scope(),
                    ptAndComScope = angular.element('[data-ng-controller="PtAndComSettingController"]').scope(),
                    gameSettingScope = angular.element('[data-ng-controller="CustGameSettingController"]').scope();

                var customer = custInfoScope.getCustInfo();

                customer.LiveCasinoSetting.PositionTaking = ptAndComScope.positionTaking;
                customer.LiveCasinoSetting.Commission = ptAndComScope.commission;
                customer.LiveCasinoSetting.GameSetting = gameSettingScope.getGameSetting();

                var settingContextForUpdate = {
                    settingViewModel: settingViewModel,
                    customer: customer,
                    isApplyPositionTakingAllMembers: ptAndComScope.uplinePTOnMember.isApplyNewUplinePositionTaking,
                    positionTakingOnMembers: ptAndComScope.uplinePTOnMember.newUplinePositionTaking,
                    updateType: updateType
                };

                customerSettingService.updateAllSetting(updateAllSettingUrl, settingContextForUpdate, $scope);
                $scope.isUpdateAllSetting = false;
            };

            $scope.afterServerReturnSuccess = function (mainResult, isUpdatePartial) {
                $scope.mainResult = mainResult;

                if (mainResult.IsSuccessful) {
                    $scope.isReadOnly = true;
                    $timeout(function () {
                        if ($scope.isEditMultiple
                            && $window.parent.actionAfterUpdatedLiveCasinoSettingMultiple) {
                            $window.parent.actionAfterUpdatedLiveCasinoSettingMultiple(isUpdatePartial);
                        }
                        else {
                            if ($window.parent.actionAfterUpdatedLiveCasinoSettingSingle) {
                                $window.parent.actionAfterUpdatedLiveCasinoSettingSingle(isUpdatePartial);
                            }
                            else {
                                $window.location.href = $window.location.href;
                            }
                        }
                    }, fanex.goldDeluxeSetting.TIME_OUT_SHOW_MESSAGE);
                }
            };

            $('#tblSetting').show();
        }
    ]);
}
else {
    alert('Missing fanex.goldDeluxeSetting!');
}