namespace Fanex.GoldDeluxe.CoreSetting.DTOs
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Linq;
    using RemotingRef;

    public class GameTypeDTO
    {
        public int Id { get; set; }

        public string Name
        {
            get
            {
                var currentLanguage = "en";

                switch (Thread.CurrentThread.CurrentCulture.Name)
                {
                    case "en-US":
                        currentLanguage = "en";
                        break;

                    case "zh-TW":
                        currentLanguage = "ch";
                        break;

                    case "zh-CN":
                        currentLanguage = "cs";
                        break;

                    case "ja-JP":
                        currentLanguage = "jp";
                        break;

                    case "th-TH":
                        currentLanguage = "th";
                        break;

                    case "ko-KR":
                        currentLanguage = "ko";
                        break;

                    case "vi-VN":
                        currentLanguage = "vn";
                        break;

                    default:
                        currentLanguage = "en";
                        break;
                }

                return RefData.GetBetTypeName(Id.ToString(), currentLanguage);
            }
        }

        public List<StakeLevelDTO> BettingLimit { get; set; }

        public string CheckedStakeLevelId
        {
            get
            {
                return BettingLimit != null ? string.Join(",", BettingLimit.Where(x => x.IsChecked).Select(x => x.Id.ToString()).ToArray()) : string.Empty;
            }
        }
    }
}
