namespace Fanex.GoldDeluxe.CoreSetting.Test.Controllers
{
    using NUnit.Framework;
    using NSubstitute;
    using Fanex.GoldDeluxe.CoreSetting.Services;
    using Fanex.GoldDeluxe.CoreSetting.Controllers;
    using Fanex.GoldDeluxe.CoreSetting.Enumerations;
    using System.Web.Mvc;
    using Fanex.GoldDeluxe.CoreSetting.ViewModels;
    using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;
    using AutoMapper;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;

    [TestFixture]
    public class SettingControllerTest
    {
        private ISettingService _settingService;
        private SettingController _settingController;

        [SetUp]
        public void SetUp()
        {
            _settingService = Substitute.For<ISettingService>();
            _settingController = new SettingController(_settingService);
        }

        [Test]
        public void EditSetting_WhenCalled_ReturnView()
        {
            Mapper.CreateMap<EditSettingViewModel, GetSettingParameters>();

            var result = (ViewResult)_settingController.EditSetting(
                custId: Arg.Any<int>(),
                upLineId: Arg.Any<int>(),
                level: Arg.Any<int>(),
                upLineLevel: Arg.Any<int>(),
                actorId: Arg.Any<int>());

            const string ExpectedView = "~/Areas/GoldDeluxeSetting/Views/EditSetting/EditSettingSingle.cshtml";
            Assert.AreEqual(ExpectedView, result.ViewName);
        }

        [Test]
        public void EditSetting_WhenCalled_ReturnViewModel()
        {
            Mapper.CreateMap<EditSettingViewModel, GetSettingParameters>();

            var result = (ViewResult)_settingController.EditSetting(
                custId: Arg.Any<int>(),
                upLineId: Arg.Any<int>(),
                level: Arg.Any<int>(),
                upLineLevel: Arg.Any<int>(),
                actorId: Arg.Any<int>());

            Assert.IsInstanceOf(typeof(EditSettingViewModel), result.ViewData.Model);
        }

        [Test]
        public void EditSetting_WhenCalled_ReturnSetting()
        {
            Mapper.CreateMap<EditSettingViewModel, GetSettingParameters>();
            int custId = 1234,
                upLineId = 123,
                level = 1,
                upLineLevel = 2,
                actorId = 8,
                subAccId = 1;
            var language = "E";
            var formType = FormType.ReadOnly;
            var param = new GetSettingParameters
            {
                CustId = custId,
                Level = (CustomerLevel)level,
                UpLineId = upLineId,
                UpLineLevel = (CustomerLevel)upLineLevel
            };
            _settingService.GetSetting(param).Returns(new SettingDTO
            {
                Commission = new CommissionDTO
                {
                    Commission = 1.0F,
                    ParentCommission = 2.0F
                },
                DisableDownlines = true,
                DisableGoldDeluxe = true,
                DisableUpline = true,
                Fax = "fax",
                FirstName = "firstname",
                LastName = "lastname",
                MobilePhone = "mobilephone",
                NickName = "nickname",
                Phone = "phone",
                PositionTaking = new PositionTakingDTO
                {
                    A1 = 1,
                    A2 = 2,
                    A4 = 3,
                    Im1 = true,
                    Im2 = true,
                    Is1 = true,
                    Is3 = true,
                    IsDisableAuto = true,
                    L2 = 8,
                    L3 = 9,
                    L4 = 10,
                    M1 = 11,
                    M1Max = 12,
                    M1Min = 13,
                    M2 = 14,
                    M3 = 15,
                    M4 = 16,
                    N1 = 17,
                    N2 = 18,
                    N3 = 19,
                    N4 = 20,
                    S1 = 21,
                    S1Max = 22,
                    S1Min = 23,
                    S3 = 24,
                    S4 = 25,
                    Um1 = 26,
                    Um2 = 27,
                    Us1 = 28,
                    Us3 = 29
                },
                Username = "username"
            });

        }
    }
}
