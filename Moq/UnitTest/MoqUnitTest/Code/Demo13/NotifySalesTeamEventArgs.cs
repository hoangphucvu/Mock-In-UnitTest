using System;

namespace MoqUnitTest.Code.Demo13
{
    public class NotifySalesTeamEventArgs : EventArgs
    {
        public string Name { get; set; }

        public NotifySalesTeamEventArgs(string name)
        {
            Name = name;
        }
    }
}