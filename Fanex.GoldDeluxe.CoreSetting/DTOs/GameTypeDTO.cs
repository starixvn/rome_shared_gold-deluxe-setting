namespace Fanex.GoldDeluxe.CoreSetting.DTOs
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using RemotingRef;

    public class GameTypeDTO
    {
        private const int BaccaratId = 1701;
        private const string SicboId = "1704";
        private const string BidMeId = "1705";

        private readonly IRemotingRefService _remotingRefService;

        public GameTypeDTO() : this(null)
        { }

        public GameTypeDTO(IRemotingRefService remotingRefService)
        {
            _remotingRefService = remotingRefService ?? new RemotingRefService();
        }

        public int Id { get; set; }

        public string Name
        {
            get
            {
                var name = _remotingRefService.GetBetTypeName(Id.ToString(), Thread.CurrentThread.CurrentCulture.Name);
                if (Id == BaccaratId)
                {
                    var sicbo = _remotingRefService.GetBetTypeName(SicboId, Thread.CurrentThread.CurrentCulture.Name);
                    var bidme = _remotingRefService.GetBetTypeName(BidMeId, Thread.CurrentThread.CurrentCulture.Name);

                    name = $"{name}, {sicbo}, {bidme}";
                }

                return name;
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