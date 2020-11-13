using System;
using System.Collections.Generic;
using System.Text;

namespace ST3Prj3DomaineCore.Models.DTO
{
    public class CommandDTO
    {
        public int ComNo { get; set; }
        public string sendID { get; set; }

        public override string ToString()
        {
            return string.Format("Rx : No: {0},Sender: {1})", ComNo, sendID);
        }
    }
}
