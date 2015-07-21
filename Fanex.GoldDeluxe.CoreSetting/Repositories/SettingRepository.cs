namespace Fanex.GoldDeluxe.CoreSetting.Repositories
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using Fanex.Common.Extensions;
    using Fanex.Data;
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;
    using Fanex.NAP.Framework.Data;

    public class SettingRepository : ISettingRepository
    {
        public SettingDTO GetSupperSetting(ICriteria criteria)
        {
            return GetSetting(criteria, GetSupperPositionTaking, GetSupperCommission);
        }

        public SettingDTO GetMasterSetting(ICriteria criteria)
        {
            return GetSetting(criteria, GetMasterPositionTaking, GetMasterCommission);
        }

        public SettingDTO GetAgentSetting(ICriteria criteria)
        {
            return GetSetting(criteria, GetAgentPositionTaking, GetAgentCommission);
        }

        public SettingDTO GetMemberSetting(ICriteria criteria)
        {
            return GetSetting(criteria, GetMemberPositionTaking, GetMemberCommission);
        }

        public SettingDTO GetMemberSettingEditBySuper(ICriteria criteria)
        {
            return GetSetting(criteria, GetMemberPositionTakingEditBySuper, GetCommissionBySuperOrMaster);
        }

        public SettingDTO GetMemberSettingEditByMaster(ICriteria criteria)
        {
            return GetSetting(criteria, GetMemberPositionTakingEditByMaster, GetCommissionBySuperOrMaster);
        }

        public ICommandResult SaveChange(ICriteria criteria)
        {
            var result = new CommandResult();

            using (var objDb = new ObjectDb(criteria.GetSettingKey()))
            {
                objDb.ExecuteNonQuery(criteria.GetSpParams());

                var outParameters = objDb.GetOuputParams();
                result = GetCommandResult(outParameters);
            }

            return result;
        }

        private CommandResult GetCommandResult(Hashtable outParameters)
        {
            var result = new CommandResult();

            if (outParameters != null)
            {
                result.Code = outParameters.Contains("errcode") && outParameters["errcode"] != DBNull.Value ? outParameters["errcode"] : string.Empty;
                result.Message = outParameters.Contains("errmsg") ? outParameters["errmsg"].ToString() : string.Empty;
            }

            return result;
        }

        private SettingDTO GetSetting(ICriteria criteria, Func<IDataReader, PositionTakingDTO> getPositionTaking, Func<IDataReader, CommissionDTO> getCommission)
        {
            var customerSetting = new SettingDTO();

            using (var objDb = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var reader = objDb.ExecuteReader(criteria.GetSpParams()))
                {
                    while (reader.Read())
                    {
                        customerSetting.Username = reader.To<string>("username");
                        customerSetting.FirstName = reader.To<string>("firstname");
                        customerSetting.LastName = reader.To<string>("lastname");
                        customerSetting.Phone = reader.To<string>("phone");
                        customerSetting.MobilePhone = reader.To<string>("mobilephone");
                        customerSetting.Fax = reader.To<string>("fax");
                        customerSetting.DisableGoldDeluxe = reader.To<bool>("disablegolddeluxe");
                        customerSetting.DisableUpline = reader.To<bool>("disableupline");
                        customerSetting.DisableDownlines = reader.To<bool>("disabledownlines");
                        customerSetting.HasDownline = reader.To<bool>("downlines");
                    }

                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            customerSetting.PositionTaking = getPositionTaking(reader);
                            customerSetting.Commission = getCommission(reader);
                        }

                        if (reader.NextResult())
                        {
                            customerSetting.GameSetting = GetGameSetting(reader);
                        }

                        if (reader.NextResult())
                        {
                            customerSetting.WinLimit = GetWinLimit(reader);
                        }
                    }
                }
            }

            return customerSetting;
        }

        private List<GameTypeDTO> GetGameSetting(IDataReader reader)
        {
            var gameTypes = new List<GameTypeDTO>();
            GameTypeDTO current = null;

            while (reader.Read())
            {
                var itemGameType = new GameTypeDTO
                {
                    Id = reader.ToInt("GameTypeID")
                };

                var itemStakeLevel = new StakeLevelDTO
                {
                    Id = reader.ToInt("StakeLevelID"),
                    Range = reader.ToString("StakeLevelName"),
                    IsChecked = reader.ToBool("IsChecked")
                };

                if (current == null || current.Id != itemGameType.Id)
                {
                    gameTypes.Add(itemGameType);
                    current = itemGameType;
                    current.BettingLimit = new List<StakeLevelDTO>();
                }

                current.BettingLimit.Add(itemStakeLevel);
            }

            return gameTypes;
        }

        private WinLimitDTO GetWinLimit(IDataReader reader)
        {
            var winLimit = new WinLimitDTO();

            while (reader.Read())
            {
                winLimit.Max = reader.ToFloat("MaxWinLimit");
                winLimit.IsAutoReset = reader.ToBool("IsAutoReset");
                winLimit.UplineMax = reader.ToFloat("UplineMaxWinLimit");
                winLimit.UplineIsAutoReset = reader.ToBool("UplineIsAutoReset");
            }

            return winLimit;
        }

        private PositionTakingDTO GetSupperPositionTaking(IDataReader reader)
        {
            var positionTaking = new PositionTakingDTO
            {
                S4 = reader.To<float>("v255spositiontaking_1701"),
                L4 = reader.To<float>("v255spositiontaking_1701_max"),
                N4 = reader.To<float>("v255spositiontaking_1701_min")
            };

            return positionTaking;
        }

        private CommissionDTO GetSupperCommission(IDataReader reader)
        {
            var commission = new CommissionDTO
            {
                Commission = reader.ToFloat("v255sdiscount_1701"),
                ParentCommission = reader.ToFloat("v255sdicount_1701_max")
            };

            return commission;
        }

        private PositionTakingDTO GetMasterPositionTaking(IDataReader reader)
        {
            var positionTaking = new PositionTakingDTO
            {
                S4 = reader.To<float>("v255spositiontaking_1701_max"),
                N3 = reader.To<float>("v255mpositiontaking_1701_min"),
                Is3 = reader.To<bool>("isauto_v255spositiontaking_1701"),
                Us3 = reader.To<float>("auto_v255spostiontaking_1701"),
                S3 = reader.To<float>("v255spositiontaking_1701"),
                M3 = reader.To<float>("v255mpositiontaking_1701")
            };

            return positionTaking;
        }

        private CommissionDTO GetMasterCommission(IDataReader reader)
        {
            var commission = new CommissionDTO
            {
                Commission = reader.ToFloat("v255discount_1701"),
                ParentCommission = reader.ToFloat("v255discount_1701_max")
            };

            return commission;
        }

        private PositionTakingDTO GetAgentPositionTaking(IDataReader reader)
        {
            var positionTaking = new PositionTakingDTO
            {
                IsDisableAuto = reader.To<bool>("DisableAutoMPT"),
                M2 = reader.To<float>("v255mpositiontaking_1701"),
                Im2 = reader.To<bool>("isauto_v255mpositiontaking_1701"),
                Um2 = reader.To<float>("auto_v255mpositiontaking_1701"),
                A2 = reader.To<float>("v255apositiontaking_1701"),
                M3 = reader.To<float>("v255mpositiontaking_1701_max"),
                N2 = reader.To<float>("v255apositiontaking_1701_min")
            };

            return positionTaking;
        }

        private CommissionDTO GetAgentCommission(IDataReader reader)
        {
            var commission = new CommissionDTO
            {
                Commission = reader.ToFloat("v255discount_1701"),
                ParentCommission = reader.ToFloat("v255discount_1701_max")
            };

            return commission;
        }

        private PositionTakingDTO GetMemberPositionTaking(IDataReader reader)
        {
            var positionTaking = new PositionTakingDTO
            {
                A1 = reader.To<float>("v255apositiontaking_1701"),
                A2 = reader.To<float>("v255apositiontaking_1701_max"),
                N2 = reader.To<float>("v255apositiontaking_1701_min"),
            };

            return positionTaking;
        }

        private CommissionDTO GetMemberCommission(IDataReader reader)
        {
            var commission = new CommissionDTO
            {
                Commission = reader.ToFloat("v255playerdiscount_1701"),
                ParentCommission = reader.ToFloat("v255playerdiscount_1701_max")
            };

            return commission;
        }

        private PositionTakingDTO GetMemberPositionTakingEditBySuper(IDataReader reader)
        {
            var positionTaking = new PositionTakingDTO
            {
                S1 = reader.To<float>("v255spositiontaking_1701"),
                S1Max = reader.To<float>("v255spositiontaking_1701_max"),
                S1Min = reader.To<float>("v255spositiontaking_1701_min"),
                M1 = reader.To<float>("v255mpositiontaking_1701"),
                A1 = reader.To<float>("v255apositiontaking_1701"),
                Us1 = reader.To<float>("auto_v255spositiontaking_1701_mem"),
                Is1 = reader.To<bool>("isauto_v255spositiontaking_1701_mem"),
                Is3 = reader.To<bool>("isauto_v255spositiontaking_1701"),
                S4 = reader.To<float>("auto_v255spositiontaking_1701_max")
            };

            return positionTaking;
        }

        private PositionTakingDTO GetMemberPositionTakingEditByMaster(IDataReader reader)
        {
            var positionTaking = new PositionTakingDTO
            {
                IsDisableAuto = reader.To<bool>("DisableAutoMPT"),
                M1 = reader.To<float>("v255mpositiontaking_1701"),
                A1 = reader.To<float>("V255apositiontaking_1701"),
                Um1 = reader.To<float>("auto_v255mpositiontaking_1701_mem"),
                Im1 = reader.To<bool>("isauto_v255mpositiontaking_1701_mem"),
                M1Max = reader.To<float>("v255mpositiontaking_1701_max"),
                M1Min = reader.To<float>("v255mpositiontaking_1701_min"),
                Im2 = reader.To<bool>("isauto_v255mpositiontaking_1701"),
                M3 = reader.To<float>("auto_v255mpositiontaking_1701_max")
            };

            return positionTaking;
        }

        private CommissionDTO GetCommissionBySuperOrMaster(IDataReader reader)
        {
            return new CommissionDTO();
        }
    }
}