fanex.goldDeluxeSetting.controller('ptAndComController', function ($scope, $window, PtAndComService) {
    var me = this;
    var customerLevel = fanex.goldDeluxeSetting.customerLevel;

    $scope.level = settingViewModel.Level;
    $scope.uplineLevel = settingViewModel.UplineLevel;
    $scope.customerLevel = customerLevel;

    $scope.positionTaking = fanex.cloneObject(settingViewModel.Setting.PositionTaking);
    $scope.commission = settingViewModel.Setting.Commission;

    $scope.uplinePTOnMemberOptions = [];
    $scope.isUpdateAllSetting = false;
    $scope.language = language;
    me.updatePTComUrl = $('#UpdatePTComSettingUrl').val();


    me.$presetOnMemberModal = $('#presetOnMemberModal');
    $scope.uplinePTOnMember =
    {
        newUplinePositionTaking: 0,
        isApplyNewUplinePositionTaking: false
    };

    $scope.isEditPresetOnMember = function () {
        var currentPT = $scope.positionTaking;


        switch (settingViewModel.Level) {
            case customerLevel.Master:
                if (settingViewModel.Setting.PositionTaking.Is3
                    && !currentPT.Is3) {
                    $scope.uplinePTOnMember.newUplinePositionTaking = fanex.roundNumber(currentPT.S4 - currentPT.M3);
                    $scope.uplinePTOnMemberOptions = fanex.createOptionsFromRange(
                                                        $scope.uplinePTOnMember.newUplinePositionTaking,
                                                        0,
                                                        $scope.uplinePTOnMember.newUplinePositionTaking,
                                                        fanex.liveCasinoSetting.PT_INTERVAL);
                    me.$presetOnMemberModal.modal({
                        backdrop: 'static',
                        show: true,
                        keyboard: false
                    });
                    return true;
                }
                break;
            case customerLevel.Agent:
                if (settingViewModel.Setting.PositionTaking.Im2
                    && !currentPT.Im2) {
                    $scope.uplinePTOnMember.newUplinePositionTaking = fanex.roundNumber(currentPT.M3 - currentPT.A2);
                    $scope.uplinePTOnMemberOptions = fanex.createOptionsFromRange(
                                                        $scope.uplinePTOnMember.newUplinePositionTaking,
                                                        0,
                                                        $scope.uplinePTOnMember.newUplinePositionTaking,
                                                        fanex.liveCasinoSetting.PT_INTERVAL);
                    me.$presetOnMemberModal.modal({
                        backdrop: 'static',
                        show: true,
                        keyboard: false
                    });
                    return true;
                }
                break;
        }
        return false;
    };

    $scope.updatePTAndComSetting = function () {
        if (!settingContext.IsSyncLiveCasino) {
            $scope.$parent.validateAndUpdateSetting(fanex.liveCasinoSetting.updateType.PositionTakingAndCommission);
            return;
        }

        if ($scope.isEditPresetOnMember()) {
            return;
        }

        ptAndComService.updatePtAndComSetting(me.updatePTComUrl, $scope.commission, $scope.positionTaking, $scope.uplinePTOnMember, $scope.$parent);
    };

    $scope.updatePTOnMember = function (isUpdate) {
        $scope.uplinePTOnMember.isApplyNewUplinePositionTaking = isUpdate;
        if ($scope.$parent.isUpdateAllSetting) {
            $scope.$parent.updateAllSetting();
        }
        else {
            ptAndComService.updatePtAndComSetting(
                        me.updatePTComUrl,
                        $scope.commission,
                        $scope.positionTaking,
                        $scope.uplinePTOnMember,
                        $scope.$parent);
        }
    };
});