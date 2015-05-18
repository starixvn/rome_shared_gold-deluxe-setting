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
    using System.Collections.Generic;
    using System;

    [TestFixture]
    public class SettingControllerTest
    {
        private ISettingService _settingService;
        private GoldDeluxeController _settingController;

        [SetUp]
        public void SetUp()
        {
            _settingService = Substitute.For<ISettingService>();
            _settingController = new GoldDeluxeController(_settingService);
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
            _settingService.GetSetting(Arg.Is<GetSettingParameters>(x => x.CustId == custId
                                                                         && x.Level == (CustomerLevel)level
                                                                         && x.UpLineId == upLineId
                                                                         && x.UpLineLevel == (CustomerLevel)upLineLevel))
                           .Returns(DummyStored.CreateSettingDTO());
            var expectedEditModel = new EditSettingViewModel
            {
                CustId = custId,
                UpLineId = upLineId,
                Level = (CustomerLevel)level,
                UpLineLevel = (CustomerLevel)upLineLevel,
                ActorId = actorId,
                SubAccId = subAccId,
                Language = language,
                FormType = formType,
                Setting = DummyStored.CreateSettingDTO()
            };

            var result = (ViewResult)_settingController.EditSetting(
                                                                custId,
                                                                upLineId,
                                                                level,
                                                                upLineLevel,
                                                                actorId,
                                                                subAccId,
                                                                language,
                                                                formType);

            AssertAllFields.Assert(expectedEditModel, (EditSettingViewModel)result.ViewData.Model);
        }

        [Test]
        public void EditSettingMultiple_WhenCalled_ReturnView()
        {
            Mapper.CreateMap<EditSettingMultipleViewModel, GetSettingParameters>();

            var result = (ViewResult)_settingController.EditSettingMultiple(
                custIds: "1,2",
                usernames: Arg.Any<string>(),
                upLineId: Arg.Any<int>(),
                level: Arg.Any<int>(),
                upLineLevel: Arg.Any<int>(),
                actorId: Arg.Any<int>());

            const string ExpectedView = "~/Areas/GoldDeluxeSetting/Views/EditSetting/EditSettingMultiple.cshtml";
            Assert.AreEqual(ExpectedView, result.ViewName);
        }

        [Test, ExpectedException(typeof(NullReferenceException))]
        public void EditSettingMultiple_CustIdsIsEmpty_ThrowException()
        {
            Mapper.CreateMap<EditSettingMultipleViewModel, GetSettingParameters>();

            var result = (ViewResult)_settingController.EditSettingMultiple(
                custIds: Arg.Any<string>(),
                usernames: Arg.Any<string>(),
                upLineId: Arg.Any<int>(),
                level: Arg.Any<int>(),
                upLineLevel: Arg.Any<int>(),
                actorId: Arg.Any<int>());
        }

        [Test]
        public void EditSettingMultiple_ValidCustIds_SetCustIdIsFirstId()
        {
            Mapper.CreateMap<EditSettingMultipleViewModel, GetSettingParameters>();

            var result = (ViewResult)_settingController.EditSettingMultiple(
                custIds: "1,2,3",
                usernames: Arg.Any<string>(),
                upLineId: Arg.Any<int>(),
                level: Arg.Any<int>(),
                upLineLevel: Arg.Any<int>(),
                actorId: Arg.Any<int>());


            const int ExpectedCustId = 1;
            Assert.AreEqual(ExpectedCustId, ((EditSettingMultipleViewModel)result.ViewData.Model).CustId);
        }

        [Test]
        public void EditSettingMultiple_WhenCalled_ReturnViewModel()
        {
            Mapper.CreateMap<EditSettingMultipleViewModel, GetSettingParameters>();

            var result = (ViewResult)_settingController.EditSettingMultiple(
              custIds: "1,2,3",
              usernames: Arg.Any<string>(),
              upLineId: Arg.Any<int>(),
              level: Arg.Any<int>(),
              upLineLevel: Arg.Any<int>(),
              actorId: Arg.Any<int>());

            Assert.IsInstanceOf(typeof(EditSettingMultipleViewModel), result.ViewData.Model);
        }

        [Test]
        public void EditSettingMultiple_WhenCalled_ReturnSetting()
        {
            Mapper.CreateMap<EditSettingMultipleViewModel, GetSettingParameters>();
            string custIds = "1,2,3,4";
            string usernames = "s1,s2,s3,s4";

            int custId = 1,
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
            _settingService.GetSetting(Arg.Is<GetSettingParameters>(x => x.CustId == custId
                                                                         && x.Level == (CustomerLevel)level
                                                                         && x.UpLineId == upLineId
                                                                         && x.UpLineLevel == (CustomerLevel)upLineLevel))
                           .Returns(DummyStored.CreateSettingDTO());
            var expectedEditModel = new EditSettingMultipleViewModel
            {
                CustId = custId,
                CustIds = custIds,
                Usernames = usernames,
                UpLineId = upLineId,
                Level = (CustomerLevel)level,
                UpLineLevel = (CustomerLevel)upLineLevel,
                ActorId = actorId,
                SubAccId = subAccId,
                Language = language,
                FormType = formType,
                Setting = DummyStored.CreateSettingDTO()
            };

            var result = (ViewResult)_settingController.EditSettingMultiple(
                                                                custIds,
                                                                usernames,
                                                                upLineId,
                                                                level,
                                                                upLineLevel,
                                                                actorId,
                                                                subAccId,
                                                                language,
                                                                formType);

            AssertAllFields.Assert(expectedEditModel, (EditSettingMultipleViewModel)result.ViewData.Model);
        }
    }
}
