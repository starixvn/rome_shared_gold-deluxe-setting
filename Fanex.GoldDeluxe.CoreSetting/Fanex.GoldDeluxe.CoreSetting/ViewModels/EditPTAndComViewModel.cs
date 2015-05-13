namespace Fanex.GoldDeluxe.CoreSetting.ViewModels
{
    using System.Collections.Generic;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;

    public class EditPTAndComViewModel
    {
        public int ActorId { get; set; }

        public int SubAccId { get; set; }

        public string Language { get; set; }

        public List<PositionTakingDTO> PositionTaking { get; set; }

        public CommissionDTO Commission { get; set; }
    }
}
