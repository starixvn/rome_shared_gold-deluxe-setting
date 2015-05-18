namespace Fanex.GoldDeluxe.CoreSetting.Test
{
    using Fanex.GoldDeluxe.CoreSetting.DTOs;
    using System.Collections.Generic;

    public static class DummyStored
    {
        public static PositionTakingDTO CreatePositionTakingDTO()
        {
            return new PositionTakingDTO
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
            };
        }

        public static CommissionDTO CreateCommissionDTO()
        {
            return new CommissionDTO
            {
                Commission = 1.0F,
                ParentCommission = 2.0F
            };
        }

        public static List<GameTypeDTO> CreateGameSettingDTO()
        {
            var gameType1 = new GameTypeDTO
            {
                Id = 1701,
                BettingLimit = CreateBettingLimit()
            };

            var gameType2 = new GameTypeDTO()
            {
                Id = 1702,
                BettingLimit = CreateBettingLimit()
            };

            return new List<GameTypeDTO> { gameType1, gameType2 };
        }

        public static List<StakeLevelDTO> CreateBettingLimit()
        {
            var stakeLevel1 = new StakeLevelDTO
            {
                Id = 1,
                IsChecked = true,
                Range = "1-2"
            };

            var stakeLevel2 = new StakeLevelDTO
            {
                Id = 2,
                IsChecked = false,
                Range = "3-4"
            };

            return new List<StakeLevelDTO> { stakeLevel1, stakeLevel2 };
        }

        public static SettingDTO CreateSettingDTO()
        {
            var setting = new SettingDTO
            {
                Commission = CreateCommissionDTO(),
                DisableDownlines = true,
                DisableGoldDeluxe = true,
                DisableUpline = true,
                Fax = "fax",
                FirstName = "firstname",
                LastName = "lastname",
                MobilePhone = "mobilephone",
                NickName = "nickname",
                Phone = "phone",
                PositionTaking = CreatePositionTakingDTO(),
                GameSetting = CreateGameSettingDTO(),
                Username = "username"
            };

            return setting;
        }
    }
}
