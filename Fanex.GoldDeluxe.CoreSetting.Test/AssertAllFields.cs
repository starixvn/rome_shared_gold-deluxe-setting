namespace Fanex.GoldDeluxe.CoreSetting.Test
{
    using System.Collections.Generic;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;
    using Fanex.GoldDeluxe.CoreSetting.ViewModels;
    using NU = NUnit.Framework;

    public static class AssertAllFields
    {
        public static void Assert(List<GameTypeDTO> listA, List<GameTypeDTO> listB)
        {
            NU.Assert.AreEqual(listA.Count, listB.Count);

            for (int i = 0; i < listA.Count; i++)
            {
                Assert(listA[i], listB[i]);
            }
        }

        public static void Assert(List<StakeLevelDTO> listA, List<StakeLevelDTO> listB)
        {
            NU.Assert.AreEqual(listA.Count, listB.Count);

            for (int i = 0; i < listA.Count; i++)
            {
                Assert(listA[i], listB[i]);
            }
        }

        public static void Assert(StakeLevelDTO objectA, StakeLevelDTO objectB)
        {
            NU.Assert.AreEqual(objectA.Id, objectB.Id);
            NU.Assert.AreEqual(objectA.IsChecked, objectB.IsChecked);
            NU.Assert.AreEqual(objectA.Range, objectB.Range);
        }

        public static void Assert(GameTypeDTO objectA, GameTypeDTO objectB)
        {
            NU.Assert.AreEqual(objectA.CheckedStakeLevelId, objectB.CheckedStakeLevelId);
            NU.Assert.AreEqual(objectA.Id, objectB.Id);
            NU.Assert.AreEqual(objectA.Name, objectB.Name);

            Assert(objectA.BettingLimit, objectB.BettingLimit);
        }

        public static void Assert(PositionTakingDTO objectA, PositionTakingDTO objectB)
        {
            NU.Assert.AreEqual(objectA.A1, objectB.A1);
            NU.Assert.AreEqual(objectA.A2, objectB.A2);
            NU.Assert.AreEqual(objectA.A4, objectB.A4);
            NU.Assert.AreEqual(objectA.Im1, objectB.Im1);
            NU.Assert.AreEqual(objectA.Im2, objectB.Im2);
            NU.Assert.AreEqual(objectA.Is1, objectB.Is1);
            NU.Assert.AreEqual(objectA.Is3, objectB.Is3);
            NU.Assert.AreEqual(objectA.IsDisableAuto, objectB.IsDisableAuto);
            NU.Assert.AreEqual(objectA.L2, objectB.L2);
            NU.Assert.AreEqual(objectA.L3, objectB.L3);
            NU.Assert.AreEqual(objectA.L4, objectB.L4);
            NU.Assert.AreEqual(objectA.M1, objectB.M1);
            NU.Assert.AreEqual(objectA.M1Max, objectB.M1Max);
            NU.Assert.AreEqual(objectA.M1Min, objectB.M1Min);
            NU.Assert.AreEqual(objectA.M2, objectB.M2);
            NU.Assert.AreEqual(objectA.M3, objectB.M3);
            NU.Assert.AreEqual(objectA.M4, objectB.M4);
            NU.Assert.AreEqual(objectA.N1, objectB.N1);
            NU.Assert.AreEqual(objectA.N2, objectB.N2);
            NU.Assert.AreEqual(objectA.N3, objectB.N3);
            NU.Assert.AreEqual(objectA.N4, objectB.N4);
            NU.Assert.AreEqual(objectA.S1, objectB.S1);
            NU.Assert.AreEqual(objectA.S1Max, objectB.S1Max);
            NU.Assert.AreEqual(objectA.S1Min, objectB.S1Min);
            NU.Assert.AreEqual(objectA.S3, objectB.S3);
            NU.Assert.AreEqual(objectA.S4, objectB.S4);
            NU.Assert.AreEqual(objectA.Um1, objectB.Um1);
            NU.Assert.AreEqual(objectA.Um2, objectB.Um2);
            NU.Assert.AreEqual(objectA.Us1, objectB.Us1);
            NU.Assert.AreEqual(objectA.Us3, objectB.Us3);
        }

        public static void Assert(CommissionDTO objectA, CommissionDTO objectB)
        {
            NU.Assert.AreEqual(objectA.Commission, objectB.Commission);
            NU.Assert.AreEqual(objectA.ParentCommission, objectB.ParentCommission);
        }

        public static void Assert(SettingDTO objectA, SettingDTO objectB)
        {
            Assert(objectA.Commission, objectB.Commission);
            Assert(objectA.GameSetting, objectB.GameSetting);
            Assert(objectA.PositionTaking, objectB.PositionTaking);

            NU.Assert.AreEqual(objectA.DisableDownlines, objectB.DisableDownlines);
            NU.Assert.AreEqual(objectA.DisableGoldDeluxe, objectB.DisableGoldDeluxe);
            NU.Assert.AreEqual(objectA.DisableUpline, objectB.DisableUpline);
            NU.Assert.AreEqual(objectA.Fax, objectB.Fax);
            NU.Assert.AreEqual(objectA.FirstName, objectB.FirstName);
            NU.Assert.AreEqual(objectA.HasDownline, objectB.HasDownline);
            NU.Assert.AreEqual(objectA.LastName, objectB.LastName);
            NU.Assert.AreEqual(objectA.MobilePhone, objectB.MobilePhone);
            NU.Assert.AreEqual(objectA.NickName, objectB.NickName);
            NU.Assert.AreEqual(objectA.Phone, objectB.Phone);
            NU.Assert.AreEqual(objectA.Username, objectB.Username);
        }

        public static void Assert(EditSettingViewModel objectA, EditSettingViewModel objectB)
        {
            NU.Assert.AreEqual(objectA.ActorId, objectB.ActorId);
            NU.Assert.AreEqual(objectA.CustId, objectB.CustId);
            NU.Assert.AreEqual(objectA.FormType, objectB.FormType);
            NU.Assert.AreEqual(objectA.IsUpdatePTAllMembers, objectB.IsUpdatePTAllMembers);
            NU.Assert.AreEqual(objectA.Language, objectB.Language);
            NU.Assert.AreEqual(objectA.Level, objectB.Level);
            NU.Assert.AreEqual(objectA.PTOnMember, objectB.PTOnMember);
            NU.Assert.AreEqual(objectA.SubAccId, objectB.SubAccId);
            NU.Assert.AreEqual(objectA.System, objectB.System);
            NU.Assert.AreEqual(objectA.UpLineId, objectB.UpLineId);
            NU.Assert.AreEqual(objectA.UpLineLevel, objectB.UpLineLevel);

            Assert(objectA.Setting, objectB.Setting);
        }

        public static void Assert(EditSettingMultipleViewModel objectA, EditSettingMultipleViewModel objectB)
        {
            NU.Assert.AreEqual(objectA.Usernames, objectB.Usernames);
            NU.Assert.AreEqual(objectA.CustIds, objectB.CustIds);
            NU.Assert.AreEqual(objectA.ActorId, objectB.ActorId);
            NU.Assert.AreEqual(objectA.CustId, objectB.CustId);
            NU.Assert.AreEqual(objectA.FormType, objectB.FormType);
            NU.Assert.AreEqual(objectA.IsUpdatePTAllMembers, objectB.IsUpdatePTAllMembers);
            NU.Assert.AreEqual(objectA.Language, objectB.Language);
            NU.Assert.AreEqual(objectA.Level, objectB.Level);
            NU.Assert.AreEqual(objectA.PTOnMember, objectB.PTOnMember);
            NU.Assert.AreEqual(objectA.SubAccId, objectB.SubAccId);
            NU.Assert.AreEqual(objectA.System, objectB.System);
            NU.Assert.AreEqual(objectA.UpLineId, objectB.UpLineId);
            NU.Assert.AreEqual(objectA.UpLineLevel, objectB.UpLineLevel);

            Assert(objectA.Setting, objectB.Setting);
        }
    }
}