using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public class SysChannelService : BaseRepository<SysChannel>, ISysChannelService
    {
        public SysChannelService(MyDbContext context)
            : base(context)
       { }
    }
}
