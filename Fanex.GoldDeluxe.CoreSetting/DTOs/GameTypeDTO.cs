namespace Fanex.GoldDeluxe.CoreSetting.DTOs
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using RemotingRef;

    public class GameTypeDTO
    {
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
                return _remotingRefService.GetBetTypeName(Id.ToString(), Thread.CurrentThread.CurrentCulture.Name);
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